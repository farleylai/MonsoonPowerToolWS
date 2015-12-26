using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ServiceModel;
using System.ServiceModel.Description;

using PowerTool;
using System.Net;

namespace PowerToolService
{
    
    [ServiceContract]
    public interface IPowerToolService
    {
        bool ApplicationIsOpen { [OperationContract] get; }
        float AuxCoarseResistorOffset { [OperationContract]get; [OperationContract]set; }
        float AuxFineResistorOffset { [OperationContract]get; [OperationContract]set; }
        uint BatterySize { [OperationContract]get; [OperationContract]set; }
        CalibrationStatus CalibrationStatus { [OperationContract]get; }
        bool CaptureAuxCurrent { [OperationContract]get; [OperationContract]set; }
        DateTime CaptureDate { [OperationContract]get; }
        bool CaptureMainCurrent { [OperationContract]get; [OperationContract]set; }
        bool CaptureUsbCurrent { [OperationContract]get; [OperationContract]set; }
        uint DeviceCount { [OperationContract]get; }
        bool DeviceIsConnected { [OperationContract]get; }
        ushort DeviceSerialNumber { [OperationContract]get; }
        bool EnableMainOutputVoltage { [OperationContract]get; [OperationContract]set; }
        bool ExceptionsAreEnabled { [OperationContract]get; [OperationContract]set; }
        ExitCode ExitCode { [OperationContract]get; }
        string FileName { [OperationContract]get; }
        byte FirmwareVersion { [OperationContract]get; }
        HardwareRevision HardwareRevision { [OperationContract]get; }
        bool HasData { [OperationContract]get; }
        int Height { [OperationContract]get; [OperationContract]set; }
        int Left { [OperationContract]get; [OperationContract]set; }
        string LogFileName { [OperationContract]get; [OperationContract]set; }
        float MainCoarseResistorOffset { [OperationContract]get; [OperationContract]set; }
        float MainFineResistorOffset { [OperationContract]get; [OperationContract]set; }
        float MainOutputVoltageSetting { [OperationContract]get; [OperationContract]set; }
        ulong MissingSampleCount { [OperationContract]get; }
        PowerToolStatus PowerToolStatus { [OperationContract]get; }
        float PowerUpCurrentLimit { [OperationContract]get; [OperationContract]set; }
        byte PowerUpTime { [OperationContract]get; [OperationContract]set; }
        byte ProtocolVersion { [OperationContract]get; }
        float RunTimeCurrentLimit { [OperationContract]get; [OperationContract]set; }
        bool SampleIsRunning { [OperationContract]get; }
        uint SampleRate { [OperationContract]get; }
        SelectionData SelectionData { [OperationContract]get; }
        SoftwareVersion SoftwareVersion { [OperationContract]get; }
        string TempDirectory { [OperationContract]get; [OperationContract]set; }
        int Top { [OperationContract]get; [OperationContract]set; }
        ulong TotalSampleCount { [OperationContract]get; }
        string TriggerSetting { [OperationContract]get; [OperationContract]set; }
        float UsbCoarseResistorOffset { [OperationContract]get; [OperationContract]set; }
        float UsbFineResistorOffset { [OperationContract]get; [OperationContract]set; }
        UsbPassthroughMode UsbPassthroughMode { [OperationContract]get; [OperationContract]set; }
        bool Visible { [OperationContract]get; [OperationContract]set; }
        Channel VoltageChannel { [OperationContract]get; [OperationContract]set; }
        uint WaitInterval { [OperationContract]get; [OperationContract]set; }
        int Width { [OperationContract]get; [OperationContract]set; }
        WindowState WindowState { [OperationContract]get; [OperationContract]set; }

        [OperationContract]
        string SayHello(string name);

