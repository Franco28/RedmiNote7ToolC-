// <copyright file=CheckFileSize>
// Copyright (c) 2019-2020 All Rights Reserved
// </copyright>
// <author>Franco28</author>
// <date> 22/1/2020 23:39:56</date>
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
                Strings.MSGBOXFileCorrupted();
                Downloads.downloadcall("Downloading OrangeFox-R10.1_01-Stable-lavender...", "https://files.orangefox.tech/OrangeFox-Stable/lavender/OrangeFox-R10.1_01-Stable-lavender.zip", @"C:\adb\TWRP\OrangeFox-R10.1_01-Stable-lavender.zip");
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
                Strings.MSGBOXFileCorrupted();
                Downloads.downloadcall("Downloading MI Recovery GLOBAL-V11.0.4.0.PFGMIXM...", "https://bitbucket.org/Franco28/flashtool-motorola-moto-g5-g5plus/downloads/recovery.img", @"C:\adb\.settings\recovery.img");
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
                Strings.MSGBOXFileCorrupted();
                Downloads.downloadcall("Downloading Persist-Fix-Lavender-GLOBAL-V11.0.4.0.PFGMIXM...", "https://bitbucket.org/Franco28/flashtool-motorola-moto-g5-g5plus/downloads/Persist-Fix-Lavender-GLOBAL-V11.0.4.0.PFGMIXM.zip", @"C:\adb\.settings\Persist-Fix-Lavender-GLOBAL-V11.0.4.0.PFGMIXM.zip");
            }
            else
            {
                MessageBox.Show("Mi Persist Fix it�s already downloaded!", "Mi Persist Fix", MessageBoxButtons.OK, MessageBoxIcon.Information);
                try
                {
                    Folders.OpenFolder(@"adb\.settings");
                }
                catch (Exception er)
                {
                    MessageBox.Show("Error: " + er, "Open Folder", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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
                Strings.MSGBOXFileCorrupted();
                Downloads.downloadcall("Downloading MI Splash...", "https://bitbucket.org/Franco28/flashtool-motorola-moto-g5-g5plus/downloads/splash.img", @"C:\adb\.settings\splash.img");
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
                Strings.MSGBOXFileCorrupted();
                Downloads.downloadcall("Downloading MI Unlock...", "http://miuirom.xiaomi.com/rom/u1106245679/3.5.1128.45/miflash_unlock-en-3.5.1128.45.zip", @"C:\adb\MIUnlock\miflash_unlock-en-3.5.1128.45.zip");
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
                Strings.MSGBOXFileCorrupted();
                Downloads.downloadcall("Downloading MI Flash...", "https://bitbucket.org/Franco28/flashtool-motorola-moto-g5-g5plus/downloads/MiFlash20181115.zip", @"C:\adb\MIFlash\MiFlash20181115.zip");
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
                Strings.MSGBOXFileCorrupted();
                Downloads.downloadcall("Downloading V11.0.4.0.PFGMIXM Recovery ROM...", "https://bigota.d.miui.com/V11.0.4.0.PFGMIXM/miui_LAVENDERGlobal_V11.0.4.0.PFGMIXM_ab70af5e76_9.0.zip", @"C:\adb\xiaomiglobalrecovery\miui_LAVENDERGlobal_V11.0.4.0.PFGMIXM_ab70af5e76_9.0.zip");
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
            decimal sizeb = 1773338347;
            string fileName = @"C:\adb\xiaomieu\xiaomi.eu_multi_HMNote7_20.1.21_v11-10.zip";
            FileInfo fi = new FileInfo(fileName);

            if (fi.Length < sizeb)
            {
                Strings.MSGBOXFileCorrupted();
                Downloads.downloadcall("Downloading xiaomi.eu_multi_HMNote7_20.1.21_v11-10...", "https://qc1.androidfilehost.com/dl/ppdBGi8VYCMrcKSJ1tvgog/1580287554/4349826312261709661/xiaomi.eu_multi_HMNote7_20.1.21_v11-10.zip", @"C:\adb\xiaomieu\xiaomi.eu_multi_HMNote7_20.1.21_v11-10.zip");
            }
            else
            {
                MessageBox.Show("Xiaomi.eu its already downloaded!", "XiaomiEU ROM", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
