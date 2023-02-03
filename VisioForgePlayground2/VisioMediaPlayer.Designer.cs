namespace VisioForgePlayground2
{
    partial class VisioMediaPlayer
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.videoView1 = new VisioForge.Core.UI.WinForms.VideoView();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // videoView1
            // 
            this.videoView1.BackColor = System.Drawing.Color.Black;
            this.videoView1.Location = new System.Drawing.Point(3, 3);
            this.videoView1.Name = "videoView1";
            this.videoView1.Size = new System.Drawing.Size(332, 233);
            this.videoView1.StatusOverlay = null;
            this.videoView1.TabIndex = 0;
            this.videoView1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.videoView1_MouseClick);
            this.videoView1.StyleChanged += new System.EventHandler(this.videoView1_StyleChanged);
            // 
            // VisioMediaPlayer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.videoView1);
            this.Name = "VisioMediaPlayer";
            this.Size = new System.Drawing.Size(338, 239);
            this.ResumeLayout(false);

        }

        #endregion

        private VisioForge.Core.UI.WinForms.VideoView videoView1;
        private System.Windows.Forms.Timer timer1;
    }
}
