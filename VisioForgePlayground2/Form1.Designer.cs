namespace VisioForgePlayground2
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.edFilename = new System.Windows.Forms.TextBox();
            this.btSelectFile = new System.Windows.Forms.Button();
            this.videoView1 = new VisioForge.Core.UI.WinForms.VideoView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tbSpeed = new System.Windows.Forms.TrackBar();
            this.label2 = new System.Windows.Forms.Label();
            this.lbTime = new System.Windows.Forms.Label();
            this.tbTimeline = new System.Windows.Forms.TrackBar();
            this.btStop = new System.Windows.Forms.Button();
            this.btPause = new System.Windows.Forms.Button();
            this.btResume = new System.Windows.Forms.Button();
            this.btStart = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btUnmute = new System.Windows.Forms.Button();
            this.btMute = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.tbVolume1 = new System.Windows.Forms.TrackBar();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbSpeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbTimeline)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbVolume1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "File Name";
            // 
            // edFilename
            // 
            this.edFilename.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edFilename.Location = new System.Drawing.Point(29, 28);
            this.edFilename.Name = "edFilename";
            this.edFilename.Size = new System.Drawing.Size(822, 22);
            this.edFilename.TabIndex = 1;
            this.edFilename.Text = "C:\\samples\\!video.mp4";
            // 
            // btSelectFile
            // 
            this.btSelectFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btSelectFile.Location = new System.Drawing.Point(875, 28);
            this.btSelectFile.Name = "btSelectFile";
            this.btSelectFile.Size = new System.Drawing.Size(75, 23);
            this.btSelectFile.TabIndex = 2;
            this.btSelectFile.Text = "...";
            this.btSelectFile.UseVisualStyleBackColor = true;
            this.btSelectFile.Click += new System.EventHandler(this.btSelectFile_Click);
            // 
            // videoView1
            // 
            this.videoView1.BackColor = System.Drawing.Color.Black;
            this.videoView1.Location = new System.Drawing.Point(29, 57);
            this.videoView1.Name = "videoView1";
            this.videoView1.Size = new System.Drawing.Size(902, 459);
            this.videoView1.StatusOverlay = null;
            this.videoView1.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tbSpeed);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.lbTime);
            this.groupBox1.Controls.Add(this.tbTimeline);
            this.groupBox1.Controls.Add(this.btStop);
            this.groupBox1.Controls.Add(this.btPause);
            this.groupBox1.Controls.Add(this.btResume);
            this.groupBox1.Controls.Add(this.btStart);
            this.groupBox1.Location = new System.Drawing.Point(29, 534);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(628, 135);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Controls";
            // 
            // tbSpeed
            // 
            this.tbSpeed.Location = new System.Drawing.Point(472, 79);
            this.tbSpeed.Name = "tbSpeed";
            this.tbSpeed.Size = new System.Drawing.Size(104, 56);
            this.tbSpeed.TabIndex = 7;
            this.tbSpeed.Scroll += new System.EventHandler(this.tbSpeed_Scroll);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(469, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 16);
            this.label2.TabIndex = 6;
            this.label2.Text = "Speed";
            // 
            // lbTime
            // 
            this.lbTime.AutoSize = true;
            this.lbTime.Location = new System.Drawing.Point(469, 29);
            this.lbTime.Name = "lbTime";
            this.lbTime.Size = new System.Drawing.Size(107, 16);
            this.lbTime.TabIndex = 5;
            this.lbTime.Text = "00:00:00/00:00:00";
            // 
            // tbTimeline
            // 
            this.tbTimeline.Location = new System.Drawing.Point(20, 17);
            this.tbTimeline.Name = "tbTimeline";
            this.tbTimeline.Size = new System.Drawing.Size(406, 56);
            this.tbTimeline.TabIndex = 4;
            this.tbTimeline.Scroll += new System.EventHandler(this.tbTimeline_Scroll);
            // 
            // btStop
            // 
            this.btStop.Location = new System.Drawing.Point(302, 79);
            this.btStop.Name = "btStop";
            this.btStop.Size = new System.Drawing.Size(75, 23);
            this.btStop.TabIndex = 3;
            this.btStop.Text = "Stop";
            this.btStop.UseVisualStyleBackColor = true;
            this.btStop.Click += new System.EventHandler(this.btStop_Click);
            // 
            // btPause
            // 
            this.btPause.Location = new System.Drawing.Point(205, 79);
            this.btPause.Name = "btPause";
            this.btPause.Size = new System.Drawing.Size(75, 23);
            this.btPause.TabIndex = 2;
            this.btPause.Text = "Pause";
            this.btPause.UseVisualStyleBackColor = true;
            this.btPause.Click += new System.EventHandler(this.btPause_Click);
            // 
            // btResume
            // 
            this.btResume.Location = new System.Drawing.Point(112, 79);
            this.btResume.Name = "btResume";
            this.btResume.Size = new System.Drawing.Size(75, 23);
            this.btResume.TabIndex = 1;
            this.btResume.Text = "Resume";
            this.btResume.UseVisualStyleBackColor = true;
            this.btResume.Click += new System.EventHandler(this.btResume_Click);
            // 
            // btStart
            // 
            this.btStart.Location = new System.Drawing.Point(20, 79);
            this.btStart.Name = "btStart";
            this.btStart.Size = new System.Drawing.Size(75, 23);
            this.btStart.TabIndex = 0;
            this.btStart.Text = "Start";
            this.btStart.UseVisualStyleBackColor = true;
            this.btStart.Click += new System.EventHandler(this.btStart_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btUnmute);
            this.groupBox2.Controls.Add(this.btMute);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.tbVolume1);
            this.groupBox2.Location = new System.Drawing.Point(663, 534);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(268, 135);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Audio output";
            // 
            // btUnmute
            // 
            this.btUnmute.Location = new System.Drawing.Point(141, 99);
            this.btUnmute.Name = "btUnmute";
            this.btUnmute.Size = new System.Drawing.Size(75, 23);
            this.btUnmute.TabIndex = 3;
            this.btUnmute.Text = "Unmute";
            this.btUnmute.UseVisualStyleBackColor = true;
            this.btUnmute.Click += new System.EventHandler(this.btUnmute_Click);
            // 
            // btMute
            // 
            this.btMute.Location = new System.Drawing.Point(45, 99);
            this.btMute.Name = "btMute";
            this.btMute.Size = new System.Drawing.Size(75, 23);
            this.btMute.TabIndex = 2;
            this.btMute.Text = "Mute";
            this.btMute.UseVisualStyleBackColor = true;
            this.btMute.Click += new System.EventHandler(this.btMute_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(62, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 16);
            this.label3.TabIndex = 1;
            this.label3.Text = "Volume";
            // 
            // tbVolume1
            // 
            this.tbVolume1.Location = new System.Drawing.Point(55, 48);
            this.tbVolume1.Name = "tbVolume1";
            this.tbVolume1.Size = new System.Drawing.Size(149, 56);
            this.tbVolume1.TabIndex = 0;
            this.tbVolume1.Scroll += new System.EventHandler(this.tbVolume1_Scroll);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(981, 682);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.videoView1);
            this.Controls.Add(this.btSelectFile);
            this.Controls.Add(this.edFilename);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbSpeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbTimeline)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbVolume1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox edFilename;
        private System.Windows.Forms.Button btSelectFile;
        private global::VisioForge.Core.UI.WinForms.VideoView videoView1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btStop;
        private System.Windows.Forms.Button btPause;
        private System.Windows.Forms.Button btResume;
        private System.Windows.Forms.Button btStart;
        private System.Windows.Forms.TrackBar tbTimeline;
        private System.Windows.Forms.Label lbTime;
        private System.Windows.Forms.TrackBar tbSpeed;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TrackBar tbVolume1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btUnmute;
        private System.Windows.Forms.Button btMute;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Timer timer1;
    }
}

