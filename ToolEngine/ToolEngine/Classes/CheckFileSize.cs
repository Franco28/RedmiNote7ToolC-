// <copyright file=CheckFileSize>
// Copyright (c) 2019-2020 All Rights Reserved
// </copyright>
// <author>Franco28</author>
// <date> 19/1/2020 18:01:53</date>
// <summary>A DLL Lib needed by Redmi Note 7 Tool</summary>

using System;
using System.IO;
using System.Windows.Forms;

namespace Franco28Tool.Engine
{
    public class CheckFileSize
    {

        public static void TWRP()
        {
            System.Threading.Thread.Sleep(2000);
            decimal sizeb = 50077781;
            string fileName = @"C:\adb\TWRP\OrangeFox-R10.1_01-Stable-lavender.zip";
            FileInfo fi = new FileInfo(fileName);

                if (fi.Length < sizeb)
                {
                    MessageBox.Show(@"File is corrupted \: Downloading again!", "Check File Engine", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    var downloadtwrp = new DownloadTWRP();
                    downloadtwrp.Show();
                }
                else
                {
                    Unzip.Unzippy(@"TWRP\OrangeFox-R10.1_01-Stable-lavender.zip", @"TWRP", true);
                }
        }

        public static void RECOVERY()
        {
            System.Threading.Thread.Sleep(2000);
            decimal sizeb = 67108864;
            string fileName = @"C:\adb\.settings\recovery.img";
            FileInfo fi = new FileInfo(fileName);

            if (fi.Length < sizeb)
            {
                MessageBox.Show(@"File is corrupted \: Downloading again!", "Check File Engine", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                var downloadrecovery = new DownloadStockRecovery();
                downloadrecovery.Show();
            }
        }

        public static void PERSIST()
        {
            System.Threading.Thread.Sleep(2000);
            decimal sizeb = 1002938;
            string fileName = @"C:\adb\.settings\Persist-Fix-Lavender-GLOBAL-V11.0.4.0.PFGMIXM.zip";
            FileInfo fi = new FileInfo(fileName);

            if (fi.Length < sizeb)
            {
                MessageBox.Show(@"File is corrupted \: Downloading again!", "Check File Engine", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                var downloadpersist = new DownloadPersist();
                downloadpersist.Show();
            }
            else
            {
                Unzip.Unzippy(@".settings\Persist-Fix-Lavender-GLOBAL-V11.0.4.0.PFGMIXM.zip", @".settings", true);
            }
        }

        public static void SPLASH()
        {
            System.Threading.Thread.Sleep(2000);
            decimal sizeb = 27232604;
            string fileName = @"C:\adb\.settings\splash.img";
            FileInfo fi = new FileInfo(fileName);

            if (fi.Length < sizeb)
            {
                MessageBox.Show(@"File is corrupted \: Downloading again!", "Check File Engine", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                var downloadsplash = new DownloadSplash();
                downloadsplash.Show();
            }
        }

        public static void MIUnlock()
        {
            System.Threading.Thread.Sleep(2000);
            decimal sizeb = 48100000;
            string fileName = @"C:\adb\MIUnlock\miflash_unlock-en-3.5.1128.45.zip";
            FileInfo fi = new FileInfo(fileName);

            if (fi.Length < sizeb)
            {
                MessageBox.Show(@"File is corrupted \: Downloading again!", "Check File Engine", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                var downloadmiunlock = new DownloadMIUnlock();
                downloadmiunlock.Show();
            }
            else
            {
                Unzip.Unzippy(@"MIUnlock\miflash_unlock-en-3.5.1128.45.zip", @"MIUnlock", true);
            }
        }

        public static void MIFlash()
        {
            System.Threading.Thread.Sleep(2000);
            decimal sizeb = 75900000;
            string fileName = @"C:\adb\MIFlash\MiFlash20181115.zip";
            FileInfo fi = new FileInfo(fileName);

            if (fi.Length < sizeb)
            {
                MessageBox.Show(@"File is corrupted \: Downloading again!", "Check File Engine", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                var downloadmiflash = new DownloadMIFlash();
                downloadmiflash.Show();
            }
            else
            {
                Unzip.Unzippy(@"MIFlash\MiFlash20181115.zip", @"MIFlash", true);
            }
        }

        public static void MIRecoveryROM()
        {
            System.Threading.Thread.Sleep(2000);
            decimal sizeb = 1964300229;
            string fileName = @"C:\adb\xiaomiglobalrecovery\miui_LAVENDERGlobal_V11.0.4.0.PFGMIXM_ab70af5e76_9.0.zip";
            FileInfo fi = new FileInfo(fileName);

            if (fi.Length < sizeb)
            {
                MessageBox.Show(@"File is corrupted \: Downloading again!", "Check File Engine", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                var downloadmirecoveryrom = new DownloadMIUIRecovery();
                downloadmirecoveryrom.Show();
            }
            else
            {
                MessageBox.Show("Mi Recovery ROM it�s already downloaded!", "Mi Recovery ROM", MessageBoxButtons.OK, MessageBoxIcon.Information);
                try
                {
                    Folders.OpenFolder(@"adb\xiaomiglobalrecovery");
                }
                catch (Exception er)
                {
                    MessageBox.Show("Error: " + er, "Open Folder", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public static void MIXiaomieuROM()
        {
            System.Threading.Thread.Sleep(2000);
            decimal sizeb = 1964300229;
            string fileName = @"C:\adb\xiaomieu\xiaomi.eu_multi_HMNote7_20.1.16_v11-10.zip";
            FileInfo fi = new FileInfo(fileName);

            if (fi.Length < sizeb)
            {
                MessageBox.Show(@"File is corrupted \: Downloading again!", "Check File Engine", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                var downloadxiaomieurom = new DownloadMIUIeu();
                downloadxiaomieurom.Show();
            }
            else
            {
                MessageBox.Show("Xiaomi.eu it�s already downloaded!", "Xiaomi eu ROM", MessageBoxButtons.OK, MessageBoxIcon.Information);
                try
                {
                    Folders.OpenFolder(@"adb\xiaomieu");
                }
                catch (Exception er)
                {
                    MessageBox.Show("Error: " + er, "Open Folder", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public static long GetDirectorySize(string path)
        {
            string[] files = Directory.GetFiles(path, "*", System.IO.SearchOption.AllDirectories);
            long size = 0;
            foreach (string file in files)
            {
                FileInfo info = new FileInfo(file);
                size += info.Length;
            }
            size /= 1000000;
            return size;
        }
    }
}
