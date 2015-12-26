using System;
using System.Text;
using System.IO;
using System.Threading;

namespace SimpleSamplingExample
{
    /// <summary>
    /// Simple Console Application that demonstrates usage of the PowerTool.Automation interface
    /// This sample code demonstrates the simplest use case of instatiating the power monitor, doing some sampling, and exporting the results.
    /// Demonstrates realtime access to sampling data
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
            Console.WriteLine("Number of command line parameters = {0}",
                args.Length);
            for (int i = 0; i < args.Length; i++)
            {
                Console.WriteLine("Arg[{0}] = [{1}]", i, args[i]);
            }


            Random random = new Random();

            PowerTool.Automation powerTool = new PowerTool.Automation();

            powerTool.OnSampleStopped += OnSampleStopped;
            powerTool.OnDeviceDisconnected += OnDeviceDisconnected;
            powerTool.OnUnhandledException += OnUnhandledException;
            powerTool.OnApplicationClosed += OnApplicationClosed;

            ushort[] serialNumbers = null;

            uint deviceCount = 0;

            const bool iniFile = false; //we are setting the parameters explicitely
            const uint waitLimit = 30;

            int runTimeMin = 3; //set a default
            if (args.Length > 0)
            {
                string strRunTime = args[0];
                runTimeMin = Convert.ToInt32(strRunTime);
            }
            Console.WriteLine("***Power Monitor Run Time (Minutes)*** {0}", runTimeMin);

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

            //Set the runtime properties you want to use
            Console.WriteLine("Setting run-time properties:");
            result = false;
            try
            {

                Console.WriteLine("    Visible                  = {0}",
                    powerTool.Visible = true);
                Console.WriteLine("    WindowState              = {0}",
                    powerTool.WindowState = PowerTool.WindowState.Normal);
                Console.WriteLine("    CaptureMainCurrent       = {0}",
                    powerTool.CaptureMainCurrent = true);
                Console.WriteLine("    CaptureUsbCurrent        = {0}",
                    powerTool.CaptureUsbCurrent = false);
                Console.WriteLine("    CaptureAuxCurrent        = {0}",
                    powerTool.CaptureAuxCurrent = false);
                Console.WriteLine("    VoltageChannel           = {0}",
                    powerTool.VoltageChannel = PowerTool.Channel.Main);
                Console.WriteLine("    UsbPassthroughMode       = {0}",
                    powerTool.UsbPassthroughMode =PowerTool.UsbPassthroughMode.Auto);
                Console.WriteLine("    BatterySize              = {0}",
                    powerTool.BatterySize = 1000 );
                Console.WriteLine("    EnableMainOutputVoltage  = {0}",
                    powerTool.EnableMainOutputVoltage = false);
                Console.WriteLine("    MainOutputVoltageSetting = {0}",
                    powerTool.MainOutputVoltageSetting = 4.2f);
                Console.WriteLine("    EnableMainOutputVoltage  = {0}",
                    powerTool.EnableMainOutputVoltage = true);
                Console.WriteLine("    Trigger Code             = {0}",
                    powerTool.TriggerSetting = "ATA");

                Console.WriteLine();
                Console.WriteLine("Read-only properties:");
                Console.WriteLine("    DeviceSerialNumber       = {0}",
                    powerTool.DeviceSerialNumber);
                Console.WriteLine("    HardwareRevision         = {0}",
                    powerTool.HardwareRevision);
                Console.WriteLine("    FirmwareVersion          = {0}",
                    powerTool.FirmwareVersion);
                Console.WriteLine("    ProtocolVersion          = {0}",
                    powerTool.ProtocolVersion);
                PowerTool.SoftwareVersion swVer = powerTool.SoftwareVersion;
                Console.WriteLine("    SoftwareVersion          = {0}.{1}.{2}.{3}",
                                      swVer.Major, swVer.Minor, swVer.Build, swVer.Revision);

                result = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            if (!result)
            {
                Console.WriteLine("Error encountered while setting properties");

                if (powerTool.DeviceIsConnected)
                    powerTool.DisconnectDevice();

                if (powerTool.ApplicationIsOpen)
                    powerTool.CloseApplication(iniFile, waitLimit);
                return;
            }

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
            //run as long as we specified, unless we lose our connection
            //if you specify a trigger with a stop condition, you will want to modify this code as the 
            //trigger should be allowed to stop sampling vs a runTime specified here

            Console.WriteLine("Outputing heartbeat data every 1 minute");

            for (int i = 1; i <= runTimeMin &&
                            powerTool.DeviceIsConnected &&
                            powerTool.SampleIsRunning; i++)
            {
                Thread.Sleep(1 * 60000);//output every 1 minute
                int timeelapsed = i / 60000;
                PowerTool.SelectionData sd = powerTool.SelectionData;
                //print out some data to the screen as we run. The SelectionData object is how you access realtime sampling information
                Console.WriteLine("\n\nElapsed min:"+i+" ,"+System.DateTime.Now.TimeOfDay+ "\tInstant Main:    count={0}, Current={1:f2}, Voltage={2:f2}",
                    sd.sampleCount, sd.instMainCurrent, sd.instMainVoltage);

            }
            Console.WriteLine();
            //stop sampling, write out data, cleanup
            if (powerTool.DeviceIsConnected)
            {
                if (powerTool.SampleIsRunning)
                    Console.WriteLine("Sample capture date: {0}",
                                        powerTool.CaptureDate.ToString());
                powerTool.StopSampling(waitLimit);

                //powerTool.EnableMainOutputVoltage = false;

                //write out data
                if (powerTool.HasData)
                {
                    const Environment.SpecialFolder sf = Environment.SpecialFolder.MyDocuments;
                    string myDoc = Environment.GetFolderPath(sf);
                    string filePrefix = myDoc + "\\PowerTool\\" +
                                        serialNumber.ToString() + ".";

                    //write PT4 file
                    Console.WriteLine("Saving PT4 file");
                    powerTool.SaveFile(filePrefix + "pt4", true, true);

                    //write CSV file
                    Console.WriteLine("Exporting CSV file");
                    powerTool.ExportCSV(0, powerTool.TotalSampleCount - 1, 1,
                                        filePrefix + "csv", true, true);
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
