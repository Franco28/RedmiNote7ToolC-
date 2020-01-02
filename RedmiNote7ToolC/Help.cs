// <copyright file=Help>
// Copyright (c) 2019-2020 All Rights Reserved
// </copyright>
// <author>Franco28</author>
// <date> 1/1/2020 16:57:11</date>
// <summary>A basic simple Tool based on C# for Xiaomi Redmi Note 7 Lavender </summary>




using System;
using System.Windows.Forms;

namespace RedmiNote7ToolC
{
    public partial class Help : Form
    {
        public Help()
        {
            InitializeComponent();
        }

        private void Help_Load(object sender, EventArgs e)
        {
            label1.Text = "Hey! " + Environment.UserName + " thanks for using this simple tool, if you have any problem you can contact me!";
            label2.Text = "© 2019 Franco28: A simple IT student - Argentina";
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (System.IO.File.Exists(@"C:\Program Files (x86)\Google\Chrome\Application\chrome.exe") & System.IO.File.Exists(@"C:\Program Files\Google\Chrome\Application\chrome.exe") == true)
            {
                BrowserCheck.StartBrowser("MicrosoftEdge.exe", "https://github.com/Franco28/RedmiNote7ToolC-");
            }
            else
            {
                BrowserCheck.StartBrowser("Chrome.exe", "https://github.com/Franco28/RedmiNote7ToolC-");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (System.IO.File.Exists(@"C:\Program Files (x86)\Google\Chrome\Application\chrome.exe") & System.IO.File.Exists(@"C:\Program Files\Google\Chrome\Application\chrome.exe") == true)
            {
                BrowserCheck.StartBrowser("MicrosoftEdge.exe", "https://t.me/francom28");
            }
            else
            {
                BrowserCheck.StartBrowser("Chrome.exe", "https://t.me/francom28");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (System.IO.File.Exists(@"C:\Program Files (x86)\Google\Chrome\Application\chrome.exe") & System.IO.File.Exists(@"C:\Program Files\Google\Chrome\Application\chrome.exe") == true)
            {
                BrowserCheck.StartBrowser("MicrosoftEdge.exe", "https://github.com/Franco28/RedmiNote7ToolC-/blob/master/README.md#redmi-note-7-tool");
            }
            else
            {
                BrowserCheck.StartBrowser("Chrome.exe", "https://github.com/Franco28/RedmiNote7ToolC-/blob/master/README.md#redmi-note-7-tool");
            }
        }

        private void Help_Disposed(object sender, EventArgs e)
        {
            this.Controls.Clear();
            this.Refresh();
            base.Dispose(Disposing);
        }

    }
}
