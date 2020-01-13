/*
 * Battery.cs - Developed by Dan Wager for AndroidLib.dll
 */

using System.IO;

namespace RegawMOD.Android
{

    public class BatteryInfo
    {
        private Device device;
        private string dump;

        private bool acPower;
        private bool usbPower;
        private bool wirelessPower;
        private int status;
        private int health;
        private bool present;
        private int level;
        private int scale;
        private int voltage;
        private double temperature;
        private string technology;
        private string outString;

        public bool ACPower
        {
            get { Update(); return this.acPower; }
        }

        public bool USBPower
        {
            get { Update(); return usbPower; }
        }

        public bool WirelessPower
        {
            get { Update(); return wirelessPower; }
        }

        public string Status
        {
            /* As defined in: http://developer.android.com/reference/android/os/BatteryManager.html
             * Property "Status" is changed from type "int" to type "string" to give a string representation
             * of the value obtained from dumpsys regarding battery status.
             * Submitted By: Omar Bizreh [DeepUnknown from Xda-Developers.com]
             */
            get
            {
                Update();
                switch (status)
                {
                    case 1:
                        return "Unknown Battery Status: " + status;
                    case 2:
                        return "Charging";
                    case 3:
                        return "Discharging";
                    case 4:
                        return "Not charging";
                    case 5:
                        return "Full";
                    default:
                        return "Unknown Value: " + status;
                }
            }
        }

        public string Health
        {

            /* As defined in: http://developer.android.com/reference/android/os/BatteryManager.html
             * Property "Health" is changed from type "int" to type "string" to give a string representation
             * of the value obtained from dumpsys regarding battery health.
             * Submitted By: Omar Bizreh [DeepUnknown from Xda-Developers.com]
             */
            get
            {
                Update();
                switch (health)
                {
                    case 1:
                        return "Unknown Health State: " + health;
                    case 2:
                        return "Good";
                    case 3:
                        return "Over Heat";
                    case 4:
                        return "Dead";
                    case 5:
                        return "Over Voltage";
                    case 6:
                        return "Unknown Failure";
                    case 7:
                        return "Cold Battery";
                    default:
                        return "Unknown Value: " + health;
                }

            }
        }

        public bool Present
        {
            get { Update(); return present; }
        }

        public int Level
        {
            get { Update(); return level; }
        }

        public int Scale
        {
            get { Update(); return scale; }
        }


        public int Voltage
        {
            get { Update(); return voltage; }
        }

        public double Temperature
        {
            get { Update(); return temperature; }
        }

        public string Technology
        {
            get { Update(); return technology; }
        }

        internal BatteryInfo(Device device)
        {
            this.device = device;
            Update();
        }

        private void Update()
        {
            if (this.device.State != DeviceState.ONLINE)
            {
                this.acPower = false;
                this.dump = null;
                this.health = -1;
                this.level = -1;
                this.present = false;
                this.scale = -1;
                this.status = -1;
                this.technology = null;
                this.temperature = -1;
                this.usbPower = false;
                this.voltage = -1;
                this.wirelessPower = false;
                this.outString = "Device Not Online";
                return;
            }

            AdbCommand adbCmd = Adb.FormAdbShellCommand(this.device, "dumpsys", "battery");
            this.dump = Adb.ExecuteAdbCommand(adbCmd);

            using (StringReader r = new StringReader(this.dump))
            {
                string line;

                while (true)
                {
                    line = r.ReadLine();

                    if (!line.Contains("Current Battery Service state"))
                    {
                        continue;
                    }
                    else
                    {
                        this.dump = line + r.ReadToEnd();
                        break;
                    }
                }
            }

            using (StringReader r = new StringReader(this.dump))
            {
                string line = "";

                while (r.Peek() != -1)
                {
                    line = r.ReadLine();

                    if (line == "")
                        continue;
                    else if (line.Contains("AC "))
                        bool.TryParse(line.Substring(14), out this.acPower);
                    else if (line.Contains("USB"))
                        bool.TryParse(line.Substring(15), out this.usbPower);
                    else if (line.Contains("Wireless"))
                        bool.TryParse(line.Substring(20), out this.wirelessPower);
                    else if (line.Contains("status"))
                        int.TryParse(line.Substring(10), out this.status);
                    else if (line.Contains("health"))
                        int.TryParse(line.Substring(10), out this.health);
                    else if (line.Contains("present"))
                        bool.TryParse(line.Substring(11), out this.present);
                    else if (line.Contains("level"))
                        int.TryParse(line.Substring(9), out this.level);
                    else if (line.Contains("scale"))
                        int.TryParse(line.Substring(9), out this.scale);
                    else if (line.Contains("voltage"))
                        int.TryParse(line.Substring(10), out this.voltage);
                    else if (line.Contains("temp"))
                       double.TryParse(line.Substring(15), out this.temperature);
                    else if (line.Contains("tech"))
                        this.technology = line.Substring(14);
                }
            }

            this.outString = this.dump.Replace("Service state", "State For Device " + this.device.SerialNumber);
        }

        public override string ToString()
        {
            Update();
            return this.outString;
        }
    }
}