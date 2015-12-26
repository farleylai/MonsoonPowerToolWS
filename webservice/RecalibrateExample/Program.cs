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
        static void start(PowerTool.Automation powerTool, uint waitLimit)
        {
            if (!powerTool.StartSampling(waitLimit))
            {
                Console.WriteLine("Failed to start sampling");

                if (powerTool.DeviceIsConnected)
                    powerTool.DisconnectDevice();

                if (powerTool.ApplicationIsOpen)
                    powerTool.CloseApplication(true, waitLimit);

            }
        }
        static void stop(PowerTool.Automation powerTool, uint waitLimit)
        {
            if (powerTool.DeviceIsConnected)
            {
                if (powerTool.SampleIsRunning)
                    powerTool.StopSampling(waitLimit);
            }
        }

        static void recalibrateMainCoarse(PowerTool.Automation powerTool, uint waitLimit, float LoadResistor)
        {
            bool calibrated = false;
            int retry = 0;
            float oldRes = powerTool.MainCoarseResistorOffset;

            while (!calibrated && retry <= 3)
            {
                retry++;
                start(powerTool, waitLimit);
                Thread.Sleep(3000); //collect a few seconds of samples.
                PowerTool.SelectionData sd = powerTool.SelectionData;
                stop(powerTool, waitLimit);
                
                //Calculate expected resistor value
                double expectedCurrent = (sd.instVoltage / (powerTool.MainCoarseResistorOffset + LoadResistor) * 1000f); //V=IR, then convert from A->mA
                Console.WriteLine(sd.instMainCurrent * powerTool.MainCoarseResistorOffset);
                Console.WriteLine("Voltage: {0}, Resistance: {1}, Expected Current: {2}, Measured current: {3}", sd.instVoltage, LoadResistor, expectedCurrent, sd.instMainCurrent);

                if (Math.Abs(expectedCurrent - sd.instMainCurrent) > expectedCurrent * 0.01f) //1% accuracy threshold
                {
                    float RecalibratedResistor = (float)(sd.instMainCurrent / expectedCurrent) * powerTool.MainCoarseResistorOffset;

                    if (RecalibratedResistor >= 0.0372 && RecalibratedResistor <= 0.0627) //Firmware limits on Sense Resistor value.
                        powerTool.MainCoarseResistorOffset = RecalibratedResistor;
                }
                else
                { calibrated = true; }
            }
            //Recalibration failed, return to old value.
            if (retry == 4)
            {
                powerTool.MainCoarseResistorOffset = oldRes; //If we didn't find a better value, return to the old setting
            }
        }
        static void recalibrateMainFine(PowerTool.Automation powerTool, uint waitLimit, float LoadResistor)
        {
            bool calibrated = false;
            int retry = 0;
            float oldRes = powerTool.MainFineResistorOffset;

            while (!calibrated && retry <= 3)
            {
                retry++;
                start(powerTool, waitLimit);
                Thread.Sleep(3000);
                PowerTool.SelectionData sd = powerTool.SelectionData;
                stop(powerTool, waitLimit);

                double expectedCurrent = (sd.instVoltage  / (powerTool.MainFineResistorOffset + LoadResistor) * 1000f);
                Console.WriteLine("Voltage: {0}, Resistance: {1}, Expected Current: {2}, Measured current: {3}", sd.instVoltage, LoadResistor, expectedCurrent, sd.instMainCurrent);

                if (Math.Abs(expectedCurrent - sd.instMainCurrent) > expectedCurrent * 0.01f) //1% accuracy threshold
                {
                    float RecalibratedResistor = (float)(sd.instMainCurrent / expectedCurrent) * powerTool.MainFineResistorOffset;

                    if (RecalibratedResistor >= 0.0372 && RecalibratedResistor <= 0.0627)
                        powerTool.MainFineResistorOffset = RecalibratedResistor;
                }
                else
                { calibrated = true; }
            }
            if (retry == 4)
            {
                powerTool.MainFineResistorOffset = oldRes;
            }
        }
        static void recalibrateAuxFine(PowerTool.Automation powerTool, uint waitLimit, float LoadResistor)
        {
            bool calibrated = false;
            int retry = 0;
            float oldRes = powerTool.AuxFineResistorOffset;

            while (!calibrated && retry <= 3)
            {
                retry++;
                start(powerTool, waitLimit);
                Thread.Sleep(3000);
                PowerTool.SelectionData sd = powerTool.SelectionData;
                stop(powerTool, waitLimit);

                double expectedCurrent = (sd.instAuxVoltage / (powerTool.AuxFineResistorOffset + LoadResistor) * 1000f);
                Console.WriteLine("Voltage: {0}, Resistance: {1}, Expected Current: {2}, Measured current: {3}", sd.instVoltage, LoadResistor, expectedCurrent, sd.instAuxCurrent);

                if (Math.Abs(expectedCurrent - sd.instAuxCurrent) > expectedCurrent * 0.01f) //1% accuracy threshold
                {
                    float RecalibratedResistor = (float)(sd.instAuxCurrent / expectedCurrent) * powerTool.AuxFineResistorOffset;

                    if (RecalibratedResistor >= 0.0872 && RecalibratedResistor <= 0.1127)
                        powerTool.AuxFineResistorOffset = RecalibratedResistor;
                }
                else
                { calibrated = true; }
            }
            if (retry == 4)
            {
                powerTool.AuxFineResistorOffset = oldRes;
            }
        }
        static void recalibrateAuxCoarse(PowerTool.Automation powerTool, uint waitLimit, float LoadResistor)
        {
            bool calibrated = false;
            int retry = 0;
            float oldRes = powerTool.AuxCoarseResistorOffset;

            while (!calibrated && retry <= 3)
            {
                retry++;
                start(powerTool, waitLimit);
                Thread.Sleep(3000);
                PowerTool.SelectionData sd = powerTool.SelectionData;
                stop(powerTool, waitLimit);

                double expectedCurrent = (sd.instAuxVoltage / (powerTool.AuxCoarseResistorOffset + LoadResistor) * 1000f);
                Console.WriteLine("Voltage: {0}, Resistance: {1}, Expected Current: {2}, Measured current: {3}", sd.instAuxVoltage, LoadResistor, expectedCurrent, sd.instAuxCurrent);

                if (Math.Abs(expectedCurrent - sd.instAuxCurrent) > expectedCurrent * 0.01f) //1% accuracy threshold
                {
                    float RecalibratedResistor = (float)(sd.instAuxCurrent / expectedCurrent) * powerTool.AuxCoarseResistorOffset;

                    if (RecalibratedResistor >= 0.0872 && RecalibratedResistor <= 0.1127)
                        powerTool.AuxCoarseResistorOffset = RecalibratedResistor;
                }
                else
                { calibrated = true; }
            }
            if (retry == 4)
            {
                powerTool.AuxCoarseResistorOffset = oldRes;
            }
        }
        static void recalibrateUsbFine(PowerTool.Automation powerTool, uint waitLimit, float LoadResistor)
        {
            bool calibrated = false;
            int retry = 0;
            float oldRes = powerTool.UsbFineResistorOffset;

            while (!calibrated && retry <= 3)
            {
                retry++;
                start(powerTool, waitLimit);
                Thread.Sleep(3000);
                PowerTool.SelectionData sd = powerTool.SelectionData;
                stop(powerTool, waitLimit);

                double expectedCurrent = (sd.instUsbVoltage / (powerTool.UsbFineResistorOffset + LoadResistor) * 1000f);
                Console.WriteLine("Voltage: {0}, Resistance: {1}, Expected Current: {2}, Measured current: {3}", sd.instUsbVoltage, LoadResistor, expectedCurrent, sd.instUsbCurrent);

                if (Math.Abs(expectedCurrent - sd.instUsbCurrent) > expectedCurrent * 0.01f) //1% accuracy threshold
                {
                    float RecalibratedResistor = (float)(sd.instUsbCurrent / expectedCurrent) * powerTool.UsbFineResistorOffset;

                    if (RecalibratedResistor >= 0.0372 && RecalibratedResistor <= 0.0627)
                        powerTool.UsbFineResistorOffset = RecalibratedResistor;
                }
                else
                { calibrated = true; }
            }
            if (retry == 4)
            {
                powerTool.UsbFineResistorOffset = oldRes;
            }
        }
        static void recalibrateUsbCoarse(PowerTool.Automation powerTool, uint waitLimit, float LoadResistor)
        {
            bool calibrated = false;
            int retry = 0;
            float oldRes = powerTool.UsbCoarseResistorOffset;

            while (!calibrated && retry <= 3)
            {
                retry++;
                start(powerTool, waitLimit);
                Thread.Sleep(3000);
                PowerTool.SelectionData sd = powerTool.SelectionData;
                stop(powerTool, waitLimit);

                double expectedCurrent = (sd.instUsbVoltage / (powerTool.UsbCoarseResistorOffset + LoadResistor) * 1000f);
                Console.WriteLine("Voltage: {0}, Resistance: {1}, Expected Current: {2}, Measured current: {3}", sd.instUsbVoltage, LoadResistor, expectedCurrent, sd.instUsbCurrent);

                if (Math.Abs(expectedCurrent - sd.instUsbCurrent) > expectedCurrent * 0.01f) //1% accuracy threshold
                {
                    float RecalibratedResistor = (float)(sd.instUsbCurrent / expectedCurrent) * powerTool.UsbCoarseResistorOffset;

                    if (RecalibratedResistor >= 0.0372 && RecalibratedResistor <= 0.0627)
                        powerTool.UsbCoarseResistorOffset = RecalibratedResistor;
                }
                else
                { calibrated = true; }
            }
            if (retry == 4)
            {
                powerTool.UsbCoarseResistorOffset = oldRes;
            }
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

            //Default Settings
            float LoadResistor = 1000f;
            string channel = "MainFine";
            if (args.Length > 0)
            {
                string loadRes = args[0];
                LoadResistor = float.Parse(loadRes);
            }
            if(args.Length > 1)
            {
                channel = args[1];
            }

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
            bool result = powerTool.OpenApplication(iniFile, waitLimit);
            if (!result)
            {
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

            //Enable voltage and Trigger Code
                Console.WriteLine("    MainOutputVoltageSetting = {0}",
                    powerTool.MainOutputVoltageSetting = 3.7f);
                Console.WriteLine("    EnableMainOutputVoltage  = {0}",
                    powerTool.EnableMainOutputVoltage = true);
                Console.WriteLine("    Trigger Code             = {0}",
                    powerTool.TriggerSetting = "ATA");

            
            //Select the channel to recalibrate.
            switch(channel)
            {
                case "MainFine":
                    powerTool.VoltageChannel = PowerTool.Channel.Main;
                    powerTool.CaptureMainCurrent = true;
                    recalibrateMainFine(powerTool, waitLimit, LoadResistor);
                    break;
                case "MainCoarse":
                    powerTool.VoltageChannel = PowerTool.Channel.Main;
                    powerTool.CaptureMainCurrent = true;
                    recalibrateMainCoarse(powerTool, waitLimit, LoadResistor);
                    break;
                case "USBFine":
                    powerTool.UsbPassthroughMode = PowerTool.UsbPassthroughMode.On;
                    powerTool.CaptureUsbCurrent = true;
                    powerTool.CaptureMainCurrent = false;
                    recalibrateUsbFine(powerTool, waitLimit, LoadResistor);
                    break;
                case "USBCoarse":
                    powerTool.UsbPassthroughMode = PowerTool.UsbPassthroughMode.On;
                    powerTool.CaptureUsbCurrent = true;
                    recalibrateUsbCoarse(powerTool, waitLimit, LoadResistor);
                    break;
                case "AuxFine":
                    powerTool.VoltageChannel = PowerTool.Channel.Aux;
                    powerTool.CaptureAuxCurrent = true;
                    recalibrateAuxFine(powerTool, waitLimit, LoadResistor);
                    break;
                case "AuxCoarse":
                    powerTool.VoltageChannel = PowerTool.Channel.Aux;
                    powerTool.CaptureAuxCurrent = true;
                    recalibrateAuxCoarse(powerTool, waitLimit, LoadResistor);
                    break;
            }
            //disconnect after completion.
            if (powerTool.DeviceIsConnected)
                powerTool.DisconnectDevice();

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
