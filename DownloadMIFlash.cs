
/* (C) 2019 Franco28 */
/* Basic Tool C# for Redmi Note 7 */

using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.IO.Compression;
using System.Net;
using System.IO;
using System.Threading;
using Microsoft.VisualBasic.FileIO;

namespace RedmiNote7ToolC
{
    public partial class DownloadMIFlash : Form
    {
        public DownloadMIFlash()
        {
            InitializeComponent();
        }

        private FileInfo infoReader;
        WebClient client = new WebClient();

        private void unzip(object file, string filepath)
        {
            string zipPath = @"C:\adb\" + file;
            string extractPath = @"C:\adb\" + filepath;

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

        private void checkfiles()
        {
            TextBox1.Text = "Checking file...";

            infoReader = new System.IO.FileInfo("MiFlash20181115.zip");
            infoReader = FileSystem.GetFileInfo(@"C:\adb\MIFlash\MiFlash20181115.zip");

            System.Threading.Thread.Sleep(3000);

            if (infoReader.Length > 75900000)
            {
                System.Threading.Thread.Sleep(1000);

                KillAsync();
                closeform();
            }
            else
            {
                MessageBox.Show(@"File is corrupted \: , downloading again!", "Mi Flash", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                startDownload();
            }
        }

        private void DownloadMIFlash_Load(object sender, EventArgs e)
        {
            Directory.SetCurrentDirectory(@"C:\adb\MIFlash\");

            string[] paths = Directory.GetFiles(@"C:\adb\MIFlash\", "MiFlash20181115.zip");
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
            if (!this.IsDisposed)
            {
                Thread thread = new Thread(() =>
                {
                    client.DownloadProgressChanged += new DownloadProgressChangedEventHandler(client_DownloadProgressChanged);
                    client.DownloadFileCompleted += new AsyncCompletedEventHandler(client_DownloadFileCompleted);
                    client.DownloadFileAsync(new Uri("https://bitbucket.org/Franco28/flashtool-motorola-moto-g5-g5plus/downloads/MiFlash20181115.zip"), @"C:\adb\MIFlash\MiFlash20181115.zip");
                });
                thread.Start();
            }
            else
            {
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
                KillAsync();
                closeform();
            }
            else
            {
                this.BeginInvoke((MethodInvoker)delegate
                {
                    if (!this.IsDisposed)
                    {
                        TextBox1.Text = "Download completed... Extracting files, this will take a while...";

                        unzip(@"MIFlash\MiFlash20181115.zip", @"MIFlash");

                        string FileToDelete;

                        FileToDelete = @"C:\adb\MIFlash\MiFlash20181115.zip";

                        if (System.IO.File.Exists(FileToDelete) == true)
                            System.IO.File.Delete(FileToDelete);

                        KillAsync();
                        closeform();
                    }
                });
            }
        }
    }
}
