// <copyright file=MiFlash.Designer>
// Copyright (c) 2019-2020 All Rights Reserved
// </copyright>
// <author>Franco28</author>
// <date> 22/1/2020 23:39:56</date>
// <summary>A simple Tool based on C# for Xiaomi Redmi Note 7 Lavender</summary>

namespace RedmiNote7ToolC
{
    partial class MiFlash
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MiFlash));
            this.flash = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // flash
            // 
            this.flash.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flash.BackColor = System.Drawing.Color.DarkGray;
            this.flash.Cursor = System.Windows.Forms.Cursors.Hand;
            this.flash.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.flash.FlatAppearance.BorderSize = 0;
            this.flash.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.flash.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.flash.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.flash.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.flash.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold);
            this.flash.ForeColor = System.Drawing.Color.Black;
            this.flash.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.flash.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.flash.Location = new System.Drawing.Point(635, 206);
            this.flash.Name = "flash";
            this.flash.Size = new System.Drawing.Size(131, 41);
            this.flash.TabIndex = 24;
            this.flash.Text = "Flash";
            this.flash.UseVisualStyleBackColor = false;
            this.flash.Click += new System.EventHandler(this.flash_Click);
            // 
            // MiFlash
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(778, 259);
            this.Controls.Add(this.flash);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MaximizeBox = false;
            this.Name = "MiFlash";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mi Flash v1.0";
            this.Load += new System.EventHandler(this.MiFlash_Load);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Button flash;
    }
}
