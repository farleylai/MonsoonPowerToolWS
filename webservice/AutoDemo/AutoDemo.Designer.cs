using System.Drawing;

namespace AutoDemo
{
    partial class AutoDemo
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.labAverage = new System.Windows.Forms.Label();
            this.labInstantaneous = new System.Windows.Forms.Label();
            this.labTime = new System.Windows.Forms.Label();
            this.labCount = new System.Windows.Forms.Label();
            this.labVolts = new System.Windows.Forms.Label();
            this.labVersion = new System.Windows.Forms.Label();
            this.labFirmwareVersion = new System.Windows.Forms.Label();
            this.labProtocolVersion = new System.Windows.Forms.Label();
            this.labHardwareRevision = new System.Windows.Forms.Label();
            this.labSerialNumber = new System.Windows.Forms.Label();
            this.labSeconds = new System.Windows.Forms.Label();
            this.btnOpenPowerTool = new System.Windows.Forms.Button();
            this.cbIniFile = new System.Windows.Forms.CheckBox();
            this.gbPowerTool = new System.Windows.Forms.GroupBox();
            this.gbWindowState = new System.Windows.Forms.GroupBox();
            this.rbMaximized = new System.Windows.Forms.RadioButton();
            this.rbNormal = new System.Windows.Forms.RadioButton();
            this.rbMinimized = new System.Windows.Forms.RadioButton();
            this.cbVisible = new System.Windows.Forms.CheckBox();
            this.txtVersion = new System.Windows.Forms.TextBox();
            this.gbDevices = new System.Windows.Forms.GroupBox();
            this.btnConnectDevice = new System.Windows.Forms.Button();
            this.lbDeviceList = new System.Windows.Forms.ListBox();
            this.btnDeviceRefresh = new System.Windows.Forms.Button();
            this.btnRunSample = new System.Windows.Forms.Button();
            this.tmrRefresh = new System.Windows.Forms.Timer(this.components);
            this.gbDevice = new System.Windows.Forms.GroupBox();
            this.gbSampling = new System.Windows.Forms.GroupBox();
            this.gbUsbPassthrough = new System.Windows.Forms.GroupBox();
            this.rbUsbSync = new System.Windows.Forms.RadioButton();
            this.rbUsbTrigger = new System.Windows.Forms.RadioButton();
            this.rbUsbAuto = new System.Windows.Forms.RadioButton();
            this.rbUsbOn = new System.Windows.Forms.RadioButton();
            this.rbUsbOff = new System.Windows.Forms.RadioButton();
            this.gbCurrent = new System.Windows.Forms.GroupBox();
            this.cbUsbCurrent = new System.Windows.Forms.CheckBox();
            this.cbMainCurrent = new System.Windows.Forms.CheckBox();
            this.cbAuxCurrent = new System.Windows.Forms.CheckBox();
            this.gbVoltChannel = new System.Windows.Forms.GroupBox();
            this.rbVoltAux = new System.Windows.Forms.RadioButton();
            this.rbVoltMain = new System.Windows.Forms.RadioButton();
            this.gbDeviceInfo = new System.Windows.Forms.GroupBox();
            this.txtFWVer = new System.Windows.Forms.TextBox();
            this.txtHWRev = new System.Windows.Forms.TextBox();
            this.txtProtVer = new System.Windows.Forms.TextBox();
            this.txtSerialNumber = new System.Windows.Forms.TextBox();
            this.gbSampleStats = new System.Windows.Forms.GroupBox();
            this.tlpAvgStats = new System.Windows.Forms.TableLayoutPanel();
            this.labAvgMainVoltage = new System.Windows.Forms.Label();
            this.labAvgUsbVoltage = new System.Windows.Forms.Label();
            this.labAvgAuxVoltage = new System.Windows.Forms.Label();
            this.labAvgMainCurrent = new System.Windows.Forms.Label();
            this.labAvgUsbCurrent = new System.Windows.Forms.Label();
            this.labAvgAuxCurrent = new System.Windows.Forms.Label();
            this.labAvgMainPower = new System.Windows.Forms.Label();
            this.labAvgUsbPower = new System.Windows.Forms.Label();
            this.labAvgAuxPower = new System.Windows.Forms.Label();
            this.labAvgMain = new System.Windows.Forms.Label();
            this.labelAvgUsb = new System.Windows.Forms.Label();
            this.labelAvgAux = new System.Windows.Forms.Label();
            this.labAvgVoltage = new System.Windows.Forms.Label();
            this.labAvgCurrent = new System.Windows.Forms.Label();
            this.labAvgPower = new System.Windows.Forms.Label();
            this.labAvgUnit = new System.Windows.Forms.Label();
            this.txtSampleTime = new System.Windows.Forms.TextBox();
            this.txtSampleCount = new System.Windows.Forms.TextBox();
            this.tlpInstStats = new System.Windows.Forms.TableLayoutPanel();
            this.labInstMain = new System.Windows.Forms.Label();
            this.labInstUsb = new System.Windows.Forms.Label();
            this.labInstMainVoltage = new System.Windows.Forms.Label();
            this.labInstUsbVoltage = new System.Windows.Forms.Label();
            this.labInstAuxVoltage = new System.Windows.Forms.Label();
            this.labInstMainCurrent = new System.Windows.Forms.Label();
            this.labInstUsbCurrent = new System.Windows.Forms.Label();
            this.labInstAuxCurrent = new System.Windows.Forms.Label();
            this.labInstMainPower = new System.Windows.Forms.Label();
            this.labInstUsbPower = new System.Windows.Forms.Label();
            this.labInstAuxPower = new System.Windows.Forms.Label();
            this.labInstAux = new System.Windows.Forms.Label();
            this.labelInstVolt = new System.Windows.Forms.Label();
            this.labInstCurrent = new System.Windows.Forms.Label();
            this.labInstPower = new System.Windows.Forms.Label();
            this.labInstUnit = new System.Windows.Forms.Label();
            this.gbVout = new System.Windows.Forms.GroupBox();
            this.tbVoutSetting = new System.Windows.Forms.TrackBar();
            this.txtVoutSetting = new System.Windows.Forms.TextBox();
            this.cbVoutEnable = new System.Windows.Forms.CheckBox();
            this.gbTimeout = new System.Windows.Forms.GroupBox();
            this.txtTimeout = new System.Windows.Forms.TextBox();
            this.tbTimeout = new System.Windows.Forms.TrackBar();
            this.gbFile = new System.Windows.Forms.GroupBox();
            this.btnExportFile = new System.Windows.Forms.Button();
            this.btnSaveFile = new System.Windows.Forms.Button();
            this.btnLoadFile = new System.Windows.Forms.Button();
            this.cbLogFile = new System.Windows.Forms.CheckBox();
            this.gbPowerTool.SuspendLayout();
            this.gbWindowState.SuspendLayout();
            this.gbDevices.SuspendLayout();
            this.gbDevice.SuspendLayout();
            this.gbSampling.SuspendLayout();
            this.gbUsbPassthrough.SuspendLayout();
            this.gbCurrent.SuspendLayout();
            this.gbVoltChannel.SuspendLayout();
            this.gbDeviceInfo.SuspendLayout();
            this.gbSampleStats.SuspendLayout();
            this.tlpAvgStats.SuspendLayout();
            this.tlpInstStats.SuspendLayout();
            this.gbVout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbVoutSetting)).BeginInit();
            this.gbTimeout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbTimeout)).BeginInit();
            this.gbFile.SuspendLayout();
            this.SuspendLayout();
            // 
            // labAverage
            // 
            this.labAverage.AutoSize = true;
            this.labAverage.Location = new System.Drawing.Point(335, 22);
            this.labAverage.Name = "labAverage";
            this.labAverage.Size = new System.Drawing.Size(50, 13);
            this.labAverage.TabIndex = 17;
            this.labAverage.Text = "Average:";
            // 
            // labInstantaneous
            // 
            this.labInstantaneous.AutoSize = true;
            this.labInstantaneous.Location = new System.Drawing.Point(87, 21);
            this.labInstantaneous.Name = "labInstantaneous";
            this.labInstantaneous.Size = new System.Drawing.Size(77, 13);
            this.labInstantaneous.TabIndex = 15;
            this.labInstantaneous.Text = "Instantaneous:";
            // 
            // labTime
            // 
            this.labTime.AutoSize = true;
            this.labTime.Location = new System.Drawing.Point(7, 63);
            this.labTime.Name = "labTime";
            this.labTime.Size = new System.Drawing.Size(33, 13);
            this.labTime.TabIndex = 13;
            this.labTime.Text = "Time:";
            // 
            // labCount
            // 
            this.labCount.AutoSize = true;
            this.labCount.Location = new System.Drawing.Point(7, 23);
            this.labCount.Name = "labCount";
            this.labCount.Size = new System.Drawing.Size(38, 13);
            this.labCount.TabIndex = 9;
            this.labCount.Text = "Count:";
            // 
            // labVolts
            // 
            this.labVolts.AutoSize = true;
            this.labVolts.Location = new System.Drawing.Point(58, 88);
            this.labVolts.Name = "labVolts";
            this.labVolts.Size = new System.Drawing.Size(30, 13);
            this.labVolts.TabIndex = 3;
            this.labVolts.Text = "Volts";
            // 
            // labVersion
            // 
            this.labVersion.AutoSize = true;
            this.labVersion.Location = new System.Drawing.Point(3, 86);
            this.labVersion.Name = "labVersion";
            this.labVersion.Size = new System.Drawing.Size(42, 13);
            this.labVersion.TabIndex = 9;
            this.labVersion.Text = "Version";
            // 
            // labFirmwareVersion
            // 
            this.labFirmwareVersion.AutoSize = true;
            this.labFirmwareVersion.Location = new System.Drawing.Point(6, 42);
            this.labFirmwareVersion.Name = "labFirmwareVersion";
            this.labFirmwareVersion.Size = new System.Drawing.Size(86, 13);
            this.labFirmwareVersion.TabIndex = 18;
            this.labFirmwareVersion.Text = "Firmware version";
            // 
            // labProtocolVersion
            // 
            this.labProtocolVersion.AutoSize = true;
            this.labProtocolVersion.Location = new System.Drawing.Point(6, 90);
            this.labProtocolVersion.Name = "labProtocolVersion";
            this.labProtocolVersion.Size = new System.Drawing.Size(83, 13);
            this.labProtocolVersion.TabIndex = 15;
            this.labProtocolVersion.Text = "Protocol version";
            // 
            // labHardwareRevision
            // 
            this.labHardwareRevision.AutoSize = true;
            this.labHardwareRevision.Location = new System.Drawing.Point(6, 66);
            this.labHardwareRevision.Name = "labHardwareRevision";
            this.labHardwareRevision.Size = new System.Drawing.Size(92, 13);
            this.labHardwareRevision.TabIndex = 14;
            this.labHardwareRevision.Text = "Hardware revision";
            // 
            // labSerialNumber
            // 
            this.labSerialNumber.AutoSize = true;
            this.labSerialNumber.Location = new System.Drawing.Point(6, 18);
            this.labSerialNumber.Name = "labSerialNumber";
            this.labSerialNumber.Size = new System.Drawing.Size(40, 13);
            this.labSerialNumber.TabIndex = 12;
            this.labSerialNumber.Text = "Serial#";
            // 
            // labSeconds
            // 
            this.labSeconds.AutoSize = true;
            this.labSeconds.Location = new System.Drawing.Point(39, 56);
            this.labSeconds.Name = "labSeconds";
            this.labSeconds.Size = new System.Drawing.Size(47, 13);
            this.labSeconds.TabIndex = 2;
            this.labSeconds.Text = "seconds";
            // 
            // btnOpenPowerTool
            // 
            this.btnOpenPowerTool.Location = new System.Drawing.Point(6, 46);
            this.btnOpenPowerTool.Name = "btnOpenPowerTool";
            this.btnOpenPowerTool.Size = new System.Drawing.Size(78, 27);
            this.btnOpenPowerTool.TabIndex = 0;
            this.btnOpenPowerTool.Text = "Open";
            this.btnOpenPowerTool.UseVisualStyleBackColor = true;
            this.btnOpenPowerTool.Click += new System.EventHandler(this.btnOpenPowerTool_Click);
            // 
            // cbIniFile
            // 
            this.cbIniFile.AutoSize = true;
            this.cbIniFile.Location = new System.Drawing.Point(6, 22);
            this.cbIniFile.Name = "cbIniFile";
            this.cbIniFile.Size = new System.Drawing.Size(78, 17);
            this.cbIniFile.TabIndex = 3;
            this.cbIniFile.Text = "Use INI file";
            this.cbIniFile.UseVisualStyleBackColor = true;
            // 
            // gbPowerTool
            // 
            this.gbPowerTool.Controls.Add(this.gbWindowState);
            this.gbPowerTool.Controls.Add(this.txtVersion);
            this.gbPowerTool.Controls.Add(this.labVersion);
            this.gbPowerTool.Controls.Add(this.cbIniFile);
            this.gbPowerTool.Controls.Add(this.btnOpenPowerTool);
            this.gbPowerTool.Location = new System.Drawing.Point(126, 8);
            this.gbPowerTool.Name = "gbPowerTool";
            this.gbPowerTool.Size = new System.Drawing.Size(199, 114);
            this.gbPowerTool.TabIndex = 6;
            this.gbPowerTool.TabStop = false;
            this.gbPowerTool.Text = "PowerTool app";
            // 
            // gbWindowState
            // 
            this.gbWindowState.Controls.Add(this.rbMaximized);
            this.gbWindowState.Controls.Add(this.rbNormal);
            this.gbWindowState.Controls.Add(this.rbMinimized);
            this.gbWindowState.Controls.Add(this.cbVisible);
            this.gbWindowState.Location = new System.Drawing.Point(95, 9);
            this.gbWindowState.Name = "gbWindowState";
            this.gbWindowState.Size = new System.Drawing.Size(98, 99);
            this.gbWindowState.TabIndex = 11;
            this.gbWindowState.TabStop = false;
            this.gbWindowState.Text = "Window state";
            // 
            // rbMaximized
            // 
            this.rbMaximized.AutoSize = true;
            this.rbMaximized.Location = new System.Drawing.Point(12, 71);
            this.rbMaximized.Name = "rbMaximized";
            this.rbMaximized.Size = new System.Drawing.Size(74, 17);
            this.rbMaximized.TabIndex = 3;
            this.rbMaximized.TabStop = true;
            this.rbMaximized.Text = "Maximized";
            this.rbMaximized.UseVisualStyleBackColor = true;
            this.rbMaximized.Click += new System.EventHandler(this.rbMaximized_Click);
            // 
            // rbNormal
            // 
            this.rbNormal.AutoSize = true;
            this.rbNormal.Location = new System.Drawing.Point(12, 54);
            this.rbNormal.Name = "rbNormal";
            this.rbNormal.Size = new System.Drawing.Size(58, 17);
            this.rbNormal.TabIndex = 2;
            this.rbNormal.TabStop = true;
            this.rbNormal.Text = "Normal";
            this.rbNormal.UseVisualStyleBackColor = true;
            this.rbNormal.Click += new System.EventHandler(this.rbNormal_Click);
            // 
            // rbMinimized
            // 
            this.rbMinimized.AutoSize = true;
            this.rbMinimized.Location = new System.Drawing.Point(12, 37);
            this.rbMinimized.Name = "rbMinimized";
            this.rbMinimized.Size = new System.Drawing.Size(71, 17);
            this.rbMinimized.TabIndex = 1;
            this.rbMinimized.TabStop = true;
            this.rbMinimized.Text = "Minimized";
            this.rbMinimized.UseVisualStyleBackColor = true;
            this.rbMinimized.Click += new System.EventHandler(this.rbMinimized_Click);
            // 
            // cbVisible
            // 
            this.cbVisible.AutoSize = true;
            this.cbVisible.Location = new System.Drawing.Point(12, 20);
            this.cbVisible.Name = "cbVisible";
            this.cbVisible.Size = new System.Drawing.Size(56, 17);
            this.cbVisible.TabIndex = 0;
            this.cbVisible.Text = "Visible";
            this.cbVisible.UseVisualStyleBackColor = true;
            this.cbVisible.Click += new System.EventHandler(this.cbVisible_Click);
            // 
            // txtVersion
            // 
            this.txtVersion.Location = new System.Drawing.Point(48, 83);
            this.txtVersion.Name = "txtVersion";
            this.txtVersion.ReadOnly = true;
            this.txtVersion.Size = new System.Drawing.Size(41, 20);
            this.txtVersion.TabIndex = 10;
            // 
            // gbDevices
            // 
            this.gbDevices.Controls.Add(this.btnConnectDevice);
            this.gbDevices.Controls.Add(this.lbDeviceList);
            this.gbDevices.Controls.Add(this.btnDeviceRefresh);
            this.gbDevices.Location = new System.Drawing.Point(466, 8);
            this.gbDevices.Name = "gbDevices";
            this.gbDevices.Size = new System.Drawing.Size(133, 114);
            this.gbDevices.TabIndex = 7;
            this.gbDevices.TabStop = false;
            this.gbDevices.Text = "Devices";
            // 
            // btnConnectDevice
            // 
            this.btnConnectDevice.Location = new System.Drawing.Point(5, 64);
            this.btnConnectDevice.Name = "btnConnectDevice";
            this.btnConnectDevice.Size = new System.Drawing.Size(78, 27);
            this.btnConnectDevice.TabIndex = 2;
            this.btnConnectDevice.Text = "Connect";
            this.btnConnectDevice.UseVisualStyleBackColor = true;
            this.btnConnectDevice.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // lbDeviceList
            // 
            this.lbDeviceList.FormattingEnabled = true;
            this.lbDeviceList.Location = new System.Drawing.Point(87, 18);
            this.lbDeviceList.Name = "lbDeviceList";
            this.lbDeviceList.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lbDeviceList.Size = new System.Drawing.Size(40, 82);
            this.lbDeviceList.TabIndex = 1;
            this.lbDeviceList.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lbDeviceList_MouseClick);
            this.lbDeviceList.DoubleClick += new System.EventHandler(this.lbDeviceList_DoubleClick);
            // 
            // btnDeviceRefresh
            // 
            this.btnDeviceRefresh.Location = new System.Drawing.Point(5, 28);
            this.btnDeviceRefresh.Name = "btnDeviceRefresh";
            this.btnDeviceRefresh.Size = new System.Drawing.Size(78, 27);
            this.btnDeviceRefresh.TabIndex = 0;
            this.btnDeviceRefresh.Text = "Refresh";
            this.btnDeviceRefresh.UseVisualStyleBackColor = true;
            this.btnDeviceRefresh.Click += new System.EventHandler(this.btnDeviceRefresh_Click);
            // 
            // btnRunSample
            // 
            this.btnRunSample.Location = new System.Drawing.Point(110, 78);
            this.btnRunSample.Name = "btnRunSample";
            this.btnRunSample.Size = new System.Drawing.Size(96, 27);
            this.btnRunSample.TabIndex = 8;
            this.btnRunSample.Text = "Run";
            this.btnRunSample.UseVisualStyleBackColor = true;
            this.btnRunSample.Click += new System.EventHandler(this.btnRunSample_Click);
            // 
            // tmrRefresh
            // 
            this.tmrRefresh.Enabled = true;
            this.tmrRefresh.Interval = 1000;
            this.tmrRefresh.Tick += new System.EventHandler(this.tmrRefresh_Tick);
            // 
            // gbDevice
            // 
            this.gbDevice.Controls.Add(this.gbSampling);
            this.gbDevice.Controls.Add(this.gbDeviceInfo);
            this.gbDevice.Controls.Add(this.gbSampleStats);
            this.gbDevice.Controls.Add(this.gbVout);
            this.gbDevice.Location = new System.Drawing.Point(6, 123);
            this.gbDevice.Name = "gbDevice";
            this.gbDevice.Size = new System.Drawing.Size(593, 246);
            this.gbDevice.TabIndex = 9;
            this.gbDevice.TabStop = false;
            this.gbDevice.Text = "Device";
            // 
            // gbSampling
            // 
            this.gbSampling.Controls.Add(this.gbUsbPassthrough);
            this.gbSampling.Controls.Add(this.gbCurrent);
            this.gbSampling.Controls.Add(this.gbVoltChannel);
            this.gbSampling.Controls.Add(this.btnRunSample);
            this.gbSampling.Location = new System.Drawing.Point(263, 15);
            this.gbSampling.Name = "gbSampling";
            this.gbSampling.Size = new System.Drawing.Size(321, 112);
            this.gbSampling.TabIndex = 15;
            this.gbSampling.TabStop = false;
            this.gbSampling.Text = "Sampling";
            // 
            // gbUsbPassthrough
            // 
            this.gbUsbPassthrough.Controls.Add(this.rbUsbSync);
            this.gbUsbPassthrough.Controls.Add(this.rbUsbTrigger);
            this.gbUsbPassthrough.Controls.Add(this.rbUsbAuto);
            this.gbUsbPassthrough.Controls.Add(this.rbUsbOn);
            this.gbUsbPassthrough.Controls.Add(this.rbUsbOff);
            this.gbUsbPassthrough.Location = new System.Drawing.Point(210, 17);
            this.gbUsbPassthrough.Name = "gbUsbPassthrough";
            this.gbUsbPassthrough.Size = new System.Drawing.Size(107, 89);
            this.gbUsbPassthrough.TabIndex = 11;
            this.gbUsbPassthrough.TabStop = false;
            this.gbUsbPassthrough.Text = "USB passthrough";
            // 
            // rbUsbSync
            // 
            this.rbUsbSync.AutoSize = true;
            this.rbUsbSync.Location = new System.Drawing.Point(47, 41);
            this.rbUsbSync.Name = "rbUsbSync";
            this.rbUsbSync.Size = new System.Drawing.Size(49, 17);
            this.rbUsbSync.TabIndex = 4;
            this.rbUsbSync.TabStop = true;
            this.rbUsbSync.Text = "Sync";
            this.rbUsbSync.UseVisualStyleBackColor = true;
            this.rbUsbSync.Click += new System.EventHandler(this.rbUsbSync_Click);
            // 
            // rbUsbTrigger
            // 
            this.rbUsbTrigger.AutoSize = true;
            this.rbUsbTrigger.Location = new System.Drawing.Point(47, 20);
            this.rbUsbTrigger.Name = "rbUsbTrigger";
            this.rbUsbTrigger.Size = new System.Drawing.Size(58, 17);
            this.rbUsbTrigger.TabIndex = 3;
            this.rbUsbTrigger.TabStop = true;
            this.rbUsbTrigger.Text = "Trigger";
            this.rbUsbTrigger.UseVisualStyleBackColor = true;
            this.rbUsbTrigger.Click += new System.EventHandler(this.rbUsbTrigger_Click);
            // 
            // rbUsbAuto
            // 
            this.rbUsbAuto.AutoSize = true;
            this.rbUsbAuto.Location = new System.Drawing.Point(6, 62);
            this.rbUsbAuto.Name = "rbUsbAuto";
            this.rbUsbAuto.Size = new System.Drawing.Size(47, 17);
            this.rbUsbAuto.TabIndex = 2;
            this.rbUsbAuto.TabStop = true;
            this.rbUsbAuto.Text = "Auto";
            this.rbUsbAuto.UseVisualStyleBackColor = true;
            this.rbUsbAuto.Click += new System.EventHandler(this.rbUsbAuto_Click);
            // 
            // rbUsbOn
            // 
            this.rbUsbOn.AutoSize = true;
            this.rbUsbOn.Location = new System.Drawing.Point(6, 41);
            this.rbUsbOn.Name = "rbUsbOn";
            this.rbUsbOn.Size = new System.Drawing.Size(39, 17);
            this.rbUsbOn.TabIndex = 1;
            this.rbUsbOn.TabStop = true;
            this.rbUsbOn.Text = "On";
            this.rbUsbOn.UseVisualStyleBackColor = true;
            this.rbUsbOn.Click += new System.EventHandler(this.rbUsbOn_Click);
            // 
            // rbUsbOff
            // 
            this.rbUsbOff.AutoSize = true;
            this.rbUsbOff.Location = new System.Drawing.Point(6, 20);
            this.rbUsbOff.Name = "rbUsbOff";
            this.rbUsbOff.Size = new System.Drawing.Size(39, 17);
            this.rbUsbOff.TabIndex = 0;
            this.rbUsbOff.TabStop = true;
            this.rbUsbOff.Text = "Off";
            this.rbUsbOff.UseVisualStyleBackColor = true;
            this.rbUsbOff.Click += new System.EventHandler(this.rbUsbOff_Click);
            // 
            // gbCurrent
            // 
            this.gbCurrent.Controls.Add(this.cbUsbCurrent);
            this.gbCurrent.Controls.Add(this.cbMainCurrent);
            this.gbCurrent.Controls.Add(this.cbAuxCurrent);
            this.gbCurrent.Location = new System.Drawing.Point(6, 16);
            this.gbCurrent.Name = "gbCurrent";
            this.gbCurrent.Size = new System.Drawing.Size(99, 89);
            this.gbCurrent.TabIndex = 10;
            this.gbCurrent.TabStop = false;
            this.gbCurrent.Text = "Capture current";
            // 
            // cbUsbCurrent
            // 
            this.cbUsbCurrent.AutoSize = true;
            this.cbUsbCurrent.Location = new System.Drawing.Point(19, 43);
            this.cbUsbCurrent.Name = "cbUsbCurrent";
            this.cbUsbCurrent.Size = new System.Drawing.Size(48, 17);
            this.cbUsbCurrent.TabIndex = 1;
            this.cbUsbCurrent.Text = "USB";
            this.cbUsbCurrent.UseVisualStyleBackColor = true;
            this.cbUsbCurrent.Click += new System.EventHandler(this.cbUsbCurrent_Click);
            // 
            // cbMainCurrent
            // 
            this.cbMainCurrent.AutoSize = true;
            this.cbMainCurrent.Location = new System.Drawing.Point(19, 22);
            this.cbMainCurrent.Name = "cbMainCurrent";
            this.cbMainCurrent.Size = new System.Drawing.Size(49, 17);
            this.cbMainCurrent.TabIndex = 0;
            this.cbMainCurrent.Text = "Main";
            this.cbMainCurrent.UseVisualStyleBackColor = true;
            this.cbMainCurrent.Click += new System.EventHandler(this.cbMainCurrent_Click);
            // 
            // cbAuxCurrent
            // 
            this.cbAuxCurrent.AutoSize = true;
            this.cbAuxCurrent.Location = new System.Drawing.Point(19, 64);
            this.cbAuxCurrent.Name = "cbAuxCurrent";
            this.cbAuxCurrent.Size = new System.Drawing.Size(44, 17);
            this.cbAuxCurrent.TabIndex = 2;
            this.cbAuxCurrent.Text = "Aux";
            this.cbAuxCurrent.UseVisualStyleBackColor = true;
            this.cbAuxCurrent.Click += new System.EventHandler(this.cbAuxCurrent_Click);
            // 
            // gbVoltChannel
            // 
            this.gbVoltChannel.Controls.Add(this.rbVoltAux);
            this.gbVoltChannel.Controls.Add(this.rbVoltMain);
            this.gbVoltChannel.Location = new System.Drawing.Point(110, 17);
            this.gbVoltChannel.Name = "gbVoltChannel";
            this.gbVoltChannel.Size = new System.Drawing.Size(96, 55);
            this.gbVoltChannel.TabIndex = 9;
            this.gbVoltChannel.TabStop = false;
            this.gbVoltChannel.Text = "Capture voltage";
            // 
            // rbVoltAux
            // 
            this.rbVoltAux.AutoSize = true;
            this.rbVoltAux.Location = new System.Drawing.Point(19, 35);
            this.rbVoltAux.Name = "rbVoltAux";
            this.rbVoltAux.Size = new System.Drawing.Size(43, 17);
            this.rbVoltAux.TabIndex = 1;
            this.rbVoltAux.TabStop = true;
            this.rbVoltAux.Text = "Aux";
            this.rbVoltAux.UseVisualStyleBackColor = true;
            this.rbVoltAux.Click += new System.EventHandler(this.rbVoltAux_Click);
            // 
            // rbVoltMain
            // 
            this.rbVoltMain.AutoSize = true;
            this.rbVoltMain.Location = new System.Drawing.Point(19, 17);
            this.rbVoltMain.Name = "rbVoltMain";
            this.rbVoltMain.Size = new System.Drawing.Size(48, 17);
            this.rbVoltMain.TabIndex = 0;
            this.rbVoltMain.TabStop = true;
            this.rbVoltMain.Text = "Main";
            this.rbVoltMain.UseVisualStyleBackColor = true;
            this.rbVoltMain.Click += new System.EventHandler(this.rbVoltMain_Click);
            // 
            // gbDeviceInfo
            // 
            this.gbDeviceInfo.Controls.Add(this.txtFWVer);
            this.gbDeviceInfo.Controls.Add(this.labFirmwareVersion);
            this.gbDeviceInfo.Controls.Add(this.txtHWRev);
            this.gbDeviceInfo.Controls.Add(this.txtProtVer);
            this.gbDeviceInfo.Controls.Add(this.labProtocolVersion);
            this.gbDeviceInfo.Controls.Add(this.labHardwareRevision);
            this.gbDeviceInfo.Controls.Add(this.txtSerialNumber);
            this.gbDeviceInfo.Controls.Add(this.labSerialNumber);
            this.gbDeviceInfo.Location = new System.Drawing.Point(10, 15);
            this.gbDeviceInfo.Name = "gbDeviceInfo";
            this.gbDeviceInfo.Size = new System.Drawing.Size(134, 112);
            this.gbDeviceInfo.TabIndex = 14;
            this.gbDeviceInfo.TabStop = false;
            this.gbDeviceInfo.Text = "Info";
            // 
            // txtFWVer
            // 
            this.txtFWVer.Location = new System.Drawing.Point(105, 38);
            this.txtFWVer.Name = "txtFWVer";
            this.txtFWVer.ReadOnly = true;
            this.txtFWVer.Size = new System.Drawing.Size(18, 20);
            this.txtFWVer.TabIndex = 19;
            this.txtFWVer.Text = "17";
            this.txtFWVer.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtHWRev
            // 
            this.txtHWRev.Location = new System.Drawing.Point(105, 62);
            this.txtHWRev.Name = "txtHWRev";
            this.txtHWRev.ReadOnly = true;
            this.txtHWRev.Size = new System.Drawing.Size(18, 20);
            this.txtHWRev.TabIndex = 17;
            this.txtHWRev.Text = "D";
            this.txtHWRev.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtProtVer
            // 
            this.txtProtVer.Location = new System.Drawing.Point(105, 86);
            this.txtProtVer.Name = "txtProtVer";
            this.txtProtVer.ReadOnly = true;
            this.txtProtVer.Size = new System.Drawing.Size(18, 20);
            this.txtProtVer.TabIndex = 16;
            this.txtProtVer.Text = "17";
            this.txtProtVer.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtSerialNumber
            // 
            this.txtSerialNumber.Location = new System.Drawing.Point(80, 14);
            this.txtSerialNumber.Name = "txtSerialNumber";
            this.txtSerialNumber.ReadOnly = true;
            this.txtSerialNumber.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtSerialNumber.Size = new System.Drawing.Size(43, 20);
            this.txtSerialNumber.TabIndex = 13;
            this.txtSerialNumber.Text = "65535";
            this.txtSerialNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // gbSampleStats
            // 
            this.gbSampleStats.Controls.Add(this.labAverage);
            this.gbSampleStats.Controls.Add(this.tlpAvgStats);
            this.gbSampleStats.Controls.Add(this.labInstantaneous);
            this.gbSampleStats.Controls.Add(this.txtSampleTime);
            this.gbSampleStats.Controls.Add(this.labTime);
            this.gbSampleStats.Controls.Add(this.txtSampleCount);
            this.gbSampleStats.Controls.Add(this.tlpInstStats);
            this.gbSampleStats.Controls.Add(this.labCount);
            this.gbSampleStats.Location = new System.Drawing.Point(10, 133);
            this.gbSampleStats.Name = "gbSampleStats";
            this.gbSampleStats.Size = new System.Drawing.Size(574, 106);
            this.gbSampleStats.TabIndex = 10;
            this.gbSampleStats.TabStop = false;
            this.gbSampleStats.Text = "Sample Statistics";
            // 
            // tlpAvgStats
            // 
            this.tlpAvgStats.AutoSize = true;
            this.tlpAvgStats.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tlpAvgStats.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
            this.tlpAvgStats.ColumnCount = 4;
            this.tlpAvgStats.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpAvgStats.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpAvgStats.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpAvgStats.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpAvgStats.Controls.Add(this.labAvgMainVoltage, 3, 1);
            this.tlpAvgStats.Controls.Add(this.labAvgUsbVoltage, 2, 1);
            this.tlpAvgStats.Controls.Add(this.labAvgAuxVoltage, 1, 1);
            this.tlpAvgStats.Controls.Add(this.labAvgMainCurrent, 3, 2);
            this.tlpAvgStats.Controls.Add(this.labAvgUsbCurrent, 2, 2);
            this.tlpAvgStats.Controls.Add(this.labAvgAuxCurrent, 1, 2);
            this.tlpAvgStats.Controls.Add(this.labAvgMainPower, 3, 3);
            this.tlpAvgStats.Controls.Add(this.labAvgUsbPower, 2, 3);
            this.tlpAvgStats.Controls.Add(this.labAvgAuxPower, 1, 3);
            this.tlpAvgStats.Controls.Add(this.labAvgMain, 3, 0);
            this.tlpAvgStats.Controls.Add(this.labelAvgUsb, 2, 0);
            this.tlpAvgStats.Controls.Add(this.labelAvgAux, 1, 0);
            this.tlpAvgStats.Controls.Add(this.labAvgVoltage, 0, 1);
            this.tlpAvgStats.Controls.Add(this.labAvgCurrent, 0, 2);
            this.tlpAvgStats.Controls.Add(this.labAvgPower, 0, 3);
            this.tlpAvgStats.Controls.Add(this.labAvgUnit, 0, 0);
            this.tlpAvgStats.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tlpAvgStats.Location = new System.Drawing.Point(337, 39);
            this.tlpAvgStats.Name = "tlpAvgStats";
            this.tlpAvgStats.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.tlpAvgStats.RowCount = 4;
            this.tlpAvgStats.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpAvgStats.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpAvgStats.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpAvgStats.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpAvgStats.Size = new System.Drawing.Size(147, 62);
            this.tlpAvgStats.TabIndex = 16;
            // 
            // labAvgMainVoltage
            // 
            this.labAvgMainVoltage.AutoSize = true;
            this.labAvgMainVoltage.Location = new System.Drawing.Point(7, 17);
            this.labAvgMainVoltage.Name = "labAvgMainVoltage";
            this.labAvgMainVoltage.Size = new System.Drawing.Size(28, 13);
            this.labAvgMainVoltage.TabIndex = 4;
            this.labAvgMainVoltage.Text = "0.00";
            // 
            // labAvgUsbVoltage
            // 
            this.labAvgUsbVoltage.AutoSize = true;
            this.labAvgUsbVoltage.Location = new System.Drawing.Point(44, 17);
            this.labAvgUsbVoltage.Name = "labAvgUsbVoltage";
            this.labAvgUsbVoltage.Size = new System.Drawing.Size(28, 13);
            this.labAvgUsbVoltage.TabIndex = 5;
            this.labAvgUsbVoltage.Text = "0.00";
            // 
            // labAvgAuxVoltage
            // 
            this.labAvgAuxVoltage.AutoSize = true;
            this.labAvgAuxVoltage.Location = new System.Drawing.Point(80, 17);
            this.labAvgAuxVoltage.Name = "labAvgAuxVoltage";
            this.labAvgAuxVoltage.Size = new System.Drawing.Size(28, 13);
            this.labAvgAuxVoltage.TabIndex = 6;
            this.labAvgAuxVoltage.Text = "0.00";
            // 
            // labAvgMainCurrent
            // 
            this.labAvgMainCurrent.AutoSize = true;
            this.labAvgMainCurrent.Location = new System.Drawing.Point(7, 32);
            this.labAvgMainCurrent.Name = "labAvgMainCurrent";
            this.labAvgMainCurrent.Size = new System.Drawing.Size(28, 13);
            this.labAvgMainCurrent.TabIndex = 8;
            this.labAvgMainCurrent.Text = "0.00";
            // 
            // labAvgUsbCurrent
            // 
            this.labAvgUsbCurrent.AutoSize = true;
            this.labAvgUsbCurrent.Location = new System.Drawing.Point(44, 32);
            this.labAvgUsbCurrent.Name = "labAvgUsbCurrent";
            this.labAvgUsbCurrent.Size = new System.Drawing.Size(28, 13);
            this.labAvgUsbCurrent.TabIndex = 9;
            this.labAvgUsbCurrent.Text = "0.00";
            // 
            // labAvgAuxCurrent
            // 
            this.labAvgAuxCurrent.AutoSize = true;
            this.labAvgAuxCurrent.Location = new System.Drawing.Point(80, 32);
            this.labAvgAuxCurrent.Name = "labAvgAuxCurrent";
            this.labAvgAuxCurrent.Size = new System.Drawing.Size(28, 13);
            this.labAvgAuxCurrent.TabIndex = 10;
            this.labAvgAuxCurrent.Text = "0.00";
            // 
            // labAvgMainPower
            // 
            this.labAvgMainPower.AutoSize = true;
            this.labAvgMainPower.Location = new System.Drawing.Point(7, 47);
            this.labAvgMainPower.Name = "labAvgMainPower";
            this.labAvgMainPower.Size = new System.Drawing.Size(28, 13);
            this.labAvgMainPower.TabIndex = 13;
            this.labAvgMainPower.Text = "0.00";
            // 
            // labAvgUsbPower
            // 
            this.labAvgUsbPower.AutoSize = true;
            this.labAvgUsbPower.Location = new System.Drawing.Point(44, 47);
            this.labAvgUsbPower.Name = "labAvgUsbPower";
            this.labAvgUsbPower.Size = new System.Drawing.Size(28, 13);
            this.labAvgUsbPower.TabIndex = 14;
            this.labAvgUsbPower.Text = "0.00";
            // 
            // labAvgAuxPower
            // 
            this.labAvgAuxPower.AutoSize = true;
            this.labAvgAuxPower.Location = new System.Drawing.Point(80, 47);
            this.labAvgAuxPower.Name = "labAvgAuxPower";
            this.labAvgAuxPower.Size = new System.Drawing.Size(28, 13);
            this.labAvgAuxPower.TabIndex = 15;
            this.labAvgAuxPower.Text = "0.00";
            // 
            // labAvgMain
            // 
            this.labAvgMain.AutoSize = true;
            this.labAvgMain.Location = new System.Drawing.Point(5, 2);
            this.labAvgMain.Name = "labAvgMain";
            this.labAvgMain.Size = new System.Drawing.Size(30, 13);
            this.labAvgMain.TabIndex = 16;
            this.labAvgMain.Text = "Main";
            // 
            // labelAvgUsb
            // 
            this.labelAvgUsb.AutoSize = true;
            this.labelAvgUsb.Location = new System.Drawing.Point(43, 2);
            this.labelAvgUsb.Name = "labelAvgUsb";
            this.labelAvgUsb.Size = new System.Drawing.Size(29, 13);
            this.labelAvgUsb.TabIndex = 17;
            this.labelAvgUsb.Text = "USB";
            // 
            // labelAvgAux
            // 
            this.labelAvgAux.AutoSize = true;
            this.labelAvgAux.Location = new System.Drawing.Point(83, 2);
            this.labelAvgAux.Name = "labelAvgAux";
            this.labelAvgAux.Size = new System.Drawing.Size(25, 13);
            this.labelAvgAux.TabIndex = 18;
            this.labelAvgAux.Text = "Aux";
            // 
            // labAvgVoltage
            // 
            this.labAvgVoltage.AutoSize = true;
            this.labAvgVoltage.Dock = System.Windows.Forms.DockStyle.Right;
            this.labAvgVoltage.Location = new System.Drawing.Point(116, 17);
            this.labAvgVoltage.Name = "labAvgVoltage";
            this.labAvgVoltage.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.labAvgVoltage.Size = new System.Drawing.Size(14, 13);
            this.labAvgVoltage.TabIndex = 20;
            this.labAvgVoltage.Text = "V";
            this.labAvgVoltage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labAvgCurrent
            // 
            this.labAvgCurrent.AutoSize = true;
            this.labAvgCurrent.Dock = System.Windows.Forms.DockStyle.Right;
            this.labAvgCurrent.Location = new System.Drawing.Point(116, 32);
            this.labAvgCurrent.Name = "labAvgCurrent";
            this.labAvgCurrent.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.labAvgCurrent.Size = new System.Drawing.Size(22, 13);
            this.labAvgCurrent.TabIndex = 21;
            this.labAvgCurrent.Text = "mA";
            // 
            // labAvgPower
            // 
            this.labAvgPower.AutoSize = true;
            this.labAvgPower.Dock = System.Windows.Forms.DockStyle.Right;
            this.labAvgPower.Location = new System.Drawing.Point(116, 47);
            this.labAvgPower.Name = "labAvgPower";
            this.labAvgPower.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.labAvgPower.Size = new System.Drawing.Size(26, 13);
            this.labAvgPower.TabIndex = 22;
            this.labAvgPower.Text = "mW";
            // 
            // labAvgUnit
            // 
            this.labAvgUnit.AutoSize = true;
            this.labAvgUnit.Dock = System.Windows.Forms.DockStyle.Right;
            this.labAvgUnit.Location = new System.Drawing.Point(116, 2);
            this.labAvgUnit.Name = "labAvgUnit";
            this.labAvgUnit.Size = new System.Drawing.Size(26, 13);
            this.labAvgUnit.TabIndex = 19;
            this.labAvgUnit.Text = "Unit";
            // 
            // txtSampleTime
            // 
            this.txtSampleTime.Location = new System.Drawing.Point(7, 78);
            this.txtSampleTime.Name = "txtSampleTime";
            this.txtSampleTime.ReadOnly = true;
            this.txtSampleTime.Size = new System.Drawing.Size(65, 20);
            this.txtSampleTime.TabIndex = 14;
            this.txtSampleTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtSampleCount
            // 
            this.txtSampleCount.Location = new System.Drawing.Point(7, 39);
            this.txtSampleCount.Name = "txtSampleCount";
            this.txtSampleCount.ReadOnly = true;
            this.txtSampleCount.Size = new System.Drawing.Size(65, 20);
            this.txtSampleCount.TabIndex = 12;
            this.txtSampleCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tlpInstStats
            // 
            this.tlpInstStats.AutoSize = true;
            this.tlpInstStats.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tlpInstStats.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
            this.tlpInstStats.ColumnCount = 4;
            this.tlpInstStats.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpInstStats.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpInstStats.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpInstStats.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpInstStats.Controls.Add(this.labInstMain, 3, 0);
            this.tlpInstStats.Controls.Add(this.labInstUsb, 2, 0);
            this.tlpInstStats.Controls.Add(this.labInstMainVoltage, 3, 1);
            this.tlpInstStats.Controls.Add(this.labInstUsbVoltage, 2, 1);
            this.tlpInstStats.Controls.Add(this.labInstAuxVoltage, 1, 1);
            this.tlpInstStats.Controls.Add(this.labInstMainCurrent, 3, 2);
            this.tlpInstStats.Controls.Add(this.labInstUsbCurrent, 2, 2);
            this.tlpInstStats.Controls.Add(this.labInstAuxCurrent, 1, 2);
            this.tlpInstStats.Controls.Add(this.labInstMainPower, 3, 3);
            this.tlpInstStats.Controls.Add(this.labInstUsbPower, 2, 3);
            this.tlpInstStats.Controls.Add(this.labInstAuxPower, 1, 3);
            this.tlpInstStats.Controls.Add(this.labInstAux, 1, 0);
            this.tlpInstStats.Controls.Add(this.labelInstVolt, 0, 1);
            this.tlpInstStats.Controls.Add(this.labInstCurrent, 0, 2);
            this.tlpInstStats.Controls.Add(this.labInstPower, 0, 3);
            this.tlpInstStats.Controls.Add(this.labInstUnit, 0, 0);
            this.tlpInstStats.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tlpInstStats.Location = new System.Drawing.Point(90, 39);
            this.tlpInstStats.Name = "tlpInstStats";
            this.tlpInstStats.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.tlpInstStats.RowCount = 4;
            this.tlpInstStats.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpInstStats.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpInstStats.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpInstStats.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpInstStats.Size = new System.Drawing.Size(147, 62);
            this.tlpInstStats.TabIndex = 11;
            // 
            // labInstMain
            // 
            this.labInstMain.AutoSize = true;
            this.labInstMain.Location = new System.Drawing.Point(5, 2);
            this.labInstMain.Name = "labInstMain";
            this.labInstMain.Size = new System.Drawing.Size(30, 13);
            this.labInstMain.TabIndex = 0;
            this.labInstMain.Text = "Main";
            this.labInstMain.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labInstUsb
            // 
            this.labInstUsb.AutoSize = true;
            this.labInstUsb.Location = new System.Drawing.Point(43, 2);
            this.labInstUsb.Name = "labInstUsb";
            this.labInstUsb.Size = new System.Drawing.Size(29, 13);
            this.labInstUsb.TabIndex = 1;
            this.labInstUsb.Text = "USB";
            // 
            // labInstMainVoltage
            // 
            this.labInstMainVoltage.AutoSize = true;
            this.labInstMainVoltage.Location = new System.Drawing.Point(7, 17);
            this.labInstMainVoltage.Name = "labInstMainVoltage";
            this.labInstMainVoltage.Size = new System.Drawing.Size(28, 13);
            this.labInstMainVoltage.TabIndex = 4;
            this.labInstMainVoltage.Text = "0.00";
            // 
            // labInstUsbVoltage
            // 
            this.labInstUsbVoltage.AutoSize = true;
            this.labInstUsbVoltage.Location = new System.Drawing.Point(44, 17);
            this.labInstUsbVoltage.Name = "labInstUsbVoltage";
            this.labInstUsbVoltage.Size = new System.Drawing.Size(28, 13);
            this.labInstUsbVoltage.TabIndex = 5;
            this.labInstUsbVoltage.Text = "0.00";
            // 
            // labInstAuxVoltage
            // 
            this.labInstAuxVoltage.AutoSize = true;
            this.labInstAuxVoltage.Location = new System.Drawing.Point(80, 17);
            this.labInstAuxVoltage.Name = "labInstAuxVoltage";
            this.labInstAuxVoltage.Size = new System.Drawing.Size(28, 13);
            this.labInstAuxVoltage.TabIndex = 6;
            this.labInstAuxVoltage.Text = "0.00";
            // 
            // labInstMainCurrent
            // 
            this.labInstMainCurrent.AutoSize = true;
            this.labInstMainCurrent.Location = new System.Drawing.Point(7, 32);
            this.labInstMainCurrent.Name = "labInstMainCurrent";
            this.labInstMainCurrent.Size = new System.Drawing.Size(28, 13);
            this.labInstMainCurrent.TabIndex = 8;
            this.labInstMainCurrent.Text = "0.00";
            // 
            // labInstUsbCurrent
            // 
            this.labInstUsbCurrent.AutoSize = true;
            this.labInstUsbCurrent.Location = new System.Drawing.Point(44, 32);
            this.labInstUsbCurrent.Name = "labInstUsbCurrent";
            this.labInstUsbCurrent.Size = new System.Drawing.Size(28, 13);
            this.labInstUsbCurrent.TabIndex = 9;
            this.labInstUsbCurrent.Text = "0.00";
            // 
            // labInstAuxCurrent
            // 
            this.labInstAuxCurrent.AutoSize = true;
            this.labInstAuxCurrent.Location = new System.Drawing.Point(80, 32);
            this.labInstAuxCurrent.Name = "labInstAuxCurrent";
            this.labInstAuxCurrent.Size = new System.Drawing.Size(28, 13);
            this.labInstAuxCurrent.TabIndex = 10;
            this.labInstAuxCurrent.Text = "0.00";
            // 
            // labInstMainPower
            // 
            this.labInstMainPower.AutoSize = true;
            this.labInstMainPower.Location = new System.Drawing.Point(7, 47);
            this.labInstMainPower.Name = "labInstMainPower";
            this.labInstMainPower.Size = new System.Drawing.Size(28, 13);
            this.labInstMainPower.TabIndex = 13;
            this.labInstMainPower.Text = "0.00";
            // 
            // labInstUsbPower
            // 
            this.labInstUsbPower.AutoSize = true;
            this.labInstUsbPower.Location = new System.Drawing.Point(44, 47);
            this.labInstUsbPower.Name = "labInstUsbPower";
            this.labInstUsbPower.Size = new System.Drawing.Size(28, 13);
            this.labInstUsbPower.TabIndex = 14;
            this.labInstUsbPower.Text = "0.00";
            // 
            // labInstAuxPower
            // 
            this.labInstAuxPower.AutoSize = true;
            this.labInstAuxPower.Location = new System.Drawing.Point(80, 47);
            this.labInstAuxPower.Name = "labInstAuxPower";
            this.labInstAuxPower.Size = new System.Drawing.Size(28, 13);
            this.labInstAuxPower.TabIndex = 15;
            this.labInstAuxPower.Text = "0.00";
            // 
            // labInstAux
            // 
            this.labInstAux.AutoSize = true;
            this.labInstAux.Location = new System.Drawing.Point(83, 2);
            this.labInstAux.Name = "labInstAux";
            this.labInstAux.Size = new System.Drawing.Size(25, 13);
            this.labInstAux.TabIndex = 16;
            this.labInstAux.Text = "Aux";
            // 
            // labelInstVolt
            // 
            this.labelInstVolt.AutoSize = true;
            this.labelInstVolt.Dock = System.Windows.Forms.DockStyle.Right;
            this.labelInstVolt.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelInstVolt.Location = new System.Drawing.Point(116, 17);
            this.labelInstVolt.Name = "labelInstVolt";
            this.labelInstVolt.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.labelInstVolt.Size = new System.Drawing.Size(14, 13);
            this.labelInstVolt.TabIndex = 19;
            this.labelInstVolt.Text = "V";
            this.labelInstVolt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labInstCurrent
            // 
            this.labInstCurrent.AutoSize = true;
            this.labInstCurrent.Dock = System.Windows.Forms.DockStyle.Right;
            this.labInstCurrent.Location = new System.Drawing.Point(116, 32);
            this.labInstCurrent.Name = "labInstCurrent";
            this.labInstCurrent.Size = new System.Drawing.Size(22, 13);
            this.labInstCurrent.TabIndex = 20;
            this.labInstCurrent.Text = "mA";
            // 
            // labInstPower
            // 
            this.labInstPower.AutoSize = true;
            this.labInstPower.Dock = System.Windows.Forms.DockStyle.Right;
            this.labInstPower.Location = new System.Drawing.Point(116, 47);
            this.labInstPower.Name = "labInstPower";
            this.labInstPower.Size = new System.Drawing.Size(26, 13);
            this.labInstPower.TabIndex = 21;
            this.labInstPower.Text = "mW";
            // 
            // labInstUnit
            // 
            this.labInstUnit.AutoSize = true;
            this.labInstUnit.Dock = System.Windows.Forms.DockStyle.Right;
            this.labInstUnit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labInstUnit.Location = new System.Drawing.Point(116, 2);
            this.labInstUnit.Name = "labInstUnit";
            this.labInstUnit.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.labInstUnit.Size = new System.Drawing.Size(26, 13);
            this.labInstUnit.TabIndex = 18;
            this.labInstUnit.Text = "Unit";
            this.labInstUnit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // gbVout
            // 
            this.gbVout.Controls.Add(this.labVolts);
            this.gbVout.Controls.Add(this.tbVoutSetting);
            this.gbVout.Controls.Add(this.txtVoutSetting);
            this.gbVout.Controls.Add(this.cbVoutEnable);
            this.gbVout.Location = new System.Drawing.Point(150, 15);
            this.gbVout.Name = "gbVout";
            this.gbVout.Size = new System.Drawing.Size(107, 112);
            this.gbVout.TabIndex = 11;
            this.gbVout.TabStop = false;
            this.gbVout.Text = "Output voltage";
            // 
            // tbVoutSetting
            // 
            this.tbVoutSetting.LargeChange = 10;
            this.tbVoutSetting.Location = new System.Drawing.Point(4, 37);
            this.tbVoutSetting.Maximum = 255;
            this.tbVoutSetting.Minimum = 1;
            this.tbVoutSetting.Name = "tbVoutSetting";
            this.tbVoutSetting.Size = new System.Drawing.Size(102, 45);
            this.tbVoutSetting.TabIndex = 2;
            this.tbVoutSetting.TickFrequency = 25;
            this.tbVoutSetting.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            this.tbVoutSetting.Value = 1;
            this.tbVoutSetting.Scroll += new System.EventHandler(this.tbVoutSetting_Scroll);
            // 
            // txtVoutSetting
            // 
            this.txtVoutSetting.Location = new System.Drawing.Point(15, 84);
            this.txtVoutSetting.MaxLength = 4;
            this.txtVoutSetting.Name = "txtVoutSetting";
            this.txtVoutSetting.ReadOnly = true;
            this.txtVoutSetting.Size = new System.Drawing.Size(37, 20);
            this.txtVoutSetting.TabIndex = 1;
            this.txtVoutSetting.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // cbVoutEnable
            // 
            this.cbVoutEnable.AutoSize = true;
            this.cbVoutEnable.Location = new System.Drawing.Point(15, 19);
            this.cbVoutEnable.Name = "cbVoutEnable";
            this.cbVoutEnable.Size = new System.Drawing.Size(59, 17);
            this.cbVoutEnable.TabIndex = 0;
            this.cbVoutEnable.Text = "Enable";
            this.cbVoutEnable.UseVisualStyleBackColor = true;
            this.cbVoutEnable.Click += new System.EventHandler(this.cbVoutEnable_Click);
            // 
            // gbTimeout
            // 
            this.gbTimeout.Controls.Add(this.labSeconds);
            this.gbTimeout.Controls.Add(this.txtTimeout);
            this.gbTimeout.Controls.Add(this.tbTimeout);
            this.gbTimeout.Location = new System.Drawing.Point(6, 8);
            this.gbTimeout.Name = "gbTimeout";
            this.gbTimeout.Size = new System.Drawing.Size(94, 80);
            this.gbTimeout.TabIndex = 11;
            this.gbTimeout.TabStop = false;
            this.gbTimeout.Text = "API timeout";
            // 
            // txtTimeout
            // 
            this.txtTimeout.Location = new System.Drawing.Point(8, 53);
            this.txtTimeout.Name = "txtTimeout";
            this.txtTimeout.ReadOnly = true;
            this.txtTimeout.Size = new System.Drawing.Size(25, 20);
            this.txtTimeout.TabIndex = 1;
            this.txtTimeout.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tbTimeout
            // 
            this.tbTimeout.AutoSize = false;
            this.tbTimeout.Location = new System.Drawing.Point(6, 13);
            this.tbTimeout.Maximum = 60;
            this.tbTimeout.Name = "tbTimeout";
            this.tbTimeout.Size = new System.Drawing.Size(78, 33);
            this.tbTimeout.TabIndex = 0;
            this.tbTimeout.TickFrequency = 2;
            this.tbTimeout.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            this.tbTimeout.Scroll += new System.EventHandler(this.tbTimeout_Scroll);
            // 
            // gbFile
            // 
            this.gbFile.Controls.Add(this.btnExportFile);
            this.gbFile.Controls.Add(this.btnSaveFile);
            this.gbFile.Controls.Add(this.btnLoadFile);
            this.gbFile.Location = new System.Drawing.Point(351, 8);
            this.gbFile.Name = "gbFile";
            this.gbFile.Size = new System.Drawing.Size(89, 114);
            this.gbFile.TabIndex = 12;
            this.gbFile.TabStop = false;
            this.gbFile.Text = "File";
            // 
            // btnExportFile
            // 
            this.btnExportFile.Location = new System.Drawing.Point(6, 77);
            this.btnExportFile.Name = "btnExportFile";
            this.btnExportFile.Size = new System.Drawing.Size(78, 27);
            this.btnExportFile.TabIndex = 2;
            this.btnExportFile.Text = "Export";
            this.btnExportFile.UseVisualStyleBackColor = true;
            this.btnExportFile.Click += new System.EventHandler(this.btnExportFile_Click);
            // 
            // btnSaveFile
            // 
            this.btnSaveFile.Location = new System.Drawing.Point(6, 48);
            this.btnSaveFile.Name = "btnSaveFile";
            this.btnSaveFile.Size = new System.Drawing.Size(78, 27);
            this.btnSaveFile.TabIndex = 1;
            this.btnSaveFile.Text = "Save";
            this.btnSaveFile.UseVisualStyleBackColor = true;
            this.btnSaveFile.Click += new System.EventHandler(this.btnSaveFile_Click);
            // 
            // btnLoadFile
            // 
            this.btnLoadFile.Location = new System.Drawing.Point(6, 19);
            this.btnLoadFile.Name = "btnLoadFile";
            this.btnLoadFile.Size = new System.Drawing.Size(78, 27);
            this.btnLoadFile.TabIndex = 0;
            this.btnLoadFile.Text = "Load";
            this.btnLoadFile.UseVisualStyleBackColor = true;
            this.btnLoadFile.Click += new System.EventHandler(this.btnLoadFile_Click);
            // 
            // cbLogFile
            // 
            this.cbLogFile.AutoSize = true;
            this.cbLogFile.Location = new System.Drawing.Point(11, 98);
            this.cbLogFile.Name = "cbLogFile";
            this.cbLogFile.Size = new System.Drawing.Size(63, 17);
            this.cbLogFile.TabIndex = 13;
            this.cbLogFile.Text = "Log File";
            this.cbLogFile.UseVisualStyleBackColor = true;
            this.cbLogFile.CheckedChanged += new System.EventHandler(this.cbLogFile_CheckedChanged);
            // 
            // AutoDemo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(603, 376);
            this.Controls.Add(this.cbLogFile);
            this.Controls.Add(this.gbPowerTool);
            this.Controls.Add(this.gbFile);
            this.Controls.Add(this.gbTimeout);
            this.Controls.Add(this.gbDevice);
            this.Controls.Add(this.gbDevices);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "AutoDemo";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "PowerTool Automation Demo";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AutoDemo_FormClosing);
            this.Load += new System.EventHandler(this.AutoDemo_Load);
            this.gbPowerTool.ResumeLayout(false);
            this.gbPowerTool.PerformLayout();
            this.gbWindowState.ResumeLayout(false);
            this.gbWindowState.PerformLayout();
            this.gbDevices.ResumeLayout(false);
            this.gbDevice.ResumeLayout(false);
            this.gbSampling.ResumeLayout(false);
            this.gbUsbPassthrough.ResumeLayout(false);
            this.gbUsbPassthrough.PerformLayout();
            this.gbCurrent.ResumeLayout(false);
            this.gbCurrent.PerformLayout();
            this.gbVoltChannel.ResumeLayout(false);
            this.gbVoltChannel.PerformLayout();
            this.gbDeviceInfo.ResumeLayout(false);
            this.gbDeviceInfo.PerformLayout();
            this.gbSampleStats.ResumeLayout(false);
            this.gbSampleStats.PerformLayout();
            this.tlpAvgStats.ResumeLayout(false);
            this.tlpAvgStats.PerformLayout();
            this.tlpInstStats.ResumeLayout(false);
            this.tlpInstStats.PerformLayout();
            this.gbVout.ResumeLayout(false);
            this.gbVout.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbVoutSetting)).EndInit();
            this.gbTimeout.ResumeLayout(false);
            this.gbTimeout.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbTimeout)).EndInit();
            this.gbFile.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOpenPowerTool;
        private System.Windows.Forms.CheckBox cbIniFile;
        private System.Windows.Forms.GroupBox gbPowerTool;
        private System.Windows.Forms.GroupBox gbDevices;
        private System.Windows.Forms.Button btnDeviceRefresh;
        private System.Windows.Forms.ListBox lbDeviceList;
        private System.Windows.Forms.Button btnConnectDevice;
        private System.Windows.Forms.Button btnRunSample;
        private System.Windows.Forms.Timer tmrRefresh;
        private System.Windows.Forms.GroupBox gbDevice;
        private System.Windows.Forms.CheckBox cbVoutEnable;
        private System.Windows.Forms.GroupBox gbVoltChannel;
        private System.Windows.Forms.RadioButton rbVoltAux;
        private System.Windows.Forms.RadioButton rbVoltMain;
        private System.Windows.Forms.GroupBox gbCurrent;
        private System.Windows.Forms.CheckBox cbAuxCurrent;
        private System.Windows.Forms.CheckBox cbUsbCurrent;
        private System.Windows.Forms.CheckBox cbMainCurrent;
        private System.Windows.Forms.GroupBox gbVout;
        private System.Windows.Forms.TextBox txtVoutSetting;
        private System.Windows.Forms.GroupBox gbSampleStats;
        private System.Windows.Forms.TableLayoutPanel tlpInstStats;
        private System.Windows.Forms.GroupBox gbTimeout;
        private System.Windows.Forms.TrackBar tbTimeout;
        private System.Windows.Forms.TextBox txtTimeout;
        private System.Windows.Forms.TrackBar tbVoutSetting;
        private System.Windows.Forms.TextBox txtSerialNumber;
        private System.Windows.Forms.TextBox txtSampleCount;
        private System.Windows.Forms.Label labInstMain;
        private System.Windows.Forms.Label labInstUsb;
        private System.Windows.Forms.Label labInstMainVoltage;
        private System.Windows.Forms.Label labInstUsbVoltage;
        private System.Windows.Forms.Label labInstAuxVoltage;
        private System.Windows.Forms.Label labInstMainCurrent;
        private System.Windows.Forms.Label labInstUsbCurrent;
        private System.Windows.Forms.Label labInstAuxCurrent;
        private System.Windows.Forms.Label labInstMainPower;
        private System.Windows.Forms.Label labInstUsbPower;
        private System.Windows.Forms.Label labInstAuxPower;
        private System.Windows.Forms.TextBox txtSampleTime;
        private System.Windows.Forms.TextBox txtVersion;
        private System.Windows.Forms.GroupBox gbDeviceInfo;
        private System.Windows.Forms.TextBox txtProtVer;
        private System.Windows.Forms.TextBox txtHWRev;
        private System.Windows.Forms.GroupBox gbFile;
        private System.Windows.Forms.Button btnExportFile;
        private System.Windows.Forms.Button btnSaveFile;
        private System.Windows.Forms.Button btnLoadFile;
        private System.Windows.Forms.GroupBox gbSampling;
        private System.Windows.Forms.TableLayoutPanel tlpAvgStats;
        private System.Windows.Forms.Label labAvgMainVoltage;
        private System.Windows.Forms.Label labAvgUsbVoltage;
        private System.Windows.Forms.Label labAvgAuxVoltage;
        private System.Windows.Forms.Label labAvgMainCurrent;
        private System.Windows.Forms.Label labAvgUsbCurrent;
        private System.Windows.Forms.Label labAvgAuxCurrent;
        private System.Windows.Forms.Label labAvgMainPower;
        private System.Windows.Forms.Label labAvgUsbPower;
        private System.Windows.Forms.Label labAvgAuxPower;
        private System.Windows.Forms.TextBox txtFWVer;
        private System.Windows.Forms.GroupBox gbUsbPassthrough;
        private System.Windows.Forms.RadioButton rbUsbTrigger;
        private System.Windows.Forms.RadioButton rbUsbAuto;
        private System.Windows.Forms.RadioButton rbUsbOn;
        private System.Windows.Forms.RadioButton rbUsbOff;
        private System.Windows.Forms.RadioButton rbUsbSync;
        private System.Windows.Forms.Label labVolts;
        private System.Windows.Forms.Label labVersion;
        private System.Windows.Forms.Label labFirmwareVersion;
        private System.Windows.Forms.Label labProtocolVersion;
        private System.Windows.Forms.Label labHardwareRevision;
        private System.Windows.Forms.Label labSerialNumber;
        private System.Windows.Forms.Label labSeconds;
        private System.Windows.Forms.Label labAverage;
        private System.Windows.Forms.Label labInstantaneous;
        private System.Windows.Forms.Label labTime;
        private System.Windows.Forms.Label labCount;
        private System.Windows.Forms.GroupBox gbWindowState;
        private System.Windows.Forms.RadioButton rbMaximized;
        private System.Windows.Forms.RadioButton rbNormal;
        private System.Windows.Forms.RadioButton rbMinimized;
        private System.Windows.Forms.CheckBox cbVisible;
        private System.Windows.Forms.Label labAvgMain;
        private System.Windows.Forms.Label labelAvgUsb;
        private System.Windows.Forms.Label labelAvgAux;
        private System.Windows.Forms.Label labInstAux;
        private System.Windows.Forms.Label labAvgUnit;
        private System.Windows.Forms.Label labInstUnit;
        private System.Windows.Forms.Label labelInstVolt;
        private System.Windows.Forms.Label labInstCurrent;
        private System.Windows.Forms.Label labInstPower;
        private System.Windows.Forms.Label labAvgVoltage;
        private System.Windows.Forms.Label labAvgCurrent;
        private System.Windows.Forms.Label labAvgPower;
        private System.Windows.Forms.CheckBox cbLogFile;
    }
}

