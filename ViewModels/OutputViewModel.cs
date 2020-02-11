using System;
using System.Windows.Media;

namespace LogitechAudioVisualizer.ViewModels
{
    public class ImageUpdatedEventArgs : EventArgs
    {
        public byte[] FftData { get; }
        public int OsVerticalScale { get; }
        public Color BackgroundColor { get; }
        public Color ForegroundColor { get; }

        public ImageUpdatedEventArgs(byte[] fftData, int osVerticalScale, Color backgroundColor, Color foregroundColor)
        {
            FftData = new byte[fftData.Length];
            Array.Copy(fftData, 0, FftData, 0, fftData.Length);

            OsVerticalScale = osVerticalScale;
            BackgroundColor = backgroundColor;
            ForegroundColor = foregroundColor;
        }
    }

    public class OutputViewModel : ViewModelBase
    {
        public event EventHandler<ImageUpdatedEventArgs> ImageUpdated;

        public void UpdateImage(byte[] fftData, int osVerticalScale, Color backgroundColor, Color foregroundColor)
        {
            ImageUpdated?.Invoke(this, new ImageUpdatedEventArgs(fftData, osVerticalScale, backgroundColor, foregroundColor));
        }
    }
}
