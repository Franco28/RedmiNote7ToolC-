/*
 * BuildProp.cs - Developed by Dan Wager for AndroidLib.dll
 */

using System;
using System.Collections.Generic;

namespace RegawMOD.Android
{

    public class BuildProp
    {
        private Device device;

        private Dictionary<string, string> prop;

        internal BuildProp(Device device)
        {
            this.prop = new Dictionary<string, string>();
            this.device = device;
        }

        public List<string> Keys
        {
            get
            {
                Update();

                List<string> keys = new List<string>();

                foreach (string key in this.prop.Keys)
                    keys.Add(key);

                return keys;
            }
        }

        public List<string> Values
        {
            get
            {
                Update();

                List<string> values = new List<string>();

                foreach (string val in this.prop.Values)
                    values.Add(val);

                return values;
            }
        }

        public string GetProp(string key)
        {
            Update();

            string tmp;

            this.prop.TryGetValue(key, out tmp);

            return tmp;
        }

        public bool SetProp(string key, string newValue)
        {
            string before;
            if (!this.prop.TryGetValue(key, out before))
                return false;

            AdbCommand adbCmd = Adb.FormAdbShellCommand(this.device, true, "setprop", key, newValue);
            Adb.ExecuteAdbCommandNoReturn(adbCmd);

            Update();

            string after;
            if (!this.prop.TryGetValue(key, out after))
                return false;

            return newValue == after;
        }

        public override string ToString()
        {
            Update();

            string outPut = "";

            foreach (KeyValuePair<string, string> s in this.prop)
                outPut += string.Format("[{0}]: [{1}]" + Environment.NewLine, s.Key, s.Value);

            return outPut;
        }

        private void Update()
        {
            try
            {
                this.prop.Clear();

                if (this.device.State != DeviceState.ONLINE)
                    return;

                AdbCommand adbCmd = Adb.FormAdbShellCommand(this.device, false, "getprop");
                string prop = Adb.ExecuteAdbCommand(adbCmd);

                string[] lines = prop.Split(new string[] { "\r\n\r\n" }, StringSplitOptions.RemoveEmptyEntries);

                for (int i = 0; i < lines.Length; i++)
                {
                    string[] entry = lines[i].Split(new string[] { "[", "]: [", "]" }, StringSplitOptions.RemoveEmptyEntries);

                    if (entry.Length == 2)
                        this.prop.Add(entry[0], entry[1]);
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex.Message, "Using: getprop in BuildProp.cs", ex.StackTrace);
            }
        }
    }
}