// <copyright file=DownloadSplash>
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
    public partial class DownloadSplash : Form
    {

        WebClient client = new WebClient();

        public DownloadSplash()
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

        private void DownloadSplash_Load(object sender, EventArgs e)
        {
            Directory.SetCurrentDirectory(@"C:\adb\.settings\splash.img");

            string[] paths = Directory.GetFiles(@"C:\adb\.settings\", "splash.img");
            if (paths.Length > 0)
            {
                CheckFileSize.SPLASH();
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
                        client.DownloadFileAsync(new Uri("https://bitbucket.org/Franco28/flashtool-motorola-moto-g5-g5plus/downloads/splash.img"), @"C:\adb\.settings\splash.img");
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
                MessageBox.Show("ERROR: Can´t connect to the server to download Mi Splash!", "Network Lost", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show("Download Canceled!", "Mi Splash", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
