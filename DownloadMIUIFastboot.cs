
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

        private void checkfiles()
        {
            infoReader = new System.IO.FileInfo("lavender_global_images_V11.0.4.0.PFGMIXM_20191110.0000.00_9.0_global_774a3e8c73.tgz");
            infoReader = FileSystem.GetFileInfo(@"C:\adb\xiaomiglobalfastboot\lavender_global_images_V11.0.4.0.PFGMIXM_20191110.0000.00_9.0_global_774a3e8c73.tgz");

            if (infoReader.Length > 3100000000)
            {

                unzip(@"xiaomiglobalfastboot\lavender_global_images_V11.0.4.0.PFGMIXM_20191110.0000.00_9.0_global_774a3e8c73.tgz", @"xiaomiglobalfastboot");

                closeform();
            }
            else
            {
                MessageBox.Show(@"File is corrupted \: , downloading again!", "Xiaomi Firmware", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                startDownload();
            }
        }

        private void closeform()
        {
            var visual = new Visual();
            visual.Dispose();
            base.Dispose(Disposing);
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

        private void startDownload()
        {
            Thread thread = new Thread(() => {
                client.DownloadProgressChanged += new DownloadProgressChangedEventHandler(client_DownloadProgressChanged);
                client.DownloadFileCompleted += new AsyncCompletedEventHandler(client_DownloadFileCompleted);
                client.DownloadFileAsync(new Uri("http://bigota.d.miui.com/V11.0.4.0.PFGMIXM/lavender_global_images_V11.0.4.0.PFGMIXM_20191110.0000.00_9.0_global_774a3e8c73.tgz"), @"C:\adb\xiaomiglobalfastboot\lavender_global_images_V11.0.4.0.PFGMIXM_20191110.0000.00_9.0_global_774a3e8c73.tgz");
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

                unzip(@"xiaomiglobalfastboot\lavender_global_images_V11.0.4.0.PFGMIXM_20191110.0000.00_9.0_global_774a3e8c73.tgz", @"xiaomiglobalfastboot");

                string FileToDelete;

                FileToDelete = @"C:\adb\xiaomiglobalfastboot\lavender_global_images_V11.0.4.0.PFGMIXM_20191110.0000.00_9.0_global_774a3e8c73.tgz";

                if (System.IO.File.Exists(FileToDelete) == true)
                    System.IO.File.Delete(FileToDelete);

                closeform();

            });
        }

    }
}
