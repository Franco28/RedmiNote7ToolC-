
/* (C) 2019 Franco28 */
/* Basic Tool C# for Redmi Note 7 */

using Microsoft.VisualBasic;
using RegawMOD.Android;
using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace RedmiNote7ToolC
{

    public partial class Visual : Form
    {
        [System.ComponentModel.Browsable(false)]

        private PerformanceCounter ramCounter;
        private PerformanceCounter cpuCounter;
        private AndroidController android;

        public Visual()
        {
            InitializeComponent();
            InitializeRAMCounter();
            InitialiseCPUCounter();
            updateTimer_Tick();
            android = AndroidController.Instance; 
        }

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

        public void FastbootExe(string fpath, string command)
        {
            try
            {
                Directory.SetCurrentDirectory(@"C:\adb\");
                System.Diagnostics.ProcessStartInfo procStartInfo =
                    new System.Diagnostics.ProcessStartInfo(@"C:\adb\" +fpath, command);
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
                  Application.DoEvents(); 
                } while (!proc.HasExited); 

                if (@"flash recovery recovery.img" == command)
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

            if (!Directory.Exists(@"C:\adb\MIFlash"))
            {
                Directory.CreateDirectory(@"C:\adb\MIFlash");
            }

            if (!Directory.Exists(@"C:\adb\MIUnlock"))
            {
                Directory.CreateDirectory(@"C:\adb\MIUnlock");
            }

            if (!Directory.Exists(@"C:\adb\xiaomiglobalfastboot"))
            {
                Directory.CreateDirectory(@"C:\adb\xiaomiglobalfastboot");
            }

            if (!Directory.Exists(@"C:\adb\xiaomiglobalfastboot\MI"))
            {
                Directory.CreateDirectory(@"C:\adb\xiaomiglobalfastboot\MI");
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
                TextBox2.Text = "Checking device connection...";

                if (android.HasConnectedDevices)
                {
                    System.Threading.Thread.Sleep(1000);
                    TextBox2.Text = "Locking bootloader...";
                    System.Threading.Thread.Sleep(1000);
                    FastbootExe(@"\fastboot.exe", @"oem lock");
                    System.Threading.Thread.Sleep(500);
                    TextBox2.Text = "Remember to always Backup your efs and persist folders!";
                }
                else
                {
                    TextBox2.Text = "Please connect your device...";
                    System.Threading.Thread.Sleep(1000);
                    MessageBox.Show("Device doesn´t found, Please connect the phone and check if developer (adb) options are enabled", "Bootloader: Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    TextBox2.Text = "Remember to always Backup your efs and persist folders!";
                }
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
                TextBox2.Text = "Checking device connection...";
                if (android.HasConnectedDevices)
                {
                    Directory.SetCurrentDirectory(@"C:\adb\TWRP\");
                    System.Threading.Thread.Sleep(1000);
                    TextBox2.Text = "Booting into OrangeFox...";
                    System.Threading.Thread.Sleep(1000);
                    FastbootExe(@"fastboot ", @"boot recovery.img");
                    System.Threading.Thread.Sleep(3000);
                    TextBox2.Text = "Remember to always Backup your efs and persist folders!";
                }
                else
                {
                    TextBox2.Text = "Please connect your device...";
                    System.Threading.Thread.Sleep(1000);
                    MessageBox.Show("Device doesn´t found, Please connect the phone and check if developer (adb) options are enabled", "Flash: Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    TextBox2.Text = "Remember to always Backup your efs and persist folders!";
                }
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
                TextBox2.Text = "Checking device connection...";
                if (android.HasConnectedDevices)
                {
                    Directory.SetCurrentDirectory(@"C:\adb\TWRP\");
                    System.Threading.Thread.Sleep(1000);
                    TextBox2.Text = "Flashing TWRP OrangeFox...";
                    System.Threading.Thread.Sleep(1000);
                    FastbootExe(@"fastboot ", @"flash recovery recovery.img");
                    System.Threading.Thread.Sleep(3000);
                    FastbootExe(@"adb ", @"reboot recovery");
                    TextBox2.Text = "Booting into OrangeFox...";
                    System.Threading.Thread.Sleep(2000);
                    TextBox2.Text = "Remember to always Backup your efs and persist folders!";
                    MessageBox.Show("TWRP Installed!", "Flash: TWRP", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    TextBox2.Text = "Please connect your device...";
                    System.Threading.Thread.Sleep(1000);
                    MessageBox.Show("Device doesn´t found, Please connect the phone and check if developer (adb) options are enabled", "Flash: Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    TextBox2.Text = "Remember to always Backup your efs and persist folders!";
                }
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
               OpenFolder(@"adb\MIFlash");
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
                        MessageBox.Show("Can´t find Firmware image...", "Firmware Missing", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        var downloadfastbootmiui = new DownloadMIUIFastboot();
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
            try
            {
                if (Ping("www.google.com") == true)
                {
                    MessageBox.Show("Can´t find Mi Flash...", "Mi FLash Missing", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    var downloadmiflash = new DownloadMIFlash();
                    downloadmiflash.Show();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("ERROR: Can´t connect to the server to download Mi Flash!", "Network Lost", MessageBoxButtons.OK, MessageBoxIcon.Error);
                System.Windows.Forms.Application.Restart();
            }
        }

        private void DownloadMiUnlockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (Ping("www.google.com") == true)
                {
                    MessageBox.Show("Can´t find Mi Unlock...", "Mi Unlock Missing", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    var downloadmiunlock = new DownloadMIUnlock();
                    downloadmiunlock.Show();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("ERROR: Can´t connect to the server to download Mi Flash!", "Network Lost", MessageBoxButtons.OK, MessageBoxIcon.Error);
                System.Windows.Forms.Application.Restart();
            }
        }

        private void EnterEDLModeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Are you sure that you wan to enter to EDL mode?", "Warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                TextBox2.Text = "Checking device connection...";
                if (android.HasConnectedDevices)
                {
                    System.Threading.Thread.Sleep(1000);
                    TextBox2.Text = "Entering to EDL mode...";
                    System.Threading.Thread.Sleep(1000);
                    FastbootExe(@"\fastboot_edl ", @" reboot-edl");
                    System.Threading.Thread.Sleep(500);
                    TextBox2.Text = "Remember to always Backup your efs and persist folders!";
                }
                else
                {
                    TextBox2.Text = "Please connect your device...";
                    System.Threading.Thread.Sleep(1000);
                    MessageBox.Show("Device doesn´t found, Please connect the phone and check if developer (adb) options are enabled", "EDL: Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    TextBox2.Text = "Remember to always Backup your efs and persist folders!";
                }
            }
            else
            {
                MessageBox.Show("EDL canceled...", "EDL", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                System.Threading.Thread.Sleep(500);
            }
        }

        private void rebootBootloaderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TextBox2.Text = "Checking device connection...";
            if (android.HasConnectedDevices)
            {
                System.Threading.Thread.Sleep(1000);
                TextBox2.Text = "Entering to Bootloader mode...";
                System.Threading.Thread.Sleep(1000);
                FastbootExe(@"\adb ", @" reboot bootloader");
                System.Threading.Thread.Sleep(500);
                TextBox2.Text = "Remember to always Backup your efs and persist folders!";
            }
            else
            {
                TextBox2.Text = "Please connect your device...";
                System.Threading.Thread.Sleep(1000);
                MessageBox.Show("Device doesn´t found, Please connect the phone and check if developer (adb) options are enabled", "BOOTLOADER: Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TextBox2.Text = "Remember to always Backup your efs and persist folders!";
            }
        }

        private void rebootRecoveryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TextBox2.Text = "Checking device connection...";
            if (android.HasConnectedDevices)
            {
                System.Threading.Thread.Sleep(1000);
                TextBox2.Text = "Entering to Recovery mode...";
                System.Threading.Thread.Sleep(1000);
                FastbootExe(@"\adb ", @" reboot recovery");
                System.Threading.Thread.Sleep(500);
                TextBox2.Text = "Remember to always Backup your efs and persist folders!";
            }
            else
            {
                TextBox2.Text = "Please connect your device...";
                System.Threading.Thread.Sleep(1000);
                MessageBox.Show("Device doesn´t found, Please connect the phone and check if developer (adb) options are enabled", "RECOVERY: Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TextBox2.Text = "Remember to always Backup your efs and persist folders!";
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
            var h = new Help();
            h.Show();
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
                        MessageBox.Show("Uninstall failed: {0} " + ex.Message, "Error: Uninstall", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.Controls.Clear();
                        base.Refresh();
                    }
                }
            }

        public void Visual_Disposed(object sender, EventArgs e)
        {
            File.Delete(@"C:\adb\.settings\net.txt");
            this.Controls.Clear();
            base.Refresh();
            foreach (var process in Process.GetProcessesByName("RedmiNote7Tool" + "adb" + "fastboot" + "fastboot_edl" + "AdbWinApi.dll" + "AdbWinUsbApi.dll"))
            {
                process.Kill();
            }
            Application.ExitThread();
            base.Dispose(Disposing);
        }

    }
}
