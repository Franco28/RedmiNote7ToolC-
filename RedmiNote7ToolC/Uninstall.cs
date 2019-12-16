
/* (C) 2019 Franco28 */
/* Basic Tool C# for Redmi Note 7 */

using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace RedmiNote7ToolC
{
    public partial class Uninstall : Form
    {
        public Uninstall()
        {
            InitializeComponent();
        }

        private void Uninstall_Load(object sender, EventArgs e)
        {

            var root = @"C:\adb";
            var pathWithEnv = @"%USERPROFILE%\AppData\Local\Apps";
            var toolinstallationfolder = Environment.ExpandEnvironmentVariables(pathWithEnv);
            var cplPath = System.IO.Path.Combine(Environment.SystemDirectory, "control.exe");

            try
            {
                var dir = new DirectoryInfo(root);
                foreach (var file in dir.GetFiles())
                {
                    file.Delete();
                    Directory.Delete(root, true);
                }

                if (Directory.Exists(root))
                    Directory.Delete(root, true);

                if (Directory.Exists(toolinstallationfolder))
                    Directory.Delete(toolinstallationfolder, true);

                MessageBox.Show("All files removed! " + "Now to fully uninstall the Tool, go to Control Panel/Uninstall " + " See you " + Environment.UserName, "Uninstall", MessageBoxButtons.OK, MessageBoxIcon.Information);

                System.Diagnostics.Process.Start(cplPath, "/name Microsoft.ProgramsAndFeatures");

                exit();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Uninstall failed: {0} " + ex.Message + " Directory throw an error, please remove it manually!", "Error: Uninstall", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void exit()
        {
            var root = @"C:\adb";
            if (Directory.Exists(root))
                Directory.Delete(root, true);

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
