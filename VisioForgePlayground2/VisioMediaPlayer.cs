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
    public partial class VisioMediaPlayer : UserControl, IMediaPlayer
    {
        #region Public Event Declarations
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
        private bool isDisplayFrame = false;
        //private bool isStopped = false;
        private double playRate = 1.0;
        private bool loadedMedia = false;
        private int volume = 50; // Windows Media Player 50% volume

        //private TimeUnit timeUnit = TimeUnit.Milliseconds; 
        //private String timePrecisionString = "F2";
        #endregion

        #region Constructor
        /// <summary>
        /// Constructs the media player.
        /// </summary>
        public VisioMediaPlayer()
        {
            InitializeComponent();

            mediaPlayer = new MediaPlayerCore(videoView1 as IVideoView);
            mediaPlayer.Source_Mode = VisioForge.Core.Types.MediaPlayer.MediaPlayerSourceMode.LAV;
            mediaPlayer.Audio_PlayAudio = true;
            mediaPlayer.Info_UseLibMediaInfo = true;
            Text += $" (SDK v{mediaPlayer.SDK_Version()})";
            mediaPlayer.Debug_Dir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "VisioForge");

            mediaPlayer.Video_Renderer_SetAuto();
            // mediaPlayer.OnError += MediaPlayer1_OnError;;
        }
        #endregion

        #region Public Properties

        /// <summary>
        /// Returns if the current media supports changing the play rate.
        /// </summary>
        public bool CanChangePlayRate => throw new NotImplementedException();

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
                return (int)TimeUnitConversion.Convert(TimeUnit.Seconds, TimeUnit.Milliseconds, mediaPlayer.Position_Get_Time().Milliseconds);
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
            bool loadedMedia = false;


            if (mediaPlayer.Playlist_GetFilename(videoIndex) != filenameOrURL)
            {
                if(OnLoading != null)
                {
                    OnLoading(this, EventArgs.Empty);
                }

                try
                {
                    if (mediaPlayer.Playlist_Add(filenameOrURL)){
                        if(OnOpened != null)
                        {
                            OnOpened(this, EventArgs.Empty);
                        }
                    }

                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
                loadedMedia = true;
            }


            mediaPlayer.Position_Set_Time(TimeSpan.FromMilliseconds(currentPositionSeconds));
            mediaPlayer.SetSpeed(playRate);

            if (!loadedMedia)
            {
                mediaPlayer.Play();
            }
            


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

        #endregion

        #region Event Handlers
        private void videoView1_StyleChanged(object sender, EventArgs e)
        {
            if (mediaPlayer.State() == PlaybackState.Play)
            {
                timer1.Enabled = true;
                if (isDisplayFrame)
                {
                    Pause();
                    isDisplayFrame = false;
                }
            }
            else if (mediaPlayer.State() == PlaybackState.Pause)
            {
                timer1.Enabled = false;
            }
            else if (!isDisplayFrame && mediaPlayer.State() == PlaybackState.Free)
            {
                timer1.Enabled = false;
                if (clickedStop)
                {
                    if (OnStopped != null)
                    {
                        OnStopped(sender, EventArgs.Empty);
                    }
                }
                else
                {
                    if (OnEnded != null)
                    {
                        OnEnded(sender, EventArgs.Empty);
                    }
                }
                clickedStop = false;
            }
        }

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
        #endregion
    }
}
