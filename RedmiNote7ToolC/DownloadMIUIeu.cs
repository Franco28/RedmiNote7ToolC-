
/* (C) 2019 Franco28 */
/* Basic Tool C# for Redmi Note 7 */

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

            decimal sizeb = 1721354054;

            string fileName = @"C:\adb\xiaomieu\xiaomi.eu_multi_HMNote7_9.12.5_v11-9.zip";
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

            string[] paths = Directory.GetFiles(@"C:\adb\xiaomieu\", "xiaomi.eu_multi_HMNote7_9.12.5_v11-9.zip");
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
                    client.DownloadFileAsync(new Uri("https://va1.androidfilehost.com/dl/G1miAJwUybY-mb_C36buBg/1576118704/4349826312261653424/xiaomi.eu_multi_HMNote7_9.12.5_v11-9.zip"), @"C:\adb\xiaomieu\xiaomi.eu_multi_HMNote7_9.12.5_v11-9.zip");
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
