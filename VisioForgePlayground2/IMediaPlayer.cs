using System;
using System.Windows.Forms;
using VisioForge.Core.Types.Events;

namespace VisioForgePlayground2
{
    /// <summary>
    /// Enumeration that defines all if the image capture file types.
    /// </summary>
    public enum CaptureImageFileType
    {
        png,
        tif,
        jpg,
        gif,
        bmp
    }

    /// <summary>
    /// Interface for using the Windows Media Player or VisioForge Media Player.
    /// </summary>
    public interface IMediaPlayer
    {
        /// <summary>
        /// Subscribe to this event if you want to know when the media has ended.
        /// </summary>
        event EventHandler<EventArgs> OnEnded;

        /// <summary>
        /// Subscribe to this event if you want to know when the media is loading.
        /// </summary>
        event EventHandler<EventArgs> OnLoading;

        /// <summary>
        /// Subscribe to this event if you want to know when the media has been opened.
        /// </summary>
        event EventHandler<EventArgs> OnOpened;

        /// <summary>
        /// Subscribe to this event if you want to know the progress playing the media.  
        /// The progress returned by ProgressEventArgs is a percentage from 0 to 100.
        /// </summary>
        event EventHandler<ProgressEventArgs> OnProgress;

        /// <summary>
        /// Subscribe to this event if you want to know when the media has been stopped.
        /// </summary>
        event EventHandler<EventArgs> OnStopped;

        /// <summary>
        /// Returns if the current media supports changing the play rate.
        /// </summary>
        bool CanChangePlayRate { get; }

        /// <summary>
        /// Clears the current video from the control.
        /// </summary>
        void Clear();

        /// <summary>
        /// Captures an image from the current frame in the media player.
        /// </summary>
        /// <param name="outputDirectory">Output directory for the captured image.</param>
        /// <param name="outputFilename">Output filename for the captured image.</param>
        /// <returns>Fully qualified path and filename for the captured image.</returns>
        String CaptureImage(String outputDirectory, String outputFilename);

        /// <summary>
        /// Gets or sets the file format for image captures.
        /// </summary>
        CaptureImageFileType CaptureImageOutputFileType { get; set; }

        /// <summary>
        /// Gets or sets the current position in milliseconds for the media.
        /// </summary>
        int CurrentPositionMilliseconds { get; set; }

        /// <summary>
        /// Displays the frame at the specified frameTime in milliseconds for the media player.
        /// </summary>
        /// <param name="frameTimeMilliseconds">Time of frame to display in milliseconds.</param>
        void DisplayFrameMilliseconds(int frameTimeMilliseconds);

        /// <summary>
        /// Gets or sets the end time in milliseconds for the media clip to be played.
        /// </summary>
        int EndTimeMilliseconds { get; set; }

        /// <summary>
        /// Gets or sets a single fully qualified filename or URL to be played by the media player.
        /// </summary>
        String FilenameOrURL { get; set; }

        /// <summary>
        /// Gets or sets if the media should be muted.
        /// </summary>
        bool IsMuted { get; set; }

        /// <summary>
        /// Gets if the current media is in a paused state.
        /// </summary>
        bool IsPaused { get; }

        /// <summary>
        /// Gets if the current media is in the playing state.
        /// </summary>
        bool IsPlaying { get; }

        /// <summary>
        /// Advances to the next frame of the currently selected video.
        /// </summary>
        void NextFrame();

        /// <summary>
        /// Pauses playback of the currently selected media.
        /// </summary>
        void Pause();

        /// <summary>
        /// Starts playback of the currently selected media.
        /// </summary>
        void Play();

        /// <summary>
        ///  Sets the play rate for the currently selected media.
        /// </summary>
        double PlayRate { set; }

        /// <summary>
        /// Regresses to the previous frame of the currently selected video.
        /// </summary>
        void PreviousFrame();

        /// <summary>
        /// Resumes playback of the currently selected media.  This function would 
        /// normally be called when the media is in the paused state.
        /// </summary>
        void Resume();

        /// <summary>
        /// Gets or sets the start time in milliseconds for the media clip to be played.
        /// </summary>
        int StartTimeMilliseconds { get; set; }

        /// <summary>
        /// Stops playback of the currently selected media.
        /// </summary>
        void Stop(bool clickedStop);

        /// <summary>
        /// Gets the UserControl associated with this media player.
        /// </summary>
        UserControl UserControl { get; }

        /// <summary>
        /// Gets or sets the volume for the media.  
        /// Volume is expected in the range of 0 to 100.
        /// </summary>
        double Volume { get; set; }
    }
}
