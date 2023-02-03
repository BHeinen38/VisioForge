using Proplanner;
using System;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Windows.Forms;
using VisioForge.Core.MediaPlayer;
using VisioForge.Core.Types;
using VisioForge.Core.Types.Events;

namespace VisioForgePlayground2
{
    public partial class MediaPlayer1 : UserControl, IMediaPlayer
    {

        #region Public Event Declarations
        /// <summary>
        /// Event that fires when the media has ended.
        /// </summary>
        public event EventHandler<EventArgs> OnEnded;

        /// <summary>
        /// Subscribe to this event if you want to know when the media is loading.
        /// 
        /// We will need to address this at a later date.
        /// </summary>
        public event EventHandler<EventArgs> OnLoading;

        /// <summary>
        /// Event that fires when the media has been opened.
        /// </summary>
        public event EventHandler<EventArgs> OnOpened;

        /// <summary>
        /// Event that fires to indicate progress playing the media.
        /// The progress returned by ProgressEventArgs is a percentage from 0 to 100.
        /// </summary>
        public event EventHandler<ProgressEventArgs> OnProgress;

        /// <summary>
        /// Event that fires when the media has stopped
        /// </summary>
        public event EventHandler<EventArgs> OnStopped;
        #endregion

        #region Private Variables
        private MediaPlayerCore mediaPlayer;
        private bool clickedStop = false;
        private double currentPositionSeconds = 0.0;
        private double? endTimeSeconds = null;
        private double? startTimeSeconds = null;
        private String filenameOrURL;
        private int videoIndex = 0;
        private bool isMuted = false;
        private bool isPaused = false;
        private bool isPlaying = false;
        private bool isResume = false;
        //private bool isStopped = false;
        private double playRate = 1.0;
        private int volume = 50; // Windows Media Player 50% volume

        //private TimeUnit timeUnit = TimeUnit.Milliseconds; 
        //private String timePrecisionString = "F2";
        #endregion

        #region Constructor
        public MediaPlayer1()
        {
            InitializeComponent();

            mediaPlayer = new MediaPlayerCore(videoView1 as IVideoView);
            mediaPlayer.Source_Mode = VisioForge.Core.Types.MediaPlayer.MediaPlayerSourceMode.LAV;
            mediaPlayer.Audio_PlayAudio = true;
            mediaPlayer.Info_UseLibMediaInfo = true;  
            mediaPlayer.Video_Renderer_SetAuto();
            btPause.Visible = false;

            this.timer1.Tick += this.timer1_Tick;
           // mediaPlayer.OnError += MediaPlayer1_OnError;
            mediaPlayer.OnStop += MediaPlayer1_OnStop;
            
        }
        #endregion

        #region Public Properties
        /// <summary>
        /// Returns if the current media supports changing the play rate.
        /// </summary>
        public bool CanChangePlayRate 
        {
            get
            {
                //I do not think that this will be needed but incase there is a problem with MPG videos

                //if (Path.GetExtension(filenameOrURL).ToUpper() == ".MPG")
                //{
                //    return false;
                //}

                //using this media player you will always be able to change the play rate
                return true;
            }
        }

        /// <summary>
        /// Gets or sets the file format for image captures.
        /// </summary>
        public CaptureImageFileType CaptureImageOutputFileType { get; set; }


        /// <summary>
        /// Gets or sets the current position in milliseconds for the media.
        /// </summary>
        public int CurrentPositionMilliseconds
        {
            get
            {
                //this will be the one that is used
                //return (int)TimeUnitConversion.Convert(TimeUnit.Seconds, TimeUnit.Milliseconds, mediaPlayer.Position_Get_Time().Milliseconds);
                return 0;
            }
            set
            {

                //this will be the one that is used 
                currentPositionSeconds = TimeUnitConversion.Convert(TimeUnit.Milliseconds, TimeUnit.Seconds, value);
                mediaPlayer.Position_Set_Time(TimeSpan.FromMilliseconds(currentPositionSeconds));
            }
        }

        /// <summary>
        /// Gets or sets the start time for the media clip to be played.
        /// </summary>
        public int StartTimeMilliseconds
        {
            get
            {
                return (int)TimeUnitConversion.Convert(TimeUnit.Seconds, TimeUnit.Milliseconds, StartTimeSeconds);
            }
            set
            {
                StartTimeSeconds = TimeUnitConversion.Convert(TimeUnit.Milliseconds, TimeUnit.Seconds, value);
            }


        }

        /// <summary>
        /// Gets or sets the end time for the media clip to be played.
        /// </summary>
        public int EndTimeMilliseconds
        {
            get
            {

                //this is the one that will be used 
                return (int)TimeUnitConversion.Convert(TimeUnit.Seconds, TimeUnit.Milliseconds, EndTimeSeconds);
            }
            set
            {
                EndTimeSeconds = TimeUnitConversion.Convert(TimeUnit.Milliseconds, TimeUnit.Seconds, value);

            }
        }

