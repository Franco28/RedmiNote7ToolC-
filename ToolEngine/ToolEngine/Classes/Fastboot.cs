// <copyright file=Fastboot>
// Copyright (c) 2019-2020 All Rights Reserved
// </copyright>
// <author>Franco28</author>
// <date> 15/1/2020 14:08:29</date>
// <summary>A DLL Lib needed by Redmi Note 7 Tool</summary>

using System;
using System.IO;
using System.Windows.Forms;

namespace Franco28Tool.Engine
{
    public class Fastboot
    {
        private string command;
        private int timeout;

        internal string Command { get { return this.command; } }
        internal int Timeout { get { return this.timeout; } }
        internal Fastboot(string command) { this.command = command; this.timeout = Franco28Tool.Engine.Command.DEFAULT_TIMEOUT; }
        public Fastboot WithTimeout(int timeout) { this.timeout = timeout; return this; }

    }

        public static class Adb
        {

        private static Object _lock = new Object();
        internal const string ADB = "adb";
        internal const string ADB_EXE = "adb.exe";
        internal const string ADB_VERSION = "1.0.39";
        internal const string FASTBOOT = "fastboot";
        internal const string FASTBOOT_EXE = "fastboot.exe";
        internal const string FASTBOOT_VERSION = "3db08f2c6889-android";

        public static void FastbootExecuteCommand(string fpath, string command)
        {
                try
                {
                    Directory.SetCurrentDirectory(@"C:\adb\");
                    System.Diagnostics.ProcessStartInfo procStartInfo =
                        new System.Diagnostics.ProcessStartInfo(@"C:\adb\" + fpath, command);
                    System.Diagnostics.Process proc = new System.Diagnostics.Process();
                    proc.StartInfo.RedirectStandardOutput = true;
                    proc.StartInfo.RedirectStandardError = true;
                    procStartInfo.UseShellExecute = false;
                    procStartInfo.CreateNoWindow = true;
                    proc.StartInfo = procStartInfo;
                    proc.Start();
                    Console.WriteLine(procStartInfo);
                    proc.WaitForExit();
                    do
                    {
                        System.Windows.Forms.Application.DoEvents();
                    } while (!proc.HasExited);

                    if (@"flash recovery C:\adb\TWRP\recovery.img" == command)
                    {
                        MessageBox.Show("Hey! Now if you want to keep the recovery fully working, you must flash the following zip", "FLASH TWRP", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Franco28Tool.Engine.Folders.OpenFolder(@"adb\TWRP");
                    }
                }
                catch (Exception objException)
                {
                    MessageBox.Show("Error: " + objException, "Fastboot & ADB: Console", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            public static string ExecuteCommand(Fastboot command, bool forceRegular = false)
            {
                string result = "";

                lock (_lock)
                {
                    result = Command.RunProcessReturnOutput(@"C:\adb\" + ADB_EXE, command.Command, forceRegular, command.Timeout);
                }

                return result;
            }
        }
}
