namespace RedmiNote7ToolC
{
    partial class DownloadMIUIFastboot
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DownloadMIUIFastboot));
            this.TextBox1 = new System.Windows.Forms.TextBox();
            this.ProgressBar1 = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // TextBox1
            // 
            this.TextBox1.BackColor = System.Drawing.Color.Gainsboro;
            this.TextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TextBox1.Cursor = System.Windows.Forms.Cursors.Default;
            this.TextBox1.Enabled = false;
            this.TextBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBox1.Location = new System.Drawing.Point(12, 33);
            this.TextBox1.Multiline = true;
            this.TextBox1.Name = "TextBox1";
            this.TextBox1.ReadOnly = true;
            this.TextBox1.Size = new System.Drawing.Size(776, 33);
            this.TextBox1.TabIndex = 9;
            this.TextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ProgressBar1
            // 
            this.ProgressBar1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ProgressBar1.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            this.ProgressBar1.Location = new System.Drawing.Point(12, 83);
            this.ProgressBar1.Name = "ProgressBar1";
            this.ProgressBar1.Size = new System.Drawing.Size(776, 37);
            this.ProgressBar1.TabIndex = 8;
            // 
            // DownloadMIUIFastboot
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(800, 152);
            this.Controls.Add(this.TextBox1);
            this.Controls.Add(this.ProgressBar1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "DownloadMIUIFastboot";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Downloading MIUI V11.0.4.0.PFGMIXM Firmware...";
            this.Load += new System.EventHandler(this.DownloadMIUIFastboot_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.TextBox TextBox1;
        internal System.Windows.Forms.ProgressBar ProgressBar1;
    }
}