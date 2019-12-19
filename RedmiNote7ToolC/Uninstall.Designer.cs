namespace RedmiNote7ToolC
{
    partial class Uninstall
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Uninstall));
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.MiBanner = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.MiBanner)).BeginInit();
            this.SuspendLayout();
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(12, 267);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(612, 39);
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar1.TabIndex = 0;
            // 
            // MiBanner
            // 
            this.MiBanner.BackColor = System.Drawing.Color.Transparent;
            this.MiBanner.Image = ((System.Drawing.Image)(resources.GetObject("MiBanner.Image")));
            this.MiBanner.ImageLocation = "";
            this.MiBanner.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.MiBanner.InitialImage = null;
            this.MiBanner.Location = new System.Drawing.Point(-7, -1);
            this.MiBanner.Name = "MiBanner";
            this.MiBanner.Size = new System.Drawing.Size(653, 155);
            this.MiBanner.TabIndex = 20;
            this.MiBanner.TabStop = false;
            // 
            // label1
            // 
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label1.Location = new System.Drawing.Point(12, 195);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(612, 41);
            this.label1.TabIndex = 21;
            // 
            // Uninstall
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(636, 352);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.MiBanner);
            this.Controls.Add(this.progressBar1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Uninstall";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Uninstalling Tool...";
            this.Closed += new System.EventHandler(this.Uninstall_Closed);
            this.Load += new System.EventHandler(this.Uninstall_Load);
            ((System.ComponentModel.ISupportInitialize)(this.MiBanner)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ProgressBar progressBar1;
        internal System.Windows.Forms.PictureBox MiBanner;
        private System.Windows.Forms.Label label1;
    }
}