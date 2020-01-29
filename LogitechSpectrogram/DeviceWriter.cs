// Decompiled with JetBrains decompiler
// Type: LogitechSpectrogram.DeviceWriter
// Assembly: Logitech Spectrogram, Version=2.8.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 51487773-CCC1-46AA-85F4-7E087432A9E8
// Assembly location: C:\Users\spesant\Downloads\Logitech Spectrogram v2.8.0 (64-bit)\Logitech Spectrogram.exe

using LedCSharp;
using System;
using System.Drawing;

namespace LogitechSpectrogram
{
  internal class DeviceWriter : IWriter
  {
    private int vGradientPosition = 1;
    private bool vGradientForward = true;
    private int hGradientPosition = 16;
    private bool hGradientForward = true;

    public void Write(byte[] fftData, int[,] settings)
    {
      if (settings[0, 2] != 1)
        return;
      bool flag = false;
      for (int index = 0; index < fftData.Length / 2; ++index)
      {
        if (fftData[index] > (byte) 0)
        {
          flag = true;
          break;
        }
      }
      LogitechGSDK.LogiLedSetTargetDevice(3);
      if (flag)
      {
        switch (settings[0, 0])
        {
          case 0:
            this.SetLED(settings[2, 0], settings[2, 1], settings[2, 2]);
            break;
          case 1:
            if (settings[2, 3] == 0)
            {
              Color[] colorArray = new Color[2]
              {
                Color.FromArgb(settings[2, 0], settings[2, 1], settings[2, 2]),
                Color.FromArgb(settings[7, 0], settings[7, 1], settings[7, 2])
              };
              int num = 50;
              int gradientPosition = this.vGradientPosition;
              this.SetLED((int) colorArray[0].R + ((int) colorArray[1].R - (int) colorArray[0].R) * gradientPosition / (num - 1), (int) colorArray[0].G + ((int) colorArray[1].G - (int) colorArray[0].G) * gradientPosition / (num - 1), (int) colorArray[0].B + ((int) colorArray[1].B - (int) colorArray[0].B) * gradientPosition / (num - 1));
              if (this.vGradientPosition == 50)
                this.vGradientForward = false;
              else if (this.vGradientPosition == 0)
                this.vGradientForward = true;
              if (this.vGradientForward)
              {
                ++this.vGradientPosition;
                break;
              }
              --this.vGradientPosition;
              break;
            }
            this.SetLED(settings[2, 0], settings[2, 1], settings[2, 2]);
            break;
          case 2:
            if (settings[2, 3] == 0)
            {
              if (this.hGradientPosition == 176)
              {
                this.hGradientPosition = 175;
                this.hGradientForward = false;
              }
              else if (this.hGradientPosition == 16)
                this.hGradientForward = true;
              int index1;
              int index2;
              if (this.hGradientForward)
              {
                index1 = this.hGradientPosition / 8;
                index2 = index1 + 1;
              }
              else
              {
                index1 = this.hGradientPosition / 8;
                index2 = index1 + 1;
              }
              Color[] colorArray = new Color[2]
              {
                Color.FromArgb(settings[index1, 0], settings[index1, 1], settings[index1, 2]),
                Color.FromArgb(settings[index2, 0], settings[index2, 1], settings[index2, 2])
              };
              int num1 = 8;
              int num2 = this.hGradientPosition - index1 * 8;
              this.SetLED((int) colorArray[0].R + ((int) colorArray[1].R - (int) colorArray[0].R) * num2 / (num1 - 1), (int) colorArray[0].G + ((int) colorArray[1].G - (int) colorArray[0].G) * num2 / (num1 - 1), (int) colorArray[0].B + ((int) colorArray[1].B - (int) colorArray[0].B) * num2 / (num1 - 1));
              if (this.hGradientForward)
              {
                ++this.hGradientPosition;
                break;
              }
              --this.hGradientPosition;
              break;
            }
            this.SetLED(settings[2, 0], settings[2, 1], settings[2, 2]);
            break;
        }
      }
      else if (settings[0, 0] == 0)
        this.SetLED(settings[1, 0], settings[1, 1], settings[1, 2]);
      else
        this.SetLED(0, 0, 0);
    }

    private int RGBtoPercent(double RGB)
    {
      return Convert.ToInt32(RGB / 2.55);
    }

    private void SetLED(int red, int green, int blue)
    {
      LogitechGSDK.LogiLedSetLighting(this.RGBtoPercent((double) red), this.RGBtoPercent((double) green), this.RGBtoPercent((double) blue));
    }
  }
}
