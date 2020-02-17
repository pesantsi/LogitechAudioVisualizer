using LedCSharp;
using LogitechAudioVisualizer.Settings;
using System;
using System.Collections;
using System.Windows.Media;

namespace LogitechSpectrogram.Writers
{
    public class KeyboardWriter : IWriter
    {
        private int[] positionMap = KeyboardLayouts.position_US;
        private float[] sizeMap = KeyboardLayouts.size_US;
        private int[,] ledMatrix = new int[7, 92];
        private int[] keyLightArray = new int[351];
        private int loopNumber;
        //private readonly MainFormInterface form;

        public KeyboardWriter(MainFormInterface form)
        {
            //this.form = form;
        }

        public void Write(byte[] fftData, int[,] settings)
        {
            Array.Clear(keyLightArray, 0, keyLightArray.Length);
            ++loopNumber;
            if (loopNumber == 100)
                loopNumber = 0;
            for (int x = 0; x < 91; ++x)
            {
                for (int y = 0; y < 7; ++y)
                {
                    if (fftData[(int)(x * 1.42)] > 17.0 * (7 - y))
                        MarkLightArray(x, y, UserSettingsManager.Instance.UserSettings.ColorMode.Value);
                }
            }
            LogitechGSDK.LogiLedSetTargetDevice(4);
            foreach (int position in positionMap)
            {
                Color foregroundColor;
                Color backgroundColor;
                Color keyColor;
                switch (UserSettingsManager.Instance.UserSettings.ColorMode.Value)
                {                   
                    case 0:
                        switch (keyLightArray[position])
                        {
                            case 0:
                                backgroundColor = Color.FromRgb((byte)UserSettingsManager.Instance.UserSettings.BgRed.Value, (byte)UserSettingsManager.Instance.UserSettings.BgGreen.Value, (byte)UserSettingsManager.Instance.UserSettings.BgBlue.Value);
                                SetLED(position, backgroundColor.R, backgroundColor.G, backgroundColor.B);
                                continue;
                            case 1:
                                foregroundColor = Color.FromRgb((byte)UserSettingsManager.Instance.UserSettings.FgRed.Value, (byte)UserSettingsManager.Instance.UserSettings.FgGreen.Value, (byte)UserSettingsManager.Instance.UserSettings.FgBlue.Value);
                                SetLED(position, foregroundColor.R, foregroundColor.G, foregroundColor.B);
                                continue;
                            default:
                                continue;
                        }
                    case 1:
                        switch (keyLightArray[position])
                        {
                            case 0:
                                backgroundColor = Color.FromRgb((byte)UserSettingsManager.Instance.UserSettings.BgRed.Value, (byte)UserSettingsManager.Instance.UserSettings.BgGreen.Value, (byte)UserSettingsManager.Instance.UserSettings.BgBlue.Value);
                                SetLED(position, backgroundColor.R, backgroundColor.G, backgroundColor.B);
                                continue;
                            case 2:
                            case 3:
                            case 4:
                            case 5:
                            case 6:
                            case 7:
                                keyColor = (Color)ColorConverter.ConvertFromString(UserSettingsManager.Instance.UserSettings.GradientColor.Value[keyLightArray[position]]);
                                SetLED(position, keyColor.R, keyColor.G, keyColor.B);
                                continue;
                            default:
                                continue;
                        }
                    case 2:
                        if (keyLightArray[position] == 0)
                        {
                            backgroundColor = Color.FromRgb((byte)UserSettingsManager.Instance.UserSettings.BgRed.Value, (byte)UserSettingsManager.Instance.UserSettings.BgGreen.Value, (byte)UserSettingsManager.Instance.UserSettings.BgBlue.Value);
                            SetLED(position, backgroundColor.R, backgroundColor.G, backgroundColor.B);
                            break;
                        }
                        keyColor = (Color)ColorConverter.ConvertFromString(UserSettingsManager.Instance.UserSettings.HGradientColor.Value[keyLightArray[position]]);
                        SetLED(position, keyColor.R, keyColor.G, keyColor.B);
                        break;
                }
            }
        }

        private void MarkLightArray(int x, int y, int colorMode)
        {
            int index = ledMatrix[y, x];
            if (index >= 350)
                return;
            switch (colorMode)
            {
                case 0:
                    keyLightArray[index] = 1;
                    break;
                case 1:
                    keyLightArray[index] = y - 1;
                    break;
                case 2:
                    keyLightArray[index] = x / 4;
                    break;
            }
        }

        public int InitKeyboard(string keyboardLayout)
        {
            KeyboardLayouts.returnLayout(keyboardLayout, out positionMap, out sizeMap);
            IEnumerator enumerator1 = positionMap.GetEnumerator();
            enumerator1.MoveNext();
            IEnumerator enumerator2 = sizeMap.GetEnumerator();
            enumerator2.MoveNext();
            for (int index1 = 0; index1 < 7; ++index1)
            {
                int num1 = 0;
                int num2 = 0;
                for (int index2 = 0; index2 < 92; ++index2)
                {
                    if (num2 == 0)
                    {
                        float current = (float)enumerator2.Current;
                        enumerator2.MoveNext();
                        if (current < 0.0)
                        {
                            num2 = (int)(-current * 4.0);
                            num1 = 350;
                        }
                        else
                        {
                            num1 = (int)enumerator1.Current;
                            enumerator1.MoveNext();
                            num2 = (int)(current * 4.0);
                        }
                    }
                    ledMatrix[index1, index2] = num1;
                    --num2;
                }
                if ((int)enumerator1.Current != 350 || (float)enumerator2.Current != 0.0)
                {
                    // this.form.setStatusBar = "An error has occurred with the keyboard lookup table";
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
            LogitechGSDK.LogiLedSetLightingForKeyWithHidCode(keyName, RGBtoPercent(red), RGBtoPercent(green), RGBtoPercent(blue));
        }
    }
}
