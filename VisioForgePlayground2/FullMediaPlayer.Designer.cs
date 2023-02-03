namespace VisioForgePlayground2
{
    partial class FullMediaPlayer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FullMediaPlayer));
            this.textBoxFilename = new System.Windows.Forms.TextBox();
            this.buttonVideoInformation = new System.Windows.Forms.Button();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.videoView1 = new VisioForge.Core.UI.WinForms.VideoView();
            this.buttonPreviousVideo = new System.Windows.Forms.Button();
            this.buttonNextVideo = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.numericUpDownPlayRate = new System.Windows.Forms.NumericUpDown();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.textBoxEndTime = new System.Windows.Forms.TextBox();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.trackBarVideo = new System.Windows.Forms.TrackBar();
            this.buttonPreviousFrame = new System.Windows.Forms.Button();
            this.buttonPlay = new System.Windows.Forms.Button();
            this.buttonPause = new System.Windows.Forms.Button();
            this.buttonNextFrame = new System.Windows.Forms.Button();
            this.buttonStop = new System.Windows.Forms.Button();
            this.buttonRecord = new System.Windows.Forms.Button();
            this.buttonLoop = new System.Windows.Forms.Button();
            this.buttonCaputureImage = new System.Windows.Forms.Button();
            this.buttonMute = new System.Windows.Forms.Button();
            this.labelPlayRate = new System.Windows.Forms.Label();
            this.textBoxVideoState = new System.Windows.Forms.TextBox();
            this.textBoxCurrentPosition = new System.Windows.Forms.TextBox();
            this.buttonNoLoop = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPlayRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarVideo)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxFilename
            // 
            this.textBoxFilename.Location = new System.Drawing.Point(37, 37);
            this.textBoxFilename.Name = "textBoxFilename";
            this.textBoxFilename.Size = new System.Drawing.Size(906, 20);
            this.textBoxFilename.TabIndex = 0;
            this.textBoxFilename.Text = "Source Filename";
            // 
            // buttonVideoInformation
            // 
            this.buttonVideoInformation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonVideoInformation.Location = new System.Drawing.Point(960, 27);
            this.buttonVideoInformation.Name = "buttonVideoInformation";
            this.buttonVideoInformation.Size = new System.Drawing.Size(72, 55);
            this.buttonVideoInformation.TabIndex = 1;
            this.buttonVideoInformation.Text = "i";
            this.toolTip.SetToolTip(this.buttonVideoInformation, "Video information");
            this.buttonVideoInformation.UseVisualStyleBackColor = true;
            // 
            // videoView1
            // 
            this.videoView1.BackColor = System.Drawing.Color.Black;
            this.videoView1.Location = new System.Drawing.Point(14, 88);
            this.videoView1.Name = "videoView1";
            this.videoView1.Size = new System.Drawing.Size(1035, 469);
            this.videoView1.StatusOverlay = null;
            this.videoView1.TabIndex = 2;
            // 
            // buttonPreviousVideo
            // 
            this.buttonPreviousVideo.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.buttonPreviousVideo.Location = new System.Drawing.Point(12, 28);
            this.buttonPreviousVideo.Name = "buttonPreviousVideo";
            this.buttonPreviousVideo.Size = new System.Drawing.Size(72, 55);
            this.buttonPreviousVideo.TabIndex = 4;
            this.buttonPreviousVideo.Text = "<<";
            this.buttonPreviousVideo.UseVisualStyleBackColor = true;
            this.buttonPreviousVideo.Click += new System.EventHandler(this.buttonPreviousVideo_Click);
            // 
            // buttonNextVideo
            // 
            this.buttonNextVideo.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.buttonNextVideo.Location = new System.Drawing.Point(975, 28);
            this.buttonNextVideo.Name = "buttonNextVideo";
            this.buttonNextVideo.Size = new System.Drawing.Size(72, 55);
            this.buttonNextVideo.TabIndex = 5;
            this.buttonNextVideo.Text = ">>";
            this.buttonNextVideo.UseVisualStyleBackColor = true;
            this.buttonNextVideo.Click += new System.EventHandler(this.buttonNextVideo_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "play.png");
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
            this.numericUpDownPlayRate.Location = new System.Drawing.Point(931, 163);
            this.numericUpDownPlayRate.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.numericUpDownPlayRate.Name = "numericUpDownPlayRate";
            this.numericUpDownPlayRate.Size = new System.Drawing.Size(125, 20);
            this.numericUpDownPlayRate.TabIndex = 16;
            this.numericUpDownPlayRate.Value = new decimal(new int[] {
            10,
            0,
            0,
            65536});
            this.numericUpDownPlayRate.ValueChanged += new System.EventHandler(this.numericUpDownPlayRate_ValueChanged);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(40, 40);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // textBoxEndTime
            // 
            this.textBoxEndTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxEndTime.BackColor = System.Drawing.SystemColors.Control;
            this.textBoxEndTime.Location = new System.Drawing.Point(882, 101);
            this.textBoxEndTime.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.textBoxEndTime.Name = "textBoxEndTime";
            this.textBoxEndTime.Size = new System.Drawing.Size(165, 20);
            this.textBoxEndTime.TabIndex = 21;
            this.textBoxEndTime.Text = "0.00 / 30.00 sec";
            this.textBoxEndTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.ImageScalingSize = new System.Drawing.Size(40, 40);
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(61, 4);
            // 
            // trackBarVideo
            // 
            this.trackBarVideo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.trackBarVideo.AutoSize = false;
            this.trackBarVideo.Location = new System.Drawing.Point(83, 42);
            this.trackBarVideo.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.trackBarVideo.Name = "trackBarVideo";
            this.trackBarVideo.Size = new System.Drawing.Size(900, 52);
            this.trackBarVideo.TabIndex = 3;
            this.trackBarVideo.Scroll += new System.EventHandler(this.trackBarVideo_Scroll);
            // 
            // buttonPreviousFrame
            // 
            this.buttonPreviousFrame.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonPreviousFrame.Location = new System.Drawing.Point(0, 153);
            this.buttonPreviousFrame.Name = "buttonPreviousFrame";
            this.buttonPreviousFrame.Size = new System.Drawing.Size(72, 55);
            this.buttonPreviousFrame.TabIndex = 6;
            this.buttonPreviousFrame.Text = "<";
            this.buttonPreviousFrame.UseVisualStyleBackColor = true;
            this.buttonPreviousFrame.Click += new System.EventHandler(this.buttonPreviousFrame_Click);
            // 
            // buttonPlay
            // 
            this.buttonPlay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonPlay.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonPlay.Location = new System.Drawing.Point(73, 155);
            this.buttonPlay.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.buttonPlay.Name = "buttonPlay";
            this.buttonPlay.Size = new System.Drawing.Size(72, 55);
            this.buttonPlay.TabIndex = 7;
            this.buttonPlay.Text = "|>";
            this.buttonPlay.UseVisualStyleBackColor = true;
            this.buttonPlay.Click += new System.EventHandler(this.buttonPlay_Click);
            // 
            // buttonPause
            // 
            this.buttonPause.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonPause.Location = new System.Drawing.Point(147, 156);
            this.buttonPause.Name = "buttonPause";
            this.buttonPause.Size = new System.Drawing.Size(72, 55);
            this.buttonPause.TabIndex = 8;
            this.buttonPause.Text = "||";
            this.buttonPause.UseVisualStyleBackColor = true;
            this.buttonPause.Click += new System.EventHandler(this.buttonPause_Click);
            // 
            // buttonNextFrame
            // 
            this.buttonNextFrame.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonNextFrame.Location = new System.Drawing.Point(225, 156);
            this.buttonNextFrame.Name = "buttonNextFrame";
            this.buttonNextFrame.Size = new System.Drawing.Size(72, 55);
            this.buttonNextFrame.TabIndex = 9;
            this.buttonNextFrame.Text = ">";
            this.buttonNextFrame.UseVisualStyleBackColor = true;
            this.buttonNextFrame.Click += new System.EventHandler(this.buttonNextFrame_Click);
            // 
            // buttonStop
            // 
            this.buttonStop.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.buttonStop.Location = new System.Drawing.Point(314, 156);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(72, 55);
            this.buttonStop.TabIndex = 10;
            this.buttonStop.Text = "X";
            this.buttonStop.UseVisualStyleBackColor = true;
            this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
            // 
            // buttonRecord
            // 
            this.buttonRecord.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.buttonRecord.Location = new System.Drawing.Point(392, 155);
            this.buttonRecord.Name = "buttonRecord";
            this.buttonRecord.Size = new System.Drawing.Size(72, 55);
            this.buttonRecord.TabIndex = 11;
            this.buttonRecord.Text = ".";
            this.buttonRecord.UseVisualStyleBackColor = true;
            this.buttonRecord.Click += new System.EventHandler(this.buttonRecord_Click);
            // 
            // buttonLoop
            // 
            this.buttonLoop.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.buttonLoop.Location = new System.Drawing.Point(470, 155);
            this.buttonLoop.Name = "buttonLoop";
            this.buttonLoop.Size = new System.Drawing.Size(72, 55);
            this.buttonLoop.TabIndex = 12;
            this.buttonLoop.Text = "lp";
            this.buttonLoop.UseVisualStyleBackColor = true;
            this.buttonLoop.Click += new System.EventHandler(this.buttonLoop_Click);
            // 
            // buttonCaputureImage
            // 
            this.buttonCaputureImage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCaputureImage.Location = new System.Drawing.Point(646, 156);
            this.buttonCaputureImage.Name = "buttonCaputureImage";
            this.buttonCaputureImage.Size = new System.Drawing.Size(72, 55);
            this.buttonCaputureImage.TabIndex = 13;
            this.buttonCaputureImage.Text = "Cap";
            this.buttonCaputureImage.UseVisualStyleBackColor = true;
            this.buttonCaputureImage.Click += new System.EventHandler(this.buttonCaputureImage_Click);
            // 
            // buttonMute
            // 
            this.buttonMute.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonMute.Location = new System.Drawing.Point(724, 156);
            this.buttonMute.Name = "buttonMute";
            this.buttonMute.Size = new System.Drawing.Size(72, 55);
            this.buttonMute.TabIndex = 14;
            this.buttonMute.Text = "Mu";
            this.buttonMute.UseVisualStyleBackColor = true;
            this.buttonMute.Click += new System.EventHandler(this.buttonMute_Click);
            // 
            // labelPlayRate
            // 
            this.labelPlayRate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.labelPlayRate.AutoSize = true;
            this.labelPlayRate.Location = new System.Drawing.Point(855, 165);
            this.labelPlayRate.Name = "labelPlayRate";
            this.labelPlayRate.Size = new System.Drawing.Size(56, 13);
            this.labelPlayRate.TabIndex = 15;
            this.labelPlayRate.Text = "Play Rate:";
            // 
            // textBoxVideoState
            // 
            this.textBoxVideoState.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textBoxVideoState.BackColor = System.Drawing.SystemColors.Control;
            this.textBoxVideoState.Location = new System.Drawing.Point(0, 106);
            this.textBoxVideoState.Name = "textBoxVideoState";
            this.textBoxVideoState.Size = new System.Drawing.Size(176, 20);
            this.textBoxVideoState.TabIndex = 17;
            this.textBoxVideoState.Text = "Video Stopped";
            // 
            // textBoxCurrentPosition
            // 
            this.textBoxCurrentPosition.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.textBoxCurrentPosition.Location = new System.Drawing.Point(453, 106);
            this.textBoxCurrentPosition.Name = "textBoxCurrentPosition";
            this.textBoxCurrentPosition.Size = new System.Drawing.Size(153, 20);
            this.textBoxCurrentPosition.TabIndex = 23;
            this.textBoxCurrentPosition.Text = "15.21";
            this.textBoxCurrentPosition.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // buttonNoLoop
            // 
            this.buttonNoLoop.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.buttonNoLoop.Location = new System.Drawing.Point(548, 156);
            this.buttonNoLoop.Name = "buttonNoLoop";
            this.buttonNoLoop.Size = new System.Drawing.Size(75, 55);
            this.buttonNoLoop.TabIndex = 24;
            this.buttonNoLoop.Text = "nlp";
            this.buttonNoLoop.UseVisualStyleBackColor = true;
            this.buttonNoLoop.Click += new System.EventHandler(this.buttonNoLoop_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonNoLoop);
            this.groupBox1.Controls.Add(this.textBoxCurrentPosition);
            this.groupBox1.Controls.Add(this.textBoxVideoState);
            this.groupBox1.Controls.Add(this.numericUpDownPlayRate);
            this.groupBox1.Controls.Add(this.textBoxEndTime);
            this.groupBox1.Controls.Add(this.labelPlayRate);
            this.groupBox1.Controls.Add(this.buttonMute);
            this.groupBox1.Controls.Add(this.buttonNextVideo);
            this.groupBox1.Controls.Add(this.buttonCaputureImage);
            this.groupBox1.Controls.Add(this.buttonPreviousVideo);
            this.groupBox1.Controls.Add(this.buttonLoop);
            this.groupBox1.Controls.Add(this.buttonRecord);
            this.groupBox1.Controls.Add(this.buttonStop);
            this.groupBox1.Controls.Add(this.buttonNextFrame);
            this.groupBox1.Controls.Add(this.buttonPause);
            this.groupBox1.Controls.Add(this.buttonPlay);
            this.groupBox1.Controls.Add(this.buttonPreviousFrame);
            this.groupBox1.Controls.Add(this.trackBarVideo);
            this.groupBox1.Location = new System.Drawing.Point(8, 564);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1056, 220);
            this.groupBox1.TabIndex = 25;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Controls";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBoxFilename);
            this.groupBox2.Controls.Add(this.videoView1);
            this.groupBox2.Controls.Add(this.buttonVideoInformation);
            this.groupBox2.Location = new System.Drawing.Point(2, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1062, 563);
            this.groupBox2.TabIndex = 26;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "VisioMediaPlayer";
            // 
            // FullMediaPlayer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.MinimumSize = new System.Drawing.Size(843, 665);
            this.Name = "FullMediaPlayer";
            this.Size = new System.Drawing.Size(1076, 789);
            this.Load += new System.EventHandler(this.FullMediaPlayer_Load);
            this.Leave += new System.EventHandler(this.FullMediaPlayer_Leave);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.FullMediaPlayer_MouseClick);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPlayRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarVideo)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxFilename;
        private System.Windows.Forms.Button buttonVideoInformation;
        private System.Windows.Forms.ToolTip toolTip;
        private VisioForge.Core.UI.WinForms.VideoView videoView1;
        private System.Windows.Forms.Button buttonPreviousVideo;
        private System.Windows.Forms.Button buttonNextVideo;
        public System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.NumericUpDown numericUpDownPlayRate;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.TextBox textBoxEndTime;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TrackBar trackBarVideo;
        private System.Windows.Forms.Button buttonPreviousFrame;
        private System.Windows.Forms.Button buttonPlay;
        private System.Windows.Forms.Button buttonPause;
        private System.Windows.Forms.Button buttonNextFrame;
        private System.Windows.Forms.Button buttonStop;
        private System.Windows.Forms.Button buttonRecord;
        private System.Windows.Forms.Button buttonLoop;
        private System.Windows.Forms.Button buttonCaputureImage;
        private System.Windows.Forms.Button buttonMute;
        private System.Windows.Forms.Label labelPlayRate;
        private System.Windows.Forms.TextBox textBoxVideoState;
        private System.Windows.Forms.TextBox textBoxCurrentPosition;
        private System.Windows.Forms.Button buttonNoLoop;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}
