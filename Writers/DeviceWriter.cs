using LedCSharp;
using LogitechAudioVisualizer.Settings;
using System;
using System.Windows.Media;
using System.Linq;

namespace LogitechSpectrogram.Writers
{
    internal class DeviceWriter : IWriter
    {
        private int vGradientPosition = 1;
        private bool vGradientForward = true;
        private int hGradientPosition = 16;
        private bool hGradientForward = true;

        public void Write(byte[] fftData, int[,] settings)
        {
            if (!UserSettingsManager.Instance.UserSettings.DeviceLighting.Value)
                return;

            LogitechGSDK.LogiLedSetTargetDevice(3);
            if (fftData.Any(d => d > 0))
            {
                Color foregroundColor;
                switch (UserSettingsManager.Instance.UserSettings.ColorMode.Value)
                {
                    case 0:
                        foregroundColor = Color.FromRgb((byte)UserSettingsManager.Instance.UserSettings.FgRed.Value, (byte)UserSettingsManager.Instance.UserSettings.FgGreen.Value, (byte)UserSettingsManager.Instance.UserSettings.FgBlue.Value);
                        SetLED(foregroundColor.R, foregroundColor.G, foregroundColor.B);
                        break;
                    case 1:
                        if (UserSettingsManager.Instance.UserSettings.VColorWaveEnable.Value)
                        {
                            Color[] colorArray = new Color[2]
                            {
                                (Color)ColorConverter.ConvertFromString(UserSettingsManager.Instance.UserSettings.GradientColor.Value[0]),
                                (Color)ColorConverter.ConvertFromString(UserSettingsManager.Instance.UserSettings.GradientColor.Value[UserSettingsManager.Instance.UserSettings.GradientColor.Value.Count-1])
                            };
                            int num = 50;
                            int gradientPosition = vGradientPosition;
                            SetLED(colorArray[0].R + (colorArray[1].R - colorArray[0].R) * gradientPosition / (num - 1), colorArray[0].G + (colorArray[1].G - colorArray[0].G) * gradientPosition / (num - 1), colorArray[0].B + (colorArray[1].B - colorArray[0].B) * gradientPosition / (num - 1));
                            if (vGradientPosition == 50)
                                vGradientForward = false;
                            else if (vGradientPosition == 0)
                                vGradientForward = true;
                            if (vGradientForward)
                            {
                                ++vGradientPosition;
                                break;
                            }
                            --vGradientPosition;
                            break;
                        }
                        foregroundColor = Color.FromRgb((byte)UserSettingsManager.Instance.UserSettings.FgRed.Value, (byte)UserSettingsManager.Instance.UserSettings.FgGreen.Value, (byte)UserSettingsManager.Instance.UserSettings.FgBlue.Value);
                        SetLED(foregroundColor.R, foregroundColor.G, foregroundColor.B);
                        break;
                    case 2:
                        if (UserSettingsManager.Instance.UserSettings.HColorWaveEnable.Value)
                        {
                            if (hGradientPosition == 176)
                            {
                                hGradientPosition = 175;
                                hGradientForward = false;
                            }
                            else if (hGradientPosition == 16)
                                hGradientForward = true;
                            int index1;
                            int index2;
                            if (hGradientForward)
                            {
                                index1 = hGradientPosition / 8;
                                index2 = index1 + 1;
                            }
                            else
                            {
                                index1 = hGradientPosition / 8;
                                index2 = index1 + 1;
                            }
                            Color[] colorArray = new Color[2]
                            {
                                (Color)ColorConverter.ConvertFromString(UserSettingsManager.Instance.UserSettings.HGradientColor.Value[index1]),
                                (Color)ColorConverter.ConvertFromString(UserSettingsManager.Instance.UserSettings.HGradientColor.Value[index2])
                            };
                            int num1 = 8;
                            int num2 = hGradientPosition - index1 * 8;
                            SetLED(colorArray[0].R + (colorArray[1].R - colorArray[0].R) * num2 / (num1 - 1), colorArray[0].G + (colorArray[1].G - colorArray[0].G) * num2 / (num1 - 1), colorArray[0].B + (colorArray[1].B - colorArray[0].B) * num2 / (num1 - 1));
                            if (hGradientForward)
                            {
                                ++hGradientPosition;
                                break;
                            }
                            --hGradientPosition;
                            break;
                        }
                        Color hGradientColor = (Color)ColorConverter.ConvertFromString(UserSettingsManager.Instance.UserSettings.HGradientColor.Value[0]);
                        SetLED(hGradientColor.R, hGradientColor.G, hGradientColor.B);
                        break;
                }
            }
            else if (UserSettingsManager.Instance.UserSettings.ColorMode.Value == 0)
            {
                Color backgroundColor = Color.FromRgb((byte)UserSettingsManager.Instance.UserSettings.BgRed.Value, (byte)UserSettingsManager.Instance.UserSettings.BgGreen.Value, (byte)UserSettingsManager.Instance.UserSettings.BgBlue.Value);
                SetLED(backgroundColor.R, backgroundColor.G, backgroundColor.B);
            }
            else
                SetLED(0, 0, 0);
        }

        private int RGBtoPercent(double RGB)
        {
            return Convert.ToInt32(RGB / 2.55);
        }

        private void SetLED(int red, int green, int blue)
        {
            LogitechGSDK.LogiLedSetLighting(RGBtoPercent(red), RGBtoPercent(green), RGBtoPercent(blue));
        }
    }
}
