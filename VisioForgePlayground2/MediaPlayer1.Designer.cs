namespace VisioForgePlayground2
{
    partial class MediaPlayer1
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonStop = new System.Windows.Forms.Button();
            this.textBTime = new System.Windows.Forms.TextBox();
            this.lbVideoState = new System.Windows.Forms.Label();
            this.numericUpDownPlayRate = new System.Windows.Forms.NumericUpDown();
            this.tbTimeline = new System.Windows.Forms.TrackBar();
            this.btMute = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btPause = new System.Windows.Forms.Button();
            this.btPlay = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPlayRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbTimeline)).BeginInit();
            this.SuspendLayout();
            // 
            // videoView1
            // 
            this.videoView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.videoView1.BackColor = System.Drawing.Color.Black;
            this.videoView1.Location = new System.Drawing.Point(7, 7);
            this.videoView1.Margin = new System.Windows.Forms.Padding(7, 7, 7, 7);
            this.videoView1.Name = "videoView1";
            this.videoView1.Size = new System.Drawing.Size(726, 497);
            this.videoView1.StatusOverlay = null;
            this.videoView1.TabIndex = 0;
            this.videoView1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.videoView1_MouseClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.buttonStop);
            this.groupBox1.Controls.Add(this.textBTime);
            this.groupBox1.Controls.Add(this.lbVideoState);
            this.groupBox1.Controls.Add(this.numericUpDownPlayRate);
            this.groupBox1.Controls.Add(this.tbTimeline);
            this.groupBox1.Controls.Add(this.btMute);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btPause);
            this.groupBox1.Controls.Add(this.btPlay);
            this.groupBox1.Location = new System.Drawing.Point(7, 518);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(7, 7, 7, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(7, 7, 7, 7);
            this.groupBox1.Size = new System.Drawing.Size(726, 185);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Controls";
            // 
            // buttonStop
            // 
            this.buttonStop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonStop.Location = new System.Drawing.Point(140, 123);
            this.buttonStop.Margin = new System.Windows.Forms.Padding(7, 7, 7, 7);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(103, 51);
            this.buttonStop.TabIndex = 14;
            this.buttonStop.Text = "Stop";
            this.buttonStop.UseVisualStyleBackColor = true;
            this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
            // 
            // textBTime
            // 
            this.textBTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.textBTime.Location = new System.Drawing.Point(551, 45);
            this.textBTime.Margin = new System.Windows.Forms.Padding(7, 7, 7, 7);
            this.textBTime.Name = "textBTime";
            this.textBTime.Size = new System.Drawing.Size(156, 35);
            this.textBTime.TabIndex = 13;
            this.textBTime.Text = "00:00/00:00";
            // 
            // lbVideoState
            // 
            this.lbVideoState.AutoSize = true;
            this.lbVideoState.Location = new System.Drawing.Point(14, 87);
            this.lbVideoState.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lbVideoState.Name = "lbVideoState";
            this.lbVideoState.Size = new System.Drawing.Size(174, 29);
            this.lbVideoState.TabIndex = 11;
            this.lbVideoState.Text = "Video Stopped";
            // 
            // numericUpDownPlayRate
            // 
            this.numericUpDownPlayRate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.numericUpDownPlayRate.DecimalPlaces = 1;
            this.numericUpDownPlayRate.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDownPlayRate.Location = new System.Drawing.Point(618, 125);
            this.numericUpDownPlayRate.Margin = new System.Windows.Forms.Padding(7, 7, 7, 7);
            this.numericUpDownPlayRate.Name = "numericUpDownPlayRate";
            this.numericUpDownPlayRate.Size = new System.Drawing.Size(91, 35);
            this.numericUpDownPlayRate.TabIndex = 10;
            this.numericUpDownPlayRate.Value = new decimal(new int[] {
            10,
            0,
            0,
            65536});
            this.numericUpDownPlayRate.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // tbTimeline
            // 
            this.tbTimeline.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbTimeline.AutoSize = false;
            this.tbTimeline.Location = new System.Drawing.Point(0, 45);
            this.tbTimeline.Margin = new System.Windows.Forms.Padding(7, 7, 7, 7);
            this.tbTimeline.Name = "tbTimeline";
            this.tbTimeline.Size = new System.Drawing.Size(560, 65);
            this.tbTimeline.TabIndex = 9;
            this.tbTimeline.Scroll += new System.EventHandler(this.tbTimeline_Scroll);
            // 
            // btMute
            // 
            this.btMute.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btMute.Location = new System.Drawing.Point(341, 120);
            this.btMute.Margin = new System.Windows.Forms.Padding(7, 7, 7, 7);
            this.btMute.Name = "btMute";
            this.btMute.Size = new System.Drawing.Size(105, 47);
            this.btMute.TabIndex = 8;
            this.btMute.Text = "Mute";
            this.btMute.UseVisualStyleBackColor = true;
            this.btMute.Click += new System.EventHandler(this.btMute_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(443, 125);
            this.label1.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 29);
            this.label1.TabIndex = 4;
            this.label1.Text = "Play Rate:";
            // 
            // btPause
            // 
            this.btPause.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btPause.Location = new System.Drawing.Point(21, 123);
            this.btPause.Margin = new System.Windows.Forms.Padding(7, 7, 7, 7);
            this.btPause.Name = "btPause";
            this.btPause.Size = new System.Drawing.Size(105, 47);
            this.btPause.TabIndex = 1;
            this.btPause.Text = "Pause";
            this.btPause.UseVisualStyleBackColor = true;
            this.btPause.Click += new System.EventHandler(this.btPause_Click);
            // 
            // btPlay
            // 
            this.btPlay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btPlay.Location = new System.Drawing.Point(21, 125);
            this.btPlay.Margin = new System.Windows.Forms.Padding(7, 7, 7, 7);
            this.btPlay.Name = "btPlay";
            this.btPlay.Size = new System.Drawing.Size(93, 47);
            this.btPlay.TabIndex = 0;
            this.btPlay.Text = "Play";
            this.btPlay.UseVisualStyleBackColor = true;
            this.btPlay.Click += new System.EventHandler(this.btPlay_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // MediaPlayer1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.Controls.Add(this.videoView1);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "MediaPlayer1";
            this.Size = new System.Drawing.Size(740, 709);
            this.Load += new System.EventHandler(this.MediaPlayer_Load);
            this.Leave += new System.EventHandler(this.MediaPlayer_Leave);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MediaPlayer_MouseClick);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPlayRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbTimeline)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private VisioForge.Core.UI.WinForms.VideoView videoView1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btPause;
        private System.Windows.Forms.Button btPlay;
        private System.Windows.Forms.Button btMute;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TrackBar tbTimeline;
        private System.Windows.Forms.NumericUpDown numericUpDownPlayRate;
        private System.Windows.Forms.Label lbVideoState;
        private System.Windows.Forms.TextBox textBTime;
        private System.Windows.Forms.Button buttonStop;
    }
}
