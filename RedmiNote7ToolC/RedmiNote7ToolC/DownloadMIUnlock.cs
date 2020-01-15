// <copyright file=DownloadMIUnlock>
// Copyright (c) 2019-2020 All Rights Reserved
// </copyright>
// <author>Franco28</author>
// <date> 15/1/2020 14:08:29</date>
// <summary>A simple Tool based on C# for Xiaomi Redmi Note 7 Lavender</summary>

using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.IO.Compression;
using System.Net;
using System.IO;
using System.Threading;
using Microsoft.VisualBasic.FileIO;

namespace RedmiNote7ToolC
{
    public partial class DownloadMIUnlock : Form
    {
        public DownloadMIUnlock()
        {
            InitializeComponent();
        }

        WebClient client = new WebClient();

        private void unzip(object file, string filepath)
        {
            string zipPath = @"C:\adb\" + file;
            string extractPath = @"C:\adb\" + filepath;

            ZipFile.ExtractToDirectory(zipPath, extractPath);
        }

        public void KillAsync()
        {
            client.Dispose();
            client.CancelAsync();
            this.Controls.Clear();
            this.Refresh();
            base.Dispose(Disposing);
            var visual = new Visual();
            visual.Refresh();
            return;
        }

        private void closeform()
        {
            var visual = new Visual();
            visual.Refresh();
            base.Dispose(Disposing);
        }

        public void checkfiles()
        {
            TextBox1.Text = "Checking file...";

            System.Threading.Thread.Sleep(2000);

            decimal sizeb = 48100000;

            string fileName = @"C:\adb\MIUnlock\miflash_unlock-en-3.5.1128.45.zip";
            FileInfo fi = new FileInfo(fileName);

            if (fi.Length < sizeb)
            {
                MessageBox.Show(@"File is corrupted \: , downloading again!", "Mi Unlock", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                startDownload();
            }
            else
            {
                System.Threading.Thread.Sleep(1000);

                KillAsync();

                unzip(@"MIUnlock\miflash_unlock-en-3.5.1128.45.zip", @"MIUnlock");

                string FileToDelete;

                FileToDelete = @"C:\adb\MIUnlock\miflash_unlock-en-3.5.1128.45.zip";

                if (System.IO.File.Exists(FileToDelete) == true)
                    System.IO.File.Delete(FileToDelete);

                closeform();
            }
        }

        private void DownloadMIUnlock_Load(object sender, EventArgs e)
        {
            Directory.SetCurrentDirectory(@"C:\adb\MIUnlock\");

            string[] paths = Directory.GetFiles(@"C:\adb\MIUnlock\", "miflash_unlock-en-3.5.1128.45.zip");
            if (paths.Length > 0)
            {
                checkfiles();
            }
            else
            {
                startDownload();
            }
        }

        public void startDownload()
        {
            if (!this.IsDisposed)
            {
                Thread thread = new Thread(() =>
                {
                    client.DownloadProgressChanged += new DownloadProgressChangedEventHandler(client_DownloadProgressChanged);
                    client.DownloadFileCompleted += new AsyncCompletedEventHandler(client_DownloadFileCompleted);
                    client.DownloadFileAsync(new Uri("http://miuirom.xiaomi.com/rom/u1106245679/3.5.1128.45/miflash_unlock-en-3.5.1128.45.zip"), @"C:\adb\MIUnlock\miflash_unlock-en-3.5.1128.45.zip");
                });
                thread.Start();
            }
            else
            {
                KillAsync();
                closeform();
            }
        }

        void client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            if (this.IsDisposed)
            {
                client.Dispose();
                client.CancelAsync();
                KillAsync();
                closeform();
                MessageBox.Show("Download Canceled!", "Download Engine", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                this.BeginInvoke((MethodInvoker)delegate
                {
                    if (!this.IsDisposed)
                    {
                        double bytesIn = double.Parse(e.BytesReceived.ToString());
                        double totalBytes = double.Parse(e.TotalBytesToReceive.ToString());
                        double percentage = bytesIn / totalBytes * 100;
                        TextBox1.Text = "Downloaded " + e.BytesReceived + " Bytes" + " of " + e.TotalBytesToReceive + " Bytes";
                        textBox2.Text = percentage + " %";
                        ProgressBar1.Value = int.Parse(Math.Truncate(percentage).ToString());
                    }
                });
            }
        }

        void client_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            if (this.IsDisposed)
            {
                client.Dispose();
                client.CancelAsync();
                MessageBox.Show("Download Canceled!", "Mi Unlock", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                KillAsync();
                closeform();
            }
            else
            {
                this.BeginInvoke((MethodInvoker)delegate
                {
                    if (!this.IsDisposed)
                    {
                        TextBox1.Text = "Download completed... Extracting files, this will take a while...";

                        unzip(@"MIUnlock\miflash_unlock-en-3.5.1128.45.zip", @"MIUnlock");

                        string FileToDelete;

                        FileToDelete = @"C:\adb\MIUnlock\miflash_unlock-en-3.5.1128.45.zip";

                        if (System.IO.File.Exists(FileToDelete) == true)
                            System.IO.File.Delete(FileToDelete);

                        KillAsync();
                        closeform();
                    }
                });
            }
        }
    }
}
