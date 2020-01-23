// <copyright file=MiStockDebloat>
// Copyright (c) 2019-2020 All Rights Reserved
// </copyright>
// <author>Franco28</author>
// <date> 22/1/2020 23:39:56</date>
// <summary>A simple Tool based on C# for Xiaomi Redmi Note 7 Lavender</summary>

using RegawMOD.Android;
using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RedmiNote7ToolC
{
    public partial class MiStockDebloat : Form
    {
        public MiStockDebloat()
        {
            InitializeComponent();
        }

        RegawMOD.Android.Device device;
        string serial;

        public bool IsConnected()
        {
            AndroidController android = null;
            android = AndroidController.Instance;
            if (android.HasConnectedDevices)
            {
                ArrayList devicelist = new ArrayList();
                serial = android.ConnectedDevices[0];
                device = android.GetConnectedDevice(serial);
                decimal temp = device.Battery.Temperature;
                ArrayList devicecheck = new ArrayList();
                devicecheck.Add(" Device: Online! ");
                devicecheck.Add(" Mode: USB debugging ");
                devicecheck.Add(" Serial Number: " + serial);
                devicecheck.Add(" -------------------------");
                devicecheck.Add(" Battery: " + device.Battery.Status.ToString() + " " + device.Battery.Level.ToString() + System.Environment.NewLine + "%");
                devicecheck.Add(" Battery Temperature: " + temp + System.Environment.NewLine + " �C");
                devicecheck.Add(" Battery Health: " + device.Battery.Health.ToString() + System.Environment.NewLine);
                listBox2.DataSource = devicecheck;
                return true;
            }
            else
            {
                ArrayList devicecheck = new ArrayList();
                devicecheck.Add(" Remember to always have enable USB DEBUGGING! ");
                devicecheck.Add(" Device: Offline! ");
                devicecheck.Add(" Mode: --- ");
                devicecheck.Add(" Serial Number: --- ");
                devicecheck.Add(" -------------------------");
                devicecheck.Add(" Battery: --- ");
                devicecheck.Add(" Battery Temperature: --- ");
                devicecheck.Add(" Battery Health: --- ");
                listBox2.DataSource = devicecheck;
                return false;
            }

        }

        private void MiStockDebloat_Load(object sender, EventArgs e)
        {
            IsConnected();
            TextBox2.Text = "Debloater MIUI ROM";
        }

        private static void HandleListBoxKeyEvents(object sender, KeyEventArgs e)
        {
            var lb = sender as ListBox;
            if (e.Control && e.KeyCode == Keys.C)
            {
                var itemstocopy = e.Shift ? lb.Items.Cast<object>() : lb.SelectedItems.Cast<object>();
                var copy_buffer = new StringBuilder();
                foreach (object item in itemstocopy)
                    copy_buffer.AppendLine(item?.ToString());
                if (copy_buffer.Length > 0)
                    Clipboard.SetText(copy_buffer.ToString());
            }
            else if (e.Control && e.KeyCode == Keys.A)
            {
                lb.BeginUpdate();
                for (var i = 0; i < lb.Items.Count; i++)
                    lb.SetSelected(i, true);
                lb.EndUpdate();
            }
        }

        private void debloatrom_Click(object sender, EventArgs e)
        {
               foreach (string sItem in this.listBox1.SelectedItems)
               {
                IsConnected();
                TextBox2.Text = "Checking device connection...";
                AndroidController android = null;
                android = AndroidController.Instance;
                string curItem = listBox1.SelectedItem.ToString();
                int index = listBox1.FindString(curItem);
                listBox1.BeginUpdate();
                Label3.Text = "Debloating App: " + sItem;

                    if (index == 0)
                    {
                        if (android.HasConnectedDevices)
                        {
                            Franco28Tool.Engine.Adb.FastbootExecuteCommand(@"\adb.exe ", @" shell pm uninstall -k --user 0 com.google.android.apps.tachyon");
                            System.Threading.Thread.Sleep(3000);
                            MessageBox.Show("App Debloated: " + sItem, "Mi Stock Debloater", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            TextBox2.Text = "Please connect your device...";
                            System.Threading.Thread.Sleep(1000);
                            MessageBox.Show("Device doesn�t found, Please connect the phone and check if developer (adb) options are enabled", "Flash: Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            this.Controls.Clear();
                            base.Refresh();
                            InitializeComponent();
                            IsConnected();
                            TextBox2.Text = "Debloater MIUI ROM";
                        }
                    }

                    if (index == 1)
                    {
                    if (android.HasConnectedDevices)
                    {
                        Franco28Tool.Engine.Adb.FastbootExecuteCommand(@"\adb.exe ", @"shell pm uninstall -k --user 0 com.google.android.music");
                        System.Threading.Thread.Sleep(3000);
                        MessageBox.Show("App Debloated: " + sItem, "Mi Stock Debloater", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        TextBox2.Text = "Please connect your device...";
                        System.Threading.Thread.Sleep(1000);
                        MessageBox.Show("Device doesn�t found, Please connect the phone and check if developer (adb) options are enabled", "Flash: Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        this.Controls.Clear();
                        base.Refresh();
                        InitializeComponent();
                        IsConnected();
                        TextBox2.Text = "Debloater MIUI ROM";
                    }
                    }

                    if (index == 2)
                    {
                    if (android.HasConnectedDevices)
                    {
                        Franco28Tool.Engine.Adb.FastbootExecuteCommand(@"\adb.exe ", @"shell pm uninstall -k --user 0 com.google.android.videos");
                        System.Threading.Thread.Sleep(3000);
                        MessageBox.Show("App Debloated: " + sItem, "Mi Stock Debloater", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        TextBox2.Text = "Please connect your device...";
                        System.Threading.Thread.Sleep(1000);
                        MessageBox.Show("Device doesn�t found, Please connect the phone and check if developer (adb) options are enabled", "Flash: Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        this.Controls.Clear();
                        base.Refresh();
                        InitializeComponent();
                        IsConnected();
                        TextBox2.Text = "Debloater MIUI ROM";
                    }
                    }

                    if (index == 3)
                    {
                    if (android.HasConnectedDevices)
                    {
                        Franco28Tool.Engine.Adb.FastbootExecuteCommand(@"\adb.exe ", @"shell pm uninstall -k --user 0 com.android.browser");
                        System.Threading.Thread.Sleep(3000);
                        MessageBox.Show("App Debloated: " + sItem, "Mi Stock Debloater", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        TextBox2.Text = "Please connect your device...";
                        System.Threading.Thread.Sleep(1000);
                        MessageBox.Show("Device doesn�t found, Please connect the phone and check if developer (adb) options are enabled", "Flash: Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        this.Controls.Clear();
                        base.Refresh();
                        InitializeComponent();
                        IsConnected();
                        TextBox2.Text = "Debloater MIUI ROM";
                    }
                    }

                    if (index == 4)
                    {
                    if (android.HasConnectedDevices)
                    {
                        Franco28Tool.Engine.Adb.FastbootExecuteCommand(@"\adb.exe ", @"shell pm uninstall -k --user 0 com.miui.bugreport");
                        System.Threading.Thread.Sleep(3000);
                        MessageBox.Show("App Debloated: " + sItem, "Mi Stock Debloater", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        TextBox2.Text = "Please connect your device...";
                        System.Threading.Thread.Sleep(1000);
                        MessageBox.Show("Device doesn�t found, Please connect the phone and check if developer (adb) options are enabled", "Flash: Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        this.Controls.Clear();
                        base.Refresh();
                        InitializeComponent();
                        IsConnected();
                        TextBox2.Text = "Debloater MIUI ROM";
                    }
                    }

                    if (index == 5)
                    {
                    if (android.HasConnectedDevices)
                    {
                        Franco28Tool.Engine.Adb.FastbootExecuteCommand(@"\adb.exe ", @"shell pm uninstall -k --user 0 com.miui.compass");
                        System.Threading.Thread.Sleep(3000);
                        MessageBox.Show("App Debloated: " + sItem, "Mi Stock Debloater", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        TextBox2.Text = "Please connect your device...";
                        System.Threading.Thread.Sleep(1000);
                        MessageBox.Show("Device doesn�t found, Please connect the phone and check if developer (adb) options are enabled", "Flash: Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        this.Controls.Clear();
                        base.Refresh();
                        InitializeComponent();
                        IsConnected();
                        TextBox2.Text = "Debloater MIUI ROM";
                    }
                    }

                    if (index == 6)
                    {
                    if (android.HasConnectedDevices)
                    {
                        Franco28Tool.Engine.Adb.FastbootExecuteCommand(@"\adb.exe ", @"shell pm uninstall -k --user 0 com.miui.notes");
                        System.Threading.Thread.Sleep(3000);
                        MessageBox.Show("App Debloated: " + sItem, "Mi Stock Debloater", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        TextBox2.Text = "Please connect your device...";
                        System.Threading.Thread.Sleep(1000);
                        MessageBox.Show("Device doesn�t found, Please connect the phone and check if developer (adb) options are enabled", "Flash: Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        this.Controls.Clear();
                        base.Refresh();
                        InitializeComponent();
                        IsConnected();
                        TextBox2.Text = "Debloater MIUI ROM";
                    }
                    }

                    if (index == 7)
                    {
                    if (android.HasConnectedDevices)
                    {
                        Franco28Tool.Engine.Adb.FastbootExecuteCommand(@"\adb.exe ", @"shell pm uninstall -k --user 0 com.miui.screenrecorder");
                        System.Threading.Thread.Sleep(3000);
                        MessageBox.Show("App Debloated: " + sItem, "Mi Stock Debloater", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        TextBox2.Text = "Please connect your device...";
                        System.Threading.Thread.Sleep(1000);
                        MessageBox.Show("Device doesn�t found, Please connect the phone and check if developer (adb) options are enabled", "Flash: Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        this.Controls.Clear();
                        base.Refresh();
                        InitializeComponent();
                        IsConnected();
                        TextBox2.Text = "Debloater MIUI ROM";
                    }
                    }

                    if (index == 8)
                    {
                    if (android.HasConnectedDevices)
                    {
                        Franco28Tool.Engine.Adb.FastbootExecuteCommand(@"\adb.exe ", @"shell pm uninstall -k --user 0 com.miui.videoplayer");
                        System.Threading.Thread.Sleep(3000);
                        MessageBox.Show("App Debloated: " + sItem, "Mi Stock Debloater", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        TextBox2.Text = "Please connect your device...";
                        System.Threading.Thread.Sleep(1000);
                        MessageBox.Show("Device doesn�t found, Please connect the phone and check if developer (adb) options are enabled", "Flash: Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        this.Controls.Clear();
                        base.Refresh();
                        InitializeComponent();
                        IsConnected();
                        TextBox2.Text = "Debloater MIUI ROM";
                    }
                    }

                    if (index == 9)
                    {
                    if (android.HasConnectedDevices)
                    {
                        Franco28Tool.Engine.Adb.FastbootExecuteCommand(@"\adb.exe ", @"shell pm uninstall -k --user 0 com.miui.player");
                        System.Threading.Thread.Sleep(3000);
                        MessageBox.Show("App Debloated: " + sItem, "Mi Stock Debloater", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        TextBox2.Text = "Please connect your device...";
                        System.Threading.Thread.Sleep(1000);
                        MessageBox.Show("Device doesn�t found, Please connect the phone and check if developer (adb) options are enabled", "Flash: Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        this.Controls.Clear();
                        base.Refresh();
                        InitializeComponent();
                        IsConnected();
                        TextBox2.Text = "Debloater MIUI ROM";
                    }
                    }

                    if (index == 10)
                    {
                    if (android.HasConnectedDevices)
                    {
                        Franco28Tool.Engine.Adb.FastbootExecuteCommand(@"\adb.exe ", @"shell pm uninstall -k --user 0 com.xiaomi.midrop");
                        System.Threading.Thread.Sleep(3000);
                        MessageBox.Show("App Debloated: " + sItem, "Mi Stock Debloater", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        TextBox2.Text = "Please connect your device...";
                        System.Threading.Thread.Sleep(1000);
                        MessageBox.Show("Device doesn�t found, Please connect the phone and check if developer (adb) options are enabled", "Flash: Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        this.Controls.Clear();
                        base.Refresh();
                        InitializeComponent();
                        IsConnected();
                        TextBox2.Text = "Debloater MIUI ROM";
                    }
                    }

                    if (index == 11)
                    {
                    if (android.HasConnectedDevices)
                    {
                        Franco28Tool.Engine.Adb.FastbootExecuteCommand(@"\adb.exe ", @"shell pm uninstall -k --user 0 com.xiaomi.mipicks");
                        System.Threading.Thread.Sleep(3000);
                        MessageBox.Show("App Debloated: " + sItem, "Mi Stock Debloater", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        TextBox2.Text = "Please connect your device...";
                        System.Threading.Thread.Sleep(1000);
                        MessageBox.Show("Device doesn�t found, Please connect the phone and check if developer (adb) options are enabled", "Flash: Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        this.Controls.Clear();
                        base.Refresh();
                        InitializeComponent();
                        IsConnected();
                        TextBox2.Text = "Debloater MIUI ROM";
                    }
                    }

                    if (index == 12)
                    {
                    if (android.HasConnectedDevices)
                    {
                        Franco28Tool.Engine.Adb.FastbootExecuteCommand(@"\adb.exe ", @"shell pm uninstall -k --user 0 com.xiaomi.scanner");
                        System.Threading.Thread.Sleep(3000);
                        MessageBox.Show("App Debloated: " + sItem, "Mi Stock Debloater", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        TextBox2.Text = "Please connect your device...";
                        System.Threading.Thread.Sleep(1000);
                        MessageBox.Show("Device doesn�t found, Please connect the phone and check if developer (adb) options are enabled", "Flash: Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        this.Controls.Clear();
                        base.Refresh();
                        InitializeComponent();
                        IsConnected();
                        TextBox2.Text = "Debloater MIUI ROM";
                    }
                    }

                    if (index == 13)
                    {
                    if (android.HasConnectedDevices)
                    {
                        Franco28Tool.Engine.Adb.FastbootExecuteCommand(@"\adb.exe ", @"shell pm uninstall -k --user 0 com.google.ar.lens");
                        System.Threading.Thread.Sleep(3000);
                        MessageBox.Show("App Debloated: " + sItem, "Mi Stock Debloater", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        TextBox2.Text = "Please connect your device...";
                        System.Threading.Thread.Sleep(1000);
                        MessageBox.Show("Device doesn�t found, Please connect the phone and check if developer (adb) options are enabled", "Flash: Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        this.Controls.Clear();
                        base.Refresh();
                        InitializeComponent();
                        IsConnected();
                        TextBox2.Text = "Debloater MIUI ROM";
                    }
                    }

                    if (index == 14)
                    {
                    if (android.HasConnectedDevices)
                    {
                        Franco28Tool.Engine.Adb.FastbootExecuteCommand(@"\adb.exe ", @"shell pm uninstall -k --user 0 com.google.android.apps.docs");
                        System.Threading.Thread.Sleep(3000);
                        MessageBox.Show("App Debloated: " + sItem, "Mi Stock Debloater", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        TextBox2.Text = "Please connect your device...";
                        System.Threading.Thread.Sleep(1000);
                        MessageBox.Show("Device doesn�t found, Please connect the phone and check if developer (adb) options are enabled", "Flash: Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        this.Controls.Clear();
                        base.Refresh();
                        InitializeComponent();
                        IsConnected();
                        TextBox2.Text = "Debloater MIUI ROM";
                    }
                    }

                    if (index == 15)
                    {
                    if (android.HasConnectedDevices)
                    {
                        Franco28Tool.Engine.Adb.FastbootExecuteCommand(@"\adb.exe ", @"shell pm uninstall -k --user 0 com.android.chrome");
                        System.Threading.Thread.Sleep(3000);
                        MessageBox.Show("App Debloated: " + sItem, "Mi Stock Debloater", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        TextBox2.Text = "Please connect your device...";
                        System.Threading.Thread.Sleep(1000);
                        MessageBox.Show("Device doesn�t found, Please connect the phone and check if developer (adb) options are enabled", "Flash: Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        this.Controls.Clear();
                        base.Refresh();
                        InitializeComponent();
                        IsConnected();
                        TextBox2.Text = "Debloater MIUI ROM";
                    }
                    }

                    if (index == 16)
                    {
                    if (android.HasConnectedDevices)
                    {
                        Franco28Tool.Engine.Adb.FastbootExecuteCommand(@"\adb.exe ", @"shell pm uninstall -k --user 0 com.google.android.youtube");
                        System.Threading.Thread.Sleep(3000);
                        MessageBox.Show("App Debloated: " + sItem, "Mi Stock Debloater", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        TextBox2.Text = "Please connect your device...";
                        System.Threading.Thread.Sleep(1000);
                        MessageBox.Show("Device doesn�t found, Please connect the phone and check if developer (adb) options are enabled", "Flash: Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        this.Controls.Clear();
                        base.Refresh();
                        InitializeComponent();
                        IsConnected();
                        TextBox2.Text = "Debloater MIUI ROM";
                    }
                    }

                    if (index == 17)
                    {
                    if (android.HasConnectedDevices)
                    {
                        Franco28Tool.Engine.Adb.FastbootExecuteCommand(@"\adb.exe ", @"shell pm uninstall -k --user 0 com.duokan.phone.remotecontroller.peel.plugin");
                        System.Threading.Thread.Sleep(3000);
                        MessageBox.Show("App Debloated: " + sItem, "Mi Stock Debloater", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        TextBox2.Text = "Please connect your device...";
                        System.Threading.Thread.Sleep(1000);
                        MessageBox.Show("Device doesn�t found, Please connect the phone and check if developer (adb) options are enabled", "Flash: Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        this.Controls.Clear();
                        base.Refresh();
                        InitializeComponent();
                        IsConnected();
                        TextBox2.Text = "Debloater MIUI ROM";
                    }
                    }

                    if (index == 18)
                    {
                    if (android.HasConnectedDevices)
                    {
                        Franco28Tool.Engine.Adb.FastbootExecuteCommand(@"\adb.exe ", @"shell pm uninstall -k --user 0 com.duokan.phone.remotecontroller");
                        System.Threading.Thread.Sleep(3000);
                        MessageBox.Show("App Debloated: " + sItem, "Mi Stock Debloater", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        TextBox2.Text = "Please connect your device...";
                        System.Threading.Thread.Sleep(1000);
                        MessageBox.Show("Device doesn�t found, Please connect the phone and check if developer (adb) options are enabled", "Flash: Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        this.Controls.Clear();
                        base.Refresh();
                        InitializeComponent();
                        IsConnected();
                        TextBox2.Text = "Debloater MIUI ROM";
                    }
                    }

                    if (index == 19)
                    {
                    if (android.HasConnectedDevices)
                    {
                        Franco28Tool.Engine.Adb.FastbootExecuteCommand(@"\adb.exe ", @"shell pm uninstall -k --user 0 com.miui.enbbs");
                        System.Threading.Thread.Sleep(3000);
                        MessageBox.Show("App Debloated: " + sItem, "Mi Stock Debloater", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        TextBox2.Text = "Please connect your device...";
                        System.Threading.Thread.Sleep(1000);
                        MessageBox.Show("Device doesn�t found, Please connect the phone and check if developer (adb) options are enabled", "Flash: Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        this.Controls.Clear();
                        base.Refresh();
                        InitializeComponent();
                        IsConnected();
                        TextBox2.Text = "Debloater MIUI ROM";
                    }
                    }
            }
            listBox1.EndUpdate();
            this.Controls.Clear();
            base.Refresh();
            InitializeComponent();
            IsConnected();
            TextBox2.Text = "Debloater MIUI ROM";
        }

        private void unselectall_Click(object sender, EventArgs e)
        {
            this.Controls.Clear();
            base.Refresh();
            InitializeComponent();
            IsConnected();
            TextBox2.Text = "Debloater MIUI ROM";
        }
    }
}
