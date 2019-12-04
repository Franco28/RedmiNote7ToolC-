
/* (C) 2019 Franco28 */
/* Basic Tool C# for Redmi Note 7 */

using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Threading;
using Microsoft.VisualBasic.FileIO;

namespace RedmiNote7ToolC
{
    public partial class DownloadMIUIeu : Form
    {
        public DownloadMIUIeu()
        {
            InitializeComponent();
        }

        private FileInfo infoReader;
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

            infoReader = new System.IO.FileInfo("xiaomi.eu_multi_HMNote7_9.11.28_v11-9.zip");
            infoReader = FileSystem.GetFileInfo(@"C:\adb\xiaomieu\xiaomi.eu_multi_HMNote7_9.11.28_v11-9.zip");

            System.Threading.Thread.Sleep(3000);

            if (infoReader.Length > 1600000000)
            {
                System.Threading.Thread.Sleep(1000);

                KillAsync();
                closeform();
            }
            else
            {
                MessageBox.Show(@"File is corrupted \: , downloading again!", "Xiaomi Recovery ROM", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                startDownload();
            }
        }

        private void DownloadMIUIeu_Load(object sender, EventArgs e)
        {
            Directory.SetCurrentDirectory(@"C:\adb\xiaomieu\");

            string[] paths = Directory.GetFiles(@"C:\adb\xiaomieu\", "xiaomi.eu_multi_HMNote7_9.11.28_v11-9.zip");
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
                    client.DownloadFileAsync(new Uri("https://or1.androidfilehost.com/dl/1JG1cjBy8l5sxnXM9EqDzg/1575646034/4349826312261648885/xiaomi.eu_multi_HMNote7_9.11.28_v11-9.zip"), @"C:\adb\xiaomieu\xiaomi.eu_multi_HMNote7_9.11.28_v11-9.zip");
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
