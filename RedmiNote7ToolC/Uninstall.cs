
/* (C) 2019 Franco28 */
/* Basic Tool C# for Redmi Note 7 */

using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using RegawMOD.Android;

namespace RedmiNote7ToolC
{
    public partial class Uninstall : Form
    {
        private AndroidController android;

        public Uninstall()
        {
            InitializeComponent();
            android = AndroidController.Instance;
        }

        public void exit()
        {
            Process myprocess = new Process();
            string arg = @"/c taskkill /f";
            try
            {
                foreach (Process p in Process.GetProcessesByName("RedmiNote7Tool"))
                {
                    arg += " /pid " + p.Id;
                }
                ProcessStartInfo process = new ProcessStartInfo("cmd");
                process.UseShellExecute = false;
                process.CreateNoWindow = true;
                process.Verb = "runas";
                process.Arguments = arg;
                Process.Start(process);
            }
            catch (Exception er)
            {
                MessageBox.Show("Killing process failed: {0} " + er.Message, "Error: Killing Process", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Application.ExitThread();
            base.Dispose(Disposing);
        }

        private void Uninstall_Load(object sender, EventArgs e)
        {
            try
            {
                var root = @"C:\adb\";
                var pathWithEnv = @"%USERPROFILE%\AppData\Local\Apps";
                var toolinstallationfolder = Environment.ExpandEnvironmentVariables(pathWithEnv);
                var cplPath = System.IO.Path.Combine(Environment.SystemDirectory, "control.exe");
                var dir = new DirectoryInfo(root);

                if (Directory.Exists(toolinstallationfolder))
                    Directory.Delete(toolinstallationfolder, true);

                MessageBox.Show("All files removed! " + "Now to fully uninstall the Tool, go to Control Panel/Uninstall " + " See you " + Environment.UserName, "Uninstall", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.label1.Text = "Hey if this screen does not disappear, close this and uninstall the tool from control panel";

                System.Diagnostics.Process.Start(cplPath, "/name Microsoft.ProgramsAndFeatures");

                    android.Dispose();

                foreach (var file in dir.GetFiles())
                {
                    file.Delete();
                }

                var paths = new[] { "C:\\adb\\StockRom", "C:\\adb\\.settings", "C:\\adb\\TWRP", "C:\\adb\\MIFlash", "C:\\adb\\MIUnlock", "C:\\adb\\xiaomiglobalfastboot\\MI", "C:\\adb\\xiaomiglobalfastboot",  "C:\\adb\\xiaomieu", "C:\\adb\\xiaomiglobalrecovery" };

                foreach (var path in paths)
                {
                    try
                    {
                        Directory.Delete(path, true);
                    }
                    catch (Exception er)
                    {
                        MessageBox.Show("Error: " + er, "Remove Folders: Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                exit();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Uninstall failed: {0} " + ex.Message + " Directory throw an error, please remove it manually!", "Error: Uninstall", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        public void Uninstall_Closed(object sender, EventArgs e)
        {
            Process myprocess = new Process();
            string arg = @"/c taskkill /f";
            try
            {
                foreach (Process p in Process.GetProcessesByName("RedmiNote7Tool"))
                {
                    arg += " /pid " + p.Id;
                }
                ProcessStartInfo process = new ProcessStartInfo("cmd");
                process.UseShellExecute = false;
                process.CreateNoWindow = true;
                process.Verb = "runas";
                process.Arguments = arg;
                Process.Start(process);
            }
            catch (Exception er)
            {
                MessageBox.Show("Killing process failed: {0} " + er.Message, "Error: Killing Process", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Application.ExitThread();
            base.Dispose(Disposing);
        }
    }
}
