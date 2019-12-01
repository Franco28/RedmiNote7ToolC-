
/* (C) 2019 Franco28 */
/* Basic Tool for Redmi Note 7 */

using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.IO.Compression;
using System.Net;
using System.IO;
using System.Threading;

namespace RedmiNote7ToolC
{
    public partial class DownloadAdbFastboot : Form
    {

        WebClient client = new WebClient();

        public DownloadAdbFastboot()
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
            var visual = new Visual();
            visual.Refresh();
            return;
        }

        private void DownloadAdbFastboot_Load(object sender, EventArgs e)
        {
            startDownload();
        }

        public void startDownload()
        {
            if (!this.IsDisposed)
            {
                Thread thread = new Thread(() =>
                {
                    client.DownloadProgressChanged += new DownloadProgressChangedEventHandler(client_DownloadProgressChanged);
                    client.DownloadFileCompleted += new AsyncCompletedEventHandler(client_DownloadFileCompleted);
                    client.DownloadFileAsync(new Uri("https://bitbucket.org/Franco28/flashtool-motorola-moto-g5-g5plus/downloads/adb.zip"), @"C:\adb\adb.zip");
                });

                thread.Start();
            }
            else
            {
                KillAsync();
            }
        }

        private void client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            try
            {
                if (!this.IsDisposed)
                {
                    this.BeginInvoke((MethodInvoker)delegate
                    {
                        double bytesIn = double.Parse(e.BytesReceived.ToString());
                        double totalBytes = double.Parse(e.TotalBytesToReceive.ToString());
                        double percentage = bytesIn / totalBytes * 100;
                        TextBox1.Text = "Downloaded " + e.BytesReceived + " Bytes" + " of " + e.TotalBytesToReceive + " Bytes";
                        textBox2.Text = percentage + " %";
                        ProgressBar1.Value = int.Parse(Math.Truncate(percentage).ToString());
                    });
                }
                else
                {
                    client.Dispose();
                    client.CancelAsync();
                    KillAsync();
                }
            }
            catch (Exception er)
            {
                MessageBox.Show("Error:" + er, "Download Engine Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                KillAsync();
            }
        }

        void client_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
                if (!this.IsDisposed)
                {
                    this.BeginInvoke((MethodInvoker)delegate
                    {

                        TextBox1.Text = "Download completed... Extracting files!";

                        Directory.SetCurrentDirectory(@"C:\adb");

                        string zipPath = "adb.zip";
                        string extractPath = @"C:\adb";

                        ZipFile.ExtractToDirectory(zipPath, extractPath);

                        string FileToDelete;

                        FileToDelete = @"C:\adb\adb.zip";

                        if (System.IO.File.Exists(FileToDelete) == true)
                            System.IO.File.Delete(FileToDelete);

                        MessageBox.Show(@"adb & fastboot installed in C:\adb", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        KillAsync();
                    });
                }
                else
                {
                    KillAsync();
                }
        }

        public void DownloadAdbFastboot_Disposed(object sender, EventArgs e)
        {
            File.Delete(@"C:\adb\.settings\net.txt");
            this.Controls.Clear();
            base.Refresh();
            Application.Restart();
            base.Dispose(Disposing);
        }

    }
}
