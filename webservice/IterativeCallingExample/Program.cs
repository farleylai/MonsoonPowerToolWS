using System;
using System.Text;
using System.IO;
using System.Threading;

namespace IterativeCallingExample
{
    /// <summary>
    /// Simple Console Application that demonstrates usage of the PowerTool.Automation interface
    /// This example demonstrates the use case of iteratively calling the power tool application and how to cleanly stop and start
    /// It includes examples of realtime access to sampling data and also how to export data once sampling is complete.
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
            Console.WriteLine("Event: Automation.ApplicationClosed("+exitCode+")");
        }

        [STAThread]
        static void Main(string[] args)
        {
            //Random random = new Random();

            PowerTool.Automation powerTool = new PowerTool.Automation();

            powerTool.OnSampleStopped += OnSampleStopped;
            powerTool.OnDeviceDisconnected += OnDeviceDisconnected;
            powerTool.OnUnhandledException += OnUnhandledException;
            powerTool.OnApplicationClosed += OnApplicationClosed;

            ushort[] serialNumbers = null;

            int success = 0;
            uint deviceCount = 0;

            const int runLimit = 3;
            const bool iniFile = false;
            const uint waitLimit = 10;
            const int runTimeSec = 10;

            const Environment.SpecialFolder sf = Environment.SpecialFolder.MyDocuments;

            //
            // iterate through <runlimit> times, running for <runtime> each time
            // fully opens and closes the powertool application instance each time.. 
            // a loop like this is shown purely as this is a common test case. 
            // If you want to simple connect to a given device, remove the iteration logic below
            //
            for (uint pass = 0; pass < runLimit; pass++)
            {
                if (pass > 0)
                    Console.WriteLine("Runs completed: {0}, successful: {1}, failed {2}",
                        pass, success, pass - success);
                else
                    Console.WriteLine("Runs scheduled: {0} ", runLimit);

                Console.WriteLine("------------------------------------------");
                Console.WriteLine("Run #{0}", pass + 1);

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
                    Thread.Sleep(1000);
                    continue;
                }

                Console.WriteLine("Starting PowerTool");
                bool result = powerTool.OpenApplication(iniFile, waitLimit);
                if (!result)
                {
                    Console.WriteLine("Failed to start PowerTool");
                    continue;
                }

                /*
                int deviceInstance = random.Next((int)deviceCount); //randomly choose one of our available devices to connect to
                ushort serialNumber = serialNumbers[deviceInstance];]
                */
                
                //connect to the first device we found
                ushort serialNumber = serialNumbers[0];
                Console.WriteLine("Connecting to serial number {0}", serialNumber);
                
                if (!powerTool.ConnectDevice(serialNumber))
                {
                    Console.WriteLine("Failed to open device {0}", serialNumber);
                    powerTool.CloseApplication(iniFile, waitLimit);
                    continue;
                }

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
                                      powerTool.UsbPassthroughMode =
                                           PowerTool.UsbPassthroughMode.Auto);
                    Console.WriteLine("    BatterySize              = {0}", 
                                      powerTool.BatterySize =  (uint)1000); 
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

                    continue;
                }

                Console.WriteLine("Starting sampling");
                if (!powerTool.StartSampling(waitLimit))
                {
                    Console.WriteLine("Failed to start sampling");

                    if (powerTool.DeviceIsConnected)
                        powerTool.DisconnectDevice();

                    if (powerTool.ApplicationIsOpen)
                        powerTool.CloseApplication(iniFile, waitLimit);

                    continue;
                }
                //run as long as we specified, unless we lose our connection
                for (int i = 1; i <= runTimeSec && 
                                powerTool.DeviceIsConnected && 
                                powerTool.SampleIsRunning; i++)
                {
                    Thread.Sleep(1 * 1000);
                    PowerTool.SelectionData sd = powerTool.SelectionData;
                    Console.Write("\rcount={0}, Current={1:f2}, Voltage={2:f2}",
                        sd.sampleCount, sd.instMainCurrent, sd.instMainVoltage);
                }
                Console.WriteLine();

                //stop sampling, write out data, cleanup
                if (powerTool.DeviceIsConnected)
                {
                    if (powerTool.SampleIsRunning)
                        powerTool.StopSampling(waitLimit);

                    Console.WriteLine("Sample capture date: {0}", 
                                      powerTool.CaptureDate.ToString());

                    // powerTool.EnableMainOutputVoltage = false;

                    //write out data
                    if (powerTool.HasData)
                    {
                        string myDoc = Environment.GetFolderPath(sf);
                        string filePrefix = myDoc + "\\PowerTool\\" + 
                                            serialNumber.ToString() + ".";

                        Console.WriteLine("Saving PT4 file");
                        powerTool.SaveFile(filePrefix + "pt4", true, true);

                        Console.WriteLine("Exporting CSV file");
                        powerTool.ExportCSV(0, powerTool.TotalSampleCount - 1, 1,
                                            filePrefix + "csv", true, true);
                    }

                    if (powerTool.DeviceIsConnected)
                        powerTool.DisconnectDevice();
                    try
                    {
                        if (powerTool.ApplicationIsOpen) 
                            powerTool.CloseApplication(iniFile, waitLimit);
                    }
                    catch { }

                }

                success++;

                Thread.Sleep(1 * 1000);

            }
            //keep the console up so the output can be seen
            Console.WriteLine("...Press Enter to exit...");
            Console.ReadLine();

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
