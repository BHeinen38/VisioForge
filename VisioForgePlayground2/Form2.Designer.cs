namespace VisioForgePlayground2
{
    partial class Form2
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
            this.fullMediaPlayer1 = new VisioForgePlayground2.FullMediaPlayer();
            this.SuspendLayout();
            // 
            // fullMediaPlayer1
            // 
            this.fullMediaPlayer1.CaptureImageOutputFileType = VisioForgePlayground2.CaptureImageFileType.png;
            this.fullMediaPlayer1.CurrentPositionMilliseconds = 0;
            this.fullMediaPlayer1.EndTimeMilliseconds = 0;
            this.fullMediaPlayer1.FilenameOrURL = null;
            this.fullMediaPlayer1.IsMuted = false;
            this.fullMediaPlayer1.Location = new System.Drawing.Point(236, 150);
            this.fullMediaPlayer1.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.fullMediaPlayer1.MinimumSize = new System.Drawing.Size(843, 665);
            this.fullMediaPlayer1.Name = "fullMediaPlayer1";
            this.fullMediaPlayer1.PlayRate = 1D;
            this.fullMediaPlayer1.Size = new System.Drawing.Size(1067, 775);
            this.fullMediaPlayer1.StartTimeMilliseconds = 0;
            this.fullMediaPlayer1.TabIndex = 0;
            this.fullMediaPlayer1.Volume = 50D;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1749, 1181);
            this.Controls.Add(this.fullMediaPlayer1);
            this.Name = "Form2";
            this.Text = "Form2";
            this.ResumeLayout(false);

        }

        #endregion

        private FullMediaPlayer fullMediaPlayer1;
    }
}