
/* (C) 2019 Franco28 */
/* Basic Tool C# for Redmi Note 7 */

using Microsoft.VisualBasic;
using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace RedmiNote7ToolC
{
    public partial class Visual : Form
    {
        private PerformanceCounter ramCounter;
        private PerformanceCounter cpuCounter;

        public Visual()
        {
            InitializeComponent();
            InitializeRAMCounter();
            InitialiseCPUCounter();
            updateTimer_Tick();
        }

        [System.ComponentModel.Browsable(false)]

        private void updateTimer_Tick()
        {
            Timer timer = new Timer();
            timer.Interval = (1 * 1000); 
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();

            Label1.Text = "Free RAM: " + Convert.ToInt64(ramCounter.NextValue()).ToString() + " MB";
            label4.Text = "CPU: " + Convert.ToInt64(cpuCounter.NextValue()).ToString() + " %";
            Label2.Text = @"Folder Size: C:\adb " + GetDirectorySize(@"C:\adb") + " MB";
        }

        private void InitialiseCPUCounter()
        {
            cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total", true);
        }

        private void InitializeRAMCounter()
        {
            ramCounter = new PerformanceCounter("Memory", "Available MBytes", true);
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            Label1.Text = "Free RAM: " + Convert.ToInt64(ramCounter.NextValue()).ToString() + " MB";
            label4.Text = "CPU: " + Convert.ToInt64(cpuCounter.NextValue()).ToString() + " %";
            Label2.Text = @"Folder Size: C:\adb " + GetDirectorySize(@"C:\adb") + " MB";
        }

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

        private void FastbootExe(object fpath, string command)
        {
            try
            {
                System.Diagnostics.ProcessStartInfo procStartInfo =
                    new System.Diagnostics.ProcessStartInfo(@"C:\adb"+fpath, " /c " + command);
                System.Diagnostics.Process proc = new System.Diagnostics.Process();

                proc.StartInfo.RedirectStandardOutput = true;
                proc.StartInfo.RedirectStandardError = true;
                proc.OutputDataReceived += new DataReceivedEventHandler(OutputHandler);
                proc.ErrorDataReceived += new DataReceivedEventHandler(OutputHandler);

                procStartInfo.UseShellExecute = true;
                procStartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal;
                procStartInfo.CreateNoWindow = true;
                proc.StartInfo = procStartInfo;
                proc.Start();
                Console.WriteLine(procStartInfo);
                proc.WaitForExit();

                if (proc.HasExited == true)
                {
                    MessageBox.Show("Option: " + command + " canceled", "Fastboot & ADB: Console", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
#pragma warning disable CS0253
                else if (@"flash recovery C:\adb\TWRP\recovery.img" == command)
#pragma warning restore CS0253
                {
                    MessageBox.Show("Hey! Now if you want to keep the recovery fully working, you must flash the following zip", "FLASH TWRP", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    OpenFolder(@"adb\TWRP");
                }

            }
            catch (Exception objException)
            {
                MessageBox.Show("Error: " + objException, "Fastboot & ADB: Console", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        static void OutputHandler(object sendingProcess, DataReceivedEventArgs outLine)
        {
            Console.WriteLine(outLine.Data);
        }

        public void OpenFolder(object folderpath)
        {
            string Proc = "Explorer.exe";
            string Args = ControlChars.Quote + System.IO.Path.Combine(@"C:\" + folderpath) + ControlChars.Quote;
            Process.Start(Proc, Args);
        }

        private void Visual_Load(object sender, EventArgs e)
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

            if (!File.Exists(@"C:\adb\adb.exe"))
            {
                try
                {
                    if (Ping("www.google.com") == true)
                    {
                        base.Dispose(Disposing);
                        var downloadadb = new DownloadAdbFastboot();
                        downloadadb.Show();
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("ERROR: Can´t connect to the server to download files!, Please connect to the Network and open again the Tool", "Network Lost", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    base.Dispose(Disposing);
                }
            }

            InitializeRAMCounter();
            updateTimer_Tick();
            System.Threading.Thread.Sleep(3000);
            TextBox2.Text = "Remember to always Backup your efs and persist folders!";
            Label3.Text = "User: " + Environment.UserName;
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
                FastbootExe(@"\fastboot.exe", @"oem lock");
            }
            else
            {
                MessageBox.Show("Lock Bootloader canceled...", "Bootloader", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                System.Threading.Thread.Sleep(1000);
            }
        }

        private void boottwrp_Click(object sender, EventArgs e)
        {

            if (!File.Exists(@"C:\adb\TWRP\recovery.img"))
            {
                try
                {
                    if (Ping("www.google.com") == true)
                    {
                        MessageBox.Show("Can´t find TWRP OrangeFox image...", "TWRP Missing", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        var downloadtwrp = new DownloadTWRP();
                        base.Dispose(Disposing);
                        downloadtwrp.Show();
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("ERROR: Can´t connect to the server to download TWRP OrangeFox image!", "Network Lost", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    System.Windows.Forms.Application.Restart();
                }
         
                } 
                else
                {
                FastbootExe(@"\fastboot.exe", @"boot recovery C:\adb\TWRP\recovery.img");
            }

        }

        private void flashtwrp_Click(object sender, EventArgs e)
        {
            if (!File.Exists(@"C:\adb\TWRP\recovery.img"))
            {
                try
                {
                    if (Ping("www.google.com") == true)
                    {
                        MessageBox.Show("Can´t find TWRP OrangeFox image...", "TWRP Missing", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        var downloadtwrp = new DownloadTWRP();
                        base.Dispose(Disposing);
                        downloadtwrp.Show();
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("ERROR: Can´t connect to the server to download TWRP OrangeFox image!", "Network Lost", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    System.Windows.Forms.Application.Restart();
                }

            }
            else
            {
                FastbootExe(@"\fastboot.exe", @"flash recovery C:\adb\TWRP\recovery.img");
            } 
        }

        private void AdbFastbootFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFolder(@"adb");
            }
            catch (Exception er)
            {
                MessageBox.Show("Error: " + er, "Open Folder", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MiFlashFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
               OpenFolder(@"adb\MI");
            } catch (Exception er)
            {
                MessageBox.Show("Error: " +er, "Open Folder", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MiUnlockFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFolder(@"adb\MIUnlock");
            }
            catch (Exception er)
            {
                MessageBox.Show("Error: " + er, "Open Folder", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DownloadLatestMIUIFastbootImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
                try
                {
                    if (Ping("www.google.com") == true)
                    {
                        MessageBox.Show("Can´t find Firmware images...", "Firmware Missing", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        var downloadfastbootmiui = new DownloadMIUIFastboot();
                        base.Dispose(Disposing);
                        downloadfastbootmiui.Show();
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("ERROR: Can´t connect to the server to download TWRP OrangeFox image!", "Network Lost", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    System.Windows.Forms.Application.Restart();
                }
        }

        private void ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFolder(@"adb\xiaomiglobalfastboot");
            }
            catch (Exception er)
            {
                MessageBox.Show("Error: " + er, "Open Folder", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (System.IO.File.Exists(@"C:\Program Files (x86)\Google\Chrome\Application\chrome.exe") & System.IO.File.Exists(@"C:\Program Files\Google\Chrome\Application\chrome.exe") == true)
            {
                BrowserCheck.StartBrowser("MicrosoftEdge.exe", "https://xiaomifirmwareupdater.com/miui/");
            }
            else
            {
                BrowserCheck.StartBrowser("Chrome.exe", "https://xiaomifirmwareupdater.com/miui/");
            }
        }

        private void DownloadLatestMIUIToolStripMenuItem_Click(object sender, EventArgs e)
        {
                try
                {
                if (Ping("www.google.com") == true)
                {
                    MessageBox.Show("Can´t find Xiaomi Recovery ROM...", "Recovery ROM Missing", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    var downloadmiuirecovery = new DownloadMIUIRecovery();
                    downloadmiuirecovery.Show();

                }
            }
                catch (Exception)
                {
                    MessageBox.Show("ERROR: Can´t connect to the server to download Xiaomi Recovery ROM!", "Network Lost", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    System.Windows.Forms.Application.Restart();
                }
        }

        private void OpenFolderXiaomiGlobalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFolder(@"adb\xiaomiglobalrecovery");
            }
            catch (Exception er)
            {
                MessageBox.Show("Error: " + er, "Open Folder", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void XiaomiGlobalPageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (System.IO.File.Exists(@"C:\Program Files (x86)\Google\Chrome\Application\chrome.exe") & System.IO.File.Exists(@"C:\Program Files\Google\Chrome\Application\chrome.exe") == true)
            {
                BrowserCheck.StartBrowser("MicrosoftEdge.exe", "https://c.mi.com/oc/miuidownload/detail?device=1700360");
            }
            else
            {
                BrowserCheck.StartBrowser("Chrome.exe", "https://c.mi.com/oc/miuidownload/detail?device=1700360");
            }
        }

        private void DownloadLatestMIUIByXiaomieuToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void OpenFolderXiaomieuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFolder(@"adb\xiaomieu");
            }
            catch (Exception er)
            {
                MessageBox.Show("Error: " + er, "Open Folder", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void XiaomieuPageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (System.IO.File.Exists(@"C:\Program Files (x86)\Google\Chrome\Application\chrome.exe") & System.IO.File.Exists(@"C:\Program Files\Google\Chrome\Application\chrome.exe") == true)
            {
                BrowserCheck.StartBrowser("MicrosoftEdge.exe", "https://xiaomi.eu/community/");
            }
            else
            {
                BrowserCheck.StartBrowser("Chrome.exe", "https://xiaomi.eu/community/");
            }
        }

        private void DownloadMiFlash2018ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void DownloadMiUnlockToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void EnterEDLModeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Are you sure that you wan to enter to EDL mode? This can´t be undone!", "Warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                FastbootExe(@"\fastboot_edl.exe", @" reboot-edl");
                System.Threading.Thread.Sleep(500);
            }
            else
            {
                MessageBox.Show("EDL canceled...", "EDL", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                System.Threading.Thread.Sleep(500);
            }
        }

        private void FlashFirmwareBetaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string[] paths = System.IO.Directory.GetFiles(@"C:\adb\MI", "XiaoMiFlash.exe");

            if (paths.Length > 0)
            {
                try
                {
                    var proc = new System.Diagnostics.Process();
                    proc = Process.Start(@"C:\adb\MI\XiaoMiFlash.exe", "");
                } 
                catch 
                {
                    MessageBox.Show("XiaoMiFlash closed...", "Mi Flash", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Error on loading XiaoMiFlash, seems to be missing...", "Mi Flash", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }     
        }

        private void OpenFlashToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This is not ready yet!", "Mi Flash By Franco28", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            var result = MessageBox.Show("Do you want to Remove all files? " + GetDirectorySize(@"C:\adb") + " MB", "Warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

             if (result == DialogResult.Yes)
                {
                    try
                    {
                        Directory.SetCurrentDirectory(@"C:\");
                        var root = @"C:\adb";

                    if (Directory.Exists(root))
                        this.Controls.Clear();
                        Directory.Delete(root, true);
                        MessageBox.Show("All files removed! " + " See you " + Environment.UserName, "Uninstall", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void Visual_Closed(object sender, EventArgs e)
        {
            this.Controls.Clear();
            base.Refresh();
            foreach (var process in Process.GetProcessesByName("RedmiNote7Tool"))
            {
                process.Kill();
            }
            Application.ExitThread();
            base.Dispose(Disposing);
        }

    }
}
