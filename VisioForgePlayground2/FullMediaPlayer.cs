using Proplanner;
using System;
using System.Globalization;
using System.IO;
using System.Windows.Forms;
using VisioForge.Core.MediaPlayer;
using VisioForge.Core.Types;
using VisioForge.Core.Types.Events;



namespace VisioForgePlayground2
{
    /// <summary>
    /// Visio Forge Media Player
    /// </summary>
    public partial class FullMediaPlayer : UserControl, IMediaPlayer
    {
        public MediaPlayerCore MediaPlayer1;
        private bool clickedStop = false;
        private double currentPositionSeconds = 0.0;
        private double? endTimeSeconds = 0.0;
        private String filenameOrURL;
        private bool isMuted = false;
        private bool isPaused = false;
        private bool isPlaying = false;
        private bool isResume = false;
        private double playRate = 1.0;
        private double? startTimeSeconds = 0.0;
        private int volume = 50; // Windows Media Player 50% volume
        private bool loopVideo = false;
        private int videoIndex = 0; //this still needs to implemented
        private TimeUnit timeUnit = TimeUnit.Milliseconds;
        private String timePrecisionString = "F2";

        /// <summary>
        /// Constructs the media player.
        /// </summary>
        public FullMediaPlayer()
        {
            InitializeComponent();

            MediaPlayer1 = new MediaPlayerCore(videoView1 as IVideoView);
            MediaPlayer1.Source_Mode = VisioForge.Core.Types.MediaPlayer.MediaPlayerSourceMode.LAV;
            MediaPlayer1.Audio_PlayAudio = true;
            MediaPlayer1.Info_UseLibMediaInfo = true;
            MediaPlayer1.Audio_OutputDevice = "Default DirectSound Device";

            // this is a useful way to be able to test.
            //mediaPlayer.FilenamesOrURL.Add("C:\\Users\\bailey.heinen\\Documents\\ProPlannerAppDummyFiles\\SNAP_20180901-120032.mp4");
            //mediaPlayer.FilenamesOrURL.Add("C:\\Users\\bailey.heinen\\Documents\\ProPlannerAppDummyFiles\\Work1.MPG");
            MediaPlayer1.Video_Renderer_SetAuto();

            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            MediaPlayer1.OnError += MediaPlayer1_OnError;
            MediaPlayer1.OnStop += MediaPlayer1_OnStop;
            MediaPlayer1.OnPlaylistFinished += MediaPlayer1_OnPlaylistFinished;
            //mediaPlayer. += FullMediaPlayer_MouseClick; //I do not know how we are going to implement mouse clicking with this media platform
        }

        /// <summary>
        /// Event that fires when the media has ended.
        /// </summary>
        public event EventHandler<EventArgs> OnEnded;

        /// <summary>
        /// Subscribe to this event if you want to know when the media is loading.
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

        /// <summary>
        /// Returns if the current media supports changing the play rate.
        /// </summary>
        public bool CanChangePlayRate
        {
            get
            {
                //Windows Media Player has a problem with .MPG files but I do not believe Visio will have the same problems

                //if (Path.GetExtension(filenameOrURL).ToUpper() == ".MPG")
                //{
                //    return false;
                //}

                //using this media player you will always be able to change the play rate
                return true;
            }
        }

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

            //I have to be able to access the namespace

            //var ffMpeg = new NReco.VideoConverter.FFMpegConverter();

            //I am including both of these right now becasue I think they both might be valid and 
            //do not know which one would work better

            //ffMpeg.GetVideoThumbnail(mediaPlayer.Playlist_GetFilename(videoIndex), filePath, mediaPlayer.Position_Get_Time().Milliseconds);

            return filePath;

        }

        /// <summary>
        /// Gets or sets the file format for image captures.
        /// </summary>
        public CaptureImageFileType CaptureImageOutputFileType { get; set; }

        /// <summary>
        /// Clears the current video from the control.
        /// </summary>
        public void Clear()
        {
            //getting rid of all Filenames in the list 
            //mediaPlayer.Playlist_Clear();

            //This will remove a video at specific inde
            MediaPlayer1.Playlist_RemoveAt(videoIndex);
        }

