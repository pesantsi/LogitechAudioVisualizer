using Avalonia.Media;
using System;

namespace LogitechAudioVisualizer.ViewModels
{
    public class ImageUpdatedEventArgs : EventArgs
    {
        public byte[] FftData { get; }
        //public int[,] Settings { get; }
        public int OsVerticalScale { get; }
        //public bool OsHighQuality { get; }
        public Color BackgroundColor { get; }
        public Color ForegroundColor { get; }
        
        public ImageUpdatedEventArgs(byte[] fftData,/* int[,] settings,*/ int osVerticalScale,/* bool osHighQuality,*/ Color backgroundColor, Color foregroundColor)
        {
            FftData = new byte[fftData.Length];
            //Settings = new int[settings.GetLength(0), settings.GetLength(1)];

            Array.Copy(fftData, 0, FftData, 0, fftData.Length);
            //Array.Copy(settings, 0, Settings, 0, settings.Length);
            OsVerticalScale = osVerticalScale;
            //OsHighQuality = osHighQuality;
            BackgroundColor = backgroundColor;
            ForegroundColor = foregroundColor;
        }
    }

    public class OutputViewModel : ViewModelBase
    {
        public event EventHandler<ImageUpdatedEventArgs> ImageUpdated;

        public void UpdateImage(byte[] fftData, /*int[,] settings,*/ int osVerticalScale, /*bool osHighQuality,*/ Color backgroundColor, Color foregroundColor)
        {
            ImageUpdated?.Invoke(this, new ImageUpdatedEventArgs(fftData, /*settings,*/ osVerticalScale, /*osHighQuality,*/ backgroundColor, foregroundColor));
        }
    }
}
