
/* (C) 2019 Franco28 */
/* Basic Tool C# for Redmi Note 7 */

using Microsoft.Win32;
using System;
using System.IO;
using System.Threading;
using System.Xml;

namespace RedmiNote7ToolC
{
    public static class VersionTest
    {

        public static object RollingInterval { get; private set; }
        private static readonly object Locker = new object();
        private static XmlDocument _doc = new XmlDocument();

        public static void Main()
        {
            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(@"C:\adb");

            if (dir.Exists)
            {
                Directory.SetCurrentDirectory(@"C:\adb");
            }
            else if ((!System.IO.Directory.Exists(@"C:\adb")))
            {
                System.IO.Directory.CreateDirectory(@"C:\adb");
            }

            if (!Directory.Exists(@"C:\adb\.settings"))
            {
                Directory.CreateDirectory(@"C:\adb\.settings");
            }

            if (!Directory.Exists(@"C:\adb\TWRP"))
            {
                Directory.CreateDirectory(@"C:\adb\TWRP");
            }

            if (!Directory.Exists(@"C:\adb\MI"))
            {
                Directory.CreateDirectory(@"C:\adb\MI");
            }

            if (!Directory.Exists(@"C:\adb\MIUnlock"))
            {
                Directory.CreateDirectory(@"C:\adb\MIUnlock");
            }

            if (!Directory.Exists(@"C:\adb\xiaomiglobalfastboot"))
            {
                Directory.CreateDirectory(@"C:\adb\xiaomiglobalfastboot");
            }

            if (!Directory.Exists(@"C:\adb\xiaomieu"))
            {
                Directory.CreateDirectory(@"C:\adb\xiaomieu");
            }

            if (!Directory.Exists(@"C:\adb\xiaomiglobalrecovery"))
            {
                Directory.CreateDirectory(@"C:\adb\xiaomiglobalrecovery");
            }

            if (File.Exists(@"C:\adb\.settings\net.txt"))
            {
                _doc.Load(@"C:\adb\.settings\net.txt");
            }
            else
            {
                var root = _doc.CreateElement("NetFramework");
                _doc.AppendChild(root);
            }

            for (int i = 0; i < 1; i++)
            {
                new Thread(new ThreadStart(GetVersionFromRegistry)).Start();
            }

            GetVersionFromRegistry();

        }

        static void Log(string first, string second)
        {
            lock (Locker)
            {
                var el = (XmlElement)_doc.DocumentElement.AppendChild(_doc.CreateElement("Logs"));
                el.SetAttribute("NetVersion", first);
                el.AppendChild(_doc.CreateElement("NetVersion")).InnerText = second;
                _doc.Save(@"C:\adb\.settings\net.txt");
            }
        }
        private static void GetVersionFromRegistry()
        {
            // Opens the registry key for the .NET Framework entry.
            using (RegistryKey ndpKey =
                    RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32).
                    OpenSubKey(@"SOFTWARE\Microsoft\NET Framework Setup\NDP\"))
            {
                foreach (var versionKeyName in ndpKey.GetSubKeyNames())
                {
                    // Skip .NET Framework 4.5 version information.
                    if (versionKeyName == "v4")
                    {
                        Log(versionKeyName, "");
                        continue;
                    }

                    if (versionKeyName.StartsWith("v"))
                    {
                        RegistryKey versionKey = ndpKey.OpenSubKey(versionKeyName);
                        // Get the .NET Framework version value.
                        var name = (string)versionKey.GetValue("Version", "");
                        // Get the service pack (SP) number.
                        var sp = versionKey.GetValue("SP", "").ToString();

                        // Get the installation flag, or an empty string if there is none.
                        var install = versionKey.GetValue("Install", "").ToString();
                        if (string.IsNullOrEmpty(install)) // No install info; it must be in a child subkey.
                        Console.WriteLine($"{versionKeyName}  {name}");
                        else
                        {
                            if (!(string.IsNullOrEmpty(sp)) && install == "1")
                            {
                                Log(name, sp);
                                Console.WriteLine($"{versionKeyName}  {name}  SP{sp}");
                            }
                        }
                        if (!string.IsNullOrEmpty(name))
                        {
                            Log(name, "");
                            continue;
                        }
                        foreach (var subKeyName in versionKey.GetSubKeyNames())
                        {
                            RegistryKey subKey = versionKey.OpenSubKey(subKeyName);
                            name = (string)subKey.GetValue("Version", "");
                            if (!string.IsNullOrEmpty(name))
                            sp = subKey.GetValue("SP", "").ToString();
                            Log(sp, name);

                            install = subKey.GetValue("Install", "").ToString();
                            Log(install, name);
                            if (string.IsNullOrEmpty(install)) //No install info; it must be later.
                            Console.WriteLine($"{versionKeyName}  {name}");
                            else
                            {
                                if (!(string.IsNullOrEmpty(sp)) && install == "1")
                                {
                                    Log(install, name);
                                    Console.WriteLine($"{subKeyName}  {name}  SP{sp}");
                                }
                                else if (install == "1")
                                {
                                    Log(install, name);
                                    Console.WriteLine($"  {subKeyName}  {name}");
                                }
                            }
                        }
                    }
                }
            }
        }
    }

}
