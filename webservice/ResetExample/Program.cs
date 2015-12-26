using System;
using System.Text;
using System.IO;
using System.Threading;

namespace ResetExample
{
    /// <summary>
    /// Simple Console Application that demonstrates usage of the PowerTool.Automation interface
    /// Demonstrates using the reset capability of the api to reset the currently connected power monitor device
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

            const bool iniFile = false; //we are setting the parameters explicitely
            const uint waitLimit = 30;

            Console.WriteLine("Enumerating devices");
            deviceCount = powerTool.EnumerateDevices(out serialNumbers);

            Console.WriteLine("{0} device(s) available:", deviceCount);
            if (deviceCount > 0)
            {
                foreach (ushort s in serialNumbers)
                    Console.WriteLine("    {0}", s);
            }
            else{
                Console.WriteLine("No devices found.");
                return;
            }

            Console.WriteLine("Starting PowerTool");
            bool result = powerTool.OpenApplication(iniFile, waitLimit);
            if (!result){
                  Console.WriteLine("Failed to start PowerTool");
                  return;
            }
            //connect to the first device we found
            ushort serialNumber = serialNumbers[0];
            Console.WriteLine("Connecting to serial number {0}", serialNumber);

            if (!powerTool.ConnectDevice(serialNumber))
            {
                   Console.WriteLine("Failed to open device {0}", serialNumber);
                   powerTool.CloseApplication(iniFile, waitLimit);
                   return;
            }


            //reset our device
            //store whether currently connected so we can return to that state
            //in our case, we know we are, but as a more general example, this would be good to do
            bool isConnected = powerTool.DeviceIsConnected;

            bool res = powerTool.ResetPowerMonitor();
            if (!res)
            {
                Console.WriteLine("Failed to reset powermonitor");
                powerTool.CloseApplication(iniFile, waitLimit);
                return;
            }

            if (isConnected){
                Console.WriteLine("Restoring connection to previously connected powermonitor");
			    //once reset, make sure you are connected again
			    if (!powerTool.ConnectDevice(serialNumber))
			    {
				    Console.WriteLine("Failed to re-open device {0}", serialNumber);
				    powerTool.CloseApplication(iniFile, waitLimit);
				    return;
			    }
                else
                {
                    Console.WriteLine("Successfully reconnected to devive {0}", serialNumber);
                }
            }

            //shut her down
            if (powerTool.DeviceIsConnected)
                powerTool.DisconnectDevice();

            Console.WriteLine("Press Enter key to exit..");
            Console.ReadLine();
            powerTool.CloseApplication(iniFile, waitLimit);
   
        }
    }
}
