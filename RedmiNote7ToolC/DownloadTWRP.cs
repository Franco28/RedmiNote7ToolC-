// <copyright file=DownloadTWRP>
// Copyright (c) 2019-2020 All Rights Reserved
// </copyright>
// <author>Franco28</author>
// <date> 31/12/2019 19:15:46</date>
// <summary>A basic simple Tool based on C# for Xiaomi Redmi Note 7 Lavender </summary>



using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.IO.Compression;
using System.Net;
using System.IO;
using System.Threading;

namespace RedmiNote7ToolC
{
    public partial class DownloadTWRP : Form
    {
        WebClient client = new WebClient();

        public DownloadTWRP()
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

        private void unzip(object file, string filepath)
        {
            string zipPath = @"C:\adb\"+file;
            string extractPath = @"C:\adb\"+filepath;

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

            decimal sizeb = 47500000;

            string fileName = @"C:\adb\TWRP\OrangeFox-R10.0_3_b001-Beta-lavender.zip";
            FileInfo fi = new FileInfo(fileName);

            if (fi.Length < sizeb)
            {
                MessageBox.Show(@"File is corrupted \: , downloading again!", "TWRP OrangeFox", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                startDownload();
            }
            else
            {
                TextBox1.Text = "Extracting files!";

                System.Threading.Thread.Sleep(1000);

                unzip(@"TWRP\OrangeFox-R10.0_3_b001-Beta-lavender.zip", @"TWRP");

                System.Threading.Thread.Sleep(1000);

                KillAsync();
                closeform();
            }
        }

        private void DownloadTWRP_Load(object sender, EventArgs e)
        {
            Directory.SetCurrentDirectory(@"C:\adb\TWRP");

            string[] paths = Directory.GetFiles(@"C:\adb\TWRP\", "OrangeFox-R10.0_3_b001-Beta-lavender.zip");
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
                            client.DownloadFileAsync(new Uri("https://files.orangefox.tech/OrangeFox-Beta/lavender/OrangeFox-R10.0_3_b001-Beta-lavender.zip"), @"C:\adb\TWRP\OrangeFox-R10.0_3_b001-Beta-lavender.zip");
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
                MessageBox.Show("ERROR: Can´t connect to the server to download TWRP OrangeFox image!", "Network Lost", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show("Download Canceled!", "TWRP OrangeFox", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                KillAsync();
                closeform();
            }
            else
            {
                this.BeginInvoke((MethodInvoker)delegate
                {
                    if (!this.IsDisposed)
                    {
                        TextBox1.Text = "Download completed... Extracting files!";

                        unzip(@"TWRP\OrangeFox-R10.0_3_b001-Beta-lavender.zip", @"TWRP");

                        KillAsync();
                        closeform();
                    }
                });
            }
        }
    }
}
