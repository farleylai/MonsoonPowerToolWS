using System;
using System.Text;
using System.IO;
using System.Threading;

namespace IniTriggerExample
{
    /// <summary>
    /// Simple Console Application that demonstrates usage of the PowerTool.Automation interface
    /// This example demonstrates using an INI file and a trigger code that specifies conditions for sampling
    /// to stop and start. 
    /// 
    /// !!Note, if you do not use a trigger code with a non-manual stop condition, this code will run indefinitely.
    /// If you do not have an ini file present you will also run indefinitely!
    /// 
    /// The easiest way to set your desired trigger codes in your ini file is to use the PowerTool GUI, specify your trigger, sample once and exit.
    /// </summary>
    class Program
    {
        static void OnSampleStopped()
        {
            Console.WriteLine("Event: Automation.SampleStopped()");
        }

        static void OnDeviceDisconnected()
        {
            Console.WriteLine("Event: Automation.DeviceDisconnected()");
        }

        static void OnUnhandledException(Exception e)
        {
            Console.WriteLine("Event: Automation.UnhandledException(e.Message=\"{0}\")",
                               e.Message);
        }

        static void OnApplicationClosed(PowerTool.ExitCode exitCode)
        {
            Console.WriteLine("Event: Automation.ApplicationClosed(" + exitCode + ")");
        }

        [STAThread]
        static void Main(string[] args)
        {

            PowerTool.Automation powerTool = new PowerTool.Automation();

            powerTool.OnSampleStopped += OnSampleStopped;
            powerTool.OnDeviceDisconnected += OnDeviceDisconnected;
            powerTool.OnUnhandledException += OnUnhandledException;
            powerTool.OnApplicationClosed += OnApplicationClosed;

            ushort[] serialNumbers = null;

            uint deviceCount = 0;

            const bool iniFile = true;
            const uint waitLimit = 30;


            Console.WriteLine("Enumerating devices");
            deviceCount = powerTool.EnumerateDevices(out serialNumbers);

            Console.WriteLine("{0} device(s) available:", deviceCount);
            if (deviceCount > 0)
            {
                foreach (ushort s in serialNumbers)
                    Console.WriteLine("    {0}", s);
            }
            else
            {
                Console.WriteLine("No devices found.");
                return;
            }

            Console.WriteLine("Starting PowerTool");
            //ini file is pulled from default application ini file location
            bool result = powerTool.OpenApplication(iniFile, waitLimit);
            if (!result)
            {
                Console.WriteLine("Failed to start PowerTool");
                return;
            }

            //connect to the first device found
            ushort serialNumber = serialNumbers[0];
            Console.WriteLine("Connecting to serial number {0}", serialNumber);

            if (!powerTool.ConnectDevice(serialNumber))
            {
                Console.WriteLine("Failed to open device {0}", serialNumber);
                powerTool.CloseApplication(iniFile, waitLimit);
                return;
            }
            //display trigger settings for debugging purposes
            Console.WriteLine("trigger settings :" + powerTool.PowerToolStatus.TriggerSetting);
            

            //even when using triggers, you must start the sampling process. The triggers will then start being evaluated.
            Console.WriteLine("Starting sampling");

            if (!powerTool.StartSampling(waitLimit))
            {
                Console.WriteLine("Failed to start sampling");

                if (powerTool.DeviceIsConnected)
                    powerTool.DisconnectDevice();

                if (powerTool.ApplicationIsOpen)
                    powerTool.CloseApplication(iniFile, waitLimit);

                return;
            }
            
            //we are running based on a trigger, run run run until done
            if (powerTool.DeviceIsConnected)
            {
                while (powerTool.SampleIsRunning)
                {
                    // nothing at all.. hang out. add some logging to screen if desired
                }
                Console.WriteLine("Done Sampling at :" + System.DateTime.Now);
//                powerTool.StopSampling(waitLimit); not necessary, handled w/ trigger

                //write out data
                if (powerTool.HasData)
                {
                    const Environment.SpecialFolder sf = Environment.SpecialFolder.MyDocuments;
                    string myDoc = Environment.GetFolderPath(sf);
                    string filePrefix = myDoc + "\\PowerTool\\" +
                                        serialNumber.ToString() + ".";
                    Console.WriteLine("Saving PT4 file");
                    powerTool.SaveFile(filePrefix + "pt4", true, true);

                }

                if (powerTool.DeviceIsConnected)
                    powerTool.DisconnectDevice();
            }


            //keep the console up so the output can be seen
            //Console.WriteLine("...Press Enter to exit...");
            //Console.ReadLine();

            //final catch- we shouldn't ever need this as we do cleanup internally
            if (powerTool.ApplicationIsOpen)
            {
                if (powerTool.SampleIsRunning)
                    powerTool.StopSampling(true);

                if (powerTool.DeviceIsConnected)
                    powerTool.DisconnectDevice();

                powerTool.CloseApplication(iniFile, waitLimit);
            }
        }
    }
}