        /// <summary>
        /// Gets or sets the current position in milliseconds for the media.
        /// </summary>
        public int CurrentPositionMilliseconds
        {
            get
            {
                return MediaPlayer1.Position_Get_Time().Milliseconds;

                //this will be the one that is used
                //return (int)TimeUnitConversion.Convert(TimeUnit.Seconds, TimeUnit.Milliseconds, mediaPlayer.Position_Get_Time().Milliseconds);
            }
            set
            {
                MediaPlayer1.Position_Set_Time(TimeSpan.FromMilliseconds(value));

                //this will be the one that is used 
                //mediaPlayer.Position_Set_Time(currentPositionSeconds = TimeUnitConversion.Convert(TimeUnit.Milliseconds, TimeUnit.Seconds, value));

            }
        }

        /// <summary>
        /// Displays the frame at the specified frameTime in milliseconds for the media player.
        /// </summary>
        /// <param name="frameTimeMilliseconds">Time of frame to display in milliseconds.</param>
        public void DisplayFrameMilliseconds(int frameTimeMilliseconds)
        {

            //This will be needed for this method to work as expected 
            //currentPositionSeconds = TimeUnitConversion.Convert(TimeUnit.Milliseconds, TimeUnit.Seconds, frameTimeMilliseconds);


            //this will be the set time that should be used 
            MediaPlayer1.Position_Set_Time(TimeSpan.FromMilliseconds(currentPositionSeconds));

            Play();

        }

        /// <summary>
        /// Gets or sets the end time for the media clip to be played.
        /// </summary>
        public int EndTimeMilliseconds
        {
            get
            {
                return 0;
                //this is the one that will be used 
                //return (int)TimeUnitConversion.Convert(TimeUnit.Seconds, TimeUnit.Milliseconds, EndTimeSeconds);
            }
            set
            {
                //EndTimeSeconds = TimeUnitConversion.Convert(TimeUnit.Milliseconds, TimeUnit.Seconds, value);
            }
        }

        /// <summary>
        /// Gets or sets a single fully qualified filename or URL to be played by the media player.
        /// </summary>
        public string FilenameOrURL
        {
            get
            {
                try
                {
                    if (filenameOrURL == null)
                    {
                        throw new ApplicationException("A media filename or URL must be specified.");
                    }
                }
                catch (Exception ex)
                {
                    //Will need the namespace 
                    //Utilities.HandleException(ex);
                }
                return filenameOrURL;
            }
            set
            {
                filenameOrURL = value;
                //mediaPlayer.Playlist_Add(filenameOrURL);
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
                    MediaPlayer1.Audio_OutputDevice_Volume_Set(0, 0);
                }
                else
                {
                    MediaPlayer1.Audio_OutputDevice_Volume_Set(0, volume);
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
        /// Advances to the next frame of the currently selected video.
        /// </summary>
        public void NextFrame()
        {
            MediaPlayer1.NextFrame();

            //this will need to be tested
            timerProgress_Tick(this, EventArgs.Empty);
        }

        /// <summary>
        /// Pauses playback of the currently selected media.
        /// </summary>
        public void Pause()
        {
            isPlaying = false;
            isResume = true;
            MediaPlayer1.Pause();
        }

        /// <summary>
        /// Starts playback of the currently selected media.
        /// </summary>
        public void Play()
        {
            //if (mediaPlayer.FilenamesOrURL.ToString() != filenameOrURL)
            //{
            //    mediaPlayer.FilenamesOrURL.Add(filenameOrURL);
            //}

            //this is used incase you would like to test the class.
            //MediaPlayer1.Playlist_Add("C:\\Users\\bailey.heinen\\Documents\\ProPlannerAppDummyFiles\\SNAP_20180901-120032.mp4");
            //MediaPlayer1.Playlist_Add("C:\\Users\\bailey.heinen\\Documents\\ProPlannerAppDummyFiles\\Work1.MPG");
            MediaPlayer1.Position_Set_Time(TimeSpan.FromMilliseconds(currentPositionSeconds));
            MediaPlayer1.SetSpeed(playRate);
            MediaPlayer1.Loop = loopVideo;

            MediaPlayer1.Play();
            timer1.Start();

            isPaused = false;
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
                MediaPlayer1.SetSpeed(playRate);
            }
        }

        /// <summary>
        /// Regresses to the previous frame of the currently selected video.
        /// </summary>
        public void PreviousFrame()
        {
            MediaPlayer1.PreviousFrame();
            timerProgress_Tick(this, EventArgs.Empty);
        }

        /// <summary>
        /// Resumes playback of the currently selected media.  This function would
        /// normally be called when the media is in the paused state.
        /// </summary>
        public void Resume()
        {
            MediaPlayer1.Loop = loopVideo;
            MediaPlayer1.Resume();
        }

        /// <summary>
        /// Gets or sets the start time for the media clip to be played.
        /// </summary>
        public int StartTimeMilliseconds
        {
            get
            {
                //these are the ones that we will use when we have the time conversions namespace

                //return (int)TimeUnitConversion.Convert(TimeUnit.Seconds, TimeUnit.Milliseconds, StartTimeSeconds);
                return 0;
            }
            set
            {
                //StartTimeSeconds = TimeUnitConversion.Convert(TimeUnit.Milliseconds, TimeUnit.Seconds, value);
            }
        }

        /// <summary>
        /// Stops playback of the currently selected media.
        /// </summary>
        public void Stop(bool clickedStop)
        {
            this.clickedStop = clickedStop;
            try
            {
                timer1.Stop();
                MediaPlayer1.Stop();

                //if(OnStopped != null)
                //{
                //    OnStopped(this, EventArgs.Empty);
                //}
            }
            catch
            {
                // do nothing
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
                    MediaPlayer1.Audio_OutputDevice_Volume_Set(0, volume);
                }
            }
        }

