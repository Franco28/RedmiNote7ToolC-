// <copyright file=Splash>
// Copyright (c) 2019-2020 All Rights Reserved
// </copyright>
// <author>Franco28</author>
// <date> 20/1/2020 18:15:10</date>
// <summary>A simple Tool based on C# for Xiaomi Redmi Note 7 Lavender</summary>

using System;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;
using RegawMOD.Android;

namespace RedmiNote7ToolC
{
    public partial class Splash : Form
    {

        private AndroidController android;
        private BackgroundWorker bw = new BackgroundWorker();

        public Splash()
        {
            bw.WorkerReportsProgress = true;
            bw.WorkerSupportsCancellation = true;
            bw.DoWork += new DoWorkEventHandler(bw_DoWork);
            bw.ProgressChanged += new ProgressChangedEventHandler(bw_ProgressChanged);
            bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bw_RunWorkerCompleted);
            android = AndroidController.Instance;
            InitializeComponent();
        }

        private void closeform()
        {
            var visual = new Visual();
            visual.Show();
            this.Controls.Clear();
            this.Refresh();
            this.Dispose(Disposing);
        }

        private void splash_Load(object sender, EventArgs e)
        {
            if (bw.IsBusy != true)
            {
                bw.RunWorkerAsync();
            }

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

                if (!Directory.Exists(@"C:\adb"))
                {
                    var paths = new[] { "C:\\adb\\", "C:\\adb\\StockRom", "C:\\adb\\.settings", "C:\\adb\\TWRP", "C:\\adb\\MIFlash", "C:\\adb\\MIUnlock", "C:\\adb\\xiaomiglobalfastboot\\MI", "C:\\adb\\xiaomieu", "C:\\adb\\xiaomiglobalrecovery" };

                    foreach (var path in paths)
                    {
                        try
                        {
                            if (Directory.Exists(path))
                            {
                                Directory.SetCurrentDirectory(@"C:\adb");
                                continue;
                            }
                            this.label1.Text = @"Creating folders...  C:\adb\";

                            System.Threading.Thread.Sleep(3000);

                            var di = Directory.CreateDirectory(path);
                        }
                        catch (Exception er)
                        {
                            MessageBox.Show("Error: " + er, "Creating Folders: Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        private void bw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Maximum = 100;
            progressBar1.Minimum = 1;
            this.label1.Text = @"Checking files...  C:\adb\ " + (e.ProgressPercentage.ToString() + "%");
            progressBar1.Value = int.Parse(e.ProgressPercentage.ToString());
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
                System.Threading.Thread.Sleep(500);
                this.label1.Text = "Starting...";
                closeform();
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
