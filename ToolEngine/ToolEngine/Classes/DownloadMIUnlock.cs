using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Threading;

namespace Franco28Tool.Engine
{
    public partial class DownloadMIUnlock : Form
    {

        WebClient client = new WebClient();

        public DownloadMIUnlock()
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

        private void DownloadMIUnlock_Load(object sender, EventArgs e)
        {
            Directory.SetCurrentDirectory(@"C:\adb\MIUnlock\miflash_unlock-en-3.5.1128.45.zip");

            string[] paths = Directory.GetFiles(@"C:\adb\MIUnlock\", "miflash_unlock-en-3.5.1128.45.zip");
            if (paths.Length > 0)
            {
                CheckFileSize.MIUnlock();
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
                        client.DownloadFileAsync(new Uri("http://miuirom.xiaomi.com/rom/u1106245679/3.5.1128.45/miflash_unlock-en-3.5.1128.45.zip"), @"C:\adb\MIUnlock\miflash_unlock-en-3.5.1128.45.zip");
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
                MessageBox.Show("ERROR: Can´t connect to the server to download Mi Unlock!", "Network Lost", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show("Download Canceled!", "Mi Unlock", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                        Unzip.Unzippy(@"MIUnlock\miflash_unlock-en-3.5.1128.45.zip", @"MIUnlock", true);

                        string FileToDelete;
                        FileToDelete = @"C:\adb\MIUnlock\miflash_unlock-en-3.5.1128.45.zip";

                        if (System.IO.File.Exists(FileToDelete) == true)
                        {
                            System.IO.File.Delete(FileToDelete);
                        }

                        KillAsync();
                        closeform();
                    }
                });
            }
        }
    }
}
