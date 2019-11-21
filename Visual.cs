
/* (C) 2019 Franco28 */
/* Basic Tool for Redmi Note 7 */

using Microsoft.VisualBasic;
using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace RedmiNote7ToolC
{
    public partial class Visual : Form
    {

        public Visual()
        {
            InitializeComponent();
        }

        private static StringBuilder cmdOutput = null;

        public long GetDirectorySize(string path)
        {
            string[] files = Directory.GetFiles(path, "*", SearchOption.AllDirectories);
            long size = 0;
            foreach (string file in files)
            {
                FileInfo info = new FileInfo(file);
                size += info.Length;
            }
            size /= 1000000;
            return size;
        }

        public void CPUShow()
        {
            PerformanceCounter cpu;

            cpu = new PerformanceCounter("Processor", "% Processor Time", "_Total");

            System.Threading.Thread.Sleep(1000);

            Label1.Text = "CPU Usage: " + cpu.NextValue() + " %";

            System.Threading.Thread.Sleep(1000);
        }

        private static void SortOutputHandler(object sendingProcess, DataReceivedEventArgs outLine)
        {
            if (!String.IsNullOrEmpty(outLine.Data))
            {
                cmdOutput.Append(Environment.NewLine + outLine.Data);
            }
        }

        public bool Ping(string host)
        {
            System.Net.NetworkInformation.Ping p = new System.Net.NetworkInformation.Ping();
            if (p.Send(host, 500).Status == System.Net.NetworkInformation.IPStatus.Success)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void Visual_Load(object sender, EventArgs e)
        {
            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(@"C:\adb");

            if (dir.Exists)
                Directory.SetCurrentDirectory(@"C:\adb");
            else if ((!System.IO.Directory.Exists(@"C:\adb")))
                System.IO.Directory.CreateDirectory(@"C:\adb");

            try
            {

                if (Ping("www.google.com") == true)
                {
                        if (!File.Exists(@"C:\adb\adb.exe"))
                        {
                            base.Dispose(Disposing);
                            var downloadadb = new DownloadAdbFastboot();
                            downloadadb.Show();
                        }
                    }
            }
            catch (Exception)
            {
                MessageBox.Show("ERROR: Can´t connect to the server to download files!", "Network Lost", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                base.Dispose(Disposing);
            }

            if (!Directory.Exists(@"C:\adb\.settings"))
                Directory.CreateDirectory(@"C:\adb\.settings");

            if (!Directory.Exists(@"C:\adb\.settings\TWRP"))
                Directory.CreateDirectory(@"C:\adb\.settings\TWRP");

            if (!Directory.Exists(@"C:\adb\MI"))
                Directory.CreateDirectory(@"C:\adb\MI");

            if (!Directory.Exists(@"C:\adb\MIUnlock"))
                Directory.CreateDirectory(@"C:\adb\MIUnlock");

            TextBox2.Text = "Remember to always Backup your efs and persist folders!";
            Label3.Text = "User: " + Environment.UserName;
            CPUShow();
            Label2.Text = @"Folder Size: C:\adb " + GetDirectorySize(@"C:\adb") + " MB";
        }

        private void unlockbootloader_Click(object sender, EventArgs e)
        {
            string[] paths = Directory.GetFiles(@"C:\adb\MIUnlock", "miflash_unlock.exe");

            if (paths.Length > 0)
                try {
                    var proc = new System.Diagnostics.Process();
                    proc = Process.Start(@"C:\adb\MIUnlock\miflash_unlock.exe", "");
                    }
                catch (Exception)
                {
                MessageBox.Show("Mi Unlock Closed...", "Mi Unlock", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            else
            {
                MessageBox.Show("Error on loading Mi Unlock, seems to be missing... Please download it!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (System.IO.File.Exists(@"C:\Program Files (x86)\Google\Chrome\Application\chrome.exe") & System.IO.File.Exists(@"C:\Program Files\Google\Chrome\Application\chrome.exe")  == true)
            {
                BrowserCheck.StartBrowser("MicrosoftEdge.exe", "https://c.mi.com/thread-1857937-1-1.html");
            }
            else
            {
                BrowserCheck.StartBrowser("Chrome.exe", "https://c.mi.com/thread-1857937-1-1.html");
            }
        }

        private void LockBootloader_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Do you want to Lock the bootloader? This will erase all your data!", "Warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                try
                {
                    cmdOutput = new StringBuilder("");
                    System.Diagnostics.Process process = new System.Diagnostics.Process();
                    System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
                    startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                    startInfo.FileName = @"C:\adb\fastboot.exe";
                    startInfo.Arguments = "/C fastboot oem lock";
                    process.StartInfo = startInfo;
                    process.Start();

                    process.OutputDataReceived += new DataReceivedEventHandler(SortOutputHandler);

                    
                    TextBox2.Text += cmdOutput;
                }
                catch (Exception er)
                {
                    MessageBox.Show("Error: " + er, "Bootloader: Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Lock Bootloader canceled...", "Bootloader", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
                System.Threading.Thread.Sleep(500);
        }

        private void boottwrp_Click(object sender, EventArgs e)
        {

        }

        private void flashtwrp_Click(object sender, EventArgs e)
        {

        }

        private void AdbFastbootFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void MiFlashFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void MiUnlockFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void DownloadLatestMIUIFastbootImageToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void ToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void ToolStripMenuItem2_Click(object sender, EventArgs e)
        {

        }

        private void DownloadLatestMIUIToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void OpenFolderXiaomiGlobalToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void XiaomiGlobalPageToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void DownloadLatestMIUIByXiaomieuToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void OpenFolderXiaomieuToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void XiaomieuPageToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void DownloadMiFlash2018ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void DownloadMiUnlockToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void EnterEDLModeToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void FlashFirmwareBetaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void OpenFlashToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void Refresh_Click(object sender, EventArgs e)
        {
            this.Controls.Clear();
            InitializeComponent();
            Visual_Load(e, e);
            base.Refresh();
        }

        private void Help_Click(object sender, EventArgs e)
        {

        }

        private void UninstallTool_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Do you want to Remove all files? " + GetDirectorySize(@"C:\adb") + " MB", "Warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

             if (result == DialogResult.Yes)
                {
                    try
                    {
                        Directory.SetCurrentDirectory(@"C:\");
                        var root = @"C:\adb";

                    if (Directory.Exists(root))
                        this.Controls.Clear();
                        Directory.Delete(root, true);
                        MessageBox.Show("All files removed! " + " See you " + Environment.UserName, "Uninstall", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        base.Dispose(Disposing);
               
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("The process failed: {0} " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.Controls.Clear();
                        base.Refresh();
                    }
                }
            }        
    }
}
