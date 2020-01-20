// <copyright file=Help.Designer>
// Copyright (c) 2019-2020 All Rights Reserved
// </copyright>
// <author>Franco28</author>
// <date> 20/1/2020 18:15:10</date>
// <summary>A simple Tool based on C# for Xiaomi Redmi Note 7 Lavender</summary>

namespace RedmiNote7ToolC
{
    partial class Help
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Help));
            this.MiBanner = new System.Windows.Forms.PictureBox();
            this.contact = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.howtouseit = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.MiBanner)).BeginInit();
            this.SuspendLayout();
            // 
            // MiBanner
            // 
            this.MiBanner.BackColor = System.Drawing.Color.Transparent;
            this.MiBanner.Image = ((System.Drawing.Image)(resources.GetObject("MiBanner.Image")));
            this.MiBanner.ImageLocation = "";
            this.MiBanner.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.MiBanner.InitialImage = null;
            this.MiBanner.Location = new System.Drawing.Point(-85, -1);
            this.MiBanner.Name = "MiBanner";
            this.MiBanner.Size = new System.Drawing.Size(669, 155);
            this.MiBanner.TabIndex = 21;
            this.MiBanner.TabStop = false;
            // 
            // contact
            // 
            this.contact.BackColor = System.Drawing.Color.Gray;
            this.contact.Cursor = System.Windows.Forms.Cursors.Hand;
            this.contact.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.contact.FlatAppearance.BorderSize = 0;
            this.contact.FlatAppearance.CheckedBackColor = System.Drawing.Color.DarkGray;
            this.contact.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkGray;
            this.contact.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkGray;
            this.contact.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.contact.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.contact.ForeColor = System.Drawing.Color.Black;
            this.contact.Image = ((System.Drawing.Image)(resources.GetObject("contact.Image")));
            this.contact.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.contact.Location = new System.Drawing.Point(8, 306);
            this.contact.Name = "contact";
            this.contact.Size = new System.Drawing.Size(174, 34);
            this.contact.TabIndex = 23;
            this.contact.Text = "Contact";
            this.contact.UseVisualStyleBackColor = false;
            this.contact.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label1.Location = new System.Drawing.Point(0, 157);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(485, 103);
            this.label1.TabIndex = 24;
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // howtouseit
            // 
            this.howtouseit.BackColor = System.Drawing.Color.Gray;
            this.howtouseit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.howtouseit.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.howtouseit.FlatAppearance.BorderSize = 0;
            this.howtouseit.FlatAppearance.CheckedBackColor = System.Drawing.Color.DarkGray;
            this.howtouseit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkGray;
            this.howtouseit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkGray;
            this.howtouseit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.howtouseit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.howtouseit.ForeColor = System.Drawing.Color.Black;
            this.howtouseit.Image = ((System.Drawing.Image)(resources.GetObject("howtouseit.Image")));
            this.howtouseit.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.howtouseit.Location = new System.Drawing.Point(301, 306);
            this.howtouseit.Name = "howtouseit";
            this.howtouseit.Size = new System.Drawing.Size(174, 34);
            this.howtouseit.TabIndex = 25;
            this.howtouseit.Text = "How to use it?";
            this.howtouseit.UseVisualStyleBackColor = false;
            this.howtouseit.Click += new System.EventHandler(this.button3_Click);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label2.Location = new System.Drawing.Point(4, 343);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(481, 31);
            this.label2.TabIndex = 26;
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Gray;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.CheckedBackColor = System.Drawing.Color.DarkGray;
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkGray;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkGray;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Black;
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.Location = new System.Drawing.Point(188, 263);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(107, 34);
            this.button1.TabIndex = 28;
            this.button1.Text = "Source";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // Help
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(487, 383);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.howtouseit);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.contact);
            this.Controls.Add(this.MiBanner);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Help";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Help";
            this.Load += new System.EventHandler(this.Help_Load);
            this.Disposed += new System.EventHandler(this.Help_Disposed);
            ((System.ComponentModel.ISupportInitialize)(this.MiBanner)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.PictureBox MiBanner;
        private System.Windows.Forms.Button contact;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button howtouseit;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
    }
}
