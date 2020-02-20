namespace LogitechSpectrogram.Writers
{
    public interface IWriter
    {
        void Write(byte[] fftData);
    }
}
