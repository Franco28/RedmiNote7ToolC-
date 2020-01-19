using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Threading;

namespace Franco28Tool.Engine
{
    public partial class DownloadTWRP : Form
    {

        WebClient client = new WebClient();

        public DownloadTWRP()
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

        private void DownloadTWRP_Load(object sender, EventArgs e)
        {
            Directory.SetCurrentDirectory(@"C:\adb\TWRP");

            string[] paths = Directory.GetFiles(@"C:\adb\TWRP\", "OrangeFox-R10.1_01-Stable-lavender.zip");
            if (paths.Length > 0)
            {
                CheckFileSize.TWRP();
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
                        client.DownloadFileAsync(new Uri("https://files.orangefox.tech/OrangeFox-Stable/lavender/OrangeFox-R10.1_01-Stable-lavender.zip"), @"C:\adb\TWRP\OrangeFox-R10.1_01-Stable-lavender.zip");
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
                        Unzip.Unzippy(@"TWRP\OrangeFox-R10.1_01-Stable-lavender.zip", @"TWRP", true);
                        KillAsync();
                        closeform();
                    }
                });
            }
        }
    }
}
