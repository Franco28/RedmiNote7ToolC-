// <copyright file=DownloadMIUIFastboot>
// Copyright (c) 2019-2020 All Rights Reserved
// </copyright>
// <author>Franco28</author>
// <date> 15/1/2020 14:08:29</date>
// <summary>A simple Tool based on C# for Xiaomi Redmi Note 7 Lavender</summary>

using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Threading;
using Franco28Tool.Engine;

namespace RedmiNote7ToolC
{
    public partial class DownloadMIUIFastboot : Form
    {

        public DownloadMIUIFastboot()
        {
            InitializeComponent();
        }

        WebClient client = new WebClient();

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

        private void checkfiles()
        {

            TextBox1.Text = "Checking file...";

            System.Threading.Thread.Sleep(2000);

            decimal sizeb = 3287682;

            string fileName = @"C:\adb\xiaomiglobalfastboot\lavender_global_images_V11.0.4.0.PFGMIXM_20191110.0000.00_9.0_global_774a3e8c73.tgz";
            FileInfo fi = new FileInfo(fileName);

            if (fi.Length < sizeb)
            {
                MessageBox.Show(@"File is corrupted \: , downloading again!", "Fastboot Firmware", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                startDownload();
            }
            else
            {
                System.Threading.Thread.Sleep(1000);
                KillAsync();
                MessageBox.Show("Fastboot Firmware it´s already downloaded! Extracting, please wait!", "Fastboot Firmware", MessageBoxButtons.OK, MessageBoxIcon.Information);

                string archive = @"C:\adb\xiaomiglobalfastboot\lavender_global_images_V11.0.4.0.PFGMIXM_20191110.0000.00_9.0_global_774a3e8c73.tgz",
           archiveDirectory = Path.GetDirectoryName(Path.GetFullPath(archive)),
           unpackDirectoryName = Guid.NewGuid().ToString();

                ZipFileWithProgress.ExtractToDirectory(archive, unpackDirectoryName,
                    new BasicProgress<double>(p => Console.WriteLine($"{p:P0} extracting complete")));
            }
        }

        private void DownloadMIUIFastboot_Load(object sender, EventArgs e)
        {
            Directory.SetCurrentDirectory(@"C:\adb\xiaomiglobalfastboot");

            string[] paths = Directory.GetFiles(@"C:\adb\xiaomiglobalfastboot\", "lavender_global_images_V11.0.4.0.PFGMIXM_20191110.0000.00_9.0_global_774a3e8c73.tgz");
            if (paths.Length > 0)
            {
                checkfiles();
            }
            else
            {
                MessageBox.Show("Can´t find Fastboot Firmware...", "Fastboot Firmware Missing", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                    client.DownloadFileAsync(new Uri("http://bigota.d.miui.com/V11.0.4.0.PFGMIXM/lavender_global_images_V11.0.4.0.PFGMIXM_20191110.0000.00_9.0_global_774a3e8c73.tgz"), @"C:\adb\xiaomiglobalfastboot\lavender_global_images_V11.0.4.0.PFGMIXM_20191110.0000.00_9.0_global_774a3e8c73.tgz");
                });
                thread.Start();
            }
            else
            {
                KillAsync();
                closeform();
            }
        }

        private void client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            if (this.IsDisposed)
            {
                client.Dispose();
                client.CancelAsync();
                KillAsync();
                closeform();
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

        private void client_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            if (this.IsDisposed)
            {
                client.Dispose();
                client.CancelAsync();
                MessageBox.Show("Download Canceled!", "Fastboot Firmware", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                KillAsync();
                closeform();
            }
            else
            {
                this.BeginInvoke((MethodInvoker)delegate
                {
                    if (!this.IsDisposed)
                    {
                        TextBox1.Text = "Download completed!";

                        KillAsync();
                        closeform();
                    }
                });
            }
        }

    }
}
