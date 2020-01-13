/*
 * Device.cs - Developed by Dan Wager for AndroidLib.dll
 */

using System.IO;

namespace RegawMOD.Android
{

    public partial class Device
    {
        private BatteryInfo battery;
        private BuildProp buildProp;
        private string serialNumber;
        private DeviceState state;

        internal Device(string deviceSerial)
        {
            this.serialNumber = deviceSerial;
            Update();
        }

        private DeviceState SetState()
        {
            string state = null;

            using (StringReader r = new StringReader(Adb.Devices()))
            {
                string line;

                while (r.Peek() != -1)
                {
                    line = r.ReadLine();

                    if (line.Contains(this.serialNumber))
                        state = line.Substring(line.IndexOf('\t') + 1);
                }
            }

            if (state == null)
            {
                using (StringReader r = new StringReader(Fastboot.Devices()))
                {
                    string line;

                    while (r.Peek() != -1)
                    {
                        line = r.ReadLine();

                        if (line.Contains(this.serialNumber))
                            state = line.Substring(line.IndexOf('\t') + 1);
                    }
                }
            }

            switch (state)
            {
                case "device":
                    return DeviceState.ONLINE;
                case "recovery":
                    return DeviceState.RECOVERY;
                case "fastboot":
                    return DeviceState.FASTBOOT;
                case "sideload":
                    return DeviceState.SIDELOAD;
                case "unauthorized":
                    return DeviceState.UNAUTHORIZED;
                default:
                    return DeviceState.UNKNOWN;
            }
        }

        public BatteryInfo Battery { get { return this.battery; } }
        public BuildProp BuildProp { get { return this.buildProp; } }
        public string SerialNumber { get { return this.serialNumber; } }
        public DeviceState State { get { return this.state; } internal set { this.state = value; } }

        public void Update()
        {
            this.state = SetState();
            this.battery = new BatteryInfo(this);
            this.buildProp = new BuildProp(this);
        }
    }
}