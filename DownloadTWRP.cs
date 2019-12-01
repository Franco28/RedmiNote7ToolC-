
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
    public partial class DownloadTWRP : Form
    {
        private FileInfo infoReader;

        public DownloadTWRP()
        {
            InitializeComponent();
        }

        private void unzip(object file, string filepath)
        {
            string zipPath = @"C:\adb\"+file;
            string extractPath = @"C:\adb\"+filepath;

            ZipFile.ExtractToDirectory(zipPath, extractPath);
        }

        private void checkfiles()
        {
            infoReader = new System.IO.FileInfo("OrangeFox-R10.0_2-Stable-lavender.zip");
            infoReader = FileSystem.GetFileInfo(@"C:\adb\TWRP\OrangeFox-R10.0_2-Stable-lavender.zip");

            if (infoReader.Length > 40900000)
            {

                unzip(@"TWRP\OrangeFox-R10.0_2-Stable-lavender.zip", @"TWRP");

                closeform();
            }
            else
            {
                MessageBox.Show(@"File is corrupted \: , downloading again!", "TWRP", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                startDownload();
            }
        }

        private void closeform()
        {
            var visual = new Visual();
            visual.Refresh();
            base.Dispose(Disposing);
        }

        private void DownloadTWRP_Load(object sender, EventArgs e)
        {
            Directory.SetCurrentDirectory(@"C:\adb\TWRP");

            string[] paths = Directory.GetFiles(@"C:\adb\TWRP\", "OrangeFox-R10.0_2-Stable-lavender.zip");
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
                WebClient client = new WebClient();
                client.DownloadProgressChanged += new DownloadProgressChangedEventHandler(client_DownloadProgressChanged);
                client.DownloadFileCompleted += new AsyncCompletedEventHandler(client_DownloadFileCompleted);
                client.DownloadFileAsync(new Uri("https://files.orangefox.tech/OrangeFox-Stable/lavender/OrangeFox-R10.0_2-Stable-lavender.zip"), @"C:\adb\TWRP\OrangeFox-R10.0_2-Stable-lavender.zip");
            });
            thread.Start();
        }

        void client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            this.BeginInvoke((MethodInvoker)delegate {
                double bytesIn = double.Parse(e.BytesReceived.ToString());
                double totalBytes = double.Parse(e.TotalBytesToReceive.ToString());
                double percentage = bytesIn / totalBytes * 100;
                TextBox1.Text = "Downloaded " + e.BytesReceived + " Bytes" + " of " + e.TotalBytesToReceive + " Bytes";
                ProgressBar1.Value = int.Parse(Math.Truncate(percentage).ToString());
            });
        }

        void client_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            this.BeginInvoke((MethodInvoker)delegate {
                TextBox1.Text = "Download completed... Extracting files!";

                unzip(@"TWRP\OrangeFox-R10.0_2-Stable-lavender.zip", @"TWRP");

                closeform();

            });
        }

    }
}
