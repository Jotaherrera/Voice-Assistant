namespace F.R.I.D.A.Y
{
    partial class frmVIERNES
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmVIERNES));
            this.tmrSpeaking = new System.Windows.Forms.Timer(this.components);
            this.lblRecognizer = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // tmrSpeaking
            // 
            this.tmrSpeaking.Enabled = true;
            this.tmrSpeaking.Interval = 1000;
            this.tmrSpeaking.Tick += new System.EventHandler(this.tmrSpeaking_Tick);
            // 
            // lblRecognizer
            // 
            this.lblRecognizer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.lblRecognizer.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblRecognizer.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblRecognizer.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.lblRecognizer.Location = new System.Drawing.Point(12, 267);
            this.lblRecognizer.Name = "lblRecognizer";
            this.lblRecognizer.Size = new System.Drawing.Size(360, 85);
            this.lblRecognizer.TabIndex = 2;
            this.lblRecognizer.Text = "Habla...";
            this.lblRecognizer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(-8, -20);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(400, 400);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // frmVIERNES
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(384, 361);
            this.Controls.Add(this.lblRecognizer);
            this.Controls.Add(this.pictureBox1);
            this.Name = "frmVIERNES";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VIERNES";
            this.Load += new System.EventHandler(this.frmFRIDAY_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer tmrSpeaking;
        private Label lblRecognizer;
        private PictureBox pictureBox1;
    }
}