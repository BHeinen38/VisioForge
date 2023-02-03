using System;
using System.IO;
using System.Windows.Forms;
using VisioForge.Core.MediaPlayer;
using VisioForge.Core.Types;
using VisioForge.Core.Types.Events;

namespace VisioForgePlayground2
{
    public partial class Form1 : Form
    {
        private MediaPlayerCore MediaPlayer1;
        private void CreateEngine()
        {
            MediaPlayer1 = new MediaPlayerCore(videoView1 as IVideoView);
            MediaPlayer1.OnStop += MediaPlayer1_OnStop;
        }


        //this need to be referenced in the form is closing
        private void DestroyEngine()
        {
            if (MediaPlayer1 != null)
            {
                MediaPlayer1.OnStop -= MediaPlayer1_OnStop;

                MediaPlayer1.Dispose();
                MediaPlayer1 = null;
            }
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void btSelectFile_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                edFilename.Text = openFileDialog1.FileName;
            }

        }

        private async void btStart_Click(object sender, EventArgs e)
        {
            MediaPlayer1.Source_Mode = global::VisioForge.Core.Types.MediaPlayer.MediaPlayerSourceMode.LAV;

            MediaPlayer1.FilenamesOrURL.Add(edFilename.Text);
            MediaPlayer1.Audio_PlayAudio = true;
            MediaPlayer1.Info_UseLibMediaInfo = true;
            MediaPlayer1.Audio_OutputDevice = "Default DirectSound Device";


            MediaPlayer1.Video_Renderer_SetAuto();

            await MediaPlayer1.PlayAsync();


            // set audio volume for each stream
            MediaPlayer1.Audio_OutputDevice_Volume_Set(0, tbVolume1.Value);

            timer1.Start();

        }

        private async void btResume_Click(object sender, EventArgs e)
        {
            await MediaPlayer1.ResumeAsync();
        }

        private async void btPause_Click(object sender, EventArgs e)
        {
            await MediaPlayer1.PauseAsync();
        }

        private async void btStop_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            await MediaPlayer1.StopAsync();
            tbTimeline.Value = 0;

        }

        private async void tbTimeline_Scroll(object sender, EventArgs e)
        {
            if (Convert.ToInt32(timer1.Tag) == 0)
            {
                await MediaPlayer1.Position_Set_TimeAsync(TimeSpan.FromSeconds(tbTimeline.Value));
            }
        }

        private void tbSpeed_Scroll(object sender, EventArgs e)
        {
            MediaPlayer1.SetSpeedAsync(tbSpeed.Value / 10.0);
        }

        private void tbVolume1_Scroll(object sender, EventArgs e)
        {
            MediaPlayer1.Audio_OutputDevice_Volume_Set(0, tbVolume1.Value);
        }

        private void btMute_Click(object sender, EventArgs e)
        {
            MediaPlayer1.Audio_OutputDevice_Volume_Set(0, 0);
        }

        private void btUnmute_Click(object sender, EventArgs e)
        {
            MediaPlayer1.Audio_OutputDevice_Volume_Set(0, tbVolume1.Value);
        }

        //private void btNextFrame_Click(object sender, EventArgs e)
        //{
        //    mediaPlayer.NextFrame();
        //}

        //private void btPreviousFrame_Click(object sender, EventArgs e)
        //{
        //    mediaPlayer.PreviousFrame();
        //}

        private void Form1_Load(object sender, EventArgs e)
        {
            CreateEngine();

            Text += $" (SDK v{MediaPlayer1.SDK_Version()})";
            MediaPlayer1.Debug_Dir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "VisioForge");
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            btStop_Click(null, null);

            DestroyEngine();
        }
        private async void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Tag = 1;
            tbTimeline.Maximum = (int)(await MediaPlayer1.Duration_TimeAsync()).TotalSeconds;

            int value = (int)(await MediaPlayer1.Position_Get_TimeAsync()).TotalSeconds;
            if ((value > 0) && (value < tbTimeline.Maximum))
            {
                tbTimeline.Value = value;
            }

            lbTime.Text = MediaPlayer1.Helpful_SecondsToTimeFormatted(tbTimeline.Value) + "/" + MediaPlayer1.Helpful_SecondsToTimeFormatted(tbTimeline.Maximum);

            timer1.Tag = 0;
        }
        private void MediaPlayer1_OnStop(object sender, StopEventArgs e)
        {
            Invoke((Action)(() =>
            {
                tbTimeline.Value = 0;
            }));
        }
    }
}
