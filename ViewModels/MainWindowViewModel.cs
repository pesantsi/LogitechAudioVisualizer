using CSCore;
using CSCore.CoreAudioAPI;
using CSCore.DSP;
using CSCore.SoundIn;
using CSCore.Streams;
using LedCSharp;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using LogitechAudioVisualizer.Settings;
using System.Windows.Media;
using LogitechSpectrogram.Writers;
using System.Windows.Input;
using Prism.Commands;

namespace LogitechAudioVisualizer.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public string SdkVersionString
        {
            get => Get<string>();
            set => Set(value);
        }

        public OutputViewModel OutputViewModel
        {
            get => Get<OutputViewModel>();
            set => Set(value);
        }

        public ICommand OpenCommand { get; }

        public ICommand CloseCommand { get; }

        private Task m_runner;
        private CancellationTokenSource m_cancellationTokenSource = new CancellationTokenSource();

        public MainWindowViewModel()
        {
            OpenCommand = new DelegateCommand(() => App.Current.MainWindow.Show());
            CloseCommand = new DelegateCommand(() =>
            {
                m_cancellationTokenSource.Cancel();
                App.Current.Shutdown();
            });

            OutputViewModel = new OutputViewModel();

            var sdkVersion = new LogiLedSdkVersion();
            LogitechGSDK.LogiLedGetSdkVersion(ref sdkVersion.MajorNum, ref sdkVersion.MinorNum, ref sdkVersion.BuildNum);
            SdkVersionString = sdkVersion.ToString();

            m_runner = new Task(DoWork, m_cancellationTokenSource.Token, TaskCreationOptions.LongRunning);
            m_runner.Start();
        }

        private class LogiLedSdkVersion
        {
            public int MajorNum;
            public int MinorNum;
            public int BuildNum;

            public override string ToString()
            {
                return $"{MajorNum}.{MinorNum}.{BuildNum}";
            }
        }

        private void DoWork()
        {
            MMDevice mmDevice = GetInputDevices()["Realtek HD Audio 2nd output (Realtek High Definition Audio)"];

            //MMDevice mmDevice = GetInputDevices()["Remote Audio"];


            string keyboardLayout = "US";
            
           // int[,] settings = new int[25, 4];
            int refreshDelay = 20;
            int amplitudeScaleType = 0;
            int amplitudeOffset = 0;
            int frequencyBoostFactor = 10;
            float spectroScale = 1.0f;
            int length = 256;
            byte[] audioBuffer = new byte[length];
            byte[] fftData = new byte[length / 2];
            float[] fftResultBuffer = new float[length];

            //DateTime now = DateTime.Now;
            List<IWriter> writerList = new List<IWriter>();
            KeyboardWriter keyboardWriter;
            writerList.Add((IWriter)(keyboardWriter = new KeyboardWriter(null)));
            keyboardWriter.InitKeyboard(keyboardLayout);
            writerList.Add((IWriter)new DeviceWriter());
            WasapiCapture wasapiCapture1 = new WasapiCapture();
            FftProvider fftProvider = new FftProvider(2, FftSize.Fft256);
            WasapiCapture wasapiCapture2 = !(mmDevice.DeviceID[5].ToString() == "1") ? (WasapiCapture)new WasapiLoopbackCapture() : new WasapiCapture();
            wasapiCapture2.Device = mmDevice;
            wasapiCapture2.Initialize();
            SoundInSource waveSource = new SoundInSource((ISoundIn)wasapiCapture2);
            SingleBlockNotificationStream sampleSource = new SingleBlockNotificationStream(waveSource.ToSampleSource().ToMono().ChangeSampleRate(8192));
            sampleSource.SingleBlockRead += (EventHandler<SingleBlockReadEventArgs>)((s, a) => fftProvider.Add(a.Left, a.Right));
            IWaveSource finalSource = sampleSource.ToWaveSource(8).ChangeSampleRate(8192);
            waveSource.DataAvailable += (EventHandler<DataAvailableEventArgs>)((s, f) => finalSource.Read(audioBuffer, 0, audioBuffer.Length));
            wasapiCapture2.Start();

            while (!m_cancellationTokenSource.Token.IsCancellationRequested)
            {
                {
                    // this.Invoke((Action)(() =>
                    //{
                    Color backgroundColor = Color.FromRgb((byte)UserSettingsManager.Instance.UserSettings.BgRed.Value, (byte)UserSettingsManager.Instance.UserSettings.BgGreen.Value, (byte)UserSettingsManager.Instance.UserSettings.BgBlue.Value);
                    Color foregroundColor = Color.FromRgb((byte)UserSettingsManager.Instance.UserSettings.FgRed.Value, (byte)UserSettingsManager.Instance.UserSettings.FgGreen.Value, (byte)UserSettingsManager.Instance.UserSettings.FgBlue.Value);

                    //settings[0, 0] = Instance.UserSettings.ColorMode.Value;
                    //settings[0, 1] = Convert.ToInt32(Instance.UserSettings.OsKeyboardColors.Value); //*this.checkBox_UseKeyboardColors.Checked;
                    //settings[0, 2] = Convert.ToInt32(UserSettingsManager.Instance.UserSettings.DeviceLighting.Value); // this.checkBox_DeviceLighting.Checked);
                    //settings[0, 3] = Convert.ToInt32(UserSettingsManager.Instance.UserSettings.DisableGLights.Value); // this.checkBox_DisableGLights.Checked);
                    switch (UserSettingsManager.Instance.UserSettings.ColorMode.Value)
                    {
                        case 0:
                            //settings[1, 0] = backgroundColor.R;
                            //settings[1, 1] = backgroundColor.G;
                            //settings[1, 2] = backgroundColor.B;
                            //settings[2, 0] = foregroundColor.R;
                            //settings[2, 1] = foregroundColor.G;
                            //settings[2, 2] = foregroundColor.B;
                            break;
                        case 1:
                            //for (int index = 0; index < UserSettingsManager.Instance.UserSettings.GradientColor.Value.Count; ++index)
                            //{
                            //    Color gradientColor = Color.FromUInt32((uint)UserSettingsManager.Instance.UserSettings.GradientColor.Value[index]);

                            //    settings[index + 2, 0] = gradientColor.R;
                            //    settings[index + 2, 1] = gradientColor.G;
                            //    settings[index + 2, 2] = gradientColor.B;
                            //}
                            //settings[2, 3] = Convert.ToInt32(UserSettingsManager.Instance.UserSettings.VColorWaveEnable.Value);
                            break;
                        case 2:
                            //Color hGradientColor = Color.FromUInt32(UserSettingsManager.Instance.UserSettings.HGradientColor.Value[0]);

                            //settings[2, 0] = hGradientColor.R;
                            //settings[2, 1] = hGradientColor.G;
                            //settings[2, 2] = hGradientColor.B;
                            //for (int index = 0; index < UserSettingsManager.Instance.UserSettings.HGradientColor.Value.Count; ++index)
                            //{
                            //    Color hGradientColor = Color.FromUInt32(UserSettingsManager.Instance.UserSettings.HGradientColor.Value[index]);

                            //    settings[index + 2, 0] = hGradientColor.R;
                            //    settings[index + 2, 1] = hGradientColor.G;
                            //    settings[index + 2, 2] = hGradientColor.B;
                            //}
                            //settings[2, 3] = Convert.ToInt32(UserSettingsManager.Instance.UserSettings.HColorWaveEnable.Value);
                            break;
                    }

                    refreshDelay = UserSettingsManager.Instance.UserSettings.RefreshDelay.Value;
                    amplitudeScaleType = UserSettingsManager.Instance.UserSettings.AmplitudeScale.Value;
                    amplitudeOffset = UserSettingsManager.Instance.UserSettings.AmplitudeOffset.Value;
                    frequencyBoostFactor = UserSettingsManager.Instance.UserSettings.FrequencyBoost.Value;
                    spectroScale = UserSettingsManager.Instance.UserSettings.SpectroScale.Value;

                    // }));

                    fftProvider.GetFftData(fftResultBuffer);
                    for (int j = 0; j < fftResultBuffer.Length / 2; ++j)
                    {
                        float num = (float)((1.0 + (j * frequencyBoostFactor) / 1280.0) * 1000.0);
                        switch (amplitudeScaleType)
                        {
                            case 0:
                                fftData[j] = ToByte((double)fftResultBuffer[j] * num * spectroScale + (double)amplitudeOffset);
                                break;
                            case 1:
                                fftData[j] = ToByte(Math.Sqrt((double)fftResultBuffer[j] * (double)num) * 6.0 * spectroScale + (double)amplitudeOffset);
                                break;
                            case 2:
                                fftData[j] = ToByte(Math.Max(Math.Log10((double)fftResultBuffer[j] * (double)num), 0.0) * 24.0 * spectroScale + (double)amplitudeOffset);
                                break;
                        }
                    }


                    writerList.ForEach((Action<IWriter>)(x => x.Write(fftData)));

                    OutputViewModel.UpdateImage(fftData, UserSettingsManager.Instance.UserSettings.OsVerticalScale.Value, backgroundColor, foregroundColor);

                    //// this.BeginInvoke((Action)(() => Application.OpenForms.OfType<OutputWindow>().FirstOrDefault<OutputWindow>()?.UpdateImage(fftData, settings, MainForm.Global.OSverticalScale, this.checkBox_HighQualityGraphics.Checked, this.button_OS_BG.BackColor, this.button_OS_FG.BackColor)));
                    // switch (MainForm.Global.ARXOnScreen)
                    // {
                    //     case 1:
                    //         LogitechArx.LogiArxSetTagContentById("fftData", "");
                    //         MainForm.Global.ARXOnScreen = 0;
                    //         break;
                    //     case 2:
                    //         LogitechArx.LogiArxSetTagContentById("fftData", string.Join<byte>(",", (IEnumerable<byte>)fftData));
                    //         break;
                    // }
                    Thread.Sleep(refreshDelay);
                }
            }

            wasapiCapture2.Stop();
            wasapiCapture2.Dispose();
            waveSource?.Dispose();
        }

        private byte ToByte(double input)
        {
            byte num;
            try
            {
                num = input >= 0.0 ? (input <= (double)byte.MaxValue ? Convert.ToByte(input) : byte.MaxValue) : (byte)0;
            }
            catch (OverflowException)
            {
                num = byte.MaxValue;
            }
            return num;
        }

        public Dictionary<string, MMDevice> GetInputDevices()
        {
            Dictionary<string, MMDevice> dictionary = new Dictionary<string, MMDevice>();
            try
            {
                using (MMDeviceEnumerator deviceEnumerator = new MMDeviceEnumerator())
                {
                    using (MMDeviceCollection deviceCollection = deviceEnumerator.EnumAudioEndpoints(DataFlow.All, DeviceState.Active))
                    {
                        MMDevice defaultAudioEndpoint = deviceEnumerator.GetDefaultAudioEndpoint(DataFlow.Render, Role.Console);
                        int num = 0;
                        foreach (MMDevice mmDevice in deviceCollection)
                        {
                            if (dictionary.ContainsKey(mmDevice.FriendlyName))
                                dictionary.Add(mmDevice.FriendlyName + " (" + num.ToString() + ")", mmDevice);
                            else
                                dictionary.Add(mmDevice.FriendlyName, mmDevice);
                            ++num;
                        }
                    }
                 }
            }
            catch (CoreAudioAPIException)
            {
                //int num = (int)MessageBox.Show("No input devices were found.", "Input Devices Not Found", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }

            return dictionary;
        }
    }

}