        /// <summary>
        /// Gets or sets a single fully qualified filename or URL to be played by the media player.
        /// </summary>
        public string FilenameOrURL
        {
            get
            {
                //try
                //{
                //    if (filenameOrURL == null)
                //    {
                //        throw new ApplicationException("A media filename or URL must be specified.");
                //    }
                //}
                //catch (Exception ex)
                //{
                //    Utilities.HandleException(ex); //ask Rob why we cannot use the public property instead. Generating exceptions can be expensive. 
                //}
                return filenameOrURL;
            }
            set
            {
                filenameOrURL = value;

                // Media file has changed so null out the times so they are recalculated
                startTimeSeconds = null;
                endTimeSeconds = null;
            }
        }

        /// <summary>
        /// Gets or sets if the media should be muted.
        /// </summary>
        public bool IsMuted
        {
            get
            {
                return isMuted;
            }
            set
            {
                isMuted = value;

                if (value)
                {
                    // Want the audio muted so set the volume to the Windows Media Player minimum volume
                    mediaPlayer.Audio_OutputDevice_Volume_Set(0, 0);
                }
                else
                {
                    mediaPlayer.Audio_OutputDevice_Volume_Set(0, volume);
                }
            }
        }

        /// <summary>
        /// Gets if the current media is in a paused state.
        /// </summary>
        public bool IsPaused
        {
            get
            {
                return isPaused;
            }
        }

        /// <summary>
        ///  Gets if the current media is in the playing state.
        /// </summary>
        public bool IsPlaying
        {
            get
            {
                return isPlaying;
            }
        }

        /// <summary>
        /// Sets the play rate for the currently selected media.
        /// </summary>
        public double PlayRate
        {
            get
            {
                return playRate;
            }
            set
            {
                playRate = value;
                mediaPlayer.SetSpeed(playRate);
            }
        }

        /// <summary>
        /// Gets the UserControl associated with this media player.
        /// </summary>
        public UserControl UserControl
        {
            get
            {
                return this;
            }
        }


        /// <summary>
        /// Gets or sets the volume for the media.
        /// Volume is expected in the range of 0 to 100.
        /// </summary>
        public double Volume
        {
            get
            {
                return volume;
            }
            set
            {
                volume = (int)value;
                if (!IsMuted)
                {
                    mediaPlayer.Audio_OutputDevice_Volume_Set(0, volume);
                }
            }
        }
        #endregion

        #region Private Properties
        private double EndTimeSeconds
        {
            get
            {
                if (!endTimeSeconds.HasValue)
                {
                    // End time was not specified, so just use 0.0
                    endTimeSeconds = 0.0;
                }
                return endTimeSeconds.Value;
            }
            set
            {
                endTimeSeconds = value;
            }
        }

