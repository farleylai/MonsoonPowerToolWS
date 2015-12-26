// ----------------------------------------------------
// AutoDemo.cs
//
// This sample GUI application demonstrates usage
// of the PowerTool.Automation interface
//
// Copyright (c) 20082009 Monsoon Solutions, Inc.
// All Rights Reserved.
// ----------------------------------------------------
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PowerTool;
using Sort;
using System.Diagnostics;
#if DEBUG
using System.IO;
#endif

namespace AutoDemo
{
    public partial class AutoDemo : Form
    {
        #region Fields
        
        // (OLE/COM) Automation interface object
        private Automation _pt;

        // Index of currently selected device (-1 == none)
        private int _connectedDevice = -1;

        // Internal device list
        private ushort[] _deviceList = new ushort[0];

        // Number of wait periods, where applicable
        private uint _waitTimeout = 30;

        // Flags that control whether event handlers show message boxes
        private volatile bool _sampleStoppageExpected = false;
        private volatile bool _deviceDisconnectionExpected = false;
        private volatile bool _applicationClosureExpected = false;
        #endregion

        #region Constructor
        public AutoDemo()
        {
            InitializeComponent();
        }
        #endregion

        #region Form loading event
        private void AutoDemo_Load(object sender, EventArgs e)
        {
            // Create the interface object
            if ((_pt = new PowerTool.Automation()) != null)
            {
                // Set general API parameters
                _pt.ExceptionsAreEnabled = false;
                _pt.WaitInterval = 1000;

                // Register our event handlers
                _pt.OnSampleStopped += this.OnSampleStopped;
                _pt.OnDeviceDisconnected += this.OnDeviceDisconnected;
                _pt.OnApplicationClosed += this.OnApplicationClosed;
                _pt.OnUnhandledException += this.OnUnhandledException;
#if DEBUG
                // Enable logging
                //_pt.LogFileName = "C:\\PowerTool.Automation.log";
#endif
                // Update the form
                UpdateData();
                UpdateSample();
            }
            else
            {
                MessageBox.Show("Unable to create PowerTool.Automation object!\n\n" +
                    "(Did you use the RegAsm utility to register PowerTool.exe?)",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }
        #endregion

        #region Set the form controls that display the state of the PowerTool window
        delegate void UpdateWindowStateCallback();
        private void UpdateWindowState()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new UpdateWindowStateCallback(UpdateWindowState));
            }
            else
            {
                bool open = _pt != null && _pt.ApplicationIsOpen;

                gbWindowState.Enabled = open;

                cbVisible.Checked = open ? _pt.Visible : false;
                rbMinimized.Checked = open ? _pt.WindowState == PowerTool.WindowState.Minimized : false;
                rbNormal.Checked = open ? _pt.WindowState == PowerTool.WindowState.Normal : false;
                rbMaximized.Checked = open ? _pt.WindowState == PowerTool.WindowState.Maximized : false;
                cbLogFile.Checked = _pt.LogFileName != null && _pt.LogFileName != "";
            }
        }
        #endregion

