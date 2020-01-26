// <copyright file=MiStockDebloat.Designer>
// Copyright (c) 2019-2020 All Rights Reserved
// </copyright>
// <author>Franco28</author>
// <date> 22/1/2020 23:39:56</date>
// <summary>A simple Tool based on C# for Xiaomi Redmi Note 7 Lavender</summary>

namespace RedmiNote7ToolC
{
    partial class MiStockDebloat
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MiStockDebloat));
            this.debloatrom = new System.Windows.Forms.Button();
            this.TextBox2 = new System.Windows.Forms.TextBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.unselectall = new System.Windows.Forms.Button();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.label6 = new System.Windows.Forms.Label();
            this.Label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // debloatrom
            // 
            this.debloatrom.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.debloatrom.BackColor = System.Drawing.Color.LightGray;
            this.debloatrom.Cursor = System.Windows.Forms.Cursors.Hand;
            this.debloatrom.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.debloatrom.FlatAppearance.BorderSize = 0;
            this.debloatrom.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.debloatrom.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.debloatrom.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.debloatrom.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.debloatrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold);
            this.debloatrom.ForeColor = System.Drawing.Color.Black;
            this.debloatrom.Image = ((System.Drawing.Image)(resources.GetObject("debloatrom.Image")));
            this.debloatrom.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.debloatrom.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.debloatrom.Location = new System.Drawing.Point(354, 452);
            this.debloatrom.Name = "debloatrom";
            this.debloatrom.Size = new System.Drawing.Size(449, 47);
            this.debloatrom.TabIndex = 25;
            this.debloatrom.Text = "Debloat ROM";
            this.debloatrom.UseVisualStyleBackColor = false;
            this.debloatrom.Click += new System.EventHandler(this.debloatrom_Click);
            // 
            // TextBox2
            // 
            this.TextBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TextBox2.BackColor = System.Drawing.Color.DimGray;
            this.TextBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TextBox2.Cursor = System.Windows.Forms.Cursors.Default;
            this.TextBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold);
            this.TextBox2.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.TextBox2.Location = new System.Drawing.Point(354, 390);
            this.TextBox2.Multiline = true;
            this.TextBox2.Name = "TextBox2";
            this.TextBox2.ReadOnly = true;
            this.TextBox2.Size = new System.Drawing.Size(449, 46);
            this.TextBox2.TabIndex = 28;
            this.TextBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // listBox1
            // 
            this.listBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBox1.BackColor = System.Drawing.Color.DimGray;
            this.listBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 20;
            this.listBox1.Items.AddRange(new object[] {
            "Google Duo",
            "Google Music",
            "Google Play Movies",
            "Mi Browser",
            "Mi Feedback",
            "Mi Compass",
            "Mi Notes",
            "Mi Screen Recorder",
            "Mi Video",
            "Mi Music",
            "Mi Drop",
            "Mi Apps",
            "Mi Scanner",
            "Google Lens",
            "Google Docs",
            "Google Chrome",
            "Google YouTube",
            "Peel Mi Remote",
            "Mi Remote controller",
            "Xiaomi MIUI Forum"});
            this.listBox1.Location = new System.Drawing.Point(12, 12);
            this.listBox1.Margin = new System.Windows.Forms.Padding(6);
            this.listBox1.Name = "listBox1";
            this.listBox1.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.listBox1.Size = new System.Drawing.Size(336, 424);
            this.listBox1.TabIndex = 32;
            // 
            // unselectall
            // 
            this.unselectall.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.unselectall.BackColor = System.Drawing.Color.LightGray;
            this.unselectall.Cursor = System.Windows.Forms.Cursors.Hand;
            this.unselectall.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.unselectall.FlatAppearance.BorderSize = 0;
            this.unselectall.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.unselectall.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.unselectall.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.unselectall.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.unselectall.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold);
            this.unselectall.ForeColor = System.Drawing.Color.Black;
            this.unselectall.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.unselectall.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.unselectall.Location = new System.Drawing.Point(12, 452);
            this.unselectall.Name = "unselectall";
            this.unselectall.Size = new System.Drawing.Size(336, 47);
            this.unselectall.TabIndex = 31;
            this.unselectall.Text = "Unselect All";
            this.unselectall.UseVisualStyleBackColor = false;
            this.unselectall.Click += new System.EventHandler(this.unselectall_Click);
            // 
            // listBox2
            // 
            this.listBox2.BackColor = System.Drawing.Color.DimGray;
            this.listBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox2.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.listBox2.FormattingEnabled = true;
            this.listBox2.ItemHeight = 20;
            this.listBox2.Location = new System.Drawing.Point(354, 166);
            this.listBox2.MultiColumn = true;
            this.listBox2.Name = "listBox2";
            this.listBox2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.listBox2.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.listBox2.Size = new System.Drawing.Size(449, 204);
            this.listBox2.TabIndex = 42;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.BackColor = System.Drawing.Color.Silver;
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label6.Location = new System.Drawing.Point(354, 120);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(449, 43);
            this.label6.TabIndex = 41;
            this.label6.Text = "Device Status";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Label3
            // 
            this.Label3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Label3.BackColor = System.Drawing.Color.DimGray;
            this.Label3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label3.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.Label3.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Label3.Location = new System.Drawing.Point(354, 65);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(449, 36);
            this.Label3.TabIndex = 43;
            this.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.BackColor = System.Drawing.Color.Silver;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(354, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(449, 43);
            this.label1.TabIndex = 44;
            this.label1.Text = "Debloat Info";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MiStockDebloat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(815, 524);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Label3);
            this.Controls.Add(this.listBox2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.unselectall);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.TextBox2);
            this.Controls.Add(this.debloatrom);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.MaximizeBox = false;
            this.Name = "MiStockDebloat";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mi Stock MIUI Debloat - BETA";
            this.Load += new System.EventHandler(this.MiStockDebloat_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        internal System.Windows.Forms.Button debloatrom;
        internal System.Windows.Forms.TextBox TextBox2;
        private System.Windows.Forms.ListBox listBox1;
        internal System.Windows.Forms.Button unselectall;
        private System.Windows.Forms.ListBox listBox2;
        internal System.Windows.Forms.Label label6;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.Label label1;
    }
}