        private double StartTimeSeconds
        {
            get
            {
                if (!startTimeSeconds.HasValue)
                {
                    // Start time was not specified, so just use 0.0
                    startTimeSeconds = 0.0;
                }
                return startTimeSeconds.Value;
            }
            set
            {
                startTimeSeconds = value;
            }
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Captures an image from the current frame in the media player.
        /// </summary>
        /// <param name="outputDirectory">Output directory for the captured image.</param>
        /// <param name="outputFilename">Output filename for the captured image.</param>
        /// <returns>Fully qualified path and filename for the captured image.</returns>
        public string CaptureImage(string outputDirectory, string outputFilename)
        {
            String filePath = Path.Combine(outputDirectory, outputFilename);

            //Delete any previous temporary files
            if (File.Exists(filePath))
            {
                File.SetAttributes(filePath, FileAttributes.Normal);
                File.Delete(filePath);
            }
            
            //below is how it was done in previously so just want to leave this here for now. 

            //var ffMpeg = new NReco.VideoConverter.FFMpegConverter();
            //ffMpeg.GetVideoThumbnail(mediaPlayer.FilenamesOrURL, filePath, mediaPlayer.Position_Get_Time().Milliseconds);

            string extension = Path.GetExtension(filePath).ToUpper();
            ImageFormat format = ImageFormat.Jpeg;

            switch (extension)
            {
                case "PNG":
                    format = ImageFormat.Png;
                    break;
                case "BMP":
                    format = ImageFormat.Bmp;
                    break;
                case "GIF":
                    format = ImageFormat.Gif;
                    break;
                case "TIF":
                    format = ImageFormat.Tiff;
                    break;
            }

            mediaPlayer.Frame_Save(filePath, format, 50, 50);

            return filePath;

        }

        /// <summary>
        /// Clears the current video from the control.
        /// </summary>
        public void Clear()
        {
            //In this UI It does not look like we will ever be loading more 
            //than one video at a time so it it is sufficient to clear the entire list
            mediaPlayer.Playlist_Clear();

            //if we wanted to remove the current video at a time it would look something like this
            //mediaPlayer.Playlist_RemoveAt(videoIndex);
        }

        /// <summary>
        /// Displays the frame at the specified frameTime in milliseconds for the media player.
        /// </summary>
        /// <param name="frameTimeMilliseconds">Time of frame to display in milliseconds.</param>
        public void DisplayFrameMilliseconds(int frameTimeMilliseconds)
        {

            //This will be needed for this method to work as expected 
            currentPositionSeconds = TimeUnitConversion.Convert(TimeUnit.Milliseconds, TimeUnit.Seconds, frameTimeMilliseconds);

            //this will be the set time that should be used 
            mediaPlayer.Position_Set_Time(TimeSpan.FromMilliseconds(currentPositionSeconds));

            Play(); //why are we calling play in here. Take it to Rob

        }

        /// <summary>
        /// Advances to the next frame of the currently selected video.
        /// </summary>
        public void NextFrame()
        {
            mediaPlayer.NextFrame();
            timerProgress_Tick(this, EventArgs.Empty);
        }

        /// <summary>
        /// Pauses playback of the currently selected media.
        /// </summary>
        public void Pause()
        {
            isPlaying = false;
            isResume = true;
            mediaPlayer.Pause();
        }

        /// <summary>
        /// Starts playback of the currently selected media.
        /// </summary>
        public void Play()
        {
            if (mediaPlayer.Playlist_GetFilename(videoIndex) != filenameOrURL)
            {
                mediaPlayer.Playlist_Add(filenameOrURL);
                videoIndex++; //make sure we are not overridng our playlist
            }


            mediaPlayer.Position_Set_Time(TimeSpan.FromMilliseconds(currentPositionSeconds));
            mediaPlayer.SetSpeed(playRate);


            mediaPlayer.Play();
            timer1.Start();
            

            isPaused = false;
        }

        /// <summary>
        /// Regresses to the previous frame of the currently selected video.
        /// </summary>
        public void PreviousFrame()
        {
            mediaPlayer.PreviousFrame(); 
            timerProgress_Tick(this, EventArgs.Empty);
        }

        /// <summary>
        /// Resumes playback of the currently selected media.  This function would
        /// normally be called when the media is in the paused state.
        /// </summary>
        public void Resume()
        {
            mediaPlayer.Resume();
        }

        /// <summary>
        /// Stops playback of the currently selected media.
        /// </summary>
        public void Stop(bool clickedStop)
        {
            this.clickedStop = clickedStop;
          
            timer1.Stop();
            mediaPlayer.Stop();

            if (OnStopped != null)
            {
                OnStopped(this, EventArgs.Empty);
            }


        }
        #endregion

        #region Private Methods
        private string Helpful_SecondsToTime(int seconds)
        {
            //minutes and seconds 
            return TimeSpan.FromSeconds(seconds).ToString("mm\\:ss", CultureInfo.InvariantCulture);

            //only seconds
            //return TimeSpan.FromSeconds(seconds).ToString("ss", CultureInfo.InvariantCulture);
        }
        #endregion

        #region Event Handlers
        private void MediaPlayer_Load(object sender, EventArgs e)
        {
            Text += $" (SDK v{mediaPlayer.SDK_Version()})";
            mediaPlayer.Debug_Dir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "VisioForge");
            
            if(OnOpened != null)
            {
                OnOpened(this, EventArgs.Empty);
            }
        }
        private void MediaPlayer1_OnStop(object sender, StopEventArgs e)
        {
            tbTimeline.Value = 0;

            if (OnStopped != null && clickedStop == true)
            {
                OnStopped(this, EventArgs.Empty);
            }
        }

        private void timerProgress_Tick(Object sender, System.EventArgs e)
        {
            double positionTime = mediaPlayer.Position_Get_Frame();

            // Express the progress as a percentage
            int progressPercent = Convert.ToInt32(((positionTime - StartTimeSeconds) / (EndTimeSeconds - StartTimeSeconds)) * 100.0);
            if (progressPercent >= 100)
            {
                // Greater than 100 means we have gone beyond the end time, so stop playback
                mediaPlayer.Stop();
            }
            else if (progressPercent >= 0)
            {
                if (OnProgress != null)
                {
                    ProgressEventArgs progressEventArgs = new ProgressEventArgs(progressPercent);
                    OnProgress(sender, progressEventArgs);
                }
            }
        }

