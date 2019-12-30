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