        [OperationContract]
        uint EnumerateDevices(out ushort[] serialNumbers);
        [OperationContract]
        ushort GetSerialNumber(uint deviceNumber);
        [OperationContract]
        bool LoadFile(string fileName);
        [OperationContract]
        bool OpenApplicationL(bool readIniFile, uint waitLimit);
        [OperationContract]
        bool OpenApplicationF(bool readIniFile, bool waitFlag);
        [OperationContract]
        bool OpenApplicationLG(bool readIniFile, uint waitLimit, bool GUI);
        [OperationContract]
        bool OpenApplicationFG(bool readIniFile, bool waitFlag, bool GUI);
        [OperationContract]
        bool CloseApplicationL(bool writeIniFile, uint waitLimit);
        [OperationContract]
        bool CloseApplicationF(bool writeIniFile, bool waitFlag);
        [OperationContract]
        bool ConnectDevice(ushort serialNumber);
        [OperationContract]
        bool DisconnectDevice();
        [OperationContract]
        bool ExportCSV(ulong lowIndex, ulong highIndex, uint granularity, string fileName, bool overwriteFile, bool createDirectory);
        [OperationContract]
        bool GetSample(ulong sampleIndex, out Sample sample);
        [OperationContract]
        bool GetSamples(ulong startIndex, uint sampleCount, out Sample[] samples);
        [OperationContract]
        bool RefreshDisplay();
        [OperationContract]
        bool ResetPowerMonitor();
        [OperationContract]
        bool SaveFile(string fileName, bool overwriteFile, bool createDirectory);
        [OperationContract]
        bool StartSamplingL(uint waitLimit);
        [OperationContract]
        bool StartSamplingF(bool waitFlag);
        [OperationContract]
        bool StopSamplingL(uint waitLimit);
        [OperationContract]
        bool StopSamplingF(bool waitFlag);
    }

    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Single, InstanceContextMode = InstanceContextMode.Single)]
    public class PowerToolService : IPowerToolService
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
            Console.WriteLine("Event: Automation.UnhandledException(e.Message=\"{0}\")", e.Message);
        }

        static void OnApplicationClosed(PowerTool.ExitCode exitCode)
        {
            Console.WriteLine("Event: Automation.ApplicationClosed(" + exitCode + ")");
        }

        private static PowerToolService Instance;
        private Automation pt;
        public PowerToolService()
        {
            pt = new Automation();
            pt.OnSampleStopped += OnSampleStopped;
            pt.OnDeviceDisconnected += OnDeviceDisconnected;
            pt.OnUnhandledException += OnUnhandledException;
            pt.OnApplicationClosed += OnApplicationClosed;
            Instance = this;
            ushort[] serialNumbers = null;
            uint count = pt.EnumerateDevices(out serialNumbers);
            if(count > 0) {
                for (int i = 0; i < count; i++)
                    Console.WriteLine("PowerTool serial[{0}]: {1}", i, serialNumbers[i]);
            } else {
                Console.WriteLine("No Monsoon Power Monitor are attached");
            }
        }

        public bool ApplicationIsOpen
        {
            get { return pt.ApplicationIsOpen; }
        }
        public float AuxCoarseResistorOffset
        {
            get { return pt.AuxCoarseResistorOffset; }
            set { pt.AuxCoarseResistorOffset = value; }
        }
        public float AuxFineResistorOffset
        {
            get { return pt.AuxFineResistorOffset; }
            set { pt.AuxFineResistorOffset = value; }
        }
        public uint BatterySize
        {
            get { return pt.BatterySize; }
            set { pt.BatterySize = value; }
        }
        public CalibrationStatus CalibrationStatus
        {
            get { return pt.CalibrationStatus; }
        }
        public bool CaptureAuxCurrent
        {
            get { return pt.CaptureAuxCurrent; }
            set { pt.CaptureAuxCurrent = value; }
        }
        public DateTime CaptureDate
        {
            get { return pt.CaptureDate; }
        }
        public bool CaptureMainCurrent
        {
            get { return pt.CaptureMainCurrent; }
            set { pt.CaptureMainCurrent = value; }
        }
        public bool CaptureUsbCurrent
        {
            get { return pt.CaptureUsbCurrent; }
            set { pt.CaptureUsbCurrent = value; }
        }
        public uint DeviceCount
        {
            get { return pt.DeviceCount; }
        }
        public bool DeviceIsConnected
        {
            get { return pt.DeviceIsConnected; }
        }
        public ushort DeviceSerialNumber
        {
            get { return pt.DeviceSerialNumber; }
        }
        public bool EnableMainOutputVoltage
        {
            get { return pt.EnableMainOutputVoltage; }
            set { pt.EnableMainOutputVoltage = value; }
        }
        public bool ExceptionsAreEnabled
        {
            get { return pt.ExceptionsAreEnabled; }
            set { pt.ExceptionsAreEnabled = value; }
        }
        public ExitCode ExitCode
        {
            get { return pt.ExitCode; }
        }
        public string FileName
        {
            get { return pt.FileName; }
        }
        public byte FirmwareVersion
        {
            get { return pt.FirmwareVersion; }
        }
        public HardwareRevision HardwareRevision
        {
            get { return HardwareRevision; }
        }
        public bool HasData
        {
            get { return pt.HasData; }
        }
        public int Height
        {
            get { return pt.Height; }
            set { pt.Height = value; }
        }
        public int Left
        {
            get { return pt.Left; }
            set { pt.Left = value; }
        }
        public string LogFileName
        {
            get { return pt.LogFileName; }
            set { pt.LogFileName = value; }
        }
        public float MainCoarseResistorOffset
        {
            get { return pt.MainCoarseResistorOffset; }
            set { pt.MainCoarseResistorOffset = value; }
        }
        public float MainFineResistorOffset
        {
            get { return pt.MainFineResistorOffset; }
            set { pt.MainFineResistorOffset = value; }
        }
        public float MainOutputVoltageSetting
        {
            get { return pt.MainOutputVoltageSetting; }
            set { pt.MainOutputVoltageSetting = value; }
        }
        public ulong MissingSampleCount
        {
            get { return pt.MissingSampleCount; }
        }
        public PowerToolStatus PowerToolStatus
        {
            get { return pt.PowerToolStatus; }
        }
        public float PowerUpCurrentLimit
        {
            get { return pt.PowerUpCurrentLimit; }
            set { pt.PowerUpCurrentLimit = value; }
        }
        public byte PowerUpTime
        {
            get { return pt.PowerUpTime; }
            set { pt.PowerUpTime = value; }
        }
        public byte ProtocolVersion
        {
            get { return pt.ProtocolVersion; }
        }
        public float RunTimeCurrentLimit
        {
            get { return pt.RunTimeCurrentLimit; }
            set { pt.RunTimeCurrentLimit = value; }
        }
        public bool SampleIsRunning
        {
            get { return pt.SampleIsRunning; }
        }
        public uint SampleRate
        {
            get { return pt.SampleRate; }
        }
        public SelectionData SelectionData
        {
            get { return pt.SelectionData; }
        }
        public SoftwareVersion SoftwareVersion
        {
            get { return pt.SoftwareVersion; }
        }
        public string TempDirectory
        {
            get { return pt.TempDirectory; }
            set { pt.TempDirectory = value; }
        }
        public int Top
        {
            get { return pt.Top; }
            set { pt.Top = value; }
        }
        public ulong TotalSampleCount
        {
            get { return pt.TotalSampleCount; }
        }
        public string TriggerSetting
        {
            get { return pt.TriggerSetting; }
            set { pt.TriggerSetting = value; }
        }
        public float UsbCoarseResistorOffset
        {
            get { return pt.UsbCoarseResistorOffset; }
            set { pt.UsbCoarseResistorOffset = value; }
        }
        public float UsbFineResistorOffset
        {
            get { return pt.UsbFineResistorOffset; }
            set { pt.UsbFineResistorOffset = value; }
        }
        public UsbPassthroughMode UsbPassthroughMode
        {
            get { return pt.UsbPassthroughMode; }
            set { pt.UsbPassthroughMode = value; }
        }
        public bool Visible
        {
            get { return pt.Visible; }
            set { pt.Visible = value; }
        }
        public Channel VoltageChannel
        {
            get { return pt.VoltageChannel; }
            set { pt.VoltageChannel = value; }
        }
        public uint WaitInterval
        {
            get { return pt.WaitInterval; }
            set { pt.WaitInterval = value; }
        }
        public int Width
        {
            get { return pt.Width; }
            set { pt.Width = value; }
        }
        public WindowState WindowState
        {
            get { return pt.WindowState; }
            set { pt.WindowState = value; }
        }

        public bool CloseApplicationL(bool writeIniFile, uint waitLimit)
        {
            return pt.CloseApplication(writeIniFile, waitLimit);
        }

        public bool CloseApplicationF(bool writeIniFile, bool waitFlag)
        {
            return pt.CloseApplication(writeIniFile, waitFlag);
        }

        public bool ConnectDevice(ushort serialNumber)
        {
            return pt.ConnectDevice(serialNumber);
        }

        public bool DisconnectDevice()
        {
            return pt.DisconnectDevice();
        }

        public uint EnumerateDevices(out ushort[] serialNumbers)
        {
            return pt.EnumerateDevices(out serialNumbers);
        }

        public bool ExportCSV(ulong lowIndex, ulong highIndex, uint granularity, string fileName, bool overwriteFile, bool createDirectory)
        {
            return pt.ExportCSV(lowIndex, highIndex, granularity, fileName, overwriteFile, createDirectory);
        }

        public bool GetSample(ulong sampleIndex, out Sample sample)
        {
            return pt.GetSample(sampleIndex, out sample);
        }

        public bool GetSamples(ulong startIndex, uint sampleCount, out Sample[] samples)
        {
            return pt.GetSamples(startIndex, sampleCount, out samples);
        }

        public ushort GetSerialNumber(uint deviceNumber)
        {
            return pt.GetSerialNumber(deviceNumber);
        }

        public bool LoadFile(string fileName)
        {
            return pt.LoadFile(fileName);
        }

        public bool OpenApplicationL(bool readIniFile, uint waitLimit)
        {
            return pt.OpenApplication(readIniFile, waitLimit);
        }

        public bool OpenApplicationF(bool readIniFile, bool waitFlag)
        {
            return pt.OpenApplication(readIniFile, waitFlag);
        }

        public bool OpenApplicationLG(bool readIniFile, uint waitLimit, bool GUI)
        {
            return pt.OpenApplication(readIniFile, waitLimit, GUI);
        }

        public bool OpenApplicationFG(bool readIniFile, bool waitFlag, bool GUI)
        {
            return pt.OpenApplication(readIniFile, waitFlag, GUI);
        }

        public bool RefreshDisplay()
        {
            return pt.RefreshDisplay();
        }

        public bool ResetPowerMonitor()
        {
            return pt.ResetPowerMonitor();
        }

        public bool SaveFile(string fileName, bool overwriteFile, bool createDirectory)
        {
            return pt.SaveFile(fileName, overwriteFile, createDirectory);
        }

        public bool StartSamplingL(uint waitLimit)
        {
            return pt.StartSampling(waitLimit);
        }

        public bool StartSamplingF(bool waitFlag)
        {
            return pt.StartSampling(waitFlag);
        }

        public bool StopSamplingL(uint waitLimit)
        {
            return pt.StopSampling(waitLimit);
        }

        public bool StopSamplingF(bool waitFlag)
        {
            return pt.StopSampling(waitFlag);
        }

        public string SayHello(string name)
        {
            return string.Format("Hello, {0}", name);
        }
    }

    class Program
    {
        private static string GetIP()
        {
            IPHostEntry host;
            string localIp = "?";
            string hostName = Dns.GetHostName();
            host = Dns.GetHostEntry(hostName);
            foreach (IPAddress ip in host.AddressList)
            {
                if (ip.AddressFamily.ToString() == "InterNetwork")
                {
                    localIp = ip.ToString();
                }
                //localIp += " " + ip.AddressFamily.ToString() + " ";
            }
            return localIp;
        }

        static void Main(string[] args)
        {
            Uri baseAddress = new Uri("http://" + GetIP() + ":8080/powertool");
            using (ServiceHost host = new ServiceHost(typeof(PowerToolService), baseAddress))
            {
                // Enable metadata publishing.
                ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
                smb.HttpGetEnabled = true;
                smb.MetadataExporter.PolicyVersion = PolicyVersion.Policy15;
                host.Description.Behaviors.Add(smb);

                // Open the ServiceHost to start listening for messages. Since
                // no endpoints are explicitly configured, the runtime will create
                // one endpoint per base address for each service contract implemented
                // by the service.
                host.Open();

                Console.WriteLine("Monsoon PowerTool service is ready at {0}", baseAddress);
                Console.WriteLine("Press <Enter> to stop the service.");
                Console.ReadLine();

                // Close the ServiceHost.
                host.Close();
            }
        }
    }
}
