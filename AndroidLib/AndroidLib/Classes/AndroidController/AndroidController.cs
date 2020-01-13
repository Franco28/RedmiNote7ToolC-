/*
 * AndroidController.cs - Handles communication between computer and Android devices
 * Developed by Dan Wager for AndroidLib.dll - 04/12/12
 */

using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace RegawMOD.Android
{

    public sealed class AndroidController
    {
        private const string ANDROID_CONTROLLER_FOLDER = "adb\\";
        private static readonly Dictionary<string, string> RESOURCES = new Dictionary<string, string>
        {
            {"adb.exe",""},
            {"AdbWinApi.dll", ""},
            {"AdbWinUsbApi.dll", ""},
            {"libwinpthread-1.dll", ""},
            {"fastboot_edl.exe", ""},
            {"fastboot.exe", ""},
        };

        private static AndroidController instance;

        private string resourceDirectory;
        private List<string> connectedDevices;
        private bool Extract_Resources = false;

        public static AndroidController Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new AndroidController();
                    instance.CreateResourceDirectories();
                    instance.ExtractResources();
                    Adb.StartServer();
                }

                return instance;
            }
        }

        public List<string> ConnectedDevices
        {
            get
            {
                this.UpdateDeviceList();
                return this.connectedDevices;
            }
        }

        internal string ResourceDirectory
        {
            get { return this.resourceDirectory; }
        }

        private AndroidController()
        {
            this.connectedDevices = new List<string>();
            ResourceFolderManager.Register(ANDROID_CONTROLLER_FOLDER);
            this.resourceDirectory = ResourceFolderManager.GetRegisteredFolderPath(ANDROID_CONTROLLER_FOLDER);
        }

        private void CreateResourceDirectories()
        {
            try
            {
                if (!Adb.ExecuteAdbCommand(new AdbCommand("version")).Contains(Adb.ADB_VERSION))
                {
                    Adb.KillServer();
                    Thread.Sleep(1000);
                    ResourceFolderManager.Unregister(ANDROID_CONTROLLER_FOLDER);
                    Extract_Resources = true;
                }
            }
            catch (Exception)
            {
                Extract_Resources = true;
            }
            ResourceFolderManager.Register(ANDROID_CONTROLLER_FOLDER);
        }

        private void ExtractResources()
        {
            if (this.Extract_Resources)
            {
                string[] res = new string[RESOURCES.Count];
                RESOURCES.Keys.CopyTo(res, 0);
                Extract.Resources(this, this.resourceDirectory, "Resources.AndroidController", res);
            }
        }

        public void Dispose()
        {
            Adb.KillServer();
            Thread.Sleep(1000);
            AndroidController.instance = null;
        }

        public Device GetConnectedDevice()
        {
            if (this.HasConnectedDevices)
                return new Device(this.connectedDevices[0]);

            return null;
        }

        public Device GetConnectedDevice(string deviceSerial)
        {
            this.UpdateDeviceList();

            if (this.connectedDevices.Contains(deviceSerial))
                return new Device(deviceSerial);

            return null;
        }


        public bool HasConnectedDevices
        {
            get { this.UpdateDeviceList(); return (this.connectedDevices.Count > 0) ? true : false; }
        }

        public bool IsDeviceConnected(string deviceSerial)
        {
            this.UpdateDeviceList();

            foreach (string s in this.connectedDevices)
                if (s.ToLower() == deviceSerial.ToLower())
                        return true;

            return false;
        }

        public bool IsDeviceConnected(Device device)
        {
            this.UpdateDeviceList();

            foreach (string d in this.connectedDevices)
                if (d == device.SerialNumber)
                        return true;

            return false;
        }

        public void UpdateDeviceList()
        {
            string deviceList = "";

            this.connectedDevices.Clear();

            deviceList = Adb.Devices();
            if (deviceList.Length > 29)
            {
                using (StringReader s = new StringReader(deviceList))
                {
                    string line;

                    while (s.Peek() != -1)
                    {
                        line = s.ReadLine();

                        if (line.StartsWith("List") || line.StartsWith("\r\n") || line.Trim() == "")
                            continue;

                        if (line.IndexOf('\t') != -1)
                        {
                            line = line.Substring(0, line.IndexOf('\t'));
                            this.connectedDevices.Add(line);
                        }
                    }
                }
            }

            deviceList = Fastboot.Devices();
            if (deviceList.Length > 0)
            {
                using (StringReader s = new StringReader(deviceList))
                {
                    string line;

                    while (s.Peek() != -1)
                    {
                        line = s.ReadLine();

                        if (line.StartsWith("List") || line.StartsWith("\r\n") || line.Trim() == "")
                            continue;

                        if (line.IndexOf('\t') != -1)
                        {
                            line = line.Substring(0, line.IndexOf('\t'));
                            this.connectedDevices.Add(line);
                        }
                    }
                }
            }
        }

        private bool _CancelRequest;

        public bool CancelWait
        {
            get { return _CancelRequest; }
            set { _CancelRequest = value; }
        }

        public void WaitForDevice()
        {
            /* Entering an endless loop will exhaust CPU. 
             * Since this method must be called in a child thread in Windows Presentation Foundation (WPF) or Windows Form Apps,
             * sleeping thread for 250 miliSecond (1/4 of a second)
             * will be more friendly to the CPU. Nonetheless checking 4 times for a connected device in each second is more than enough,
             * and will not result in late response from the app if a device gets connected. 
             */
            while (!this.HasConnectedDevices && !this.CancelWait)
            {
                Thread.Sleep(250);
            }
            this.CancelWait = false;
        }
    }

}

