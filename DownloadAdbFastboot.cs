
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

        private void DownloadAdbFastboot_Load(object sender, EventArgs e)
        {
            startDownload();
        }

        private void closeform()
        {
            var visual = new Visual();
            visual.Show();
            base.Dispose(Disposing);
        }

        private void startDownload()
        {
            Thread thread = new Thread(() => {
                client.DownloadProgressChanged += new DownloadProgressChangedEventHandler(client_DownloadProgressChanged);
                client.DownloadFileCompleted += new AsyncCompletedEventHandler(client_DownloadFileCompleted);
                client.DownloadFileAsync(new Uri("https://bitbucket.org/Franco28/flashtool-motorola-moto-g5-g5plus/downloads/adb.zip"), @"C:\adb\adb.zip");
            });
            thread.Start();
        }

        void client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            if (!this.IsDisposed)
            {
                this.BeginInvoke((MethodInvoker)delegate {

                    double bytesIn = double.Parse(e.BytesReceived.ToString());
                    double totalBytes = double.Parse(e.TotalBytesToReceive.ToString());
                    double percentage = bytesIn / totalBytes * 100;
                    TextBox1.Text = "Downloaded " + e.BytesReceived + " Bytes" + " of " + e.TotalBytesToReceive + " Bytes";
                    ProgressBar1.Value = int.Parse(Math.Truncate(percentage).ToString());
                });
            }
            else
            {
                client.Dispose();
                client.CancelAsync();
                this.Controls.Clear();
                base.Refresh();
                MessageBox.Show("Download Canceled!", "Download Engine", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                closeform();
                return;
            }
        }

        void client_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            this.BeginInvoke((MethodInvoker)delegate {
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

                closeform();
            });
        }

    }
}
