// <copyright file=MiFlash>
// Copyright (c) 2019-2020 All Rights Reserved
// </copyright>
// <author>Franco28</author>
// <date> 20/1/2020 17:44:26</date>
// <summary>A simple Tool based on C# for Xiaomi Redmi Note 7 Lavender</summary>

using System;
using System.Windows.Forms;
using MiUSB;

namespace RedmiNote7ToolC
{
    public partial class MiFlash : Form
    {
        public MiFlash()
        {
            InitializeComponent();
        }

        private void flash_Click(object sender, EventArgs e)
        {
            if (USB_CONNECTION_STATUS.NoDeviceConnected.Equals(true))
            {

            } 
            else
            {
                MessageBox.Show("Please connect a Device!", "Mi Flash", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void MiFlash_Load(object sender, EventArgs e)
        {

        }
    }
}
