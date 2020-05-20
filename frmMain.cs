using NAudio.CoreAudioApi;
using NAudio.CoreAudioApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Management;
using System.Windows.Forms;

namespace WinMikes
{
    public partial class FrmMain : Form, IMMNotificationClient
    {
        public FrmMain()
        {
            InitializeComponent();

            //For USB devices and so on
            HardwareNotification.RegisterUsbDeviceNotification(this.Handle);

            //For MM EndPoints (not only USB)
            var enumerator = new NAudio.CoreAudioApi.MMDeviceEnumerator();
            enumerator.RegisterEndpointNotificationCallback(this);

            //Initial fill lists
            updateMMList();
            updateUSBList();

        }

        private void btnListMM_Click(object sender, EventArgs e)
        {
            updateMMList();
        } 

        private void btnUSBRefresh_Click(object sender, EventArgs e)
        {
            updateUSBList();
        }

        public void updateMMList()
        {
            var audioDevices = GetMMDevices();
            lvDevices.Items.Clear();
            foreach (var device in audioDevices)
            {
                var lvi = new ListViewItem();
                lvi.Text = device.FriendlyName;
                lvi.SubItems.Add("-");
                lvi.SubItems.Add(device.State.ToString());
                lvi.SubItems.Add(device.ID);
                lvDevices.Items.Add(lvi);
            }
        }

        private void updateUSBList()
        {
        }

        static List<MMDevice> GetMMDevices()
        {
            List<MMDevice> res = new List<MMDevice>();
            MMDeviceEnumerator names = new MMDeviceEnumerator();
            var devices = names.EnumerateAudioEndPoints(DataFlow.Capture, DeviceState.Active);
            foreach (var device in devices) {
                res.Add(device);
            }
            return res;
        }

        static List<String> GetUSBSoundDevices()
        {
            List<String> devices = new List<String>();

            ManagementObjectCollection collection;
            using (var searcher = new ManagementObjectSearcher(@"Select * From Win32_SoundDevice"))
                collection = searcher.Get();

            foreach (var device in collection)
            {
                devices.Add((string)device.GetPropertyValue("ProductName"));
            }

            collection.Dispose();
            return devices;
        }
    
        static List<USBDeviceInfo> GetUSBDevices()
        {
            List<USBDeviceInfo> devices = new List<USBDeviceInfo>();

            ManagementObjectCollection collection;
            using (var searcher = new ManagementObjectSearcher(@"Select * From Win32_USBHub"))
                collection = searcher.Get();

            foreach (var device in collection)
            {
                devices.Add(new USBDeviceInfo(
                (string)device.GetPropertyValue("DeviceID"),
                (string)device.GetPropertyValue("PNPDeviceID"),
                (string)device.GetPropertyValue("Description")
                ));
            }

            collection.Dispose();
            return devices;
        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            if (m.Msg == HardwareNotification.WmDevicechange)
            {
                switch ((int)m.WParam)
                {
                    case HardwareNotification.DbtDeviceremovecomplete:
                        ReactToUSBChange("USB Device Removed");
                        break;
                    case HardwareNotification.DbtDevicearrival:
                        ReactToUSBChange("USB Device Added");
                        break;
                }
            }
        }

        public void ReactToUSBChange(string msg)
        {
            if (this.InvokeRequired)
            {
                this.Invoke((MethodInvoker)delegate { ReactToUSBChange(msg); });
                return;
            }
            // Log event
            lbEvents.Items.Add(msg);
            // Update Devices List
            updateUSBList();
        }

        public void ReactToHardwareChange(string msg) 
        {
            if (this.InvokeRequired) 
            {
                this.Invoke((MethodInvoker)delegate { ReactToHardwareChange(msg); });
                return;
            }
            // Log event
            lbEvents.Items.Add(msg);
            // Update Devices List
            updateMMList();
        }

        void IMMNotificationClient.OnDeviceStateChanged(string deviceId, DeviceState newState)
        {
            ReactToHardwareChange(String.Format("OnDeviceStateChanged --> Device Id: {0} ; Device State: {1}", deviceId, newState));
        }
        void IMMNotificationClient.OnDeviceAdded(string pwstrDeviceId) {
            ReactToHardwareChange(String.Format("OnDeviceAdded --> Device Id: {0}", pwstrDeviceId));
        }
        void IMMNotificationClient.OnDeviceRemoved(string deviceId) {
            ReactToHardwareChange(String.Format("OnDeviceRemoved --> Device Id: {0}", deviceId));
        }
        void IMMNotificationClient.OnDefaultDeviceChanged(DataFlow flow, Role role, string defaultDeviceId) {
            ReactToHardwareChange(String.Format("OnDefaultDeviceChanged --> Default Device Id: {0}", defaultDeviceId));
        }
        void IMMNotificationClient.OnPropertyValueChanged(string pwstrDeviceId, PropertyKey key) {
            // way too verbose -- ReactToHardwareChange(String.Format("OnPropertyValueChanged --> Device Id: {0} ; Property: {1}", pwstrDeviceId, key));
        }

        private void btClearEvents_Click(object sender, EventArgs e)
        {
            lbEvents.Items.Clear();
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("control.exe", "mmsys.cpl sounds");
        }
    }

    class USBDeviceInfo
    {
        public USBDeviceInfo(string deviceID, string pnpDeviceID, string description)
        {
            this.DeviceID = deviceID;
            this.PnpDeviceID = pnpDeviceID;
            this.Description = description;
        }
        public string DeviceID { get; private set; }
        public string PnpDeviceID { get; private set; }
        public string Description { get; private set; }
    }

}
