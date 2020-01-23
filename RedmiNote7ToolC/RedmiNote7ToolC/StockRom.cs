// <copyright file=StockRom>
// Copyright (c) 2019-2020 All Rights Reserved
// </copyright>
// <author>Franco28</author>
// <date> 22/1/2020 23:39:56</date>
// <summary>A simple Tool based on C# for Xiaomi Redmi Note 7 Lavender</summary>

using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Threading;

namespace RedmiNote7ToolC
{
    public partial class StockRom : Form
    {
        WebClient client = new WebClient();

        public StockRom()
        {
            InitializeComponent();
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

            decimal sizeb = 47500000;

            string fileName = @"C:\adb\StockRom\";
            FileInfo fi = new FileInfo(fileName);

            if (fi.Length < sizeb)
            {
                MessageBox.Show(@"File is corrupted \: , downloading again!", "StockRom", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                startDownload();
            }
            else
            {
                KillAsync();
                closeform();
            }
        }

        private void StockRom_Load(object sender, EventArgs e)
        {
            Directory.SetCurrentDirectory(@"C:\adb\StockRom");
        }

        private void downloadrom_Click(object sender, EventArgs e)
        {
            MessageBox.Show(@"This is not ready yet!", "StockRom", MessageBoxButtons.OK, MessageBoxIcon.Information);
            KillAsync();
            closeform();
            KillAsync();
            closeform();
            string[] paths = Directory.GetFiles(@"C:\adb\StockRom\", "");
                if (paths.Length > 0)
                {
                    checkfiles();
                }
                else
                {
                    startDownload();
                }                       
        }

        private void startDownload()
        {
                if (Ping("www.google.com") == true)
                {
                    if (!this.IsDisposed)
                    {
                        Thread thread = new Thread(() =>
                        {
                            client.DownloadProgressChanged += new DownloadProgressChangedEventHandler(client_DownloadProgressChanged);
                            client.DownloadFileCompleted += new AsyncCompletedEventHandler(client_DownloadFileCompleted);
                            client.DownloadFileAsync(new Uri(" "), @"C:\adb\StockRom\");
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
                    MessageBox.Show("ERROR: Can´t connect to the server to download StockRom!", "Network Lost", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        progressBar1.Value = int.Parse(Math.Truncate(percentage).ToString());
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
                MessageBox.Show("Download Canceled!", "StockRom", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                KillAsync();
                closeform();
            }
            else
            {
                this.BeginInvoke((MethodInvoker)delegate
                {
                    if (!this.IsDisposed)
                    {
                        TextBox1.Text = "Download completed...";
                        KillAsync();
                        closeform();
                    }
                });
            }
        }
    }
}
