namespace VoiceAssistant
{
    partial class frmVoiceAssistant
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmVoiceAssistant));
            tmrSpeaking = new System.Windows.Forms.Timer(components);
            lblRecognizer = new Label();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // tmrSpeaking
            // 
            tmrSpeaking.Enabled = true;
            tmrSpeaking.Interval = 1000;
            tmrSpeaking.Tick += tmrSpeaking_Tick;
            // 
            // lblRecognizer
            // 
            lblRecognizer.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            lblRecognizer.BackColor = SystemColors.ActiveCaptionText;
            lblRecognizer.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            lblRecognizer.ForeColor = Color.CornflowerBlue;
            lblRecognizer.Location = new Point(12, 267);
            lblRecognizer.Name = "lblRecognizer";
            lblRecognizer.Size = new Size(360, 85);
            lblRecognizer.TabIndex = 2;
            lblRecognizer.Text = "Say \"Hi assistant\"";
            lblRecognizer.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(-8, -20);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(400, 400);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // frmVoiceAssistant
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaptionText;
            ClientSize = new Size(384, 361);
            Controls.Add(lblRecognizer);
            Controls.Add(pictureBox1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "frmVoiceAssistant";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "VoiceAssistant";
            Load += frmVoiceAssistant_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.Timer tmrSpeaking;
        private Label lblRecognizer;
        private PictureBox pictureBox1;
    }
}