        private void btPlay_Click(object sender, EventArgs e)
        {
            lbVideoState.Text = "Video Playing";
            btPlay.Visible = false;
            btPause.Visible = true;

            if(isResume == true)
            {
                Resume();
            }
            else if(clickedStop == true)
            {
                mediaPlayer.Position_Set_Time(TimeSpan.FromMilliseconds(StartTimeSeconds));
                clickedStop = false;
                isPlaying = true;
                Play();
            }
            else
            {
                isPlaying = true;
                Play();
                timer1.Start();
            }
        }

        private void btPause_Click(object sender, EventArgs e)
        {
            btPause.Visible = false;
            btPlay.Visible = true;

            lbVideoState.Text = "Video Paused";
                isPaused = true;
                Pause();
        }

        private void btMute_Click(object sender, EventArgs e)
        {
            if(isMuted == false)
            {
                IsMuted = true;
                isMuted = true;
            }
            else
            {
                IsMuted = false;
                isMuted = false;

            }
        }
        

        private void tbTimeline_Scroll(object sender, EventArgs e)
        { 
            if (Convert.ToInt32(timer1.Tag) == 0)
            {
               mediaPlayer.Position_Set_Time(TimeSpan.FromSeconds(tbTimeline.Value));
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Tag = 1;
            tbTimeline.Maximum = (int)mediaPlayer.Duration_Time().TotalSeconds;

            int value = (int)mediaPlayer.Position_Get_Time().TotalSeconds;

            if (tbTimeline.Value == tbTimeline.Maximum && !mediaPlayer.Playlist_PlayNext() && OnEnded != null)
            {
                OnEnded(this, EventArgs.Empty);
            }

            if ((value > 0) && (value < tbTimeline.Maximum))
            {
                tbTimeline.Value = value;
            }

            textBTime.Text = Helpful_SecondsToTime(tbTimeline.Value) + "/" + Helpful_SecondsToTime(tbTimeline.Maximum);

            //below is how it is being done in the Assembly planner just do not have the namespaces and wanted to test this is as close as I could get it 

            //lbTime.Text = String.Format("{0} / {1} {2}",
            //                                        TimeUnitConversion.Convert(TimeUnit.Milliseconds, timeUnit, StartTimeMilliseconds).ToString(timePrecisionString),
            //                                        TimeUnitConversion.Convert(TimeUnit.Milliseconds, timeUnit, EndTimeMilliseconds).ToString(timePrecisionString),
            //                                        TimeUnitConversion.GetShortenedTimeUnitString(timeUnit.ToString()));


            timer1.Tag = 0;
        }

        private void MediaPlayer_Leave(object sender, EventArgs e)
        {
            if (mediaPlayer != null)
            {
                mediaPlayer.OnStop -= MediaPlayer1_OnStop;
                //mediaPlayer.OnError -= MediaPlayer1_OnError;

                mediaPlayer.Dispose();
                mediaPlayer = null;
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            if(mediaPlayer != null)
            {
                mediaPlayer.SetSpeed((double)numericUpDownPlayRate.Value); 
            }
        }
        //private void MediaPlayer1_OnError(object sender, ErrorsEventArgs e)
        //{
        //    //this will need to be commented out once we get the namespaces

        //    //// If the Player encounters a corrupt or missing file, 
        //    //// show the hexadecimal error code and URL.
        //    //try
        //    //{
        //    //    IWMPMedia2 errSource = e.pMediaObject as IWMPMedia2;
        //    //    IWMPErrorItem errorItem = errSource.Error;
        //    //    UtilityMethods.ShowError("Error " + errorItem.errorCode.ToString("X") + " in " + errSource.sourceURL);
        //    //}
        //    //catch (InvalidCastException) // In case pMediaObject is not an IWMPMedia item.
        //    //{
        //    //    UtilityMethods.ShowError("Error.");
        //    //}
        //}

        //this is not really useful at the moment
        private void MediaPlayer_MouseClick(object sender, MouseEventArgs e) //this need to be checked with Rob
        {
            if(e.Button == MouseButtons.Right)
            {
                if (Parent != null && Parent.Parent != null)
                {
                    Parent.Parent.ContextMenuStrip.Show(MousePosition);
                }
            }
        }
       
        private void buttonStop_Click(object sender, EventArgs e)
        {
            isPlaying = false;
            btPause.Visible = false;
            btPlay.Visible = true;
            isResume = false;


            if (OnStopped != null && clickedStop == true)
            {
                OnStopped(this, EventArgs.Empty);
            }
            Stop(true);

            timer1.Stop();

            tbTimeline.Value = 0;
        }
        #endregion

        private void videoView1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (Parent != null && Parent.Parent != null)
                {
                    Parent.Parent.ContextMenuStrip.Show(MousePosition);
                }
            }
        }
    }
}
