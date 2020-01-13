
using System;
using System.IO;
using System.Windows.Forms;

namespace Franco28Tool.Engine
{
    public class Fastboot
    {
        public static void FastbootExe(string fpath, string command)
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
    }
}
