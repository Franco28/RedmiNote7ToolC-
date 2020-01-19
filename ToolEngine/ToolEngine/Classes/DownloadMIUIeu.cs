// <copyright file=DownloadMIUIeu>
// Copyright (c) 2019-2020 All Rights Reserved
// </copyright>
// <author>Franco28</author>
// <date> 19/1/2020 18:01:53</date>
// <summary>A DLL Lib needed by Redmi Note 7 Tool</summary>
using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Threading;

namespace Franco28Tool.Engine
{
    public partial class DownloadMIUIeu : Form
    {

        WebClient client = new WebClient();

        public DownloadMIUIeu()
        {
            InitializeComponent();
        }

        public void KillAsync()
        {
            client.Dispose();
            client.CancelAsync();
            this.Controls.Clear();
            this.Refresh();
            base.Dispose(Disposing);
            this.Refresh();
            client.Dispose();
            client.CancelAsync();
            return;
        }

        private void closeform()
        {
            this.Refresh();
            base.Dispose(Disposing);
        }

        private void DownloadMIUIeu_Load(object sender, EventArgs e)
        {
            Directory.SetCurrentDirectory(@"C:\adb\xiaomieu\xiaomi.eu_multi_HMNote7_20.1.16_v11-10.zip");

            string[] paths = Directory.GetFiles(@"C:\adb\xiaomieu\", "xiaomi.eu_multi_HMNote7_20.1.16_v11-10.zip");
            if (paths.Length > 0)
            {
                CheckFileSize.MIXiaomieuROM();
            }
            else
            {
                startDownload();
            }
        }

        private void startDownload()
        {
            if (InternetCheck.Ping("www.google.com") == true)
            {
                if (!this.IsDisposed)
                {
                    Thread thread = new Thread(() =>
                    {
                        client.DownloadProgressChanged += new DownloadProgressChangedEventHandler(client_DownloadProgressChanged);
                        client.DownloadFileCompleted += new AsyncCompletedEventHandler(client_DownloadFileCompleted);
                        client.DownloadFileAsync(new Uri("https://qc5.androidfilehost.com/dl/S9oQnzzY8Bu7VUdlzvjb5w/1579692787/4349826312261702702/xiaomi.eu_multi_HMNote7_20.1.16_v11-10.zip"), @"C:\adb\xiaomieu\xiaomi.eu_multi_HMNote7_20.1.16_v11-10.zip");
                    });
                    thread.Start();
                }
                else
                {
                    KillAsync();
                    closeform();
                }
            }
            else
            {
                MessageBox.Show("ERROR: Can´t connect to the server to download Mi Xiaomi eu ROM!", "Network Lost", MessageBoxButtons.OK, MessageBoxIcon.Error);
                client.Dispose();
                client.CancelAsync();
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
                MessageBox.Show("Download Canceled!", "Mi Xiaomi eu ROM", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                        try
                        {
                            Folders.OpenFolder(@"adb\xiaomieu");
                        }
                        catch (Exception er)
                        {
                            MessageBox.Show("Error: " + er, "Open Folder", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        KillAsync();
                        closeform();
                    }
                });
            }
        }
    }
}