        private double EndTimeSeconds
        {
            get
            {
                if (!endTimeSeconds.HasValue)
                {
                    // End time was not specified, so just use 0.0
                    endTimeSeconds = trackBarVideo.Maximum;
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


        //below is the events
        private void numericUpDownPlayRate_ValueChanged(object sender, EventArgs e)
        {
            if (MediaPlayer1 != null)
            {
                MediaPlayer1.SetSpeed((double)numericUpDownPlayRate.Value);
            }
        }
        private void timerProgress_Tick(Object sender, System.EventArgs e)
        {
            double positionTime = MediaPlayer1.Position_Get_Frame();

            // Express the progress as a percentage
            int progressPercent = Convert.ToInt32((((int)positionTime - (int)StartTimeSeconds) / ((int)EndTimeSeconds - (int)StartTimeSeconds)) * 100.0);
            if (progressPercent >= 100)
            {
                // Greater than 100 means we have gone beyond the end time, so stop playback
                MediaPlayer1.Stop();
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
        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Tag = 1;
            trackBarVideo.Maximum = (int)MediaPlayer1.Duration_Time().TotalSeconds;

            int value = (int)MediaPlayer1.Position_Get_Time().TotalSeconds;
            
            if ((value > 0) && (value < trackBarVideo.Maximum))
            {
                trackBarVideo.Value = value;
            }

            //textBoxEndTime.Text = Helpful_SecondsToTime(trackBarVideo.Value) + "/" + Helpful_SecondsToTime(trackBarVideo.Maximum);
            textBoxCurrentPosition.Text = Helpful_SecondsToTime(trackBarVideo.Value);

            //below is how it is being done in the Assembly planner just do not have the namespaces and wanted to test this is as close as I could get it 

            textBoxEndTime.Text = String.Format("{0} / {1} {2}",
                                                    TimeUnitConversion.Convert(TimeUnit.Milliseconds, timeUnit, StartTimeSeconds).ToString(timePrecisionString),
                                                    TimeUnitConversion.Convert(TimeUnit.Milliseconds, timeUnit, EndTimeSeconds).ToString(timePrecisionString),
                                                    TimeUnitConversion.GetShortenedTimeUnitString(timeUnit.ToString()));


            timer1.Tag = 0;
        }
        private string Helpful_SecondsToTime(int seconds)
        {
            //minutes and seconds 
            return TimeSpan.FromSeconds(seconds).ToString("mm\\:ss", CultureInfo.InvariantCulture);

            //only seconds
            //return TimeSpan.FromSeconds(seconds).ToString("ss", CultureInfo.InvariantCulture);
        }

        private void trackBarVideo_Scroll(object sender, EventArgs e)
        {
            if (trackBarVideo.Value == trackBarVideo.Maximum && OnEnded != null)
            {
                OnEnded(this, EventArgs.Empty);
            }
            if(loopVideo == true && trackBarVideo.Value == trackBarVideo.Maximum)
            {
                MediaPlayer1.Loop = true;
                MediaPlayer1.Position_Set_Time(TimeSpan.MinValue);
                trackBarVideo.Value = trackBarVideo.Minimum;
            }
            else
            {
                MediaPlayer1.Loop = false;
            }

            if (Convert.ToInt32(timer1.Tag) == 0)
            {
               MediaPlayer1.Position_Set_Time(TimeSpan.FromSeconds(trackBarVideo.Value));
            }
        }

        private void FullMediaPlayer_Leave(object sender, EventArgs e)
        {
            if (MediaPlayer1 != null)
            {
                MediaPlayer1.OnStop -= MediaPlayer1_OnStop;
                MediaPlayer1.OnError -= MediaPlayer1_OnError;

                MediaPlayer1.Dispose();
                MediaPlayer1 = null;
            }
        }
        private void MediaPlayer1_OnStop(object sender, StopEventArgs e)
        {
            trackBarVideo.Value = 0;

            if (OnStopped != null) //&& clickedStop == true
            {
                OnStopped(this, EventArgs.Empty);
            }
        }
        private void MediaPlayer1_OnError(object sender, ErrorsEventArgs e)
        {
            //this will need to be commented out once we get the namespaces

            //// If the Player encounters a corrupt or missing file, 
            //// show the hexadecimal error code and URL.
            //try
            //{
            //    IWMPMedia2 errSource = e.pMediaObject as IWMPMedia2;
            //    IWMPErrorItem errorItem = errSource.Error;
            //    UtilityMethods.ShowError("Error " + errorItem.errorCode.ToString("X") + " in " + errSource.sourceURL);
            //}
            //catch (InvalidCastException) // In case pMediaObject is not an IWMPMedia item.
            //{
            //    UtilityMethods.ShowError("Error.");
            //}
        }

        private void FullMediaPlayer_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (Parent != null && Parent.Parent != null)
                {
                    Parent.Parent.ContextMenuStrip.Show(MousePosition);
                }
            }
            
        }
        private void buttonPlay_Click(object sender, EventArgs e)
        {
            clickedStop = false;
            if (isResume == true)
            {
                textBoxVideoState.Text = "Video Playing";
                MediaPlayer1.Loop = loopVideo;
                Resume();
            }
            else
            {
                isPlaying = true;
                textBoxVideoState.Text = "Video Playing";
                MediaPlayer1.Loop = loopVideo;
                Play();
                timer1.Start();
            }
        }

        private void buttonPause_Click(object sender, EventArgs e)
        {
            isPaused = true;
            textBoxVideoState.Text = "Video Paused";
            MediaPlayer1.Loop = loopVideo;
            Pause();
        }

        private void buttonMute_Click(object sender, EventArgs e)
        {
            if (isMuted == false)
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

        private void buttonStop_Click(object sender, EventArgs e)
        {
            Stop(true);

            if (OnStopped != null && clickedStop == true)
            {
                OnStopped(this, EventArgs.Empty);
            }
            
            timer1.Stop();

            trackBarVideo.Value = 0;
        }

        private void buttonPreviousFrame_Click(object sender, EventArgs e)
        {
            PreviousFrame();
        }

        private void buttonNextFrame_Click(object sender, EventArgs e)
        {
            NextFrame();
        }

        private void buttonCaputureImage_Click(object sender, EventArgs e)
        {
        }

        private void buttonPreviousVideo_Click(object sender, EventArgs e)
        {
            if(MediaPlayer1.Playlist_GetCount() > 1)
            {
                MediaPlayer1.Playlist_PlayPrevious();
                videoIndex--; //subtract the index
            }
        }

        private void buttonNextVideo_Click(object sender, EventArgs e)
        {
            if (MediaPlayer1.Playlist_GetCount() > 1)
            {
                MediaPlayer1.Playlist_PlayNext();
                videoIndex++; //add the index
            }

        }

        private void buttonRecord_Click(object sender, EventArgs e)
        {

        }

        private void buttonNoLoop_Click(object sender, EventArgs e)
        {
            loopVideo = false;
            buttonLoop.Visible = true;
            buttonNoLoop.Visible = false;

        }
        private void buttonLoop_Click(object sender, EventArgs e)
        {
            loopVideo = true;
            buttonLoop.Visible = false;
            buttonNoLoop.Visible = true;
        }

        private void FullMediaPlayer_Load(object sender, EventArgs e)
        {
            Text += $" (SDK v{MediaPlayer1.SDK_Version()})";
            MediaPlayer1.Debug_Dir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "VisioForge");

            if (OnOpened != null)
            {
                OnOpened(this, EventArgs.Empty);
            }

        }
        //this would be another way that we can implement onEnded when the playlist finishes
        private void MediaPlayer1_OnPlaylistFinished(object sender, EventArgs e)
        {
            if(OnEnded != null)
            {
                OnEnded(this, EventArgs.Empty);
            }
        }
    }
}
