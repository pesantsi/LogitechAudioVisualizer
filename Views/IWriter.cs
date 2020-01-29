// Decompiled with JetBrains decompiler
// Type: LogitechSpectrogram.IWriter
// Assembly: Logitech Spectrogram, Version=2.8.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 51487773-CCC1-46AA-85F4-7E087432A9E8
// Assembly location: C:\Users\spesant\Downloads\Logitech Spectrogram v2.8.0 (64-bit)\Logitech Spectrogram.exe

namespace LogitechSpectrogram
{
  public interface IWriter
  {
    void Write(byte[] fftData, int[,] settings);
  }
}