        #region Enable or disable controls based on what's currently happening
        delegate void EnableControlsCallback();
        private void EnableControls()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new EnableControlsCallback(EnableControls));
            }
            else
            {
                bool ok = _pt != null;
                bool open = ok && _pt.ApplicationIsOpen;
                bool connected = open && _pt.DeviceIsConnected;
                bool sampling = connected && _pt.SampleIsRunning;
                bool hasData = open && _pt.HasData;

                gbDevices.Enabled = ok;
                gbDevice.Enabled = open && connected;
                gbSampleStats.Enabled = open && connected && sampling;
                gbVout.Enabled = open && connected && !sampling;
                gbVoltChannel.Enabled = open && connected && !sampling;
                gbCurrent.Enabled = open && connected && !sampling;
                gbWindowState.Enabled = open;

                btnConnectDevice.Enabled = open && lbDeviceList.SelectedIndex >= 0;
                btnDeviceRefresh.Enabled = /*open &&*/ !connected && !sampling;
                btnRunSample.Enabled = connected;
                btnLoadFile.Enabled = open && !sampling;
                btnSaveFile.Enabled = open && !sampling && hasData;
                btnExportFile.Enabled = open && !sampling && hasData;
                lbDeviceList.Enabled = btnDeviceRefresh.Enabled;
                rbVoltMain.Enabled = cbMainCurrent.Checked;
                rbVoltAux.Enabled = cbAuxCurrent.Checked;

                btnOpenPowerTool.Text = open ? "Close" : "Open";
                btnConnectDevice.Text = connected ? "Disconnect" : "Connect";
                btnRunSample.Text = sampling ? "Stop" : "Run";

                cbLogFile.Enabled = true;

                Refresh();
            }
        }
        #endregion

        #region Refresh the form with up-to-date data
        delegate void UpdateDataCallback();
        private void UpdateData()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new UpdateDataCallback(UpdateData));
            }
            else
            {
                EnableControls();

                bool ok = _pt != null;
                bool open = ok && _pt.ApplicationIsOpen;
                bool connected = open && _pt.DeviceIsConnected;
                bool sampling = connected && _pt.SampleIsRunning;
                bool hasData = open && _pt.HasData;

                tbTimeout.Value = (int)_waitTimeout;
                txtTimeout.Text = _waitTimeout.ToString();

                txtVersion.Text = open ? _pt.SoftwareVersion.ToString() : "";

                UpdateWindowState();

                cbVoutEnable.Checked = connected ? _pt.EnableMainOutputVoltage : false;
                txtVoutSetting.Text = connected ? _pt.MainOutputVoltageSetting.ToString("f2") : "";

                rbVoltMain.Checked = connected ? (_pt.VoltageChannel == PowerTool.Channel.Main) : false;
                rbVoltAux.Checked = connected ? (!rbVoltMain.Checked) : false;

                cbMainCurrent.Checked = connected ? _pt.CaptureMainCurrent : false;
                cbUsbCurrent.Checked = connected ? _pt.CaptureUsbCurrent : false;
                cbAuxCurrent.Checked = connected ? _pt.CaptureAuxCurrent : false;

                txtSerialNumber.Text = connected ? _pt.DeviceSerialNumber.ToString() : "";
                txtFWVer.Text = connected ? _pt.FirmwareVersion.ToString() : "";
                txtHWRev.Text = connected ? _pt.HardwareRevision.ToString() : "";
                txtProtVer.Text = connected ? _pt.ProtocolVersion.ToString() : "";

                txtVoutSetting.Text = connected ? _pt.MainOutputVoltageSetting.ToString("f2") : "";
                tbVoutSetting.Value = connected ? (int)(100 * (_pt.MainOutputVoltageSetting - 2.0f)) : 1;

                gbUsbPassthrough.Enabled = open && connected && !sampling;
                UsbPassthroughMode usbMode = _pt.UsbPassthroughMode;
                rbUsbOn.Checked = usbMode == UsbPassthroughMode.On;
                rbUsbOff.Checked = usbMode == UsbPassthroughMode.Off;
                rbUsbAuto.Checked = usbMode == UsbPassthroughMode.Auto;
                rbUsbTrigger.Checked = usbMode == UsbPassthroughMode.Trigger;
                rbUsbSync.Checked = usbMode == UsbPassthroughMode.Sync;

                Refresh();
            }
        }
        #endregion

        #region Obtain and display sampling statistics from the PowerTool application
        delegate void UpdateSampleCallback();
        private void UpdateSample()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new UpdateSampleCallback(UpdateSample));
            }
            else
            {
                PowerTool.SelectionData data = _pt.SelectionData;

                txtSampleCount.Text = data.sampleCount.ToString();
                txtSampleTime.Text = data.sampleTime.ToString("f2");

                tlpInstStats.SuspendLayout();

                labInstMainVoltage.Text = data.instMainVoltage.ToString("f2");
                labInstMainCurrent.Text = data.instMainCurrent.ToString("f2");
                labInstMainPower.Text = data.instMainPower.ToString("f2");

                labInstUsbVoltage.Text = data.instUsbVoltage.ToString("f2");
                labInstUsbCurrent.Text = data.instUsbCurrent.ToString("f2");
                labInstUsbPower.Text = data.instUsbPower.ToString("f2");

                labInstAuxVoltage.Text = data.instAuxVoltage.ToString("f2");
                labInstAuxCurrent.Text = data.instAuxCurrent.ToString("f2");
                labInstAuxPower.Text = data.instAuxPower.ToString("f2");

                tlpInstStats.ResumeLayout(true);

                tlpAvgStats.SuspendLayout();

                labAvgMainVoltage.Text = (data.sumMainVoltage / Math.Max(1, data.sampleCount - data.missingCount)).ToString("f2");
                labAvgMainCurrent.Text = (data.sumMainCurrent / Math.Max(1, data.sampleCount - data.missingCount)).ToString("f2");
                labAvgMainPower.Text = (data.sumMainPower / Math.Max(1, data.sampleCount - data.missingCount)).ToString("f2");

                labAvgUsbVoltage.Text = (data.sumUsbVoltage / Math.Max(1, data.sampleCount - data.missingCount)).ToString("f2");
                labAvgUsbCurrent.Text = (data.sumUsbCurrent / Math.Max(1, data.sampleCount - data.missingCount)).ToString("f2");
                labAvgUsbPower.Text = (data.sumUsbPower / Math.Max(1, data.sampleCount - data.missingCount)).ToString("f2");

                labAvgAuxVoltage.Text = (data.sumAuxVoltage / Math.Max(1, data.sampleCount - data.missingCount)).ToString("f2");
                labAvgAuxCurrent.Text = (data.sumAuxCurrent / Math.Max(1, data.sampleCount - data.missingCount)).ToString("f2");
                labAvgAuxPower.Text = (data.sumAuxPower / Math.Max(1, data.sampleCount - data.missingCount)).ToString("f2");

                tlpAvgStats.ResumeLayout();

                Refresh();
            }
        }
        #endregion

        #region Refresh the device list
        private uint EnumerateDevices()
        {
            uint count = _pt.EnumerateDevices(out _deviceList);

            if (count > 1)
                Sort.Sort.IntroSort(CompareDevices, SwapDevices, (int)count);

            return count;
        }

        // Swap two device list entries... used in the sort
        private void SwapDevices(int i, int j)
        {
            Utils.Utils.Swap<ushort>(ref _deviceList[i], ref _deviceList[j]);
        }

        // Compare two device list entries... used in the sort
        private int CompareDevices(int i, int j)
        {
            int result = _deviceList[i] - _deviceList[j];

            // Shouldn't be any ties, but just in case,
            // use the original list position as a tiebreaker
            if (result == 0)
                result = i - j;

            return result;
        }
        #endregion

        #region Handle the Open/Close button click
        private void btnOpenPowerTool_Click(object sender, EventArgs e)
        {
            // remember the existing cursor, replace with hour glass
            Cursor oldCursor = this.Cursor;
            this.Cursor = Cursors.WaitCursor;

            if (_pt.ApplicationIsOpen)
            {
                // Application is running, so stop and close it
                if (_pt.SampleIsRunning)
                    _sampleStoppageExpected = true;

                if (_pt.DeviceIsConnected)
                    _deviceDisconnectionExpected = true;

                _applicationClosureExpected = true;

                if (_pt.CloseApplication(cbIniFile.Checked, _waitTimeout))
                {
                    lbDeviceList.ClearSelected();
                    lbDeviceList.Items.Clear();
                }
                else
                {
                    MessageBox.Show("Failed to close application", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                // Application is not running, so start it up
                _applicationClosureExpected = false;

                if (_pt.OpenApplication(cbIniFile.Checked, _waitTimeout))
                {
                    btnDeviceRefresh_Click(null, null);

                    UpdateData();
                }
                else
                {
                    MessageBox.Show("Failed to open application", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            UpdateData();

            // restore old cursor
            this.Cursor = oldCursor;
        }
        #endregion

        #region Device list handlers
        private void btnDeviceRefresh_Click(object sender, EventArgs e)
        {
            // remember the existing cursor, replace with hour glass
            Cursor oldCursor = this.Cursor;
            this.Cursor = Cursors.WaitCursor;

            // clear the old list and selection
            lbDeviceList.Items.Clear();
            lbDeviceList.SelectedIndex = -1;

            // enumerate the available devices
            uint count = EnumerateDevices();
            if (count > 0)
            {
                // populate list box
                for (int i = 0; i < count; i++)
                    lbDeviceList.Items.Add(_deviceList[i].ToString());

                // pre-select the first one
                lbDeviceList.SelectedIndex = 0;
            }

            // restore old cursor
            this.Cursor = oldCursor;

            UpdateData();
        }

        private void lbDeviceList_MouseClick(object sender, MouseEventArgs e)
        {
            EnableControls();
        }
        #endregion

        #region Bring the PowerTool application completely down
        private void ClosePowerTool()
        {
            if (_pt.SampleIsRunning)
            {
                _sampleStoppageExpected = true;
                _pt.StopSampling(_waitTimeout);
            }

            if (_pt.DeviceIsConnected)
            {
                _deviceDisconnectionExpected = true;
                _pt.DisconnectDevice();
            }

            if (_pt.ApplicationIsOpen)
            {
                _applicationClosureExpected = true;
                _pt.CloseApplication(cbIniFile.Checked, _waitTimeout);
            }

            UpdateData();

            _pt = null;
        }
        #endregion

        #region Form closing event
        private void AutoDemo_FormClosing(object sender, FormClosingEventArgs e)
        {
            _applicationClosureExpected = true;

            ClosePowerTool();
        }
        #endregion

        #region Device select/connect/disconnect
        private void ConnectDevice(int devIndex)
        {
            if (_pt.DeviceIsConnected)
            {
                // Device is connected, so disconnect
                _deviceDisconnectionExpected = true;

                if (_pt.SampleIsRunning)
                    _sampleStoppageExpected = true;

                if (_pt.DisconnectDevice())
                {
                    _connectedDevice = -1;

                    _pt.RefreshDisplay();

                    _deviceDisconnectionExpected = false;
                }
                else
                {
                    MessageBox.Show("Failed to disconnect from device", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (devIndex >= 0 && devIndex < _deviceList.Length)
            {
                // Device not connected, so connect
                _deviceDisconnectionExpected = false;

                if (_pt.ConnectDevice(_deviceList[devIndex]))
                {
                    _connectedDevice = devIndex;

                    _pt.RefreshDisplay();
                }
                else
                {
                    MessageBox.Show("Failed to Connect to device", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            UpdateData();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            ConnectDevice(lbDeviceList.SelectedIndex);
        }

        private void lbDeviceList_DoubleClick(object sender, EventArgs e)
        {
            btnConnect_Click(sender, e);
        }
        #endregion

        #region Start or stop Sampling mode
        private void btnRunSample_Click(object sender, EventArgs e)
        {
            // Remember the existing cursor, replace with hour glass
            Cursor oldCursor = this.Cursor;
            this.Cursor = Cursors.WaitCursor;

#if DISABLED
            while (true)
            {
                _pt.EnableMainOutputVoltage = !_pt.EnableMainOutputVoltage;

                byte newMode = (byte)_pt.UsbPassthroughMode;
                ++newMode;
                if (newMode > (byte)UsbPassthroughMode.Sync)
                    newMode = (byte)UsbPassthroughMode.Off;
                _pt.UsbPassthroughMode = (UsbPassthroughMode)newMode;

                this.UpdateData();
                this.Invalidate();
                _pt.RefreshDisplay();
            }
#endif

            if (_pt.SampleIsRunning)
            {
                // Sample is running, so stop it
                _sampleStoppageExpected = true;

                if (!_pt.StopSampling(_waitTimeout))
                {
                    MessageBox.Show("Failed to stop sampling", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                // Sample not running, so start it
                _sampleStoppageExpected = false;

                if (!_pt.StartSampling(_waitTimeout))
                {
                    MessageBox.Show("Failed to start sampling", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            // restore the old cursor
            this.Cursor = oldCursor;

            UpdateData();
            UpdateSample();
        }
        #endregion

        #region Periodic form refresh
        private void tmrRefresh_Tick(object sender, EventArgs e)
        {
            EnableControls();
            UpdateWindowState();

            if (_pt.SampleIsRunning)
                UpdateSample();
        }
        #endregion

        #region Enable/disable Main Output Voltage
        private void cbVoutEnable_Click(object sender, EventArgs e)
        {
            _pt.EnableMainOutputVoltage = cbVoutEnable.Checked;

            //Debug.Assert(_pt.EnableMainOutputVoltage == cbVoutEnable.Checked);
            
            UpdateData();
        
            Debug.Assert(_pt.EnableMainOutputVoltage == cbVoutEnable.Checked);
        }
        #endregion

        #region Control PowerTool application window state
        private void cbVisible_Click(object sender, EventArgs e)
        {
            if (_pt.ApplicationIsOpen)
            {
                _pt.Visible = cbVisible.Checked;
            }

            UpdateWindowState();
        }

        private void rbMinimized_Click(object sender, EventArgs e)
        {
            if (_pt.ApplicationIsOpen)
            {
                _pt.WindowState = PowerTool.WindowState.Minimized;
            }

            UpdateWindowState();
        }

        private void rbNormal_Click(object sender, EventArgs e)
        {
            if (_pt.ApplicationIsOpen)
            {
                _pt.WindowState = PowerTool.WindowState.Normal;
            }

            UpdateWindowState();
        }

        private void rbMaximized_Click(object sender, EventArgs e)
        {
            if (_pt.ApplicationIsOpen)
            {
                _pt.WindowState = PowerTool.WindowState.Maximized;
            }

            UpdateWindowState();
        }

        private void cbLogFile_CheckedChanged(object sender, EventArgs e)
        {
            _pt.LogFileName = cbLogFile.Checked ? "C:\\PowerTool.Automation.log" : "";

            UpdateWindowState();
        }

        #endregion

        #region Voltage channel selection
        private void rbVoltMain_Click(object sender, EventArgs e)
        {
            if (_pt.ApplicationIsOpen && _pt.DeviceIsConnected && !_pt.SampleIsRunning)
            {
                _pt.VoltageChannel = PowerTool.Channel.Main;
                UpdateData();
            }
        }

        private void rbVoltAux_Click(object sender, EventArgs e)
        {
            if (_pt.ApplicationIsOpen && _pt.DeviceIsConnected && !_pt.SampleIsRunning)
            {
                _pt.VoltageChannel = PowerTool.Channel.Aux;
                UpdateData();
            }
        }
        #endregion

        #region Change API timeout
        private void tbTimeout_Scroll(object sender, EventArgs e)
        {
            _waitTimeout = (uint)tbTimeout.Value;

            txtTimeout.Text = _waitTimeout.ToString();
        }
        #endregion

        #region Set Main voltage output setting
        private void tbVoutSetting_Scroll(object sender, EventArgs e)
        {
            _pt.MainOutputVoltageSetting = 2.0f + tbVoutSetting.Value * 0.01f;

            txtVoutSetting.Text = _pt.MainOutputVoltageSetting.ToString("f2");
        }
        #endregion

        #region Main/USB/Aux current selection
        private void cbMainCurrent_Click(object sender, EventArgs e)
        {
            if (!cbMainCurrent.Checked && !cbUsbCurrent.Checked && !cbAuxCurrent.Checked)
            {
                MessageBox.Show("At least one data channel must be enabled",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbMainCurrent.Checked = true;
            }
            else
            {
                _pt.CaptureMainCurrent = cbMainCurrent.Checked;

                if (!cbMainCurrent.Checked && rbVoltMain.Checked && cbAuxCurrent.Checked)
                {
                    _pt.VoltageChannel = PowerTool.Channel.Aux;

                    rbVoltMain.Checked = false;
                    rbVoltAux.Checked = true;
                }

                EnableControls();
            }
        }

        private void cbUsbCurrent_Click(object sender, EventArgs e)
        {
            if (!cbMainCurrent.Checked && !cbUsbCurrent.Checked && !cbAuxCurrent.Checked)
            {
                MessageBox.Show("At least one data channel must be enabled",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbUsbCurrent.Checked = true;
            }
            else
            {
                _pt.CaptureUsbCurrent = cbUsbCurrent.Checked;

                EnableControls();
            }
        }

        private void cbAuxCurrent_Click(object sender, EventArgs e)
        {
            if (!cbMainCurrent.Checked && !cbUsbCurrent.Checked && !cbAuxCurrent.Checked)
            {
                MessageBox.Show("At least one data channel must be enabled",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbAuxCurrent.Checked = true;
            }
            else
            {
                _pt.CaptureAuxCurrent = cbAuxCurrent.Checked;

                if (!cbAuxCurrent.Checked && rbVoltAux.Checked && cbMainCurrent.Checked)
                {
                    _pt.VoltageChannel = PowerTool.Channel.Main;

                    rbVoltMain.Checked = true;
                    rbVoltAux.Checked = false;
                }

                EnableControls();
            }
        }
        #endregion

        #region Load/Save PT4 file
        private void btnLoadFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog d = new OpenFileDialog();
            d.InitialDirectory = ".";
            d.Filter = "PowerTool 4.0 data file (PT4)|*.pt4";

            if (d.ShowDialog() == DialogResult.OK)
            {
                if (!_pt.LoadFile(d.FileName))
                {
                    MessageBox.Show("Unable to load data file", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnSaveFile_Click(object sender, EventArgs e)
        {
            SaveFileDialog d = new SaveFileDialog();
            d.InitialDirectory = ".";
            d.Filter = "PowerTool 4.0 data file (PT4)|*.pt4";

            if (d.ShowDialog() == DialogResult.OK && !string.IsNullOrEmpty(d.FileName))
            {
                if (d.FileName != "" && !_pt.SaveFile(d.FileName, true, true))
                {
                    MessageBox.Show("Unable to save data file", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        #endregion

        #region Export to CSV file
        private void btnExportFile_Click(object sender, EventArgs e)
        {
            Cursor oldCursor = this.Cursor;
            this.Cursor = Cursors.WaitCursor;

            // Choose a file to export our PT4 data to
            SaveFileDialog d = new SaveFileDialog();
            d.InitialDirectory = ".";
            d.Filter = "Comma-separated variable (CSV) file|*.csv";

            DialogResult ret = d.ShowDialog();

            if (ret == DialogResult.OK && !string.IsNullOrEmpty(d.FileName))
            {
                string fileName = d.FileName;
                string ext = fileName.Substring(fileName.Length-4, 4).ToLower();
                
                if (ext == ".csv")
                {
                    // Export CSV file
                    if (!_pt.ExportCSV(0, _pt.TotalSampleCount - 1, 1, fileName, true, true))
                    {
                        MessageBox.Show("Unable to export data file", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show("File exported", "Success",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    // Unknown file type
                    MessageBox.Show("Unknown file type \"" + ext + "\"", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                this.Cursor = oldCursor;
            }
        }
        #endregion

        #region Event handlers (connection loss, app closed, etc.)
        delegate void OnSampleStoppedCallback();
        private void OnSampleStopped()
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new OnSampleStoppedCallback(OnSampleStopped));
            }
            else
            {
                if (!_sampleStoppageExpected)
                {
                    MessageBox.Show("Sampling has stopped unexpectedly", "Information",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                _sampleStoppageExpected = false;

                EnableControls();
            }
        }

        delegate void OnDeviceDisconnectedCallback();
        private void OnDeviceDisconnected()
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new OnDeviceDisconnectedCallback(OnDeviceDisconnected));
            }
            else
            {
                if (!_deviceDisconnectionExpected)
                {
                    MessageBox.Show("Device has disconnected unexpectedly", "Information",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                _deviceDisconnectionExpected = false;

                EnableControls();
            }
        }

        delegate void OnUnhandledExceptionCallback(Exception e);
        private void OnUnhandledException(Exception e)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new OnUnhandledExceptionCallback(OnUnhandledException), new object[] { e });
            }
            else
            {
                UpdateData();
            }
        }

        delegate void OnApplicationClosedCallback(ExitCode exitCode);
        private void OnApplicationClosed(ExitCode exitCode)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new OnApplicationClosedCallback(OnApplicationClosed), new object[] { exitCode });
            }
            else
            {
                if (!_applicationClosureExpected)
                {
                    MessageBox.Show("Application has closed unexpectedly", "Information",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                _applicationClosureExpected = false;

                EnableControls();
            }
        }
        #endregion

        #region Handlers for USB Passthrough Mode clicks
        private void rbUsbOff_Click(object sender, EventArgs e)
        {
            _pt.UsbPassthroughMode = UsbPassthroughMode.Off;
        }

        private void rbUsbOn_Click(object sender, EventArgs e)
        {
            _pt.UsbPassthroughMode = UsbPassthroughMode.On;
        }

        private void rbUsbAuto_Click(object sender, EventArgs e)
        {
            _pt.UsbPassthroughMode = UsbPassthroughMode.Auto;
        }

        private void rbUsbTrigger_Click(object sender, EventArgs e)
        {
            _pt.UsbPassthroughMode = UsbPassthroughMode.Trigger;
        }

        private void rbUsbSync_Click(object sender, EventArgs e)
        {
            _pt.UsbPassthroughMode = UsbPassthroughMode.Sync;
        }
        #endregion
    }
}