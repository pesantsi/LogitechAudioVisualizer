using CSCore;
using CSCore.CoreAudioAPI;
using CSCore.DSP;
using CSCore.SoundIn;
using CSCore.Streams;
using LedCSharp;
using LogitechSpectrogram;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using LogitechAudioVisualizer.Settings;
using System.Windows.Media;
using LogitechSpectrogram.Writers;

namespace LogitechAudioVisualizer.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public string Greeting => "Hello World!";

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

        public MainWindowViewModel()
        {
            //try
            //{
            //    this.InitializeComponent();
            //    this.backgroundWorker_Main.WorkerSupportsCancellation = true;
            //    this.backgroundWorker_Main.DoWork += new DoWorkEventHandler(this.backgroundWorker_Main_DoWork);
            //    this.backgroundWorker_Main.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.backgroundWorker_Main_RunWorkerCompleted);
            //    this.backgroundWorker_Cycle.WorkerSupportsCancellation = true;
            //    this.backgroundWorker_Cycle.DoWork += new DoWorkEventHandler(this.backgroundWorker_Cycle_DoWork);
            //    this.backgroundWorker_Cycle.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.backgroundWorker_Cycle_RunWorkerCompleted);
            //    this.Activated += new EventHandler(this.MainForm_Activated);
            //    this.Deactivate += new EventHandler(this.MainForm_Deactivated);
            //    this.Text = "Logitech Spectrogram - v" + MainForm.Global.programVersion + " (2016-05-22)";
            //    MainForm.Global.programArch = !Environment.Is64BitProcess ? "  (32-bit)" : "  (64-bit)";
            //    this.label_A_ProgramVersion.Text = "Program Version:            " + MainForm.Global.programVersion + MainForm.Global.programArch;
            //    this.getInputDevices();
            //    this.comboBox_KeyboardLayout.DataSource = (object)new BindingSource((object)KeyboardLayouts.keyboardLayoutList, (string)null);
            //    this.comboBox_KeyboardLayout.DisplayMember = "Key";
            //    this.comboBox_KeyboardLayout.ValueMember = "Value";
            //    this.linkLabel_A_Logitech.Links.Add(33, 18, (object)"http://dynftw.tk/spectrogram/");
            //    this.linkLabel_A_Logitech.Links.Add(51, 15, (object)"http://forums.logitech.com/t5/Scripting-and-SDK/G910-Keyboard-Spectrogram-Audio-Visualisation/td-p/1419221");
            //    this.comboBox_KL_ColorMode.SelectedIndex = 0;
            //    this.comboBox_AmplitudeScale.SelectedIndex = 0;
            //    this.comboBox_VColorWaveDirection.SelectedIndex = 0;
            //    this.comboBox_VColorWaveSpacing.SelectedIndex = 0;
            //    this.comboBox_HColorWaveDirection.SelectedIndex = 1;
            //    this.comboBox_HColorWaveSpacing.SelectedIndex = 0;
            //    this.generateGradientButtons();
            //    this.loadSettings();
            //    this.loadTooltips();
            //}
            //catch (FileNotFoundException ex)
            //{
            //    int num = (int)MessageBox.Show("A required component is missing. This program will now exit.\n\n" + ex.Message, "Component Missing", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            //    Environment.Exit(0);
            //}
            //catch (ConfigurationErrorsException ex)
            //{
            //    if (MessageBox.Show("An error occurred while loading the settings file.\n\nClick 'OK' to restore default settings and then exit the program (a copy of your settings will be left in the settings folder). Start the program again and it should start normally.\n\nClick 'Cancel' to exit the program without taking any action.", "Configuration File Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Hand) == DialogResult.OK)
            //    {
            //        BackupSettings.backupSettings();
            //        Environment.Exit(0);
            //    }
            //    else
            //        Environment.Exit(0);
            //}
            //catch (Exception ex)
            //{
            //    int num = (int)MessageBox.Show("An error occurred during program startup (Stage 1). This program will now exit.\n\n" + ex.Message + "\n\n" + (object)ex.TargetSite, "Program Startup Error (Stage 1)", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            //    Environment.Exit(0);
            //}
            //if (this.comboBox_InputDevice.SelectedValue == null || this.checkBox_AutoDefaultDevice.Checked)
            //{
            //    try
            //    {
            //        this.comboBox_InputDevice.SelectedIndex = MainForm.Global.defaultSelectedIndex;
            //    }
            //    catch
            //    {
            //    }
            //}

            try
            {
                var sdkVersion = new LogiLedSdkVersion();
                LogitechGSDK.LogiLedGetSdkVersion(ref sdkVersion.MajorNum, ref sdkVersion.MinorNum, ref sdkVersion.BuildNum);
                SdkVersionString = sdkVersion.ToString();

                Task.Run(DoWork);

            }
            catch (DllNotFoundException)
            {
                // int num = (int)MessageBox.Show("The file \"LogitechLedEnginesWrapper.dll\" could not be found.\nRefer to the FAQ for possible solutions. This program will now exit.\n\n" + ex.Message, "DLL Missing: LogitechLedEnginesWrapper", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                //Environment.Exit(0);
            }

            //try
            //{
            //    if (!this.checkBox_ARXApp.Checked)
            //        return;
            //    this.startARX();
            //}
            //catch (DllNotFoundException ex)
            //{
            //    int num = (int)MessageBox.Show("The file \"LogitechGArxControlEnginesWrapper.dll\" could not be found.\nRefer to the FAQ for possible solutions.\n\n" + ex.Message, "DLL Missing: LogitechGArxControlEnginesWrapper", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            //}
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
            //MMDevice mmDevice = GetInputDevices()["Realtek HD Audio 2nd output (Realtek High Definition Audio)"];

            MMDevice mmDevice = GetInputDevices()["Remote Audio"];


            string keyboardLayout = "US";
            //while (true)
            //{
            //    try
            //    {
            //        //mmDevice = ((KeyValuePair<string, MMDevice>)this.comboBox_InputDevice.SelectedItem).Value;
            //        //keyboardLayout = (string)this.comboBox_KeyboardLayout.SelectedValue;

            //        // mmDevice = (MMDevice) this.Invoke((Action) (() => ((KeyValuePair<string, MMDevice>) this.comboBox_InputDevice.SelectedItem).Value));
            //        // keyboardLayout = (string) this.Invoke((Action) (() => (string) this.comboBox_KeyboardLayout.SelectedValue));
            //        break;
            //    }
            //    catch (InvalidOperationException ex)
            //    {
            //        Thread.Sleep(1000);
            //    }
            //}
            int[,] settings = new int[25, 4];
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

            OutputViewModel = new OutputViewModel();

            label_5:
            //for (int i = 0; i < 2; ++i)
            {
                // if (!this.backgroundWorker_Main.CancellationPending)
                {
                    // this.Invoke((Action)(() =>
                    //{
                    Color backgroundColor = Color.FromRgb((byte)UserSettingsManager.Instance.UserSettings.BgRed.Value, (byte)UserSettingsManager.Instance.UserSettings.BgGreen.Value, (byte)UserSettingsManager.Instance.UserSettings.BgBlue.Value);
                    Color foregroundColor = Color.FromRgb((byte)UserSettingsManager.Instance.UserSettings.FgRed.Value, (byte)UserSettingsManager.Instance.UserSettings.FgGreen.Value, (byte)UserSettingsManager.Instance.UserSettings.FgBlue.Value);

                    //settings[0, 0] = Instance.UserSettings.ColorMode.Value;
                    //settings[0, 1] = Convert.ToInt32(Instance.UserSettings.OsKeyboardColors.Value); //*this.checkBox_UseKeyboardColors.Checked;
                    //settings[0, 2] = Convert.ToInt32(UserSettingsManager.Instance.UserSettings.DeviceLighting.Value); // this.checkBox_DeviceLighting.Checked);
                    settings[0, 3] = Convert.ToInt32(UserSettingsManager.Instance.UserSettings.DisableGLights.Value); // this.checkBox_DisableGLights.Checked);
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


                    writerList.ForEach((Action<IWriter>)(x => x.Write(fftData, settings)));

                    OutputViewModel.UpdateImage(fftData, /*settings,*/ UserSettingsManager.Instance.UserSettings.OsVerticalScale.Value,/* UserSettingsManager.Instance.UserSettings.OsHighQuality.Value,*/ backgroundColor, foregroundColor);

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
                    //TimeSpan timeSpan = DateTime.Now - now;
                    //now = DateTime.Now;
                }
                //else
                //{
                //    if (wasapiCapture2 != null)
                //    {
                //        wasapiCapture2.Stop();
                //        wasapiCapture2.Dispose();
                //        wasapiCapture1 = (WasapiCapture)null;
                //    }
                //    waveSource?.Dispose();
                //    LogitechGSDK.LogiLedSetTargetDevice(MainForm.Global.LogitechAllDevices);
                //    LogitechGSDK.LogiLedRestoreLighting();
                //    this._resetEvent.Set();
                //    return;
                //}
            }
            goto label_5;
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
            //this.comboBox_InputDevice.DataSource = (object)null;
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
                            //if (mmDevice.FriendlyName == defaultAudioEndpoint.FriendlyName)
                            //     MainForm.Global.defaultSelectedIndex = num;
                            if (dictionary.ContainsKey(mmDevice.FriendlyName))
                                dictionary.Add(mmDevice.FriendlyName + " (" + num.ToString() + ")", mmDevice);
                            else
                                dictionary.Add(mmDevice.FriendlyName, mmDevice);
                            ++num;
                        }
                    }
                    //this.comboBox_InputDevice.DataSource = (object)new BindingSource((object)dictionary, (string)null);
                    //this.comboBox_InputDevice.DisplayMember = "Value";
                    //this.comboBox_InputDevice.ValueMember = "Key";
                    //this.comboBox_InputDevice.SelectedIndex = MainForm.Global.defaultSelectedIndex;
                }
            }
            catch (CoreAudioAPIException)
            {
                //int num = (int)MessageBox.Show("No input devices were found.", "Input Devices Not Found", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }

            return dictionary;
        }
    }

    //public static class Global
    //{
    //    public static string programVersion = Utilities.getProductVersion();
    //    public static string programArch = "";
    //    public static string SDKversion = "";
    //    public static bool outputWindowOpen = false;
    //    public static bool programReady = false;
    //    public static bool programActive = true;
    //    public static float scale = 1f;
    //    public static float OSverticalScale = 2f;
    //    public static int defaultSelectedIndex = 0;
    //    //public static Color[] gradientColor = new Color[6];
    //    //public static Color[] hGradientColor = new Color[23];
    //    public static string oldStatusBarMessage = "";
    //    public static bool loadSettings = true;
    //    public static int LogitechAllDevices = 7;
    //    public static bool ARXRunning = false;
    //    public static bool ARXActive = false;
    //    public static bool sendToARX = true;
    //    public static bool jQuerySetQueue = false;
    //    public static string jQuerySetQueuedCommands = "";
    //    public static int ARXCurrentTab = 0;
    //    public static int ARXOnScreen = 0;
    //    public static bool firstMinimize = true;
    //    public const string programDate = "2016-05-22";
    //    public const int numOfDefaultGradientProfiles = 5;
    //    public const int numOfCustomGradientProfiles = 10;
    //    public const int numOfGradientProfiles = 15;
    //    public static DateTime lastUpdateCheck;
    //}
}
