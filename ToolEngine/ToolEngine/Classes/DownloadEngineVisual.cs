// <copyright file=DownloadEngineVisual>
// Copyright (c) 2019-2020 All Rights Reserved
// </copyright>
// <author>Franco28</author>
// <date> 29/1/2020 13:16:41</date>
// <summary>A DLL Lib needed by Redmi Note 7 Tool</summary>

using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.Net;
using System.Threading;

namespace Franco28Tool.Engine
{
    public partial class DownloadEngineVisual : Form
    {

        WebClient client = new WebClient();

        public DownloadEngineVisual()
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

        public void closeform()
        {
            this.Refresh();
            base.Dispose(Disposing);
        }

        public void DownloadEngineVisual_Load(object sender, EventArgs e)
        {
            TextBox1.Text = "Checking internet connection...";
        }

        public void startDownload(string url, string filepath)
        {
            System.Threading.Thread.Sleep(3000);
            TextBox1.Text = "Checking internet connection ERROR: Please click the option again!";
            try
            {
                if (InternetCheck.Ping("www.google.com") == true)
                {
                    TextBox1.Text = "Checking internet connection: OK";
                    System.Threading.Thread.Sleep(1000);
                    if (!this.IsDisposed)
                    {
                        Thread thread = new Thread(() =>
                        {
                            client.DownloadProgressChanged += new DownloadProgressChangedEventHandler(client_DownloadProgressChanged);
                            client.DownloadFileCompleted += new AsyncCompletedEventHandler(client_DownloadFileCompleted);
                            client.DownloadFileAsync(new Uri(url), filepath);
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
                    TextBox1.Text = "Checking internet connection: ERROR";
                    MessageBox.Show("ERROR: Can´t connect to the server to download files!", "Network Lost", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    client.Dispose();
                    client.CancelAsync();
                    KillAsync();
                    closeform();
                    base.Dispose(Disposing);
                }
            }
            catch (Exception er)
            {
                MessageBox.Show("ERROR: " + er, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            if (!this.IsDisposed)
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
                    else
                    {
                        client.Dispose();
                        client.CancelAsync();
                        KillAsync();
                        closeform();
                    }
                });
            }
            else
            {
                client.Dispose();
                client.CancelAsync();
                KillAsync();
                closeform();
            }
        }

        public void client_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            if (this.IsDisposed)
            {
                client.Dispose();
                client.CancelAsync();
                MessageBox.Show("Download Canceled!", "Download Engine", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                KillAsync();
                closeform();
            }
            else
            {
                this.BeginInvoke((MethodInvoker)delegate
                {
                    TextBox1.Text = "Download completed!";
                    MessageBox.Show("Files downloaded! Please to execute the action, click again the option!", "Download Engine", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    KillAsync();
                    closeform();
                });
            }
        }
    }
}
