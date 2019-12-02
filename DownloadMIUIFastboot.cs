
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
    public partial class DownloadMIUIFastboot : Form
    {
        private FileInfo infoReader;
        WebClient client = new WebClient();

        public DownloadMIUIFastboot()
        {
            InitializeComponent();
        }

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

        private void checkfiles()
        {
            TextBox1.Text = "Checking file...";

            infoReader = new System.IO.FileInfo("lavender_global_images_V11.0.4.0.PFGMIXM_20191110.0000.00_9.0_global_774a3e8c73.tgz");
            infoReader = FileSystem.GetFileInfo(@"C:\adb\xiaomiglobalfastboot\lavender_global_images_V11.0.4.0.PFGMIXM_20191110.0000.00_9.0_global_774a3e8c73.tgz");

            System.Threading.Thread.Sleep(3000);

            if (infoReader.Length > 3100000000)
            {
                System.Threading.Thread.Sleep(1000);

                KillAsync();
            }
            else
            {
                MessageBox.Show(@"File is corrupted \: , downloading again!", "Fastboot Firmware", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                startDownload();
            }
        }

        private void DownloadMIUIFastboot_Load(object sender, EventArgs e)
        {
            Directory.SetCurrentDirectory(@"C:\adb\xiaomiglobalfastboot");

            string[] paths = Directory.GetFiles(@"C:\adb\xiaomiglobalfastboot\", "lavender_global_images_V11.0.4.0.PFGMIXM_20191110.0000.00_9.0_global_774a3e8c73.tgz");
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
                    client.DownloadFileAsync(new Uri("http://bigota.d.miui.com/V11.0.4.0.PFGMIXM/lavender_global_images_V11.0.4.0.PFGMIXM_20191110.0000.00_9.0_global_774a3e8c73.tgz"), @"C:\adb\xiaomiglobalfastboot\lavender_global_images_V11.0.4.0.PFGMIXM_20191110.0000.00_9.0_global_774a3e8c73.tgz");
                });

                thread.Start();
            }
            else
            {
                KillAsync();
            }
        }

        void client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
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
                    client.Dispose();
                    client.CancelAsync();

                    TextBox1.Text = "Download completed... Extracting files, this will take a while...";

                    unzip(@"xiaomiglobalfastboot\lavender_global_images_V11.0.4.0.PFGMIXM_20191110.0000.00_9.0_global_774a3e8c73.tgz", @"xiaomiglobalfastboot\MI");

                    string FileToDelete;

                    FileToDelete = @"C:\adb\xiaomiglobalfastboot\lavender_global_images_V11.0.4.0.PFGMIXM_20191110.0000.00_9.0_global_774a3e8c73.tgz";

                    if (System.IO.File.Exists(FileToDelete) == true)
                        System.IO.File.Delete(FileToDelete);

                    KillAsync();
                });
            }
            else
            {
                KillAsync();
            }
        }

        private void DownloadMIUIFastboot_Closed(object sender, EventArgs e)
        {
            client.Dispose();
            client.CancelAsync();
            MessageBox.Show("Download Canceled!", "Download Engine", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            KillAsync();
        }

    }
}
