// <copyright file=DownloadMIUIeu>
// Copyright (c) 2019-2020 All Rights Reserved
// </copyright>
// <author>Franco28</author>
// <date> 1/1/2020 16:46:20</date>
// <summary>A basic simple Tool based on C# for Xiaomi Redmi Note 7 Lavender </summary>




using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Threading;
using Microsoft.VisualBasic;
using System.Diagnostics;

namespace RedmiNote7ToolC
{
    public partial class DownloadMIUIeu : Form
    {
        public DownloadMIUIeu()
        {
            InitializeComponent();
        }

        WebClient client = new WebClient();

        public void OpenFolder(object folderpath)
        {
            string Proc = "Explorer.exe";
            string Args = ControlChars.Quote + System.IO.Path.Combine(@"C:\" + folderpath) + ControlChars.Quote;
            Process.Start(Proc, Args);
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

            decimal sizeb = 1726270105;

            string fileName = @"C:\adb\xiaomieu\xiaomi.eu_multi_HMNote7_9.12.12_v11-9.zip";
            FileInfo fi = new FileInfo(fileName);

            if (fi.Length < sizeb)

            {
                MessageBox.Show(@"File is corrupted \: , downloading again!", "Xiaomi.eu ROM", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                startDownload();
            }
            else
            {
                System.Threading.Thread.Sleep(1000);

                KillAsync();
                MessageBox.Show("Xiaomi.eu it´s already downloaded!", "Xiaomi.eu", MessageBoxButtons.OK, MessageBoxIcon.Information);
                try
                {
                    OpenFolder(@"adb\xiaomieu");
                }
                catch (Exception er)
                {
                    MessageBox.Show("Error: " + er, "Open Folder", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                closeform();
            }
        }

        private void DownloadMIUIeu_Load(object sender, EventArgs e)
        {
            Directory.SetCurrentDirectory(@"C:\adb\xiaomieu\");

            string[] paths = Directory.GetFiles(@"C:\adb\xiaomieu\", "xiaomi.eu_multi_HMNote7_9.12.12_v11-9.zip");
            if (paths.Length > 0)
            {
                checkfiles();
            }
            else
            {
                MessageBox.Show("Can´t find Xiaomi.eu ROM...", "Xiaomi.eu ROM Missing", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                    client.DownloadFileAsync(new Uri("https://va2.androidfilehost.com/dl/BDaILW1VHWlZ8MTdk6CWVw/1576499584/4349826312261670807/xiaomi.eu_multi_HMNote7_9.12.12_v11-9.zip"), @"C:\adb\xiaomieu\xiaomi.eu_multi_HMNote7_9.12.12_v11-9.zip");
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
                MessageBox.Show("Download Canceled!", "Xiaomi.eu ROM", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
