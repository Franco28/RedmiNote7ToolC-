
/* (C) 2019 Franco28 */
/* Basic Tool C# for Redmi Note 7 */

using System;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;

namespace RedmiNote7ToolC
{
    public partial class splash : Form
    {

        private BackgroundWorker bw = new BackgroundWorker();

        public splash()
        {
            InitializeComponent();
            bw.WorkerReportsProgress = true;
            bw.WorkerSupportsCancellation = true;
            bw.DoWork += new DoWorkEventHandler(bw_DoWork);
            bw.ProgressChanged += new ProgressChangedEventHandler(bw_ProgressChanged);
            bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bw_RunWorkerCompleted);
        }

        public object Dispatcher { get; private set; }
        public object data { get; private set; }

        public bool Ping(string host)
        {
            System.Net.NetworkInformation.Ping p = new System.Net.NetworkInformation.Ping();
            if (p.Send(host, 500).Status == System.Net.NetworkInformation.IPStatus.Success)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void closeform()
        {
            var visual = new Visual();
            visual.Show();
            this.Controls.Clear();
            this.Refresh();
            this.Dispose(Disposing);
        }

        private void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;

            for (int i = 1; (i <= 10); i++)
            {
                if ((worker.CancellationPending == true))
                {
                    e.Cancel = true;
                    break;
                }
                else
                {
                    // Perform a time consuming operation and report progress.
                    System.Threading.Thread.Sleep(300);
                    worker.ReportProgress((i * 10));
                }
            }
        }

        private void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if ((e.Cancelled == true))
            {
                this.label1.Text = "Canceled!";
            }

            else if (!(e.Error == null))
            {
                this.label1.Text = ("Error: " + e.Error.Message);
            }

            else
            {
                this.label1.Text = "Done!";
                System.Threading.Thread.Sleep(500);
                this.label1.Text = "Starting...";
                closeform();
            }
        }

        private void bw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(@"C:\adb");

            this.label1.Text = @"Checking files... C:\adb\ " + (e.ProgressPercentage.ToString() + "%");
            progressBar1.Value = int.Parse(e.ProgressPercentage.ToString());

            if (dir.Exists)
            {
                Directory.SetCurrentDirectory(@"C:\adb");
            }
            else if ((!System.IO.Directory.Exists(@"C:\adb")))
            {
                System.IO.Directory.CreateDirectory(@"C:\adb");
                this.label1.Text = @" adb folder created" + (e.ProgressPercentage.ToString() + "%");
            }

            if (!Directory.Exists(@"C:\adb\.settings"))
            {
                Directory.CreateDirectory(@"C:\adb\.settings");
                this.label1.Text = @" adb\.settings folder created" + (e.ProgressPercentage.ToString() + "%");
            }

            if (!Directory.Exists(@"C:\adb\TWRP"))
            {
                Directory.CreateDirectory(@"C:\adb\TWRP");
                this.label1.Text = @" adb\TWRP folder created" + (e.ProgressPercentage.ToString() + "%");
            }

            if (!Directory.Exists(@"C:\adb\MI"))
            {
                Directory.CreateDirectory(@"C:\adb\MI");
                this.label1.Text = @" adb\MI folder created" + (e.ProgressPercentage.ToString() + "%");
            }

            if (!Directory.Exists(@"C:\adb\MIUnlock"))
            {
                Directory.CreateDirectory(@"C:\adb\MIUnlock");
                this.label1.Text = @" adb\MIUnlock folder created" + (e.ProgressPercentage.ToString() + "%");
            }

            if (!Directory.Exists(@"C:\adb\xiaomiglobalfastboot"))
            {
                Directory.CreateDirectory(@"C:\adb\xiaomiglobalfastboot");
                this.label1.Text = @" adb\xiaomiglobalfastboot folder created" + (e.ProgressPercentage.ToString() + "%");
            }

            if (!Directory.Exists(@"C:\adb\xiaomieu"))
            {
                Directory.CreateDirectory(@"C:\adb\xiaomieu");
                this.label1.Text = @" adb\xiaomieu folder created" + (e.ProgressPercentage.ToString() + "%");
            }

            if (!Directory.Exists(@"C:\adb\xiaomiglobalrecovery"))
            {
                Directory.CreateDirectory(@"C:\adb\xiaomiglobalrecovery");
                this.label1.Text = @" adb\xiaomiglobalrecovery folder created" + (e.ProgressPercentage.ToString() + "%");
            }


        }

        private void splash_Load(object sender, EventArgs e)
        {
            if (bw.IsBusy != true)
            {
                bw.RunWorkerAsync();
            }

        }

        private void splash_Closed(object sender, EventArgs e)
        {
            this.Controls.Clear();
            this.Refresh();
            this.Dispose(Disposing);

            Application.ExitThread();
        }
    }
}
