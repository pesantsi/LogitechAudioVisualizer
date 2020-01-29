// Decompiled with JetBrains decompiler
// Type: LogitechSpectrogram.KeyboardWriter
// Assembly: Logitech Spectrogram, Version=2.8.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 51487773-CCC1-46AA-85F4-7E087432A9E8
// Assembly location: C:\Users\spesant\Downloads\Logitech Spectrogram v2.8.0 (64-bit)\Logitech Spectrogram.exe

using LedCSharp;
using System;
using System.Collections;

namespace LogitechSpectrogram
{
  public class KeyboardWriter : IWriter
  {
    private int[] positionMap = KeyboardLayouts.position_US;
    private float[] sizeMap = KeyboardLayouts.size_US;
    private int[,] ledMatrix = new int[7, 92];
    private int[] keyLightArray = new int[351];
    private int loopNumber;
    private readonly MainFormInterface form;

    public KeyboardWriter(MainFormInterface form)
    {
      this.form = form;
    }

    public void Write(byte[] fftData, int[,] settings)
    {
      Array.Clear((Array) this.keyLightArray, 0, this.keyLightArray.Length);
      ++this.loopNumber;
      if (this.loopNumber == 100)
        this.loopNumber = 0;
      for (int x = 0; x < 91; ++x)
      {
        for (int y = 0; y < 7; ++y)
        {
          if ((double) fftData[(int) ((double) x * 1.42)] > 17.0 * (double) (7 - y))
            this.MarkLightArray(x, y, settings[0, 0]);
        }
      }
      LogitechGSDK.LogiLedSetTargetDevice(4);
      foreach (int position in this.positionMap)
      {
        switch (settings[0, 0])
        {
          case 0:
            switch (this.keyLightArray[position])
            {
              case 0:
                this.SetLED(position, settings[1, 0], settings[1, 1], settings[1, 2]);
                continue;
              case 1:
                this.SetLED(position, settings[2, 0], settings[2, 1], settings[2, 2]);
                continue;
              default:
                continue;
            }
          case 1:
            switch (this.keyLightArray[position])
            {
              case 0:
                this.SetLED(position, 0, 0, 0);
                continue;
              case 2:
              case 3:
              case 4:
              case 5:
              case 6:
              case 7:
                this.SetLED(position, settings[this.keyLightArray[position], 0], settings[this.keyLightArray[position], 1], settings[this.keyLightArray[position], 2]);
                continue;
              default:
                continue;
            }
          case 2:
            if (this.keyLightArray[position] == 0)
            {
              this.SetLED(position, 0, 0, 0);
              break;
            }
            this.SetLED(position, settings[this.keyLightArray[position], 0], settings[this.keyLightArray[position], 1], settings[this.keyLightArray[position], 2]);
            break;
        }
      }
    }

    private void MarkLightArray(int x, int y, int colorMode)
    {
      int index = this.ledMatrix[y, x];
      if (index >= 350)
        return;
      switch (colorMode)
      {
        case 0:
          this.keyLightArray[index] = 1;
          break;
        case 1:
          this.keyLightArray[index] = y + 1;
          break;
        case 2:
          this.keyLightArray[index] = x / 4 + 2;
          break;
      }
    }

    public int InitKeyboard(string keyboardLayout)
    {
      KeyboardLayouts.returnLayout(keyboardLayout, out this.positionMap, out this.sizeMap);
      IEnumerator enumerator1 = this.positionMap.GetEnumerator();
      enumerator1.MoveNext();
      IEnumerator enumerator2 = this.sizeMap.GetEnumerator();
      enumerator2.MoveNext();
      for (int index1 = 0; index1 < 7; ++index1)
      {
        int num1 = 0;
        int num2 = 0;
        for (int index2 = 0; index2 < 92; ++index2)
        {
          if (num2 == 0)
          {
            float current = (float) enumerator2.Current;
            enumerator2.MoveNext();
            if ((double) current < 0.0)
            {
              num2 = (int) (-(double) current * 4.0);
              num1 = 350;
            }
            else
            {
              num1 = (int) enumerator1.Current;
              enumerator1.MoveNext();
              num2 = (int) ((double) current * 4.0);
            }
          }
          this.ledMatrix[index1, index2] = num1;
          --num2;
        }
        if ((int) enumerator1.Current != 350 || (double) (float) enumerator2.Current != 0.0)
        {
          this.form.setStatusBar = "An error has occurred with the keyboard lookup table";
          return 1;
        }
        enumerator1.MoveNext();
        enumerator2.MoveNext();
      }
      return 0;
    }

    private int RGBtoPercent(double RGB)
    {
      return Convert.ToInt32(RGB / 2.55);
    }

    private void SetLED(int keyName, int red, int green, int blue)
    {
      if (keyName == 350)
        return;
      LogitechGSDK.LogiLedSetLightingForKeyWithHidCode(keyName, this.RGBtoPercent((double) red), this.RGBtoPercent((double) green), this.RGBtoPercent((double) blue));
    }
  }
}
