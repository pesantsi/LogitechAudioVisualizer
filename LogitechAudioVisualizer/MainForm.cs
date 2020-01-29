// Decompiled with JetBrains decompiler
// Type: LogitechSpectrogram.MainForm
// Assembly: Logitech Spectrogram, Version=2.8.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 51487773-CCC1-46AA-85F4-7E087432A9E8
// Assembly location: C:\Users\spesant\Downloads\Logitech Spectrogram v2.8.0 (64-bit)\Logitech Spectrogram.exe

using CSCore;
using CSCore.CoreAudioAPI;
using CSCore.DSP;
using CSCore.SoundIn;
using CSCore.Streams;
using CSCore.Win32;
using Gma.System.MouseKeyHook;
using LedCSharp;
using LogitechSpectrogram.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace LogitechSpectrogram
{
  public class MainForm : Form, MainFormInterface
  {
    private static System.Timers.Timer _timer = new System.Timers.Timer();
    private static System.Timers.Timer _timer_jQuerySet = new System.Timers.Timer();
    private AutoResetEvent _resetEvent = new AutoResetEvent(false);
    private LogitechArx.logiArxCbContext contextCallback;
    private IKeyboardMouseEvents m_GlobalHook;
    private IContainer components;
    private Button button_StartSpectro;
    private BackgroundWorker backgroundWorker_Main;
    private TrackBar trackBar_red;
    private TrackBar trackBar_blue;
    private TrackBar trackBar_green;
    private BackgroundWorker backgroundWorker_Cycle;
    private CheckBox checkBox_Cycle;
    private TabControl tabControl_Main;
    private TabPage tabPage1;
    private TabPage tabPage2;
    private TabPage tabPage3;
    private NumericUpDown numericUpDown_blue;
    private NumericUpDown numericUpDown_green;
    private NumericUpDown numericUpDown_red;
    private NumericUpDown numericUpDown_CycleDelay;
    private Label label_CycleDelay;
    private GroupBox groupBox_FGColor;
    private Label label_Green;
    private Label label_Red;
    private Label label_Blue;
    private StatusStrip statusStrip_Main;
    private ComboBox comboBox_InputDevice;
    private TabPage tabPage4;
    private ColorDialog colorDialog_Main;
    private Button button_Foreground;
    private GroupBox groupBox_BGColor;
    private Button button_Background;
    private Label label_BGBlue;
    private NumericUpDown numericUpDown_BGBlue;
    private Label label_BGGreen;
    private Label label_BGRed;
    private NumericUpDown numericUpDown_BGRed;
    private NumericUpDown numericUpDown_BGGreen;
    private Label label_InputDevice;
    private Button button_OpenConsole;
    private CheckBox checkBox_AutoConsole;
    private GroupBox groupBox_OS_Manual;
    private GroupBox groupBox_OS_Settings;
    private Label label_A_ProgramName;
    private Label label_A_ProgramAuthor;
    private Label label_A_ProgramVersion;
    private Label label_A_SDKVersion;
    private GroupBox groupBox_A_Thanks;
    private Label label_A_Thanks;
    private LinkLabel linkLabel_A_Logitech;
    private NumericUpDown numericUpDown_SpectroScale;
    private Label label_SpectroScale;
    private NumericUpDown numericUpDown_RefreshDelay;
    private Label label_RefreshDelay;
    private Button button_RestoreSettings;
    private PictureBox pictureBox_Logo;
    private Panel panel_KL_SolidColor;
    private Label label_KL_ColorMode;
    private ComboBox comboBox_KL_ColorMode;
    private Button button_RefreshInputDevice;
    private Panel panel_KL_HorizontalGradient;
    private Panel panel_KL_VerticalGradient;
    private Button button_GenerateVGradient;
    private ComboBox comboBox_VerticalProfiles;
    private Button button_SaveVProfile;
    private Button button_LoadVProfile;
    private Button button_FlipVGradient;
    private Button button_ExportSettings;
    private Button button_ImportSettings;
    private Button button_RenameVProfile;
    private GroupBox groupBox_VProfiles;
    private GroupBox groupBox_TransformVGradient;
    private CheckBox checkBox_HighQualityGraphics;
    private CheckBox checkBox_UseKeyboardColors;
    private Label label_OS_Scale;
    private NumericUpDown numericUpDown_OS_Scale;
    private GroupBox groupBox_OS_Colors;
    private Button button_OS_FG;
    private Button button_OS_BG;
    private Label label_OS_FG;
    private Label label_OS_BG;
    private Label label_AmplitudeScale;
    private ComboBox comboBox_AmplitudeScale;
    private Label label_AmplitudeOffset;
    private NumericUpDown numericUpDown_AmplitudeOffset;
    private CheckBox checkBox_AutoDefaultDevice;
    private NumericUpDown numericUpDown_FrequencyBoost;
    private Label label_FrequencyBoost;
    private CheckBox checkBox_DisableGLights;
    private CheckBox checkBox_DeviceLighting;
    private CheckBox checkBox_ARXApp;
    private CheckBox checkBox_AutoStartup;
    private CheckBox checkBox_MinimiseStartup;
    private NotifyIcon notifyIcon_Main;
    private GroupBox groupBox_SettingsSpectrogram;
    private GroupBox groupBox_SettingsGeneral;
    private GroupBox groupBox_SettingsFile;
    private ComboBox comboBox_KeyboardLayout;
    private Label label_KeyboardLayout;
    private CheckBox checkBox_UpdateCheck;
    private Button button_UpdateCheck;
    private Button button_ImportSettingsVersion;
    private CheckBox checkBox_MediaKeys;
    private ToolStripStatusLabel toolStripStatusLabel1;
    private GroupBox groupBox_VColorWave;
    private CheckBox checkBox_VColorWaveEnable;
    private NumericUpDown numericUpDown_VColorWaveDelay;
    private Label label_VColorWaveDelay;
    private ComboBox comboBox_VColorWaveDirection;
    private Label label_VColorWaveDirection;
    private ComboBox comboBox_VColorWaveSpacing;
    private Label label_VColorWaveSpacing;
    private GroupBox groupBox_HColorWave;
    private Label label_HColorWaveSpacing;
    private ComboBox comboBox_HColorWaveSpacing;
    private Label label_HColorWaveDirection;
    private ComboBox comboBox_HColorWaveDirection;
    private Label label_HColorWaveDelay;
    private NumericUpDown numericUpDown_HColorWaveDelay;
    private CheckBox checkBox_HColorWaveEnable;
    private Label label1;

    public MainForm()
    {
      try
      {
        this.InitializeComponent();
        this.backgroundWorker_Main.WorkerSupportsCancellation = true;
        this.backgroundWorker_Main.DoWork += new DoWorkEventHandler(this.backgroundWorker_Main_DoWork);
        this.backgroundWorker_Main.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.backgroundWorker_Main_RunWorkerCompleted);
        this.backgroundWorker_Cycle.WorkerSupportsCancellation = true;
        this.backgroundWorker_Cycle.DoWork += new DoWorkEventHandler(this.backgroundWorker_Cycle_DoWork);
        this.backgroundWorker_Cycle.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.backgroundWorker_Cycle_RunWorkerCompleted);
        this.Activated += new EventHandler(this.MainForm_Activated);
        this.Deactivate += new EventHandler(this.MainForm_Deactivated);
        this.Text = "Logitech Spectrogram - v" + MainForm.Global.programVersion + " (2016-05-22)";
        MainForm.Global.programArch = !Environment.Is64BitProcess ? "  (32-bit)" : "  (64-bit)";
        this.label_A_ProgramVersion.Text = "Program Version:            " + MainForm.Global.programVersion + MainForm.Global.programArch;
        this.getInputDevices();
        this.comboBox_KeyboardLayout.DataSource = (object) new BindingSource((object) KeyboardLayouts.keyboardLayoutList, (string) null);
        this.comboBox_KeyboardLayout.DisplayMember = "Key";
        this.comboBox_KeyboardLayout.ValueMember = "Value";
        this.linkLabel_A_Logitech.Links.Add(33, 18, (object) "http://dynftw.tk/spectrogram/");
        this.linkLabel_A_Logitech.Links.Add(51, 15, (object) "http://forums.logitech.com/t5/Scripting-and-SDK/G910-Keyboard-Spectrogram-Audio-Visualisation/td-p/1419221");
        this.comboBox_KL_ColorMode.SelectedIndex = 0;
        this.comboBox_AmplitudeScale.SelectedIndex = 0;
        this.comboBox_VColorWaveDirection.SelectedIndex = 0;
        this.comboBox_VColorWaveSpacing.SelectedIndex = 0;
        this.comboBox_HColorWaveDirection.SelectedIndex = 1;
        this.comboBox_HColorWaveSpacing.SelectedIndex = 0;
        this.generateGradientButtons();
        this.loadSettings();
        this.loadTooltips();
      }
      catch (FileNotFoundException ex)
      {
        int num = (int) MessageBox.Show("A required component is missing. This program will now exit.\n\n" + ex.Message, "Component Missing", MessageBoxButtons.OK, MessageBoxIcon.Hand);
        Environment.Exit(0);
      }
      catch (ConfigurationErrorsException ex)
      {
        if (MessageBox.Show("An error occurred while loading the settings file.\n\nClick 'OK' to restore default settings and then exit the program (a copy of your settings will be left in the settings folder). Start the program again and it should start normally.\n\nClick 'Cancel' to exit the program without taking any action.", "Configuration File Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Hand) == DialogResult.OK)
        {
          BackupSettings.backupSettings();
          Environment.Exit(0);
        }
        else
          Environment.Exit(0);
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show("An error occurred during program startup (Stage 1). This program will now exit.\n\n" + ex.Message + "\n\n" + (object) ex.TargetSite, "Program Startup Error (Stage 1)", MessageBoxButtons.OK, MessageBoxIcon.Hand);
        Environment.Exit(0);
      }
      if (this.comboBox_InputDevice.SelectedValue == null || this.checkBox_AutoDefaultDevice.Checked)
      {
        try
        {
          this.comboBox_InputDevice.SelectedIndex = MainForm.Global.defaultSelectedIndex;
        }
        catch
        {
        }
      }
      try
      {
        if (LogitechGSDK.LogiLedInit())
        {
          this.toolStripStatusLabel1.Text = "Ready";
          int[] numArray = new int[3];
          LogitechGSDK.LogiLedGetSdkVersion(ref numArray[0], ref numArray[1], ref numArray[2]);
          MainForm.Global.SDKversion = numArray[0].ToString() + "." + numArray[1].ToString() + "." + numArray[2].ToString();
          this.label_A_SDKVersion.Text = "LED SDK Version:          " + MainForm.Global.SDKversion;
          LogitechGSDK.LogiLedSetTargetDevice(MainForm.Global.LogitechAllDevices);
          LogitechGSDK.LogiLedSaveCurrentLighting();
        }
        else
        {
          this.toolStripStatusLabel1.Text = "Failed to connect to Logitech Gaming Software";
          this.button_StartSpectro.Enabled = false;
        }
      }
      catch (DllNotFoundException ex)
      {
        int num = (int) MessageBox.Show("The file \"LogitechLedEnginesWrapper.dll\" could not be found.\nRefer to the FAQ for possible solutions. This program will now exit.\n\n" + ex.Message, "DLL Missing: LogitechLedEnginesWrapper", MessageBoxButtons.OK, MessageBoxIcon.Hand);
        Environment.Exit(0);
      }
      try
      {
        if (!this.checkBox_ARXApp.Checked)
          return;
        this.startARX();
      }
      catch (DllNotFoundException ex)
      {
        int num = (int) MessageBox.Show("The file \"LogitechGArxControlEnginesWrapper.dll\" could not be found.\nRefer to the FAQ for possible solutions.\n\n" + ex.Message, "DLL Missing: LogitechGArxControlEnginesWrapper", MessageBoxButtons.OK, MessageBoxIcon.Hand);
      }
    }

    private void MainForm_Load(object sender, EventArgs e)
    {
      try
      {
        MainForm.Global.programReady = true;
        if (this.checkBox_UpdateCheck.Checked)
          this.checkBox_UpdateCheck.Checked = UpdateChecker.checkForUpdate(false, this.checkBox_UpdateCheck.Checked);
        string importPath;
        if (Settings.Default.upgradeRequired && UpgradeSettings.upgradeSettings(out importPath))
          this.importSettings(false, importPath);
        if (this.checkBox_AutoStartup.Checked)
          this.button_StartSpectro_Click((object) null, (EventArgs) null);
        if (this.checkBox_MinimiseStartup.Checked)
          this.WindowState = FormWindowState.Minimized;
        if (this.checkBox_MediaKeys.Checked)
          this.subscribeGlobalHook();
        this.backgroundWorker_Cycle.RunWorkerAsync();
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show("An error occurred during program startup (Stage 2).\n\n" + ex.Message + "\n\n" + (object) ex.TargetSite, "Program Startup Error (Stage 2)", MessageBoxButtons.OK, MessageBoxIcon.Hand);
      }
    }

    private void loadTooltips()
    {
      ToolTip toolTip = new ToolTip();
      toolTip.AutoPopDelay = 10000;
      toolTip.InitialDelay = 1000;
      toolTip.ReshowDelay = 500;
      toolTip.ShowAlways = true;
      toolTip.SetToolTip((Control) this.button_StartSpectro, "Starts the spectrogram");
      toolTip.SetToolTip((Control) this.comboBox_InputDevice, "Selects the source from which audio is captured for the spectrogram output");
      string caption1 = "Refreshes the list of input devices";
      toolTip.SetToolTip((Control) this.button_RefreshInputDevice, caption1);
      toolTip.SetToolTip((Control) this.label_InputDevice, caption1);
      toolTip.SetToolTip((Control) this.comboBox_KL_ColorMode, "Sets the keyboard color mode");
      toolTip.SetToolTip((Control) this.button_Foreground, "The selected foreground color - this can be set by clicking this button or using the controls above");
      toolTip.SetToolTip((Control) this.button_Background, "The selected background color - this can be set by clicking this button or using the controls above");
      toolTip.SetToolTip((Control) this.checkBox_Cycle, "Enables the color cycle effect, which automatically cycles through the color spectrum, starting at red");
      string caption2 = "Sets the speed of the color cycle effect in milliseconds";
      toolTip.SetToolTip((Control) this.label_CycleDelay, caption2);
      toolTip.SetToolTip((Control) this.numericUpDown_CycleDelay, caption2);
      toolTip.SetToolTip((Control) this.button_LoadVProfile, "Loads the gradient profile selected in the drop down box above");
      toolTip.SetToolTip((Control) this.button_SaveVProfile, "Saves the currently displayed gradient to the gradient profile selected in the drop down box above");
      toolTip.SetToolTip((Control) this.button_RenameVProfile, "Renames the gradient profile selected in the drop down box above");
      toolTip.SetToolTip((Control) this.button_GenerateVGradient, "Generates a gradient by blending the colors in the top-most and bottom-most buttons at the right");
      toolTip.SetToolTip((Control) this.button_FlipVGradient, "Flips the currently displayed gradient");
      string caption3 = "Sets the speed of the color wave effect in milliseconds";
      toolTip.SetToolTip((Control) this.label_VColorWaveDelay, caption3);
      toolTip.SetToolTip((Control) this.numericUpDown_VColorWaveDelay, caption3);
      toolTip.SetToolTip((Control) this.label_HColorWaveDelay, caption3);
      toolTip.SetToolTip((Control) this.numericUpDown_HColorWaveDelay, caption3);
      string caption4 = "Sets the difference between the colors in each row or column";
      toolTip.SetToolTip((Control) this.label_VColorWaveSpacing, caption4);
      toolTip.SetToolTip((Control) this.comboBox_VColorWaveSpacing, caption4);
      toolTip.SetToolTip((Control) this.label_HColorWaveSpacing, caption4);
      toolTip.SetToolTip((Control) this.comboBox_HColorWaveSpacing, caption4);
      string caption5 = "Sets the direction of motion for the color wave effect";
      toolTip.SetToolTip((Control) this.label_VColorWaveDirection, caption5);
      toolTip.SetToolTip((Control) this.comboBox_VColorWaveDirection, caption5);
      toolTip.SetToolTip((Control) this.label_HColorWaveDirection, caption5);
      toolTip.SetToolTip((Control) this.comboBox_HColorWaveDirection, caption5);
      toolTip.SetToolTip((Control) this.checkBox_AutoConsole, "Automatically opens the on-screen output window when the spectrogram is started and closes it when the spectrogram is stopped");
      toolTip.SetToolTip((Control) this.checkBox_HighQualityGraphics, "Enables high quality graphics for the on-screen output - disable this to improve performance slightly");
      toolTip.SetToolTip((Control) this.checkBox_UseKeyboardColors, "Uses the colors defined in the Keyboard Lighting tab for the on-screen output");
      string caption6 = "Sets the vertical scale of the on-screen output";
      toolTip.SetToolTip((Control) this.label_OS_Scale, caption6);
      toolTip.SetToolTip((Control) this.numericUpDown_OS_Scale, caption6);
      string caption7 = "Sets the sensitivity of the spectrogram - a lower value will result in reduced spectrogram height";
      toolTip.SetToolTip((Control) this.label_SpectroScale, caption7);
      toolTip.SetToolTip((Control) this.numericUpDown_SpectroScale, caption7);
      string caption8 = "Creates a slope which gradually boosts the amplitude of higher frequencies - a value of 0 disables this boost";
      toolTip.SetToolTip((Control) this.label_FrequencyBoost, caption8);
      toolTip.SetToolTip((Control) this.numericUpDown_FrequencyBoost, caption8);
      string caption9 = "Sets the vertical scale of the spectrogram";
      toolTip.SetToolTip((Control) this.label_AmplitudeScale, caption9);
      toolTip.SetToolTip((Control) this.comboBox_AmplitudeScale, caption9);
      string caption10 = "Sets the offset of the vertical scale - a negative value 'lowers' the spectrogram output while a positive value 'raises' it";
      toolTip.SetToolTip((Control) this.label_AmplitudeOffset, caption10);
      toolTip.SetToolTip((Control) this.numericUpDown_AmplitudeOffset, caption10);
      string caption11 = "Sets the refresh delay of the spectrogram - lower values will cause it refresh more frequently but will be more intensive";
      toolTip.SetToolTip((Control) this.label_RefreshDelay, caption11);
      toolTip.SetToolTip((Control) this.numericUpDown_RefreshDelay, caption11);
    }

    private void button_StartSpectro_Click(object sender, EventArgs e)
    {
      if (!this.backgroundWorker_Main.IsBusy)
      {
        if (string.IsNullOrEmpty(this.comboBox_InputDevice.Text))
        {
          int num = (int) MessageBox.Show("The spectrogram could not be started as no input device has been selected.", "No Selected Input Device", MessageBoxButtons.OK, MessageBoxIcon.Hand);
        }
        else
        {
          this.button_RefreshInputDevice.Enabled = false;
          this.comboBox_InputDevice.Enabled = false;
          this.comboBox_KeyboardLayout.Enabled = false;
          if (this.checkBox_AutoConsole.Checked)
            this.openOutputWindow();
          if (this.checkBox_DisableGLights.Checked)
          {
            LogitechGSDK.LogiLedSetTargetDevice(4);
            LogitechGSDK.LogiLedSetLighting(0, 0, 0);
          }
          this.backgroundWorker_Main.RunWorkerAsync();
          this.button_StartSpectro.Text = "Stop Spectrogram";
          this.sendToARX("runSpectro", "start");
        }
      }
      else
      {
        this.backgroundWorker_Main.CancelAsync();
        this._resetEvent.WaitOne();
        this.StopSpectroUIUpdate();
      }
    }

    public void StopSpectroUIUpdate()
    {
      if (this.checkBox_AutoConsole.Checked)
        this.closeOutputWindow();
      LogitechGSDK.LogiLedRestoreLighting();
      this.button_RefreshInputDevice.Enabled = true;
      this.comboBox_InputDevice.Enabled = true;
      this.comboBox_KeyboardLayout.Enabled = true;
      this.button_StartSpectro.Text = "Start Spectrogram";
      this.sendToARX("runSpectro", "stop");
    }

    private void backgroundWorker_Main_DoWork(object sender, DoWorkEventArgs e)
    {
      MMDevice mmDevice;
      string keyboardLayout;
      while (true)
      {
        try
        {
                    mmDevice = ((KeyValuePair<string, MMDevice>)this.comboBox_InputDevice.SelectedItem).Value;
                   keyboardLayout = (string) this.comboBox_KeyboardLayout.SelectedValue;

                    // mmDevice = (MMDevice) this.Invoke((Action) (() => ((KeyValuePair<string, MMDevice>) this.comboBox_InputDevice.SelectedItem).Value));
                    // keyboardLayout = (string) this.Invoke((Action) (() => (string) this.comboBox_KeyboardLayout.SelectedValue));
                    break;
        }
        catch (InvalidOperationException ex)
        {
          Thread.Sleep(1000);
        }
      }
      int[,] settings = new int[25, 4];
      int refreshDelay = 20;
      int amplitudeScaleType = 0;
      int amplitudeOffset = 0;
      int frequencyBoostFactor = 10;
      int length = 256;
      byte[] audioBuffer = new byte[length];
      byte[] fftData = new byte[length / 2];
      float[] fftResultBuffer = new float[length];
      DateTime now = DateTime.Now;
      List<IWriter> writerList = new List<IWriter>();
      KeyboardWriter keyboardWriter;
      writerList.Add((IWriter) (keyboardWriter = new KeyboardWriter((MainFormInterface) this)));
      keyboardWriter.InitKeyboard(keyboardLayout);
      writerList.Add((IWriter) new DeviceWriter());
      WasapiCapture wasapiCapture1 = new WasapiCapture();
      FftProvider fftProvider = new FftProvider(2, FftSize.Fft256);
      WasapiCapture wasapiCapture2 = !(mmDevice.DeviceID[5].ToString() == "1") ? (WasapiCapture) new WasapiLoopbackCapture() : new WasapiCapture();
      wasapiCapture2.Device = mmDevice;
      wasapiCapture2.Initialize();
      SoundInSource waveSource = new SoundInSource((ISoundIn) wasapiCapture2);
      SingleBlockNotificationStream sampleSource = new SingleBlockNotificationStream(waveSource.ToSampleSource().ToMono().ChangeSampleRate(8192));
      sampleSource.SingleBlockRead += (EventHandler<SingleBlockReadEventArgs>) ((s, a) => fftProvider.Add(a.Left, a.Right));
      IWaveSource finalSource = sampleSource.ToWaveSource(8).ChangeSampleRate(8192);
      waveSource.DataAvailable += (EventHandler<DataAvailableEventArgs>) ((s, f) => finalSource.Read(audioBuffer, 0, audioBuffer.Length));
      wasapiCapture2.Start();
label_5:
      for (int index1 = 0; index1 < 2; ++index1)
      {
        if (!this.backgroundWorker_Main.CancellationPending)
        {
          this.BeginInvoke((Action) (() =>
          {
            settings[0, 0] = this.comboBox_KL_ColorMode.SelectedIndex;
            settings[0, 1] = Convert.ToInt32(this.checkBox_UseKeyboardColors.Checked);
            settings[0, 2] = Convert.ToInt32(this.checkBox_DeviceLighting.Checked);
            settings[0, 3] = Convert.ToInt32(this.checkBox_DisableGLights.Checked);
            switch (this.comboBox_KL_ColorMode.SelectedIndex)
            {
              case 0:
                settings[1, 0] = (int) this.numericUpDown_BGRed.Value;
                settings[1, 1] = (int) this.numericUpDown_BGGreen.Value;
                settings[1, 2] = (int) this.numericUpDown_BGBlue.Value;
                settings[2, 0] = this.trackBar_red.Value;
                settings[2, 1] = this.trackBar_green.Value;
                settings[2, 2] = this.trackBar_blue.Value;
                break;
              case 1:
                for (int index = 0; index < MainForm.Global.gradientColor.GetLength(0); ++index)
                {
                  settings[index + 2, 0] = (int) MainForm.Global.gradientColor[index].R;
                  settings[index + 2, 1] = (int) MainForm.Global.gradientColor[index].G;
                  settings[index + 2, 2] = (int) MainForm.Global.gradientColor[index].B;
                }
                settings[2, 3] = Convert.ToInt32(this.checkBox_VColorWaveEnable.Checked);
                break;
              case 2:
                settings[2, 0] = (int) MainForm.Global.hGradientColor[1].R;
                settings[2, 1] = (int) MainForm.Global.hGradientColor[1].G;
                settings[2, 2] = (int) MainForm.Global.hGradientColor[1].B;
                for (int index = 1; index < MainForm.Global.hGradientColor.GetLength(0); ++index)
                {
                  settings[index + 2, 0] = (int) MainForm.Global.hGradientColor[index].R;
                  settings[index + 2, 1] = (int) MainForm.Global.hGradientColor[index].G;
                  settings[index + 2, 2] = (int) MainForm.Global.hGradientColor[index].B;
                }
                settings[2, 3] = Convert.ToInt32(this.checkBox_HColorWaveEnable.Checked);
                break;
            }
            refreshDelay = Convert.ToInt32(this.numericUpDown_RefreshDelay.Value);
            amplitudeScaleType = this.comboBox_AmplitudeScale.SelectedIndex;
            amplitudeOffset = (int) this.numericUpDown_AmplitudeOffset.Value;
            frequencyBoostFactor = (int) this.numericUpDown_FrequencyBoost.Value;
          }));
          fftProvider.GetFftData(fftResultBuffer);
          for (int index2 = 0; index2 < fftResultBuffer.Length / 2; ++index2)
          {
            float num = (float) ((1.0 + (double) (index2 * frequencyBoostFactor) / 1280.0) * 1000.0);
            switch (amplitudeScaleType)
            {
              case 0:
                fftData[index2] = this.ToByte((double) fftResultBuffer[index2] * (double) num * (double) MainForm.Global.scale + (double) amplitudeOffset);
                break;
              case 1:
                fftData[index2] = this.ToByte(Math.Sqrt((double) fftResultBuffer[index2] * (double) num) * 6.0 * (double) MainForm.Global.scale + (double) amplitudeOffset);
                break;
              case 2:
                fftData[index2] = this.ToByte(Math.Max(Math.Log10((double) fftResultBuffer[index2] * (double) num), 0.0) * 24.0 * (double) MainForm.Global.scale + (double) amplitudeOffset);
                break;
            }
          }
          writerList.ForEach((Action<IWriter>) (x => x.Write(fftData, settings)));
          this.BeginInvoke((Action) (() => Application.OpenForms.OfType<OutputWindow>().FirstOrDefault<OutputWindow>()?.UpdateImage(fftData, settings, MainForm.Global.OSverticalScale, this.checkBox_HighQualityGraphics.Checked, this.button_OS_BG.BackColor, this.button_OS_FG.BackColor)));
          switch (MainForm.Global.ARXOnScreen)
          {
            case 1:
              LogitechArx.LogiArxSetTagContentById("fftData", "");
              MainForm.Global.ARXOnScreen = 0;
              break;
            case 2:
              LogitechArx.LogiArxSetTagContentById("fftData", string.Join<byte>(",", (IEnumerable<byte>) fftData));
              break;
          }
          Thread.Sleep(refreshDelay);
          TimeSpan timeSpan = DateTime.Now - now;
          now = DateTime.Now;
        }
        else
        {
          if (wasapiCapture2 != null)
          {
            wasapiCapture2.Stop();
            wasapiCapture2.Dispose();
            wasapiCapture1 = (WasapiCapture) null;
          }
          waveSource?.Dispose();
          LogitechGSDK.LogiLedSetTargetDevice(MainForm.Global.LogitechAllDevices);
          LogitechGSDK.LogiLedRestoreLighting();
          this._resetEvent.Set();
          return;
        }
      }
      goto label_5;
    }

    public void backgroundWorker_Main_RunWorkerCompleted(
      object sender,
      RunWorkerCompletedEventArgs e)
    {
      if (e.Error == null)
        return;
      int num = (int) MessageBox.Show("An error has occurred in the primary spectrogram thread.\n\n" + e.Error.Message, "Error in Primary Spectrogram Thread");
    }

    private static WaveFormat WaveFormatFromBlob(Blob blob)
    {
      if (blob.Length == 40)
        return (WaveFormat) Marshal.PtrToStructure(blob.Data, typeof (WaveFormatExtensible));
      return (WaveFormat) Marshal.PtrToStructure(blob.Data, typeof (WaveFormat));
    }

    private void backgroundWorker_Cycle_DoWork(object sender, DoWorkEventArgs e)
    {
      while (true)
      {
        switch (this.currentColorMode())
        {
          case 0:
            for (int i = 0; i <= 1530; ++i)
            {
              int num = this.currentColorMode();
              if (this.currentCycleStatus(0) && num == 0)
              {
                if (i == 0)
                  this.Invoke((Action) (() =>
                  {
                    this.trackBar_red.Value = (int) byte.MaxValue;
                    this.trackBar_green.Value = 0;
                    this.trackBar_blue.Value = 0;
                  }));
                int color = 0;
                int value = 0;
                this.solidColorCycle(i, out color, out value);
                try
                {
                  switch (color)
                  {
                    case 0:
                      this.Invoke((Action) (() => this.trackBar_red.Value = value));
                      break;
                    case 1:
                      this.Invoke((Action) (() => this.trackBar_green.Value = value));
                      break;
                    case 2:
                      this.Invoke((Action) (() => this.trackBar_blue.Value = value));
                      break;
                  }
                }
                catch (ObjectDisposedException ex)
                {
                }
                if (i == 1530)
                  i = 0;
                try
                {
                  Thread.Sleep((int) this.Invoke((Action) (() => Convert.ToInt32(this.numericUpDown_CycleDelay.Value))));
                }
                catch (ObjectDisposedException ex)
                {
                }
              }
              else
                break;
            }
            break;
          case 1:
            int millisecondsTimeout1 = 15;
            for (int index1 = 0; index1 <= 1530; index1 += 5)
            {
              int num1 = this.currentColorMode();
              int num2 = this.currentCycleStatus(1) ? 1 : 0;
              int num3 = this.currentWaveDirection(1);
              int num4 = this.currentWaveSpacing(1);
              if (num2 != 0 && num1 == 1)
              {
                for (int index2 = 0; index2 < MainForm.Global.gradientColor.Length; ++index2)
                {
                  int i = index1 + index2 * num4;
                  if (i > 1530)
                    i -= 1530;
                  int red;
                  int green;
                  int blue;
                  this.colorWave(i, out red, out green, out blue);
                  switch (num3)
                  {
                    case 0:
                      MainForm.Global.gradientColor[index2] = Color.FromArgb(red, green, blue);
                      break;
                    case 1:
                      MainForm.Global.gradientColor[MainForm.Global.gradientColor.Length - 1 - index2] = Color.FromArgb(red, green, blue);
                      break;
                  }
                }
                int num5 = millisecondsTimeout1 >= 5 ? (millisecondsTimeout1 >= 10 ? 20 : 40) : 80;
                if (index1 % num5 == 0)
                {
                  try
                  {
                    this.Invoke((Action) (() =>
                    {
                      for (int index = 0; index < MainForm.Global.gradientColor.Length; ++index)
                        (((IEnumerable<Control>) this.panel_KL_VerticalGradient.Controls.Find(index.ToString(), false)).FirstOrDefault<Control>() as Button).BackColor = MainForm.Global.gradientColor[index];
                    }));
                  }
                  catch (ObjectDisposedException ex)
                  {
                  }
                }
                if (index1 >= 1530)
                  index1 = 0;
                try
                {
                  millisecondsTimeout1 = (int) this.Invoke((Action) (() => Convert.ToInt32(this.numericUpDown_VColorWaveDelay.Value)));
                  Thread.Sleep(millisecondsTimeout1);
                }
                catch (ObjectDisposedException ex)
                {
                }
              }
              else
                break;
            }
            break;
          case 2:
            int millisecondsTimeout2 = 15;
            int index3 = 11;
            for (int index1 = 0; index1 <= 1530; index1 += 5)
            {
              int num1 = this.currentColorMode();
              int num2 = this.currentCycleStatus(2) ? 1 : 0;
              int num3 = this.currentWaveDirection(2);
              int num4 = this.currentWaveSpacing(2);
              if (num2 != 0 && num1 == 2)
              {
                for (int index2 = 0; index2 < MainForm.Global.hGradientColor.Length; ++index2)
                {
                  int i = index1 + index2 * num4;
                  if (i > 3060)
                    i -= 3060;
                  else if (i > 1530)
                    i -= 1530;
                  int red;
                  int green;
                  int blue;
                  this.colorWave(i, out red, out green, out blue);
                  switch (num3)
                  {
                    case 0:
                      MainForm.Global.hGradientColor[index2] = Color.FromArgb(red, green, blue);
                      break;
                    case 1:
                      MainForm.Global.hGradientColor[MainForm.Global.hGradientColor.Length - 1 - index2] = Color.FromArgb(red, green, blue);
                      break;
                    case 2:
                      if (index2 == 0)
                      {
                        MainForm.Global.hGradientColor[index3] = Color.FromArgb(red, green, blue);
                        break;
                      }
                      if (index2 <= index3)
                      {
                        MainForm.Global.hGradientColor[index3 - index2] = Color.FromArgb(red, green, blue);
                        MainForm.Global.hGradientColor[index3 + index2] = Color.FromArgb(red, green, blue);
                        break;
                      }
                      break;
                    case 3:
                      if (index2 == index3)
                      {
                        MainForm.Global.hGradientColor[index3] = Color.FromArgb(red, green, blue);
                        break;
                      }
                      if (index2 < index3)
                      {
                        MainForm.Global.hGradientColor[MainForm.Global.hGradientColor.Length - 1 - index2] = Color.FromArgb(red, green, blue);
                        MainForm.Global.hGradientColor[index2] = Color.FromArgb(red, green, blue);
                        break;
                      }
                      break;
                  }
                }
                int num5 = millisecondsTimeout2 >= 5 ? (millisecondsTimeout2 >= 10 ? 20 : 40) : 80;
                if (index1 % num5 == 0 && MainForm.Global.sendToARX)
                  this.sendToARX("HGradientColors", (string) null);
                if (index1 >= 1530)
                  index1 = 0;
                try
                {
                  millisecondsTimeout2 = (int) this.Invoke((Action) (() => Convert.ToInt32(this.numericUpDown_HColorWaveDelay.Value)));
                  Thread.Sleep(millisecondsTimeout2);
                }
                catch (ObjectDisposedException ex)
                {
                }
              }
              else
                break;
            }
            break;
        }
        Thread.Sleep(500);
      }
    }

    public void backgroundWorker_Cycle_RunWorkerCompleted(
      object sender,
      RunWorkerCompletedEventArgs e)
    {
      if (e.Error == null)
        return;
      int num = (int) MessageBox.Show("An error has occurred in the secondary spectrogram thread.\n\n" + e.Error.Message, "Error in Secondary Spectrogram Thread");
    }

    private int currentColorMode()
    {
      try
      {
                return (int)this.Invoke(new Func<int>(() => { return this.comboBox_KL_ColorMode.SelectedIndex; }));
      }
      catch (ObjectDisposedException ex)
      {
        return 0;
      }
    }

    private bool currentCycleStatus(int colorMode)
    {
      try
      {
        switch (colorMode)
        {
          case 0:
            return (bool) this.checkBox_Cycle.Checked;
          case 1:
            return (bool) this.checkBox_VColorWaveEnable.Checked;
          case 2:
            return (bool) this.checkBox_HColorWaveEnable.Checked;
          default:
            return false;
        }
      }
      catch (ObjectDisposedException ex)
      {
        return false;
      }
    }

    private int currentWaveDirection(int colorMode)
    {
      try
      {
                if (colorMode == 1)
                    return (int)this.Invoke(new Func<int>(() =>
                    {
                        return this.comboBox_VColorWaveDirection.SelectedIndex;
                    }));
        if (colorMode == 2)
          return (int) this.comboBox_HColorWaveDirection.SelectedIndex;
        return 0;
      }
      catch (ObjectDisposedException ex)
      {
        return 0;
      }
    }

    private int currentWaveSpacing(int colorMode)
    {
      try
      {
        switch (colorMode)
        {
          case 1:
            int num1;
            switch ((int) this.comboBox_VColorWaveSpacing.SelectedIndex)
            {
              case 1:
                num1 = 102;
                break;
              case 2:
                num1 = 153;
                break;
              default:
                num1 = 51;
                break;
            }
            return num1;
          case 2:
            int num2;
            switch ((int) this.comboBox_HColorWaveSpacing.SelectedIndex)
            {
              case 1:
                num2 = 51;
                break;
              case 2:
                num2 = 75;
                break;
              default:
                num2 = 25;
                break;
            }
            return num2;
          default:
            return 0;
        }
      }
      catch (ObjectDisposedException ex)
      {
        return 0;
      }
    }

    private void solidColorCycle(int i, out int color, out int value)
    {
      if (i <= (int) byte.MaxValue)
      {
        color = 1;
        value = i;
      }
      else if (i <= 510)
      {
        color = 0;
        value = 510 - i;
      }
      else if (i <= 765)
      {
        color = 2;
        value = i - 510;
      }
      else if (i <= 1020)
      {
        color = 1;
        value = 1020 - i;
      }
      else if (i <= 1275)
      {
        color = 0;
        value = i - 1020;
      }
      else if (i <= 1530)
      {
        color = 2;
        value = 1530 - i;
      }
      else
      {
        color = 0;
        value = 0;
      }
    }

    private void colorWave(int i, out int red, out int green, out int blue)
    {
      if (i <= (int) byte.MaxValue)
      {
        red = (int) byte.MaxValue;
        green = i;
        blue = 0;
      }
      else if (i <= 510)
      {
        red = 510 - i;
        green = (int) byte.MaxValue;
        blue = 0;
      }
      else if (i <= 765)
      {
        red = 0;
        green = (int) byte.MaxValue;
        blue = i - 510;
      }
      else if (i <= 1020)
      {
        red = 0;
        green = 1020 - i;
        blue = (int) byte.MaxValue;
      }
      else if (i <= 1275)
      {
        red = i - 1020;
        green = 0;
        blue = (int) byte.MaxValue;
      }
      else if (i <= 1530)
      {
        red = (int) byte.MaxValue;
        green = 0;
        blue = 1530 - i;
      }
      else
      {
        red = (int) byte.MaxValue;
        green = 0;
        blue = 0;
      }
    }

    private void checkBox_Cycle_CheckedChanged(object sender, EventArgs e)
    {
      if (this.checkBox_Cycle.Checked)
      {
        this.trackBar_red.Enabled = false;
        this.trackBar_green.Enabled = false;
        this.trackBar_blue.Enabled = false;
        this.numericUpDown_red.Enabled = false;
        this.numericUpDown_blue.Enabled = false;
        this.numericUpDown_green.Enabled = false;
        this.button_Foreground.Enabled = false;
        if (!MainForm.Global.sendToARX)
          return;
        this.sendToARX("cycleColors", "start");
      }
      else
      {
        if (this.checkBox_Cycle.Checked)
          return;
        this.trackBar_red.Enabled = true;
        this.trackBar_green.Enabled = true;
        this.trackBar_blue.Enabled = true;
        this.numericUpDown_red.Enabled = true;
        this.numericUpDown_blue.Enabled = true;
        this.numericUpDown_green.Enabled = true;
        this.button_Foreground.Enabled = true;
        if (!MainForm.Global.sendToARX)
          return;
        this.sendToARX("cycleColors", "stop");
      }
    }

    private void numericUpDown_CycleDelay_ValueChanged(object sender, EventArgs e)
    {
      if (!MainForm.Global.sendToARX)
        return;
      this.sendToARX("cycleColorsDelay", this.numericUpDown_CycleDelay.Value.ToString());
    }

    private void trackBar_red_ValueChanged(object sender, EventArgs e)
    {
      this.numericUpDown_red.Value = (Decimal) this.trackBar_red.Value;
      this.button_Foreground.BackColor = Color.FromArgb(this.trackBar_red.Value, this.trackBar_green.Value, this.trackBar_blue.Value);
      if (!MainForm.Global.sendToARX)
        return;
      string[] strArray = new string[5]
      {
        this.trackBar_red.Value.ToString(),
        ",",
        null,
        null,
        null
      };
      int num = this.trackBar_green.Value;
      strArray[2] = num.ToString();
      strArray[3] = ",";
      num = this.trackBar_blue.Value;
      strArray[4] = num.ToString();
      this.sendToARX("KL_FGColor", string.Concat(strArray));
    }

    private void trackBar_green_ValueChanged(object sender, EventArgs e)
    {
      this.numericUpDown_green.Value = (Decimal) this.trackBar_green.Value;
      this.button_Foreground.BackColor = Color.FromArgb(this.trackBar_red.Value, this.trackBar_green.Value, this.trackBar_blue.Value);
      if (!MainForm.Global.sendToARX)
        return;
      string[] strArray = new string[5]
      {
        this.trackBar_red.Value.ToString(),
        ",",
        null,
        null,
        null
      };
      int num = this.trackBar_green.Value;
      strArray[2] = num.ToString();
      strArray[3] = ",";
      num = this.trackBar_blue.Value;
      strArray[4] = num.ToString();
      this.sendToARX("KL_FGColor", string.Concat(strArray));
    }

    private void trackBar_blue_ValueChanged(object sender, EventArgs e)
    {
      this.numericUpDown_blue.Value = (Decimal) this.trackBar_blue.Value;
      this.button_Foreground.BackColor = Color.FromArgb(this.trackBar_red.Value, this.trackBar_green.Value, this.trackBar_blue.Value);
      if (!MainForm.Global.sendToARX)
        return;
      string[] strArray = new string[5]
      {
        this.trackBar_red.Value.ToString(),
        ",",
        null,
        null,
        null
      };
      int num = this.trackBar_green.Value;
      strArray[2] = num.ToString();
      strArray[3] = ",";
      num = this.trackBar_blue.Value;
      strArray[4] = num.ToString();
      this.sendToARX("KL_FGColor", string.Concat(strArray));
    }

    private void numericUpDown_red_ValueChanged(object sender, EventArgs e)
    {
      this.trackBar_red.Value = Convert.ToInt32(this.numericUpDown_red.Value);
    }

    private void numericUpDown_green_ValueChanged(object sender, EventArgs e)
    {
      this.trackBar_green.Value = Convert.ToInt32(this.numericUpDown_green.Value);
    }

    private void numericUpDown_blue_ValueChanged(object sender, EventArgs e)
    {
      this.trackBar_blue.Value = Convert.ToInt32(this.numericUpDown_blue.Value);
    }

    private void button_Foreground_Click(object sender, EventArgs e)
    {
      this.colorDialog_Main.Color = Color.FromArgb(this.trackBar_red.Value, this.trackBar_green.Value, this.trackBar_blue.Value);
      if (this.colorDialog_Main.ShowDialog() != DialogResult.OK)
        return;
      this.trackBar_red.Value = (int) this.colorDialog_Main.Color.R;
      this.trackBar_green.Value = (int) this.colorDialog_Main.Color.G;
      this.trackBar_blue.Value = (int) this.colorDialog_Main.Color.B;
    }

    public void syncColors()
    {
      this.numericUpDown_red.Value = (Decimal) this.trackBar_red.Value;
      this.numericUpDown_green.Value = (Decimal) this.trackBar_green.Value;
      this.numericUpDown_blue.Value = (Decimal) this.trackBar_blue.Value;
      this.button_Foreground.BackColor = Color.FromArgb(this.trackBar_red.Value, this.trackBar_green.Value, this.trackBar_blue.Value);
      this.button_Background.BackColor = Color.FromArgb(Convert.ToInt32(this.numericUpDown_BGRed.Value), Convert.ToInt32(this.numericUpDown_BGGreen.Value), Convert.ToInt32(this.numericUpDown_BGBlue.Value));
    }

    private void numericUpDown_BG_ValueChanged(object sender, EventArgs e)
    {
      this.button_Background.BackColor = Color.FromArgb(Convert.ToInt32(this.numericUpDown_BGRed.Value), Convert.ToInt32(this.numericUpDown_BGGreen.Value), Convert.ToInt32(this.numericUpDown_BGBlue.Value));
      if (!MainForm.Global.sendToARX)
        return;
      this.sendToARX("KL_BGColor", this.numericUpDown_BGRed.Value.ToString() + "," + this.numericUpDown_BGGreen.Value.ToString() + "," + this.numericUpDown_BGBlue.Value.ToString());
    }

    private void button_Background_Click(object sender, EventArgs e)
    {
      this.colorDialog_Main.Color = Color.FromArgb(Convert.ToInt32(this.numericUpDown_BGRed.Value), Convert.ToInt32(this.numericUpDown_BGGreen.Value), Convert.ToInt32(this.numericUpDown_BGBlue.Value));
      if (this.colorDialog_Main.ShowDialog() != DialogResult.OK)
        return;
      this.numericUpDown_BGRed.Value = (Decimal) this.colorDialog_Main.Color.R;
      this.numericUpDown_BGGreen.Value = (Decimal) this.colorDialog_Main.Color.G;
      this.numericUpDown_BGBlue.Value = (Decimal) this.colorDialog_Main.Color.B;
    }

    public void getInputDevices()
    {
      this.comboBox_InputDevice.DataSource = (object) null;
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
              if (mmDevice.FriendlyName == defaultAudioEndpoint.FriendlyName)
                MainForm.Global.defaultSelectedIndex = num;
              if (dictionary.ContainsKey(mmDevice.FriendlyName))
                dictionary.Add(mmDevice.FriendlyName + " (" + num.ToString() + ")", mmDevice);
              else
                dictionary.Add(mmDevice.FriendlyName, mmDevice);
              ++num;
            }
          }
          this.comboBox_InputDevice.DataSource = (object) new BindingSource((object) dictionary, (string) null);
          this.comboBox_InputDevice.DisplayMember = "Value";
          this.comboBox_InputDevice.ValueMember = "Key";
          this.comboBox_InputDevice.SelectedIndex = MainForm.Global.defaultSelectedIndex;
        }
      }
      catch (CoreAudioAPIException ex)
      {
        int num = (int) MessageBox.Show("No input devices were found.", "Input Devices Not Found", MessageBoxButtons.OK, MessageBoxIcon.Hand);
      }
    }

    private void comboBox_InputDevice_SelectedIndexChanged(object sender, EventArgs e)
    {
      this.sendToARX("inputDevices", (string) null);
    }

    private void button_RefreshInputDevice_Click(object sender, EventArgs e)
    {
      this.getInputDevices();
      this.sendToARX("inputDevices", (string) null);
    }

    private void button_OpenConsole_Click(object sender, EventArgs e)
    {
      if (!Application.OpenForms.OfType<OutputWindow>().Any<OutputWindow>())
        this.openOutputWindow();
      else
        this.closeOutputWindow();
    }

    public bool openOutputWindow()
    {
      if (Application.OpenForms.OfType<OutputWindow>().Any<OutputWindow>())
        return true;
      new OutputWindow((MainFormInterface) this).Show();
      this.button_OpenConsole.Text = "Close Output Window";
      return true;
    }

    public void closeOutputWindow()
    {
      OutputWindow outputWindow = Application.OpenForms.OfType<OutputWindow>().FirstOrDefault<OutputWindow>();
      if (outputWindow == null)
        return;
      outputWindow.Close();
      this.button_OpenConsole.Text = "Open Output Window";
    }

    public string openOutputWindowText
    {
      get
      {
        return this.button_OpenConsole.Text;
      }
      set
      {
        this.button_OpenConsole.Text = value;
      }
    }

    private void linkLabel_A_Logitech_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
      Process.Start(e.Link.LinkData.ToString());
    }

    private async void numericUpDown_SpectroScale_TextChanged(object sender, EventArgs e)
    {
      await Task.Delay(2500);
      MainForm.Global.scale = (float) this.numericUpDown_SpectroScale.Value;
      if (!MainForm.Global.sendToARX)
        return;
      this.sendToARX(((Control) sender).Name, ((NumericUpDown) sender).Value.ToString());
    }

    private async void numericUpDown_OS_Scale_TextChanged(object sender, EventArgs e)
    {
      await Task.Delay(2500);
      MainForm.Global.OSverticalScale = (float) this.numericUpDown_OS_Scale.Value;
    }

    private void updateOSColorsUI()
    {
      if (this.checkBox_UseKeyboardColors.Checked)
        this.groupBox_OS_Colors.Enabled = false;
      else
        this.groupBox_OS_Colors.Enabled = true;
    }

    private void checkBox_UseKeyboardColors_CheckedChanged(object sender, EventArgs e)
    {
      this.updateOSColorsUI();
    }

    private void comboBox_KL_ColorMode_SelectedIndexChanged(object sender, EventArgs e)
    {
      this.panel_KL_SolidColor.Visible = false;
      this.panel_KL_VerticalGradient.Visible = false;
      this.panel_KL_HorizontalGradient.Visible = false;
      switch (this.comboBox_KL_ColorMode.SelectedIndex)
      {
        case 0:
          this.panel_KL_SolidColor.Visible = true;
          break;
        case 1:
          this.panel_KL_VerticalGradient.Visible = true;
          break;
        case 2:
          this.panel_KL_HorizontalGradient.Visible = true;
          break;
      }
      this.sendToARX("changeColorMode", this.comboBox_KL_ColorMode.SelectedIndex.ToString());
    }

    protected override void OnFormClosing(FormClosingEventArgs e)
    {
      if (this.backgroundWorker_Cycle.IsBusy)
        this.backgroundWorker_Cycle.CancelAsync();
      if (this.backgroundWorker_Main.IsBusy)
      {
        this.backgroundWorker_Main.CancelAsync();
        this._resetEvent.WaitOne();
      }
      if (MainForm.Global.ARXRunning)
        LogitechArx.LogiArxShutdown();
      this.saveSettings();
    }

    private void generateGradientButtons()
    {
      Button[] buttonArray = new Button[6];
      int num1 = 308;
      int num2 = 15;
      for (int index = 0; index < buttonArray.Length; ++index)
      {
        buttonArray[index] = new Button();
        buttonArray[index].Name = index.ToString();
        buttonArray[index].Parent = (Control) this.panel_KL_VerticalGradient;
        buttonArray[index].Size = new Size(35, 35);
        buttonArray[index].Location = new Point(num1 + 50, num2 + index * buttonArray[index].Height);
        buttonArray[index].Click += new EventHandler(this.button_Gradient_Click);
        buttonArray[index].BackColorChanged += new EventHandler(this.button_Gradient_BackColorChanged);
      }
      this.panel_KL_VerticalGradient.Controls.AddRange((Control[]) buttonArray);
    }

    private void button_Gradient_Click(object sender, EventArgs e)
    {
      this.colorDialog_Main.Color = ((Control) sender).BackColor;
      if (this.colorDialog_Main.ShowDialog() != DialogResult.OK)
        return;
      ((Control) sender).BackColor = this.colorDialog_Main.Color;
    }

    private void button_Gradient_BackColorChanged(object sender, EventArgs e)
    {
      Button button = (Button) sender;
      MainForm.Global.gradientColor[int.Parse(button.Name)] = button.BackColor;
      this.updateARXGradientColors();
    }

    public void loadSettings()
    {
      // ISSUE: variable of a compiler-generated type
      Settings PSD = Settings.Default;
      if (PSD.inputDevice != null)
        MainForm.Utils.TryLoad((Action) (() => this.comboBox_InputDevice.SelectedValue = PSD.inputDevice));
      MainForm.Utils.TryLoad((Action) (() => this.trackBar_red.Value = PSD.FGRed));
      MainForm.Utils.TryLoad((Action) (() => this.trackBar_green.Value = PSD.FGGreen));
      MainForm.Utils.TryLoad((Action) (() => this.trackBar_blue.Value = PSD.FGBlue));
      MainForm.Utils.TryLoad((Action) (() => this.numericUpDown_BGRed.Value = (Decimal) PSD.BGRed));
      MainForm.Utils.TryLoad((Action) (() => this.numericUpDown_BGGreen.Value = (Decimal) PSD.BGGreen));
      MainForm.Utils.TryLoad((Action) (() => this.numericUpDown_BGBlue.Value = (Decimal) PSD.BGBlue));
      MainForm.Utils.TryLoad((Action) (() => this.colorDialog_Main.CustomColors = PSD.customColors));
      MainForm.Utils.TryLoad((Action) (() => this.checkBox_Cycle.Checked = PSD.cycleColors));
      MainForm.Utils.TryLoad((Action) (() => this.numericUpDown_CycleDelay.Value = (Decimal) PSD.cycleDelay));
      MainForm.Utils.TryLoad((Action) (() => this.checkBox_VColorWaveEnable.Checked = PSD.vColorWaveEnable));
      MainForm.Utils.TryLoad((Action) (() => this.numericUpDown_VColorWaveDelay.Value = (Decimal) PSD.vColorWaveDelay));
      MainForm.Utils.TryLoad((Action) (() => this.comboBox_VColorWaveSpacing.SelectedIndex = PSD.vColorWaveSpacing));
      MainForm.Utils.TryLoad((Action) (() => this.comboBox_VColorWaveDirection.SelectedIndex = PSD.vColorWaveDirection));
      for (int i = 0; i < MainForm.Global.hGradientColor.GetLength(0); i++)
        MainForm.Utils.TryLoad((Action) (() => MainForm.Global.hGradientColor[i] = Color.FromArgb((int) this.intToRGB(PSD.hGradientColor[i], 0), (int) this.intToRGB(PSD.hGradientColor[i], 1), (int) this.intToRGB(PSD.hGradientColor[i], 2))));
      MainForm.Utils.TryLoad((Action) (() => this.checkBox_HColorWaveEnable.Checked = PSD.hColorWaveEnable));
      MainForm.Utils.TryLoad((Action) (() => this.numericUpDown_HColorWaveDelay.Value = (Decimal) PSD.hColorWaveDelay));
      MainForm.Utils.TryLoad((Action) (() => this.comboBox_HColorWaveSpacing.SelectedIndex = PSD.hColorWaveSpacing));
      MainForm.Utils.TryLoad((Action) (() => this.comboBox_HColorWaveDirection.SelectedIndex = PSD.hColorWaveDirection));
      MainForm.Utils.TryLoad((Action) (() => this.checkBox_AutoConsole.Checked = PSD.autoConsole));
      MainForm.Utils.TryLoad((Action) (() => this.checkBox_HighQualityGraphics.Checked = PSD.OS_highQuality));
      MainForm.Utils.TryLoad((Action) (() => this.checkBox_UseKeyboardColors.Checked = PSD.OS_keyboardColors));
      MainForm.Utils.TryLoad((Action) (() => this.numericUpDown_OS_Scale.Value = PSD.OS_verticalScale));
      MainForm.Utils.TryLoad((Action) (() => this.button_OS_FG.BackColor = PSD.OS_FG));
      MainForm.Utils.TryLoad((Action) (() => this.button_OS_BG.BackColor = PSD.OS_BG));
      MainForm.Utils.TryLoad((Action) (() => this.comboBox_KeyboardLayout.SelectedIndex = PSD.keyboardLayout));
      MainForm.Utils.TryLoad((Action) (() => this.numericUpDown_SpectroScale.Value = PSD.spectroScale));
      MainForm.Utils.TryLoad((Action) (() => this.numericUpDown_RefreshDelay.Value = (Decimal) PSD.refreshDelay));
      MainForm.Utils.TryLoad((Action) (() => this.numericUpDown_FrequencyBoost.Value = (Decimal) PSD.frequencyBoost));
      MainForm.Utils.TryLoad((Action) (() => this.comboBox_AmplitudeScale.SelectedIndex = PSD.amplitudeScale));
      MainForm.Utils.TryLoad((Action) (() => this.numericUpDown_AmplitudeOffset.Value = (Decimal) PSD.amplitudeOffset));
      MainForm.Utils.TryLoad((Action) (() => this.checkBox_AutoDefaultDevice.Checked = PSD.defaultDevice));
      MainForm.Utils.TryLoad((Action) (() => this.checkBox_DisableGLights.Checked = PSD.disableGLights));
      MainForm.Utils.TryLoad((Action) (() => this.checkBox_DeviceLighting.Checked = PSD.deviceLighting));
      MainForm.Utils.TryLoad((Action) (() => this.checkBox_AutoStartup.Checked = PSD.autoStartup));
      MainForm.Utils.TryLoad((Action) (() => this.checkBox_MediaKeys.Checked = PSD.mediaKeys));
      MainForm.Utils.TryLoad((Action) (() => this.checkBox_MinimiseStartup.Checked = PSD.minimiseStartup));
      MainForm.Utils.TryLoad((Action) (() => this.checkBox_ARXApp.Checked = PSD.ARXApp));
      MainForm.Utils.TryLoad((Action) (() => MainForm.Global.lastUpdateCheck = PSD.lastUpdateCheck));
      MainForm.Utils.TryLoad((Action) (() => this.checkBox_UpdateCheck.Checked = PSD.updateCheck));
      MainForm.Utils.TryLoad((Action) (() => this.comboBox_KL_ColorMode.SelectedIndex = PSD.colorMode));
      MainForm.Utils.TryLoad((Action) (() => this.loadProfileNames()));
      for (int i = 0; i < MainForm.Global.gradientColor.GetLength(0); i++)
      {
        Button b = ((IEnumerable<Control>) this.panel_KL_VerticalGradient.Controls.Find(i.ToString(), false)).FirstOrDefault<Control>() as Button;
        MainForm.Utils.TryLoad((Action) (() => this.loadGradientColors(b, i)));
      }
      this.syncColors();
      this.updateOSColorsUI();
      MainForm.Global.loadSettings = true;
    }

    public void saveSettings()
    {
      try
      {
        // ISSUE: variable of a compiler-generated type
        Settings settings = Settings.Default;
        settings.upgradeRequired = false;
        settings.inputDevice = this.comboBox_InputDevice.SelectedValue;
        settings.FGRed = this.trackBar_red.Value;
        settings.FGGreen = this.trackBar_green.Value;
        settings.FGBlue = this.trackBar_blue.Value;
        settings.BGRed = (int) this.numericUpDown_BGRed.Value;
        settings.BGGreen = (int) this.numericUpDown_BGGreen.Value;
        settings.BGBlue = (int) this.numericUpDown_BGBlue.Value;
        settings.customColors = this.colorDialog_Main.CustomColors;
        settings.cycleColors = this.checkBox_Cycle.Checked;
        settings.cycleDelay = (int) this.numericUpDown_CycleDelay.Value;
        settings.vColorWaveEnable = this.checkBox_VColorWaveEnable.Checked;
        settings.vColorWaveDelay = (int) this.numericUpDown_VColorWaveDelay.Value;
        settings.vColorWaveSpacing = this.comboBox_VColorWaveSpacing.SelectedIndex;
        settings.vColorWaveDirection = this.comboBox_VColorWaveDirection.SelectedIndex;
        settings.hColorWaveEnable = this.checkBox_HColorWaveEnable.Checked;
        settings.hColorWaveDelay = (int) this.numericUpDown_HColorWaveDelay.Value;
        settings.hColorWaveSpacing = this.comboBox_HColorWaveSpacing.SelectedIndex;
        settings.hColorWaveDirection = this.comboBox_HColorWaveDirection.SelectedIndex;
        settings.autoConsole = this.checkBox_AutoConsole.Checked;
        settings.OS_highQuality = this.checkBox_HighQualityGraphics.Checked;
        settings.OS_keyboardColors = this.checkBox_UseKeyboardColors.Checked;
        settings.OS_verticalScale = this.numericUpDown_OS_Scale.Value;
        settings.OS_FG = this.button_OS_FG.BackColor;
        settings.OS_BG = this.button_OS_BG.BackColor;
        settings.keyboardLayout = this.comboBox_KeyboardLayout.SelectedIndex;
        settings.spectroScale = this.numericUpDown_SpectroScale.Value;
        settings.refreshDelay = (int) this.numericUpDown_RefreshDelay.Value;
        settings.frequencyBoost = (int) this.numericUpDown_FrequencyBoost.Value;
        settings.amplitudeScale = this.comboBox_AmplitudeScale.SelectedIndex;
        settings.amplitudeOffset = (int) this.numericUpDown_AmplitudeOffset.Value;
        settings.defaultDevice = this.checkBox_AutoDefaultDevice.Checked;
        settings.disableGLights = this.checkBox_DisableGLights.Checked;
        settings.deviceLighting = this.checkBox_DeviceLighting.Checked;
        settings.autoStartup = this.checkBox_AutoStartup.Checked;
        settings.mediaKeys = this.checkBox_MediaKeys.Checked;
        settings.minimiseStartup = this.checkBox_MinimiseStartup.Checked;
        settings.ARXApp = this.checkBox_ARXApp.Checked;
        settings.lastUpdateCheck = MainForm.Global.lastUpdateCheck;
        settings.updateCheck = this.checkBox_UpdateCheck.Checked;
        settings.colorMode = this.comboBox_KL_ColorMode.SelectedIndex;
        int[] numArray1 = new int[MainForm.Global.gradientColor.GetLength(0)];
        int[] numArray2 = new int[MainForm.Global.hGradientColor.GetLength(0)];
        for (int index = 0; index < MainForm.Global.gradientColor.GetLength(0); ++index)
          numArray1[index] = this.RGBToInt((int) MainForm.Global.gradientColor[index].R, (int) MainForm.Global.gradientColor[index].G, (int) MainForm.Global.gradientColor[index].B);
        for (int index = 0; index < MainForm.Global.hGradientColor.GetLength(0); ++index)
          numArray2[index] = this.RGBToInt((int) MainForm.Global.hGradientColor[index].R, (int) MainForm.Global.hGradientColor[index].G, (int) MainForm.Global.hGradientColor[index].B);
        settings.gradientColor = numArray1;
        settings.hGradientColor = numArray2;
        settings.Save();
      }
      catch (Exception ex)
      {
        if (MessageBox.Show("An error occurred while saving program settings.\n\n" + ex.Message + "\n\n" + (object) ex.InnerException, "Saving Program Settings Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Hand) == DialogResult.Retry)
          this.saveSettings();
      }
    }

    public void exportSettings()
    {
      SaveFileDialog saveFileDialog = new SaveFileDialog();
      saveFileDialog.Filter = "config files (*.config)|*.config";
      saveFileDialog.RestoreDirectory = true;
      saveFileDialog.DefaultExt = "config";
      DateTime now = DateTime.Now;
      saveFileDialog.FileName = "g910spectro_" + now.ToString("yy-MM-dd_HHmmss");
      if (saveFileDialog.ShowDialog() != DialogResult.OK)
        return;
      try
      {
        this.saveSettings();
        File.Copy(ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.PerUserRoamingAndLocal).FilePath, saveFileDialog.FileName, true);
        this.flashStatusBarMessage("Settings Exported To File", 2000);
      }
      catch (UnauthorizedAccessException ex)
      {
        int num = (int) MessageBox.Show("You do not have permission to export to this location. Please choose another location.", "Export Settings Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show("An error occurred while exporting settings: " + ex.Message, "Export Settings Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
      }
    }

    public void importSettings(bool manualFilePath, string filePath)
    {
      try
      {
        if (manualFilePath)
        {
          OpenFileDialog openFileDialog = new OpenFileDialog();
          openFileDialog.Filter = "config files (*.config)|*.config";
          openFileDialog.RestoreDirectory = true;
          openFileDialog.DefaultExt = "config";
          if (openFileDialog.ShowDialog() != DialogResult.OK)
            return;
          filePath = openFileDialog.FileName;
        }
        System.Configuration.Configuration configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.PerUserRoamingAndLocal);
        if (!configuration.HasFile)
          this.saveSettings();
        File.Copy(filePath, configuration.FilePath, true);
        string contents = File.ReadAllText(configuration.FilePath).Replace("KeyboardAudio.Properties.Settings", "LogitechSpectrogram.Properties.Settings");
        File.WriteAllText(configuration.FilePath, contents);
        Settings.Default.Reload();
        this.loadSettings();
        if (manualFilePath)
          this.flashStatusBarMessage("Settings Imported From File", 2000);
        else
          this.flashStatusBarMessage("Settings Imported From Previous Version", 2000);
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show("An error occurred while importing settings: " + ex.Message, "Import Settings Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
      }
    }

    private void button_RestoreSettings_Click(object sender, EventArgs e)
    {
      if (MessageBox.Show("This will restore the default settings for the entire program.\nAre you sure you want to continue?", "Restore Default Settings", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
        return;
      Settings.Default.Reset();
      this.loadSettings();
    }

    private void button_ExportSettings_Click(object sender, EventArgs e)
    {
      this.exportSettings();
    }

    private void button_ImportSettings_Click(object sender, EventArgs e)
    {
      this.importSettings(true, (string) null);
    }

    private void button_ImportSettingsVersion_Click(object sender, EventArgs e)
    {
      string importPath;
      if (!UpgradeSettings.upgradeSettings(out importPath))
        return;
      this.importSettings(false, importPath);
    }

    private void numericUpDown_Settings_ValueChanged(object sender, EventArgs e)
    {
      if (!MainForm.Global.sendToARX)
        return;
      this.sendToARX(((Control) sender).Name, ((NumericUpDown) sender).Value.ToString());
    }

    private void comboBox_AmplitudeScale_SelectedIndexChanged(object sender, EventArgs e)
    {
      this.sendToARX("comboBox_AmplitudeScale", (string) null);
    }

    private void comboBox_KeyboardLayout_SelectedIndexChanged(object sender, EventArgs e)
    {
      this.sendToARX("comboBox_KeyboardLayout", (string) null);
    }

    private void checkBox_Settings_CheckedChanged(object sender, EventArgs e)
    {
      this.sendToARX(((Control) sender).Name, ((CheckBox) sender).Checked.ToString());
      if (sender != this.checkBox_MediaKeys || !MainForm.Global.programReady)
        return;
      if (this.checkBox_MediaKeys.Checked)
        this.subscribeGlobalHook();
      else
        this.unsubscribeGlobalHook();
    }

    private void button_UpdateCheck_Click(object sender, EventArgs e)
    {
      this.checkBox_UpdateCheck.Checked = UpdateChecker.checkForUpdate(true, this.checkBox_UpdateCheck.Checked);
    }

    private void flipGradient()
    {
      Color[] colorArray = (Color[]) MainForm.Global.gradientColor.Clone();
      for (int index = 0; index < colorArray.Length; ++index)
        (((IEnumerable<Control>) this.panel_KL_VerticalGradient.Controls.Find(index.ToString(), false)).FirstOrDefault<Control>() as Button).BackColor = colorArray[colorArray.Length - 1 - index];
    }

    private void generateGradient()
    {
      Color[] colorArray = new Color[2]
      {
        MainForm.Global.gradientColor[0],
        MainForm.Global.gradientColor[5]
      };
      int num = 6;
      for (int index = 0; index < num; ++index)
      {
        int red = (int) colorArray[0].R + ((int) colorArray[1].R - (int) colorArray[0].R) * index / (num - 1);
        int green = (int) colorArray[0].G + ((int) colorArray[1].G - (int) colorArray[0].G) * index / (num - 1);
        int blue = (int) colorArray[0].B + ((int) colorArray[1].B - (int) colorArray[0].B) * index / (num - 1);
        (((IEnumerable<Control>) this.panel_KL_VerticalGradient.Controls.Find(index.ToString(), false)).FirstOrDefault<Control>() as Button).BackColor = Color.FromArgb(red, green, blue);
      }
    }

    private void loadGradientColors(Button button, int i)
    {
      button.BackColor = Color.FromArgb((int) this.intToRGB(Settings.Default.gradientColor[i], 0), (int) this.intToRGB(Settings.Default.gradientColor[i], 1), (int) this.intToRGB(Settings.Default.gradientColor[i], 2));
    }

    private void loadProfileColors(Button button, int i)
    {
      button.BackColor = Color.FromArgb((int) this.intToRGB(Convert.ToInt32(Settings.Default.verticalProfiles[i]), 0), (int) this.intToRGB(Convert.ToInt32(Settings.Default.verticalProfiles[i]), 1), (int) this.intToRGB(Convert.ToInt32(Settings.Default.verticalProfiles[i]), 2));
    }

    private void loadProfileNames()
    {
      this.comboBox_VerticalProfiles.Items.Clear();
      for (int index = 1; index < 16; ++index)
        this.comboBox_VerticalProfiles.Items.Add((object) Settings.Default.verticalProfiles[index * (MainForm.Global.gradientColor.GetLength(0) + 1) - 1]);
    }

    private void saveProfile()
    {
      int selectedIndex = this.comboBox_VerticalProfiles.SelectedIndex;
      if (selectedIndex < 0)
      {
        int num1 = (int) MessageBox.Show("Please select a profile slot to save to.", "Profile Slot Not Selected", MessageBoxButtons.OK, MessageBoxIcon.Hand);
      }
      else
      {
        int num2 = selectedIndex * (MainForm.Global.gradientColor.GetLength(0) + 1);
        int index1 = (selectedIndex + 1) * (MainForm.Global.gradientColor.GetLength(0) + 1) - 1;
        for (int index2 = num2; index2 < index1; ++index2)
          Settings.Default.verticalProfiles[index2] = this.RGBToInt((int) MainForm.Global.gradientColor[index2 - num2].R, (int) MainForm.Global.gradientColor[index2 - num2].G, (int) MainForm.Global.gradientColor[index2 - num2].B).ToString();
        Settings.Default.verticalProfiles[index1] = this.comboBox_VerticalProfiles.GetItemText(this.comboBox_VerticalProfiles.SelectedItem);
        Settings.Default.Save();
        this.flashStatusBarMessage("Gradient Profile Saved", 2000);
      }
    }

    private void loadProfile()
    {
      int selectedIndex = this.comboBox_VerticalProfiles.SelectedIndex;
      if (selectedIndex < 0)
      {
        int num1 = (int) MessageBox.Show("Please select a profile slot to load from.", "Profile Slot Not Selected", MessageBoxButtons.OK, MessageBoxIcon.Hand);
      }
      else
      {
        int num2 = selectedIndex * (MainForm.Global.gradientColor.GetLength(0) + 1);
        int num3 = (selectedIndex + 1) * (MainForm.Global.gradientColor.GetLength(0) + 1) - 1;
        for (int i = num2; i < num3; ++i)
          this.loadProfileColors(((IEnumerable<Control>) this.panel_KL_VerticalGradient.Controls.Find((i - num2).ToString(), false)).FirstOrDefault<Control>() as Button, i);
        this.flashStatusBarMessage("Gradient Profile Loaded", 2000);
        this.sendToARX("gradientProfiles", (string) null);
      }
    }

    private void button_RenameVProfile_Click(object sender, EventArgs e)
    {
      int selectedIndex = this.comboBox_VerticalProfiles.SelectedIndex;
      if (selectedIndex < 0)
      {
        int num = (int) MessageBox.Show("Please select a profile slot to rename.", "Profile Slot Not Selected", MessageBoxButtons.OK, MessageBoxIcon.Hand);
      }
      else
      {
        using (ProfileRenameForm profileRenameForm = new ProfileRenameForm())
        {
          if (profileRenameForm.ShowDialog((IWin32Window) this) != DialogResult.OK)
            return;
          this.renameProfile(selectedIndex, profileRenameForm.newProfileName);
        }
      }
    }

    private void renameProfile(int SelectedIndex, string newProfileName)
    {
      Settings.Default.verticalProfiles[(SelectedIndex + 1) * (MainForm.Global.gradientColor.GetLength(0) + 1) - 1] = newProfileName;
      this.saveSettings();
      Settings.Default.Reload();
      this.comboBox_VerticalProfiles.Items.Clear();
      this.loadSettings();
      this.comboBox_VerticalProfiles.SelectedIndex = SelectedIndex;
      this.flashStatusBarMessage("Gradient Profile Renamed", 2000);
      this.sendToARX("gradientProfiles", (string) null);
    }

    private int RGBToInt(int r, int g, int b)
    {
      return 0 | (r & (int) byte.MaxValue) << 16 | (g & (int) byte.MaxValue) << 8 | b & (int) byte.MaxValue;
    }

    private byte intToRGB(int colorInt, int color)
    {
      byte num = 0;
      switch (color)
      {
        case 0:
          num = Convert.ToByte(colorInt >> 16 & (int) byte.MaxValue);
          break;
        case 1:
          num = Convert.ToByte(colorInt >> 8 & (int) byte.MaxValue);
          break;
        case 2:
          num = Convert.ToByte(colorInt & (int) byte.MaxValue);
          break;
      }
      return num;
    }

    private byte ToByte(double input)
    {
      byte num;
      try
      {
        num = input >= 0.0 ? (input <= (double) byte.MaxValue ? Convert.ToByte(input) : byte.MaxValue) : (byte) 0;
      }
      catch (OverflowException ex)
      {
        num = byte.MaxValue;
      }
      return num;
    }

    private bool IsOdd(int value)
    {
      return (uint) (value % 2) > 0U;
    }

    public void flashStatusBarMessage(string message, int duration)
    {
      if (!MainForm._timer.Enabled)
        MainForm.Global.oldStatusBarMessage = (string) this.toolStripStatusLabel1.Text.Clone();
      else
        MainForm._timer.Stop();
      this.toolStripStatusLabel1.Text = message;
      this.statusStrip_Main.Refresh();
      MainForm._timer.Interval = (double) duration;
      MainForm._timer.AutoReset = false;
      MainForm._timer.Elapsed += new ElapsedEventHandler(this._timer_Elapsed);
      MainForm._timer.Enabled = true;
    }

    private void _timer_Elapsed(object sender, ElapsedEventArgs e)
    {
      if (this.InvokeRequired)
      {
        this.Invoke((Action) (() =>
        {
          this.toolStripStatusLabel1.Text = MainForm.Global.oldStatusBarMessage;
          this.statusStrip_Main.Refresh();
        }));
      }
      else
      {
        this.toolStripStatusLabel1.Text = MainForm.Global.oldStatusBarMessage;
        this.statusStrip_Main.Refresh();
      }
    }

    public string setStatusBar
    {
      get
      {
        return this.toolStripStatusLabel1.Text;
      }
      set
      {
        if (this.InvokeRequired)
        {
          this.Invoke((Action) (() =>
          {
            this.toolStripStatusLabel1.Text = value;
            this.statusStrip_Main.Refresh();
          }));
        }
        else
        {
          this.toolStripStatusLabel1.Text = value;
          this.statusStrip_Main.Refresh();
        }
      }
    }

    private void button_SaveVProfile_Click(object sender, EventArgs e)
    {
      this.saveProfile();
    }

    private void button_LoadVProfile_Click(object sender, EventArgs e)
    {
      this.loadProfile();
    }

    private void button_FlipVGradient_Click(object sender, EventArgs e)
    {
      this.flipGradient();
    }

    private void button_GenerateVGradient_Click(object sender, EventArgs e)
    {
      this.generateGradient();
    }

    private void MainForm_Resize(object sender, EventArgs e)
    {
      if (this.WindowState == FormWindowState.Minimized)
      {
        this.notifyIcon_Main.Visible = true;
        this.Hide();
        this.ShowInTaskbar = false;
        if (!MainForm.Global.firstMinimize || this.checkBox_MinimiseStartup.Checked)
          return;
        this.notifyIcon_Main.BalloonTipTitle = "Logitech Spectrogram";
        this.notifyIcon_Main.BalloonTipText = "Minimized to tray";
        this.notifyIcon_Main.ShowBalloonTip(1000);
        MainForm.Global.firstMinimize = false;
      }
      else
      {
        if (this.WindowState != FormWindowState.Normal)
          return;
        this.ShowInTaskbar = true;
        this.notifyIcon_Main.Visible = false;
      }
    }

    private void notifyIcon_Main_Click(object sender, EventArgs e)
    {
      this.Show();
      this.WindowState = FormWindowState.Normal;
    }

    public void subscribeGlobalHook()
    {
      this.m_GlobalHook = Hook.GlobalEvents();
      this.m_GlobalHook.KeyDown += new KeyEventHandler(this.OnKeyDown);
    }

    private void OnKeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode == Keys.MediaPlayPause)
      {
        this.button_StartSpectro_Click((object) null, (EventArgs) null);
      }
      else
      {
        if (e.KeyCode != Keys.MediaStop || !this.backgroundWorker_Main.IsBusy)
          return;
        this.button_StartSpectro_Click((object) null, (EventArgs) null);
      }
    }

    public void unsubscribeGlobalHook()
    {
      this.m_GlobalHook.KeyDown -= new KeyEventHandler(this.OnKeyDown);
      this.m_GlobalHook.Dispose();
    }

    private void MainForm_Activated(object sender, EventArgs e)
    {
      MainForm.Global.programActive = true;
    }

    private void MainForm_Deactivated(object sender, EventArgs e)
    {
      MainForm.Global.programActive = false;
    }

    private void startARX()
    {
      this.contextCallback.arxCallBack = new LogitechArx.logiArxCB(this.SDKCallback);
      this.contextCallback.arxContext = IntPtr.Zero;
      if (!LogitechArx.LogiArxInit("arxSpectrogram", "Spectrogram", ref this.contextCallback))
        this.ARXErrorResponse(LogitechArx.LogiArxGetLastError());
      else
        MainForm.Global.ARXRunning = true;
    }

    private void SDKCallback(int eventType, int eventValue, string eventArg, IntPtr context)
    {
      switch (eventType)
      {
        case 1:
          MainForm.Global.ARXActive = true;
          break;
        case 2:
          MainForm.Global.ARXActive = false;
          break;
        case 4:
          if (eventArg.StartsWith("e_determined/RequestData|"))
          {
            this.BeginInvoke((Action) (() =>
            {
              this.sendToARX("changeColorMode", this.comboBox_KL_ColorMode.SelectedIndex.ToString());
              this.jQuerySet("setColorPicker('#KL_FGColor', '" + this.trackBar_red.Value.ToString() + "," + this.trackBar_green.Value.ToString() + "," + this.trackBar_blue.Value.ToString() + "');");
              this.sendToARX("KL_BGColor", this.numericUpDown_BGRed.Value.ToString() + "," + this.numericUpDown_BGGreen.Value.ToString() + "," + this.numericUpDown_BGBlue.Value.ToString());
              this.sendToARX("cycleColorsDelay", this.numericUpDown_CycleDelay.Value.ToString());
              if (this.checkBox_Cycle.Checked)
                this.sendToARX("cycleColors", "start");
              else
                this.sendToARX("cycleColors", "stop");
              if (this.backgroundWorker_Main.IsBusy)
                this.sendToARX("runSpectro", "start");
              else
                this.sendToARX("runSpectro", "stop");
              this.sendToARX("inputDevices", (string) null);
              this.sendToARX("gradientProfiles", (string) null);
              for (int index = 0; index < MainForm.Global.gradientColor.Length; ++index)
                this.sendToARX("VGradientColors", index.ToString() + MainForm.Global.gradientColor[index].R.ToString() + "," + MainForm.Global.gradientColor[index].G.ToString() + "," + MainForm.Global.gradientColor[index].B.ToString());
              this.sendToARX("HGradientColors", (string) null);
              Decimal num = this.numericUpDown_SpectroScale.Value;
              this.sendToARX("numericUpDown_SpectroScale", num.ToString());
              num = this.numericUpDown_FrequencyBoost.Value;
              this.sendToARX("numericUpDown_FrequencyBoost", num.ToString());
              num = this.numericUpDown_AmplitudeOffset.Value;
              this.sendToARX("numericUpDown_AmplitudeOffset", num.ToString());
              num = this.numericUpDown_RefreshDelay.Value;
              this.sendToARX("numericUpDown_RefreshDelay", num.ToString());
              this.sendToARX("comboBox_AmplitudeScale", (string) null);
              this.sendToARX("comboBox_KeyboardLayout", (string) null);
              this.sendToARX("checkBox_UpdateCheck", this.checkBox_UpdateCheck.Checked.ToString());
              this.sendToARX("checkBox_AutoDefaultDevice", this.checkBox_AutoDefaultDevice.Checked.ToString());
              this.sendToARX("checkBox_AutoStartup", this.checkBox_AutoStartup.Checked.ToString());
              this.sendToARX("checkBox_MinimiseStartup", this.checkBox_MinimiseStartup.Checked.ToString());
              this.sendToARX("checkBox_MediaKeys", this.checkBox_MediaKeys.Checked.ToString());
              this.sendToARX("checkBox_DisableGLights", this.checkBox_DisableGLights.Checked.ToString());
              this.sendToARX("checkBox_DeviceLighting", this.checkBox_DeviceLighting.Checked.ToString());
              this.sendToARX("checkBox_ARXApp", this.checkBox_ARXApp.Checked.ToString());
              LogitechArx.LogiArxSetTagContentById("About_PVersion", MainForm.Global.programVersion + MainForm.Global.programArch);
              LogitechArx.LogiArxSetTagContentById("About_LVersion", MainForm.Global.SDKversion);
            }));
            break;
          }
          if (eventArg.StartsWith("KL_FGColor|"))
          {
            int colorInt = Convert.ToInt32(eventArg.Remove(0, 11), 16);
            this.BeginInvoke((Action) (() =>
            {
              MainForm.Global.sendToARX = false;
              this.trackBar_red.Value = (int) this.intToRGB(colorInt, 0);
              this.trackBar_green.Value = (int) this.intToRGB(colorInt, 1);
              this.trackBar_blue.Value = (int) this.intToRGB(colorInt, 2);
              MainForm.Global.sendToARX = true;
            }));
            break;
          }
          if (eventArg.StartsWith("KL_BGColor|"))
          {
            int colorInt = Convert.ToInt32(eventArg.Remove(0, 11), 16);
            this.BeginInvoke((Action) (() =>
            {
              MainForm.Global.sendToARX = false;
              this.numericUpDown_BGRed.Value = (Decimal) this.intToRGB(colorInt, 0);
              this.numericUpDown_BGGreen.Value = (Decimal) this.intToRGB(colorInt, 1);
              this.numericUpDown_BGBlue.Value = (Decimal) this.intToRGB(colorInt, 2);
              MainForm.Global.sendToARX = true;
            }));
            break;
          }
          if (eventArg.StartsWith("KL_CC|"))
          {
            this.BeginInvoke((Action) (() =>
            {
              MainForm.Global.sendToARX = false;
              if (this.checkBox_Cycle.Checked)
              {
                this.checkBox_Cycle.Checked = false;
                LogitechArx.LogiArxSetTagContentById("jQueryColor", "");
              }
              else
                this.checkBox_Cycle.Checked = true;
              MainForm.Global.sendToARX = true;
            }));
            break;
          }
          if (eventArg.StartsWith("KL_CC_Delay|"))
          {
            int delayInt;
            if (!int.TryParse(eventArg.Remove(0, 12), out delayInt))
              break;
            this.BeginInvoke((Action) (() =>
            {
              try
              {
                if (this.backgroundWorker_Cycle.IsBusy)
                {
                  this.numericUpDown_CycleDelay.Value = (Decimal) delayInt;
                }
                else
                {
                  MainForm.Global.sendToARX = false;
                  this.numericUpDown_CycleDelay.Value = (Decimal) delayInt;
                  MainForm.Global.sendToARX = true;
                }
              }
              catch
              {
              }
            }));
            break;
          }
          if (eventArg.StartsWith("KL_ColorMode|"))
          {
            int newColorMode;
            if (!int.TryParse(eventArg.Remove(0, 13), out newColorMode))
              break;
            this.BeginInvoke((Action) (() =>
            {
              try
              {
                this.comboBox_KL_ColorMode.SelectedIndex = newColorMode;
              }
              catch
              {
              }
            }));
            break;
          }
          if (eventArg.StartsWith("RunSpectro|"))
          {
            this.BeginInvoke((Action) (() => this.button_StartSpectro_Click((object) null, (EventArgs) null)));
            break;
          }
          if (eventArg.StartsWith("RefreshInputDevices|"))
          {
            this.BeginInvoke((Action) (() =>
            {
              if (this.backgroundWorker_Main.IsBusy)
                return;
              this.button_RefreshInputDevice_Click((object) null, (EventArgs) null);
            }));
            break;
          }
          if (eventArg.StartsWith("SetInputDevice|"))
          {
            int newSelectedIndex;
            if (!int.TryParse(eventArg.Remove(0, 15), out newSelectedIndex))
              break;
            this.BeginInvoke((Action) (() =>
            {
              try
              {
                this.comboBox_InputDevice.SelectedIndex = newSelectedIndex;
              }
              catch
              {
              }
            }));
            break;
          }
          if (eventArg.StartsWith("KL_VG_Load|") || eventArg.StartsWith("KL_VG_Save|"))
          {
            int newSelectedIndex;
            if (!int.TryParse(eventArg.Remove(0, 11), out newSelectedIndex))
              break;
            this.BeginInvoke((Action) (() =>
            {
              try
              {
                this.comboBox_VerticalProfiles.SelectedIndex = newSelectedIndex;
              }
              catch
              {
              }
              if (eventArg.StartsWith("KL_VG_Load|"))
              {
                this.loadProfile();
              }
              else
              {
                if (!eventArg.StartsWith("KL_VG_Save|"))
                  return;
                this.saveProfile();
              }
            }));
            break;
          }
          if (eventArg.StartsWith("KL_VG_Rename|"))
          {
            try
            {
              string[] output = eventArg.Split("|".ToCharArray(), 3, StringSplitOptions.None);
              int newSelectedIndex;
              if (!int.TryParse(output[1], out newSelectedIndex))
                break;
              this.BeginInvoke((Action) (() =>
              {
                this.comboBox_VerticalProfiles.SelectedIndex = newSelectedIndex;
                this.renameProfile(newSelectedIndex, output[2]);
              }));
              break;
            }
            catch
            {
              break;
            }
          }
          else
          {
            if (eventArg == "KL_VG_Generate")
            {
              this.BeginInvoke((Action) (() => this.generateGradient()));
              break;
            }
            if (eventArg == "KL_VG_Flip")
            {
              this.BeginInvoke((Action) (() => this.flipGradient()));
              break;
            }
            if (eventArg.StartsWith("KL_VGColor|"))
            {
              try
              {
                string[] output = eventArg.Split("|".ToCharArray(), 3, StringSplitOptions.None);
                int buttonNumber;
                if (!int.TryParse(output[1].Remove(0, 14), out buttonNumber))
                  break;
                this.BeginInvoke((Action) (() => (((IEnumerable<Control>) this.panel_KL_VerticalGradient.Controls.Find(buttonNumber.ToString(), false)).FirstOrDefault<Control>() as Button).BackColor = ColorTranslator.FromHtml("#" + output[2])));
                break;
              }
              catch
              {
                break;
              }
            }
            else if (eventArg.StartsWith("Tab|"))
            {
              int result;
              if (!int.TryParse(eventArg.Remove(0, 4), out result))
                break;
              MainForm.Global.ARXCurrentTab = result;
              switch (result)
              {
                case 0:
                case 2:
                case 3:
                  MainForm.Global.ARXOnScreen = 1;
                  return;
                case 1:
                  MainForm.Global.ARXOnScreen = 2;
                  return;
                default:
                  return;
              }
            }
            else
            {
              if (eventArg.StartsWith("|checkBox_"))
              {
                this.BeginInvoke((Action) (() =>
                {
                  CheckBox checkBox = ((IEnumerable<Control>) this.groupBox_SettingsGeneral.Controls.Find(eventArg.Substring(1), false)).FirstOrDefault<Control>() as CheckBox;
                  if (checkBox == null)
                    return;
                  if (checkBox.Checked)
                    checkBox.Checked = false;
                  else
                    checkBox.Checked = true;
                }));
                break;
              }
              if (eventArg.StartsWith("numericUpDown_"))
              {
                try
                {
                  string[] output = eventArg.Split("|".ToCharArray(), 2, StringSplitOptions.None);
                  Decimal value;
                  if (!Decimal.TryParse(output[1], out value))
                    break;
                  this.BeginInvoke((Action) (() =>
                  {
                    NumericUpDown numericUpDown = ((IEnumerable<Control>) this.groupBox_SettingsSpectrogram.Controls.Find(output[0], false)).FirstOrDefault<Control>() as NumericUpDown;
                    if (numericUpDown == null)
                      return;
                    MainForm.Global.sendToARX = false;
                    numericUpDown.Value = !(numericUpDown.Minimum > value) ? (!(numericUpDown.Maximum < value) ? value : numericUpDown.Maximum) : numericUpDown.Minimum;
                    MainForm.Global.sendToARX = true;
                  }));
                  break;
                }
                catch
                {
                  break;
                }
              }
              else
              {
                if (eventArg.StartsWith("SetAmplitudeScale|"))
                {
                  int newSelectedIndex;
                  if (!int.TryParse(eventArg.Remove(0, 18), out newSelectedIndex))
                    break;
                  this.BeginInvoke((Action) (() =>
                  {
                    try
                    {
                      this.comboBox_AmplitudeScale.SelectedIndex = newSelectedIndex;
                    }
                    catch
                    {
                    }
                  }));
                  break;
                }
                if (!eventArg.StartsWith("SetKeyboardLayout|"))
                  break;
                int newSelectedIndex1;
                if (!int.TryParse(eventArg.Remove(0, 18), out newSelectedIndex1))
                  break;
                this.BeginInvoke((Action) (() =>
                {
                  try
                  {
                    this.comboBox_KeyboardLayout.SelectedIndex = newSelectedIndex1;
                  }
                  catch
                  {
                  }
                }));
                break;
              }
            }
          }
        case 8:
          LogitechArx.LogiArxAddFileAs("ARX\\jquery.mobile.css", "jquery.mobile.css", "");
          LogitechArx.LogiArxAddFileAs("ARX\\spectrum.css", "spectrum.css", "");
          LogitechArx.LogiArxAddFileAs("ARX\\main.css", "main.css", "");
          LogitechArx.LogiArxAddFileAs("ARX\\jquery.js", "jquery.js", "");
          LogitechArx.LogiArxAddFileAs("ARX\\jquery.mobile.js", "jquery.mobile.js", "");
          LogitechArx.LogiArxAddFileAs("ARX\\spectrum.js", "spectrum.js", "");
          LogitechArx.LogiArxAddFileAs("ARX\\main.js", "main.js", "");
          LogitechArx.LogiArxAddFileAs("ARX\\index.html", "index.html", "");
          LogitechArx.LogiArxSetIndex("index.html");
          break;
        case 16:
          this.flashStatusBarMessage("ARX: Device Disconnected", 3000);
          break;
      }
    }

    private void ARXErrorResponse(int errorCode)
    {
      switch (errorCode)
      {
        case 1:
          this.flashStatusBarMessage("ARX Error: Wrong parameter format", 5000);
          break;
        case 2:
          this.flashStatusBarMessage("ARX Error: Null parameter not supported", 5000);
          break;
        case 3:
          this.flashStatusBarMessage("ARX Error: Wrong file path", 5000);
          break;
        case 4:
          this.flashStatusBarMessage("ARX Error: SDK not initialized", 5000);
          break;
        case 5:
          this.flashStatusBarMessage("ARX Error: SDK already initialized", 5000);
          break;
        case 6:
          if (MainForm.Global.ARXRunning)
          {
            LogitechArx.LogiArxShutdown();
            MainForm.Global.ARXRunning = false;
          }
          this.toolStripStatusLabel1.Text = "ARX Error: Connection with Logitech Gaming Software is broken";
          break;
        case 7:
          this.flashStatusBarMessage("ARX Error: Error creating thread", 5000);
          break;
        case 8:
          this.flashStatusBarMessage("ARX Error: Error copying memory", 5000);
          break;
      }
    }

    private void sendToARX(string item, string value)
    {
      if (!MainForm.Global.ARXRunning || !MainForm.Global.ARXActive)
        return;
      if (item == "KL_FGColor")
      {
        if (MainForm.Global.ARXCurrentTab >= 2 || this.comboBox_KL_ColorMode.SelectedIndex != 0)
          return;
        LogitechArx.LogiArxSetTagContentById("jQueryColor", "setColorPicker('#KL_FGColor', '" + value + "');");
      }
      else if (item == "KL_BGColor")
        this.jQuerySet("setColorPicker('#KL_BGColor', '" + value + "');");
      else if (item == "cycleColors")
      {
        if (value == "start")
        {
          this.jQuerySet("$('#KL_FGColor').spectrum('disable'); $('#KL_cycle_colors').unbind('change').val('on').flipswitch('refresh').bind('change', function() {cycleColorsChange('#KL_cycle_colors'); ACBridge.click('KL_CC|');});");
        }
        else
        {
          LogitechArx.LogiArxSetTagContentById("jQueryColor", "");
          this.jQuerySet("$('#KL_FGColor').spectrum('enable'); $('#KL_cycle_colors').unbind('change').val('off').flipswitch('refresh').bind('change', function() {cycleColorsChange('#KL_cycle_colors'); ACBridge.click('KL_CC|');});");
        }
      }
      else if (item == "cycleColorsDelay")
        LogitechArx.LogiArxSetTagPropertyById("KL_CC_Delay", nameof (value), value);
      else if (item == "runSpectro")
      {
        if (value == "start")
        {
          LogitechArx.LogiArxSetTagContentById("RunSpectro", "Stop");
          LogitechArx.LogiArxSetTagContentById("InputDevices", "");
          LogitechArx.LogiArxSetTagContentById("comboBox_KeyboardLayout", "");
        }
        else
        {
          LogitechArx.LogiArxSetTagContentById("RunSpectro", "Start");
          this.populateARXcomboBox("InputDevices", (object) this.comboBox_InputDevice);
          this.populateARXcomboBox("comboBox_KeyboardLayout", (object) this.comboBox_KeyboardLayout);
        }
      }
      else if (item == "inputDevices")
        this.populateARXcomboBox("InputDevices", (object) this.comboBox_InputDevice);
      else if (item == "changeColorMode")
      {
        if (value == "0")
          this.jQuerySet("$('#KL_nav_SolidColor').trigger('click');");
        else if (value == "1")
        {
          this.jQuerySet("$('#KL_nav_VGradient').trigger('click');");
        }
        else
        {
          if (!(value == "2"))
            return;
          this.jQuerySet("$('#KL_nav_HGradient').trigger('click');");
        }
      }
      else if (item == "VGradientColors")
      {
        string command = "";
        for (int index = 0; index < MainForm.Global.gradientColor.Length; ++index)
        {
          string[] strArray = new string[10];
          strArray[0] = command;
          strArray[1] = "setColorPicker('#KL_VGradient_P";
          strArray[2] = index.ToString();
          strArray[3] = "', '";
          byte num = MainForm.Global.gradientColor[index].R;
          strArray[4] = num.ToString();
          strArray[5] = ",";
          num = MainForm.Global.gradientColor[index].G;
          strArray[6] = num.ToString();
          strArray[7] = ",";
          num = MainForm.Global.gradientColor[index].B;
          strArray[8] = num.ToString();
          strArray[9] = "');";
          command = string.Concat(strArray);
        }
        this.jQuerySet(command);
      }
      else if (item == "gradientProfiles")
        this.populateARXcomboBox("GradientProfile", (object) this.comboBox_VerticalProfiles);
      else if (item.StartsWith("numericUpDown_"))
        LogitechArx.LogiArxSetTagPropertyById(item, nameof (value), value);
      else if (item == "comboBox_AmplitudeScale")
        this.populateARXcomboBox(item, (object) this.comboBox_AmplitudeScale);
      else if (item == "comboBox_KeyboardLayout")
        this.populateARXcomboBox(item, (object) this.comboBox_KeyboardLayout);
      else if (item.StartsWith("checkBox_"))
      {
        this.jQuerySet("$('#" + item + "').prop('checked', " + value.ToLower() + ").checkboxradio('refresh');");
      }
      else
      {
        if (!(item == "HGradientColors"))
          return;
        string command = "";
        for (int index = 0; index < MainForm.Global.hGradientColor.Length; ++index)
          command = command + "hGradientColor[" + (object) index + "] = 'rgb(" + (object) MainForm.Global.hGradientColor[index].R + "," + (object) MainForm.Global.hGradientColor[index].G + "," + (object) MainForm.Global.hGradientColor[index].B + ")';";
        this.jQuerySet(command);
      }
    }

    private void clearARXjQuery()
    {
      if (!MainForm.Global.ARXRunning)
        return;
      LogitechArx.LogiArxSetTagContentById("jQueryColor", "");
      LogitechArx.LogiArxSetTagContentById("jQuerySet", "");
    }

    private void jQuerySet(string command)
    {
      if (!MainForm._timer_jQuerySet.Enabled)
      {
        LogitechArx.LogiArxSetTagContentById(nameof (jQuerySet), command);
        MainForm.Global.jQuerySetQueuedCommands = "";
        MainForm._timer_jQuerySet = new System.Timers.Timer(100.0);
        MainForm._timer_jQuerySet.Elapsed += new ElapsedEventHandler(this._timer_jQuerySet_Elapsed);
        MainForm._timer_jQuerySet.Enabled = true;
      }
      else
      {
        if (!(MainForm.Global.jQuerySetQueuedCommands != command))
          return;
        MainForm.Global.jQuerySetQueuedCommands += command;
        MainForm.Global.jQuerySetQueue = true;
      }
    }

    private void _timer_jQuerySet_Elapsed(object sender, ElapsedEventArgs e)
    {
      MainForm._timer_jQuerySet.Enabled = false;
      if (MainForm.Global.jQuerySetQueue)
      {
        MainForm.Global.jQuerySetQueue = false;
        this.jQuerySet(MainForm.Global.jQuerySetQueuedCommands);
      }
      else
      {
        Thread.Sleep(500);
        LogitechArx.LogiArxSetTagContentById("jQuerySet", "");
      }
    }

    private void populateARXcomboBox(string HTMLid, object _comboBox)
    {
      ComboBox comboBox = (ComboBox) _comboBox;
      string newContent = "";
      int num = 0;
      if (comboBox.SelectedIndex > -1)
        num = comboBox.SelectedIndex;
      for (int index = 0; index < comboBox.Items.Count; ++index)
      {
        if (index == num)
          newContent = newContent + "<option selected='selected' value='" + index.ToString() + "'>" + comboBox.GetItemText(comboBox.Items[index]) + "</option>";
        else
          newContent = newContent + "<option value='" + index.ToString() + "'>" + comboBox.GetItemText(comboBox.Items[index]) + "</option>";
      }
      LogitechArx.LogiArxSetTagContentById(HTMLid, newContent);
      this.jQuerySet("$('#" + HTMLid + "').val('" + num.ToString() + "').selectmenu('refresh');");
    }

    private void updateARXGradientColors()
    {
      this.sendToARX("VGradientColors", (string) null);
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.components = (IContainer) new Container();
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (MainForm));
      this.button_StartSpectro = new Button();
      this.backgroundWorker_Main = new BackgroundWorker();
      this.trackBar_red = new TrackBar();
      this.trackBar_blue = new TrackBar();
      this.trackBar_green = new TrackBar();
      this.backgroundWorker_Cycle = new BackgroundWorker();
      this.checkBox_Cycle = new CheckBox();
      this.tabControl_Main = new TabControl();
      this.tabPage1 = new TabPage();
      this.comboBox_KL_ColorMode = new ComboBox();
      this.label_KL_ColorMode = new Label();
      this.panel_KL_HorizontalGradient = new Panel();
      this.groupBox_HColorWave = new GroupBox();
      this.label_HColorWaveSpacing = new Label();
      this.comboBox_HColorWaveSpacing = new ComboBox();
      this.label_HColorWaveDirection = new Label();
      this.comboBox_HColorWaveDirection = new ComboBox();
      this.label_HColorWaveDelay = new Label();
      this.numericUpDown_HColorWaveDelay = new NumericUpDown();
      this.checkBox_HColorWaveEnable = new CheckBox();
      this.panel_KL_SolidColor = new Panel();
      this.groupBox_FGColor = new GroupBox();
      this.button_Foreground = new Button();
      this.label_Blue = new Label();
      this.label_Green = new Label();
      this.label_Red = new Label();
      this.label_CycleDelay = new Label();
      this.numericUpDown_CycleDelay = new NumericUpDown();
      this.numericUpDown_blue = new NumericUpDown();
      this.numericUpDown_red = new NumericUpDown();
      this.numericUpDown_green = new NumericUpDown();
      this.groupBox_BGColor = new GroupBox();
      this.label_BGBlue = new Label();
      this.numericUpDown_BGBlue = new NumericUpDown();
      this.label_BGGreen = new Label();
      this.button_Background = new Button();
      this.label_BGRed = new Label();
      this.numericUpDown_BGRed = new NumericUpDown();
      this.numericUpDown_BGGreen = new NumericUpDown();
      this.panel_KL_VerticalGradient = new Panel();
      this.groupBox_VColorWave = new GroupBox();
      this.label_VColorWaveSpacing = new Label();
      this.comboBox_VColorWaveSpacing = new ComboBox();
      this.label_VColorWaveDirection = new Label();
      this.comboBox_VColorWaveDirection = new ComboBox();
      this.label_VColorWaveDelay = new Label();
      this.numericUpDown_VColorWaveDelay = new NumericUpDown();
      this.checkBox_VColorWaveEnable = new CheckBox();
      this.groupBox_TransformVGradient = new GroupBox();
      this.button_GenerateVGradient = new Button();
      this.button_FlipVGradient = new Button();
      this.groupBox_VProfiles = new GroupBox();
      this.comboBox_VerticalProfiles = new ComboBox();
      this.button_RenameVProfile = new Button();
      this.button_LoadVProfile = new Button();
      this.button_SaveVProfile = new Button();
      this.tabPage2 = new TabPage();
      this.groupBox_OS_Colors = new GroupBox();
      this.label_OS_BG = new Label();
      this.label_OS_FG = new Label();
      this.button_OS_BG = new Button();
      this.button_OS_FG = new Button();
      this.groupBox_OS_Settings = new GroupBox();
      this.numericUpDown_OS_Scale = new NumericUpDown();
      this.label_OS_Scale = new Label();
      this.checkBox_UseKeyboardColors = new CheckBox();
      this.checkBox_HighQualityGraphics = new CheckBox();
      this.checkBox_AutoConsole = new CheckBox();
      this.groupBox_OS_Manual = new GroupBox();
      this.button_OpenConsole = new Button();
      this.tabPage3 = new TabPage();
      this.groupBox_SettingsFile = new GroupBox();
      this.button_ImportSettingsVersion = new Button();
      this.button_RestoreSettings = new Button();
      this.button_ExportSettings = new Button();
      this.button_ImportSettings = new Button();
      this.groupBox_SettingsGeneral = new GroupBox();
      this.checkBox_MediaKeys = new CheckBox();
      this.button_UpdateCheck = new Button();
      this.checkBox_UpdateCheck = new CheckBox();
      this.label_KeyboardLayout = new Label();
      this.comboBox_KeyboardLayout = new ComboBox();
      this.checkBox_AutoDefaultDevice = new CheckBox();
      this.checkBox_DisableGLights = new CheckBox();
      this.checkBox_MinimiseStartup = new CheckBox();
      this.checkBox_DeviceLighting = new CheckBox();
      this.checkBox_AutoStartup = new CheckBox();
      this.checkBox_ARXApp = new CheckBox();
      this.groupBox_SettingsSpectrogram = new GroupBox();
      this.label_SpectroScale = new Label();
      this.numericUpDown_SpectroScale = new NumericUpDown();
      this.numericUpDown_FrequencyBoost = new NumericUpDown();
      this.label_FrequencyBoost = new Label();
      this.label_AmplitudeScale = new Label();
      this.comboBox_AmplitudeScale = new ComboBox();
      this.label_AmplitudeOffset = new Label();
      this.numericUpDown_AmplitudeOffset = new NumericUpDown();
      this.label_RefreshDelay = new Label();
      this.numericUpDown_RefreshDelay = new NumericUpDown();
      this.tabPage4 = new TabPage();
      this.pictureBox_Logo = new PictureBox();
      this.linkLabel_A_Logitech = new LinkLabel();
      this.groupBox_A_Thanks = new GroupBox();
      this.label_A_Thanks = new Label();
      this.label_A_SDKVersion = new Label();
      this.label_A_ProgramVersion = new Label();
      this.label_A_ProgramAuthor = new Label();
      this.label_A_ProgramName = new Label();
      this.statusStrip_Main = new StatusStrip();
      this.toolStripStatusLabel1 = new ToolStripStatusLabel();
      this.comboBox_InputDevice = new ComboBox();
      this.colorDialog_Main = new ColorDialog();
      this.label_InputDevice = new Label();
      this.button_RefreshInputDevice = new Button();
      this.notifyIcon_Main = new NotifyIcon(this.components);
      this.label1 = new Label();
      this.trackBar_red.BeginInit();
      this.trackBar_blue.BeginInit();
      this.trackBar_green.BeginInit();
      this.tabControl_Main.SuspendLayout();
      this.tabPage1.SuspendLayout();
      this.panel_KL_HorizontalGradient.SuspendLayout();
      this.groupBox_HColorWave.SuspendLayout();
      this.numericUpDown_HColorWaveDelay.BeginInit();
      this.panel_KL_SolidColor.SuspendLayout();
      this.groupBox_FGColor.SuspendLayout();
      this.numericUpDown_CycleDelay.BeginInit();
      this.numericUpDown_blue.BeginInit();
      this.numericUpDown_red.BeginInit();
      this.numericUpDown_green.BeginInit();
      this.groupBox_BGColor.SuspendLayout();
      this.numericUpDown_BGBlue.BeginInit();
      this.numericUpDown_BGRed.BeginInit();
      this.numericUpDown_BGGreen.BeginInit();
      this.panel_KL_VerticalGradient.SuspendLayout();
      this.groupBox_VColorWave.SuspendLayout();
      this.numericUpDown_VColorWaveDelay.BeginInit();
      this.groupBox_TransformVGradient.SuspendLayout();
      this.groupBox_VProfiles.SuspendLayout();
      this.tabPage2.SuspendLayout();
      this.groupBox_OS_Colors.SuspendLayout();
      this.groupBox_OS_Settings.SuspendLayout();
      this.numericUpDown_OS_Scale.BeginInit();
      this.groupBox_OS_Manual.SuspendLayout();
      this.tabPage3.SuspendLayout();
      this.groupBox_SettingsFile.SuspendLayout();
      this.groupBox_SettingsGeneral.SuspendLayout();
      this.groupBox_SettingsSpectrogram.SuspendLayout();
      this.numericUpDown_SpectroScale.BeginInit();
      this.numericUpDown_FrequencyBoost.BeginInit();
      this.numericUpDown_AmplitudeOffset.BeginInit();
      this.numericUpDown_RefreshDelay.BeginInit();
      this.tabPage4.SuspendLayout();
      ((ISupportInitialize) this.pictureBox_Logo).BeginInit();
      this.groupBox_A_Thanks.SuspendLayout();
      this.statusStrip_Main.SuspendLayout();
      this.SuspendLayout();
      this.button_StartSpectro.Location = new Point(5, 12);
      this.button_StartSpectro.Margin = new Padding(0, 3, 3, 3);
      this.button_StartSpectro.Name = "button_StartSpectro";
      this.button_StartSpectro.Size = new Size(116, 23);
      this.button_StartSpectro.TabIndex = 0;
      this.button_StartSpectro.Text = "Start Spectrogram";
      this.button_StartSpectro.UseVisualStyleBackColor = true;
      this.button_StartSpectro.Click += new EventHandler(this.button_StartSpectro_Click);
      this.trackBar_red.BackColor = SystemColors.ControlLightLight;
      this.trackBar_red.Location = new Point(46, 23);
      this.trackBar_red.Maximum = (int) byte.MaxValue;
      this.trackBar_red.Name = "trackBar_red";
      this.trackBar_red.Size = new Size(211, 45);
      this.trackBar_red.TabIndex = 1;
      this.trackBar_red.TickFrequency = 5;
      this.trackBar_red.Value = (int) byte.MaxValue;
      this.trackBar_red.ValueChanged += new EventHandler(this.trackBar_red_ValueChanged);
      this.trackBar_blue.BackColor = SystemColors.ControlLightLight;
      this.trackBar_blue.Location = new Point(46, 125);
      this.trackBar_blue.Maximum = (int) byte.MaxValue;
      this.trackBar_blue.Name = "trackBar_blue";
      this.trackBar_blue.Size = new Size(211, 45);
      this.trackBar_blue.TabIndex = 2;
      this.trackBar_blue.TickFrequency = 5;
      this.trackBar_blue.ValueChanged += new EventHandler(this.trackBar_blue_ValueChanged);
      this.trackBar_green.BackColor = SystemColors.ControlLightLight;
      this.trackBar_green.Location = new Point(46, 74);
      this.trackBar_green.Maximum = (int) byte.MaxValue;
      this.trackBar_green.Name = "trackBar_green";
      this.trackBar_green.Size = new Size(211, 45);
      this.trackBar_green.TabIndex = 3;
      this.trackBar_green.TickFrequency = 5;
      this.trackBar_green.ValueChanged += new EventHandler(this.trackBar_green_ValueChanged);
      this.checkBox_Cycle.AutoSize = true;
      this.checkBox_Cycle.Location = new Point(70, 180);
      this.checkBox_Cycle.Name = "checkBox_Cycle";
      this.checkBox_Cycle.Size = new Size(84, 17);
      this.checkBox_Cycle.TabIndex = 4;
      this.checkBox_Cycle.Text = "Cycle Colors";
      this.checkBox_Cycle.UseVisualStyleBackColor = true;
      this.checkBox_Cycle.CheckedChanged += new EventHandler(this.checkBox_Cycle_CheckedChanged);
      this.tabControl_Main.Controls.Add((Control) this.tabPage1);
      this.tabControl_Main.Controls.Add((Control) this.tabPage2);
      this.tabControl_Main.Controls.Add((Control) this.tabPage3);
      this.tabControl_Main.Controls.Add((Control) this.tabPage4);
      this.tabControl_Main.Location = new Point(5, 49);
      this.tabControl_Main.Margin = new Padding(0, 3, 0, 3);
      this.tabControl_Main.Name = "tabControl_Main";
      this.tabControl_Main.SelectedIndex = 0;
      this.tabControl_Main.Size = new Size(489, 306);
      this.tabControl_Main.TabIndex = 5;
      this.tabPage1.Controls.Add((Control) this.comboBox_KL_ColorMode);
      this.tabPage1.Controls.Add((Control) this.label_KL_ColorMode);
      this.tabPage1.Controls.Add((Control) this.panel_KL_HorizontalGradient);
      this.tabPage1.Controls.Add((Control) this.panel_KL_SolidColor);
      this.tabPage1.Controls.Add((Control) this.panel_KL_VerticalGradient);
      this.tabPage1.Location = new Point(4, 22);
      this.tabPage1.Name = "tabPage1";
      this.tabPage1.Padding = new Padding(3);
      this.tabPage1.Size = new Size(481, 280);
      this.tabPage1.TabIndex = 0;
      this.tabPage1.Text = "Keyboard Lighting";
      this.tabPage1.UseVisualStyleBackColor = true;
      this.comboBox_KL_ColorMode.DropDownStyle = ComboBoxStyle.DropDownList;
      this.comboBox_KL_ColorMode.FormattingEnabled = true;
      this.comboBox_KL_ColorMode.Items.AddRange(new object[3]
      {
        (object) "Solid Color",
        (object) "Vertical Gradient",
        (object) "Horizontal Gradient"
      });
      this.comboBox_KL_ColorMode.Location = new Point(176, 11);
      this.comboBox_KL_ColorMode.Name = "comboBox_KL_ColorMode";
      this.comboBox_KL_ColorMode.Size = new Size(176, 21);
      this.comboBox_KL_ColorMode.TabIndex = 15;
      this.comboBox_KL_ColorMode.SelectedIndexChanged += new EventHandler(this.comboBox_KL_ColorMode_SelectedIndexChanged);
      this.label_KL_ColorMode.AutoSize = true;
      this.label_KL_ColorMode.Location = new Point(106, 14);
      this.label_KL_ColorMode.Name = "label_KL_ColorMode";
      this.label_KL_ColorMode.Size = new Size(64, 13);
      this.label_KL_ColorMode.TabIndex = 14;
      this.label_KL_ColorMode.Text = "Color Mode:";
      this.panel_KL_HorizontalGradient.Controls.Add((Control) this.label1);
      this.panel_KL_HorizontalGradient.Controls.Add((Control) this.groupBox_HColorWave);
      this.panel_KL_HorizontalGradient.Location = new Point(10, 40);
      this.panel_KL_HorizontalGradient.Name = "panel_KL_HorizontalGradient";
      this.panel_KL_HorizontalGradient.Size = new Size(462, 237);
      this.panel_KL_HorizontalGradient.TabIndex = 15;
      this.panel_KL_HorizontalGradient.Visible = false;
      this.groupBox_HColorWave.Controls.Add((Control) this.label_HColorWaveSpacing);
      this.groupBox_HColorWave.Controls.Add((Control) this.comboBox_HColorWaveSpacing);
      this.groupBox_HColorWave.Controls.Add((Control) this.label_HColorWaveDirection);
      this.groupBox_HColorWave.Controls.Add((Control) this.comboBox_HColorWaveDirection);
      this.groupBox_HColorWave.Controls.Add((Control) this.label_HColorWaveDelay);
      this.groupBox_HColorWave.Controls.Add((Control) this.numericUpDown_HColorWaveDelay);
      this.groupBox_HColorWave.Controls.Add((Control) this.checkBox_HColorWaveEnable);
      this.groupBox_HColorWave.Location = new Point(78, 98);
      this.groupBox_HColorWave.Name = "groupBox_HColorWave";
      this.groupBox_HColorWave.Size = new Size(301, 75);
      this.groupBox_HColorWave.TabIndex = 15;
      this.groupBox_HColorWave.TabStop = false;
      this.groupBox_HColorWave.Text = "Color Wave";
      this.label_HColorWaveSpacing.AutoSize = true;
      this.label_HColorWaveSpacing.Location = new Point(6, 47);
      this.label_HColorWaveSpacing.Name = "label_HColorWaveSpacing";
      this.label_HColorWaveSpacing.Size = new Size(49, 13);
      this.label_HColorWaveSpacing.TabIndex = 14;
      this.label_HColorWaveSpacing.Text = "Spacing:";
      this.comboBox_HColorWaveSpacing.DropDownStyle = ComboBoxStyle.DropDownList;
      this.comboBox_HColorWaveSpacing.FormattingEnabled = true;
      this.comboBox_HColorWaveSpacing.Items.AddRange(new object[3]
      {
        (object) "Small",
        (object) "Medium",
        (object) "Large"
      });
      this.comboBox_HColorWaveSpacing.Location = new Point(61, 44);
      this.comboBox_HColorWaveSpacing.Name = "comboBox_HColorWaveSpacing";
      this.comboBox_HColorWaveSpacing.Size = new Size(60, 21);
      this.comboBox_HColorWaveSpacing.TabIndex = 13;
      this.label_HColorWaveDirection.AutoSize = true;
      this.label_HColorWaveDirection.Location = new Point(138, 47);
      this.label_HColorWaveDirection.Name = "label_HColorWaveDirection";
      this.label_HColorWaveDirection.Size = new Size(52, 13);
      this.label_HColorWaveDirection.TabIndex = 12;
      this.label_HColorWaveDirection.Text = "Direction:";
      this.comboBox_HColorWaveDirection.DropDownStyle = ComboBoxStyle.DropDownList;
      this.comboBox_HColorWaveDirection.FormattingEnabled = true;
      this.comboBox_HColorWaveDirection.Items.AddRange(new object[4]
      {
        (object) "Left",
        (object) "Right",
        (object) "Center In",
        (object) "Center Out"
      });
      this.comboBox_HColorWaveDirection.Location = new Point(203, 44);
      this.comboBox_HColorWaveDirection.Name = "comboBox_HColorWaveDirection";
      this.comboBox_HColorWaveDirection.Size = new Size(89, 21);
      this.comboBox_HColorWaveDirection.TabIndex = 11;
      this.label_HColorWaveDelay.AutoSize = true;
      this.label_HColorWaveDelay.Location = new Point(138, 20);
      this.label_HColorWaveDelay.Name = "label_HColorWaveDelay";
      this.label_HColorWaveDelay.Size = new Size(59, 13);
      this.label_HColorWaveDelay.TabIndex = 10;
      this.label_HColorWaveDelay.Text = "Delay (ms):";
      this.numericUpDown_HColorWaveDelay.Location = new Point(203, 18);
      this.numericUpDown_HColorWaveDelay.Maximum = new Decimal(new int[4]
      {
        1000,
        0,
        0,
        0
      });
      this.numericUpDown_HColorWaveDelay.Minimum = new Decimal(new int[4]
      {
        1,
        0,
        0,
        0
      });
      this.numericUpDown_HColorWaveDelay.Name = "numericUpDown_HColorWaveDelay";
      this.numericUpDown_HColorWaveDelay.Size = new Size(89, 20);
      this.numericUpDown_HColorWaveDelay.TabIndex = 9;
      this.numericUpDown_HColorWaveDelay.Value = new Decimal(new int[4]
      {
        15,
        0,
        0,
        0
      });
      this.checkBox_HColorWaveEnable.AutoSize = true;
      this.checkBox_HColorWaveEnable.Location = new Point(9, 19);
      this.checkBox_HColorWaveEnable.Name = "checkBox_HColorWaveEnable";
      this.checkBox_HColorWaveEnable.Size = new Size(118, 17);
      this.checkBox_HColorWaveEnable.TabIndex = 0;
      this.checkBox_HColorWaveEnable.Text = "Enable Color Wave";
      this.checkBox_HColorWaveEnable.UseVisualStyleBackColor = true;
      this.panel_KL_SolidColor.Controls.Add((Control) this.groupBox_FGColor);
      this.panel_KL_SolidColor.Controls.Add((Control) this.groupBox_BGColor);
      this.panel_KL_SolidColor.Location = new Point(9, 40);
      this.panel_KL_SolidColor.Name = "panel_KL_SolidColor";
      this.panel_KL_SolidColor.Size = new Size(462, 237);
      this.panel_KL_SolidColor.TabIndex = 13;
      this.panel_KL_SolidColor.Visible = false;
      this.groupBox_FGColor.Controls.Add((Control) this.button_Foreground);
      this.groupBox_FGColor.Controls.Add((Control) this.label_Blue);
      this.groupBox_FGColor.Controls.Add((Control) this.label_Green);
      this.groupBox_FGColor.Controls.Add((Control) this.label_Red);
      this.groupBox_FGColor.Controls.Add((Control) this.trackBar_red);
      this.groupBox_FGColor.Controls.Add((Control) this.trackBar_green);
      this.groupBox_FGColor.Controls.Add((Control) this.label_CycleDelay);
      this.groupBox_FGColor.Controls.Add((Control) this.trackBar_blue);
      this.groupBox_FGColor.Controls.Add((Control) this.numericUpDown_CycleDelay);
      this.groupBox_FGColor.Controls.Add((Control) this.checkBox_Cycle);
      this.groupBox_FGColor.Controls.Add((Control) this.numericUpDown_blue);
      this.groupBox_FGColor.Controls.Add((Control) this.numericUpDown_red);
      this.groupBox_FGColor.Controls.Add((Control) this.numericUpDown_green);
      this.groupBox_FGColor.Location = new Point(8, 7);
      this.groupBox_FGColor.Name = "groupBox_FGColor";
      this.groupBox_FGColor.Size = new Size(329, 216);
      this.groupBox_FGColor.TabIndex = 11;
      this.groupBox_FGColor.TabStop = false;
      this.groupBox_FGColor.Text = "Foreground Color";
      this.button_Foreground.Location = new Point(9, 167);
      this.button_Foreground.Name = "button_Foreground";
      this.button_Foreground.Size = new Size(40, 40);
      this.button_Foreground.TabIndex = 12;
      this.button_Foreground.UseVisualStyleBackColor = true;
      this.button_Foreground.Click += new EventHandler(this.button_Foreground_Click);
      this.label_Blue.AutoSize = true;
      this.label_Blue.Location = new Point(6, 129);
      this.label_Blue.Name = "label_Blue";
      this.label_Blue.Size = new Size(31, 13);
      this.label_Blue.TabIndex = 14;
      this.label_Blue.Text = "Blue:";
      this.label_Green.AutoSize = true;
      this.label_Green.Location = new Point(6, 78);
      this.label_Green.Name = "label_Green";
      this.label_Green.Size = new Size(39, 13);
      this.label_Green.TabIndex = 13;
      this.label_Green.Text = "Green:";
      this.label_Red.AutoSize = true;
      this.label_Red.Location = new Point(6, 27);
      this.label_Red.Name = "label_Red";
      this.label_Red.Size = new Size(30, 13);
      this.label_Red.TabIndex = 12;
      this.label_Red.Text = "Red:";
      this.label_CycleDelay.AutoSize = true;
      this.label_CycleDelay.Location = new Point(169, 181);
      this.label_CycleDelay.Name = "label_CycleDelay";
      this.label_CycleDelay.Size = new Size(88, 13);
      this.label_CycleDelay.TabIndex = 9;
      this.label_CycleDelay.Text = "Cycle Delay (ms):";
      this.numericUpDown_CycleDelay.Location = new Point(263, 179);
      this.numericUpDown_CycleDelay.Maximum = new Decimal(new int[4]
      {
        1000,
        0,
        0,
        0
      });
      this.numericUpDown_CycleDelay.Minimum = new Decimal(new int[4]
      {
        1,
        0,
        0,
        0
      });
      this.numericUpDown_CycleDelay.Name = "numericUpDown_CycleDelay";
      this.numericUpDown_CycleDelay.Size = new Size(55, 20);
      this.numericUpDown_CycleDelay.TabIndex = 8;
      this.numericUpDown_CycleDelay.Value = new Decimal(new int[4]
      {
        20,
        0,
        0,
        0
      });
      this.numericUpDown_CycleDelay.ValueChanged += new EventHandler(this.numericUpDown_CycleDelay_ValueChanged);
      this.numericUpDown_blue.Location = new Point(262, (int) sbyte.MaxValue);
      this.numericUpDown_blue.Maximum = new Decimal(new int[4]
      {
        (int) byte.MaxValue,
        0,
        0,
        0
      });
      this.numericUpDown_blue.Name = "numericUpDown_blue";
      this.numericUpDown_blue.Size = new Size(55, 20);
      this.numericUpDown_blue.TabIndex = 7;
      this.numericUpDown_blue.ValueChanged += new EventHandler(this.numericUpDown_blue_ValueChanged);
      this.numericUpDown_red.Location = new Point(263, 25);
      this.numericUpDown_red.Maximum = new Decimal(new int[4]
      {
        (int) byte.MaxValue,
        0,
        0,
        0
      });
      this.numericUpDown_red.Name = "numericUpDown_red";
      this.numericUpDown_red.Size = new Size(55, 20);
      this.numericUpDown_red.TabIndex = 5;
      this.numericUpDown_red.Value = new Decimal(new int[4]
      {
        (int) byte.MaxValue,
        0,
        0,
        0
      });
      this.numericUpDown_red.ValueChanged += new EventHandler(this.numericUpDown_red_ValueChanged);
      this.numericUpDown_green.Location = new Point(263, 76);
      this.numericUpDown_green.Maximum = new Decimal(new int[4]
      {
        (int) byte.MaxValue,
        0,
        0,
        0
      });
      this.numericUpDown_green.Name = "numericUpDown_green";
      this.numericUpDown_green.Size = new Size(55, 20);
      this.numericUpDown_green.TabIndex = 6;
      this.numericUpDown_green.ValueChanged += new EventHandler(this.numericUpDown_green_ValueChanged);
      this.groupBox_BGColor.Controls.Add((Control) this.label_BGBlue);
      this.groupBox_BGColor.Controls.Add((Control) this.numericUpDown_BGBlue);
      this.groupBox_BGColor.Controls.Add((Control) this.label_BGGreen);
      this.groupBox_BGColor.Controls.Add((Control) this.button_Background);
      this.groupBox_BGColor.Controls.Add((Control) this.label_BGRed);
      this.groupBox_BGColor.Controls.Add((Control) this.numericUpDown_BGRed);
      this.groupBox_BGColor.Controls.Add((Control) this.numericUpDown_BGGreen);
      this.groupBox_BGColor.Location = new Point(343, 7);
      this.groupBox_BGColor.Name = "groupBox_BGColor";
      this.groupBox_BGColor.Size = new Size(110, 216);
      this.groupBox_BGColor.TabIndex = 12;
      this.groupBox_BGColor.TabStop = false;
      this.groupBox_BGColor.Text = "Background Color";
      this.label_BGBlue.AutoSize = true;
      this.label_BGBlue.Location = new Point(6, 131);
      this.label_BGBlue.Name = "label_BGBlue";
      this.label_BGBlue.Size = new Size(31, 13);
      this.label_BGBlue.TabIndex = 17;
      this.label_BGBlue.Text = "Blue:";
      this.numericUpDown_BGBlue.Location = new Point(46, (int) sbyte.MaxValue);
      this.numericUpDown_BGBlue.Maximum = new Decimal(new int[4]
      {
        (int) byte.MaxValue,
        0,
        0,
        0
      });
      this.numericUpDown_BGBlue.Name = "numericUpDown_BGBlue";
      this.numericUpDown_BGBlue.Size = new Size(55, 20);
      this.numericUpDown_BGBlue.TabIndex = 10;
      this.numericUpDown_BGBlue.ValueChanged += new EventHandler(this.numericUpDown_BG_ValueChanged);
      this.label_BGGreen.AutoSize = true;
      this.label_BGGreen.Location = new Point(6, 80);
      this.label_BGGreen.Name = "label_BGGreen";
      this.label_BGGreen.Size = new Size(39, 13);
      this.label_BGGreen.TabIndex = 16;
      this.label_BGGreen.Text = "Green:";
      this.button_Background.Location = new Point(34, 167);
      this.button_Background.Name = "button_Background";
      this.button_Background.Size = new Size(40, 40);
      this.button_Background.TabIndex = 13;
      this.button_Background.UseVisualStyleBackColor = true;
      this.button_Background.Click += new EventHandler(this.button_Background_Click);
      this.label_BGRed.AutoSize = true;
      this.label_BGRed.Location = new Point(6, 29);
      this.label_BGRed.Name = "label_BGRed";
      this.label_BGRed.Size = new Size(30, 13);
      this.label_BGRed.TabIndex = 15;
      this.label_BGRed.Text = "Red:";
      this.numericUpDown_BGRed.Location = new Point(46, 27);
      this.numericUpDown_BGRed.Maximum = new Decimal(new int[4]
      {
        (int) byte.MaxValue,
        0,
        0,
        0
      });
      this.numericUpDown_BGRed.Name = "numericUpDown_BGRed";
      this.numericUpDown_BGRed.Size = new Size(55, 20);
      this.numericUpDown_BGRed.TabIndex = 8;
      this.numericUpDown_BGRed.ValueChanged += new EventHandler(this.numericUpDown_BG_ValueChanged);
      this.numericUpDown_BGGreen.Location = new Point(46, 78);
      this.numericUpDown_BGGreen.Maximum = new Decimal(new int[4]
      {
        (int) byte.MaxValue,
        0,
        0,
        0
      });
      this.numericUpDown_BGGreen.Name = "numericUpDown_BGGreen";
      this.numericUpDown_BGGreen.Size = new Size(55, 20);
      this.numericUpDown_BGGreen.TabIndex = 9;
      this.numericUpDown_BGGreen.ValueChanged += new EventHandler(this.numericUpDown_BG_ValueChanged);
      this.panel_KL_VerticalGradient.Controls.Add((Control) this.groupBox_VColorWave);
      this.panel_KL_VerticalGradient.Controls.Add((Control) this.groupBox_TransformVGradient);
      this.panel_KL_VerticalGradient.Controls.Add((Control) this.groupBox_VProfiles);
      this.panel_KL_VerticalGradient.Location = new Point(10, 40);
      this.panel_KL_VerticalGradient.Name = "panel_KL_VerticalGradient";
      this.panel_KL_VerticalGradient.Size = new Size(462, 237);
      this.panel_KL_VerticalGradient.TabIndex = 16;
      this.panel_KL_VerticalGradient.Visible = false;
      this.groupBox_VColorWave.Controls.Add((Control) this.label_VColorWaveSpacing);
      this.groupBox_VColorWave.Controls.Add((Control) this.comboBox_VColorWaveSpacing);
      this.groupBox_VColorWave.Controls.Add((Control) this.label_VColorWaveDirection);
      this.groupBox_VColorWave.Controls.Add((Control) this.comboBox_VColorWaveDirection);
      this.groupBox_VColorWave.Controls.Add((Control) this.label_VColorWaveDelay);
      this.groupBox_VColorWave.Controls.Add((Control) this.numericUpDown_VColorWaveDelay);
      this.groupBox_VColorWave.Controls.Add((Control) this.checkBox_VColorWaveEnable);
      this.groupBox_VColorWave.Location = new Point(7, 155);
      this.groupBox_VColorWave.Name = "groupBox_VColorWave";
      this.groupBox_VColorWave.Size = new Size(265, 75);
      this.groupBox_VColorWave.TabIndex = 14;
      this.groupBox_VColorWave.TabStop = false;
      this.groupBox_VColorWave.Text = "Color Wave";
      this.label_VColorWaveSpacing.AutoSize = true;
      this.label_VColorWaveSpacing.Location = new Point(6, 47);
      this.label_VColorWaveSpacing.Name = "label_VColorWaveSpacing";
      this.label_VColorWaveSpacing.Size = new Size(49, 13);
      this.label_VColorWaveSpacing.TabIndex = 14;
      this.label_VColorWaveSpacing.Text = "Spacing:";
      this.comboBox_VColorWaveSpacing.DropDownStyle = ComboBoxStyle.DropDownList;
      this.comboBox_VColorWaveSpacing.FormattingEnabled = true;
      this.comboBox_VColorWaveSpacing.Items.AddRange(new object[3]
      {
        (object) "Small",
        (object) "Medium",
        (object) "Large"
      });
      this.comboBox_VColorWaveSpacing.Location = new Point(61, 44);
      this.comboBox_VColorWaveSpacing.Name = "comboBox_VColorWaveSpacing";
      this.comboBox_VColorWaveSpacing.Size = new Size(60, 21);
      this.comboBox_VColorWaveSpacing.TabIndex = 13;
      this.label_VColorWaveDirection.AutoSize = true;
      this.label_VColorWaveDirection.Location = new Point(138, 47);
      this.label_VColorWaveDirection.Name = "label_VColorWaveDirection";
      this.label_VColorWaveDirection.Size = new Size(52, 13);
      this.label_VColorWaveDirection.TabIndex = 12;
      this.label_VColorWaveDirection.Text = "Direction:";
      this.comboBox_VColorWaveDirection.DropDownStyle = ComboBoxStyle.DropDownList;
      this.comboBox_VColorWaveDirection.FormattingEnabled = true;
      this.comboBox_VColorWaveDirection.Items.AddRange(new object[2]
      {
        (object) "Up",
        (object) "Down"
      });
      this.comboBox_VColorWaveDirection.Location = new Point(203, 44);
      this.comboBox_VColorWaveDirection.Name = "comboBox_VColorWaveDirection";
      this.comboBox_VColorWaveDirection.Size = new Size(54, 21);
      this.comboBox_VColorWaveDirection.TabIndex = 11;
      this.label_VColorWaveDelay.AutoSize = true;
      this.label_VColorWaveDelay.Location = new Point(138, 20);
      this.label_VColorWaveDelay.Name = "label_VColorWaveDelay";
      this.label_VColorWaveDelay.Size = new Size(59, 13);
      this.label_VColorWaveDelay.TabIndex = 10;
      this.label_VColorWaveDelay.Text = "Delay (ms):";
      this.numericUpDown_VColorWaveDelay.Location = new Point(203, 18);
      this.numericUpDown_VColorWaveDelay.Maximum = new Decimal(new int[4]
      {
        1000,
        0,
        0,
        0
      });
      this.numericUpDown_VColorWaveDelay.Minimum = new Decimal(new int[4]
      {
        1,
        0,
        0,
        0
      });
      this.numericUpDown_VColorWaveDelay.Name = "numericUpDown_VColorWaveDelay";
      this.numericUpDown_VColorWaveDelay.Size = new Size(54, 20);
      this.numericUpDown_VColorWaveDelay.TabIndex = 9;
      this.numericUpDown_VColorWaveDelay.Value = new Decimal(new int[4]
      {
        15,
        0,
        0,
        0
      });
      this.checkBox_VColorWaveEnable.AutoSize = true;
      this.checkBox_VColorWaveEnable.Location = new Point(9, 19);
      this.checkBox_VColorWaveEnable.Name = "checkBox_VColorWaveEnable";
      this.checkBox_VColorWaveEnable.Size = new Size(118, 17);
      this.checkBox_VColorWaveEnable.TabIndex = 0;
      this.checkBox_VColorWaveEnable.Text = "Enable Color Wave";
      this.checkBox_VColorWaveEnable.UseVisualStyleBackColor = true;
      this.groupBox_TransformVGradient.Controls.Add((Control) this.button_GenerateVGradient);
      this.groupBox_TransformVGradient.Controls.Add((Control) this.button_FlipVGradient);
      this.groupBox_TransformVGradient.Location = new Point(7, 88);
      this.groupBox_TransformVGradient.Name = "groupBox_TransformVGradient";
      this.groupBox_TransformVGradient.Size = new Size(265, 61);
      this.groupBox_TransformVGradient.TabIndex = 13;
      this.groupBox_TransformVGradient.TabStop = false;
      this.groupBox_TransformVGradient.Text = "Transform Gradient";
      this.button_GenerateVGradient.Location = new Point(7, 21);
      this.button_GenerateVGradient.Name = "button_GenerateVGradient";
      this.button_GenerateVGradient.Size = new Size(122, 23);
      this.button_GenerateVGradient.TabIndex = 0;
      this.button_GenerateVGradient.Text = "Generate";
      this.button_GenerateVGradient.UseVisualStyleBackColor = true;
      this.button_GenerateVGradient.Click += new EventHandler(this.button_GenerateVGradient_Click);
      this.button_FlipVGradient.Location = new Point(139, 21);
      this.button_FlipVGradient.Name = "button_FlipVGradient";
      this.button_FlipVGradient.Size = new Size(118, 23);
      this.button_FlipVGradient.TabIndex = 10;
      this.button_FlipVGradient.Text = "Flip";
      this.button_FlipVGradient.UseVisualStyleBackColor = true;
      this.button_FlipVGradient.Click += new EventHandler(this.button_FlipVGradient_Click);
      this.groupBox_VProfiles.Controls.Add((Control) this.comboBox_VerticalProfiles);
      this.groupBox_VProfiles.Controls.Add((Control) this.button_RenameVProfile);
      this.groupBox_VProfiles.Controls.Add((Control) this.button_LoadVProfile);
      this.groupBox_VProfiles.Controls.Add((Control) this.button_SaveVProfile);
      this.groupBox_VProfiles.Location = new Point(8, 4);
      this.groupBox_VProfiles.Name = "groupBox_VProfiles";
      this.groupBox_VProfiles.Size = new Size(264, 78);
      this.groupBox_VProfiles.TabIndex = 12;
      this.groupBox_VProfiles.TabStop = false;
      this.groupBox_VProfiles.Text = "Gradient Profiles";
      this.comboBox_VerticalProfiles.DropDownStyle = ComboBoxStyle.DropDownList;
      this.comboBox_VerticalProfiles.FormattingEnabled = true;
      this.comboBox_VerticalProfiles.Location = new Point(7, 19);
      this.comboBox_VerticalProfiles.Name = "comboBox_VerticalProfiles";
      this.comboBox_VerticalProfiles.Size = new Size(250, 21);
      this.comboBox_VerticalProfiles.TabIndex = 1;
      this.button_RenameVProfile.Location = new Point(178, 46);
      this.button_RenameVProfile.Name = "button_RenameVProfile";
      this.button_RenameVProfile.Size = new Size(80, 23);
      this.button_RenameVProfile.TabIndex = 11;
      this.button_RenameVProfile.Text = "Rename";
      this.button_RenameVProfile.UseVisualStyleBackColor = true;
      this.button_RenameVProfile.Click += new EventHandler(this.button_RenameVProfile_Click);
      this.button_LoadVProfile.Location = new Point(6, 46);
      this.button_LoadVProfile.Name = "button_LoadVProfile";
      this.button_LoadVProfile.Size = new Size(80, 23);
      this.button_LoadVProfile.TabIndex = 10;
      this.button_LoadVProfile.Text = "Load";
      this.button_LoadVProfile.UseVisualStyleBackColor = true;
      this.button_LoadVProfile.Click += new EventHandler(this.button_LoadVProfile_Click);
      this.button_SaveVProfile.Location = new Point(92, 46);
      this.button_SaveVProfile.Name = "button_SaveVProfile";
      this.button_SaveVProfile.Size = new Size(80, 23);
      this.button_SaveVProfile.TabIndex = 2;
      this.button_SaveVProfile.Text = "Save";
      this.button_SaveVProfile.UseVisualStyleBackColor = true;
      this.button_SaveVProfile.Click += new EventHandler(this.button_SaveVProfile_Click);
      this.tabPage2.Controls.Add((Control) this.groupBox_OS_Colors);
      this.tabPage2.Controls.Add((Control) this.groupBox_OS_Settings);
      this.tabPage2.Controls.Add((Control) this.groupBox_OS_Manual);
      this.tabPage2.Location = new Point(4, 22);
      this.tabPage2.Name = "tabPage2";
      this.tabPage2.Padding = new Padding(3);
      this.tabPage2.Size = new Size(481, 280);
      this.tabPage2.TabIndex = 1;
      this.tabPage2.Text = "On-Screen Output";
      this.tabPage2.UseVisualStyleBackColor = true;
      this.groupBox_OS_Colors.Controls.Add((Control) this.label_OS_BG);
      this.groupBox_OS_Colors.Controls.Add((Control) this.label_OS_FG);
      this.groupBox_OS_Colors.Controls.Add((Control) this.button_OS_BG);
      this.groupBox_OS_Colors.Controls.Add((Control) this.button_OS_FG);
      this.groupBox_OS_Colors.Location = new Point(14, 197);
      this.groupBox_OS_Colors.Name = "groupBox_OS_Colors";
      this.groupBox_OS_Colors.Size = new Size(452, 77);
      this.groupBox_OS_Colors.TabIndex = 4;
      this.groupBox_OS_Colors.TabStop = false;
      this.groupBox_OS_Colors.Text = "Colors";
      this.label_OS_BG.AutoSize = true;
      this.label_OS_BG.Location = new Point(267, 35);
      this.label_OS_BG.Name = "label_OS_BG";
      this.label_OS_BG.Size = new Size(95, 13);
      this.label_OS_BG.TabIndex = 16;
      this.label_OS_BG.Text = "Background Color:";
      this.label_OS_FG.AutoSize = true;
      this.label_OS_FG.Location = new Point(42, 35);
      this.label_OS_FG.Name = "label_OS_FG";
      this.label_OS_FG.Size = new Size(91, 13);
      this.label_OS_FG.TabIndex = 15;
      this.label_OS_FG.Text = "Foreground Color:";
      this.button_OS_BG.BackColor = Color.Black;
      this.button_OS_BG.Location = new Point(368, 21);
      this.button_OS_BG.Name = "button_OS_BG";
      this.button_OS_BG.Size = new Size(40, 40);
      this.button_OS_BG.TabIndex = 14;
      this.button_OS_BG.UseVisualStyleBackColor = false;
      this.button_OS_BG.Click += new EventHandler(this.button_Gradient_Click);
      this.button_OS_FG.BackColor = Color.Red;
      this.button_OS_FG.Location = new Point(139, 21);
      this.button_OS_FG.Name = "button_OS_FG";
      this.button_OS_FG.Size = new Size(40, 40);
      this.button_OS_FG.TabIndex = 13;
      this.button_OS_FG.UseVisualStyleBackColor = false;
      this.button_OS_FG.Click += new EventHandler(this.button_Gradient_Click);
      this.groupBox_OS_Settings.Controls.Add((Control) this.numericUpDown_OS_Scale);
      this.groupBox_OS_Settings.Controls.Add((Control) this.label_OS_Scale);
      this.groupBox_OS_Settings.Controls.Add((Control) this.checkBox_UseKeyboardColors);
      this.groupBox_OS_Settings.Controls.Add((Control) this.checkBox_HighQualityGraphics);
      this.groupBox_OS_Settings.Controls.Add((Control) this.checkBox_AutoConsole);
      this.groupBox_OS_Settings.Location = new Point(14, 69);
      this.groupBox_OS_Settings.Name = "groupBox_OS_Settings";
      this.groupBox_OS_Settings.Size = new Size(452, 121);
      this.groupBox_OS_Settings.TabIndex = 3;
      this.groupBox_OS_Settings.TabStop = false;
      this.groupBox_OS_Settings.Text = "On-Screen Output Settings";
      this.numericUpDown_OS_Scale.DecimalPlaces = 3;
      this.numericUpDown_OS_Scale.Increment = new Decimal(new int[4]
      {
        1,
        0,
        0,
        65536
      });
      this.numericUpDown_OS_Scale.Location = new Point(128, 88);
      this.numericUpDown_OS_Scale.Maximum = new Decimal(new int[4]
      {
        1000,
        0,
        0,
        0
      });
      this.numericUpDown_OS_Scale.Minimum = new Decimal(new int[4]
      {
        1,
        0,
        0,
        196608
      });
      this.numericUpDown_OS_Scale.Name = "numericUpDown_OS_Scale";
      this.numericUpDown_OS_Scale.Size = new Size(85, 20);
      this.numericUpDown_OS_Scale.TabIndex = 5;
      this.numericUpDown_OS_Scale.Value = new Decimal(new int[4]
      {
        2,
        0,
        0,
        0
      });
      this.numericUpDown_OS_Scale.TextChanged += new EventHandler(this.numericUpDown_OS_Scale_TextChanged);
      this.label_OS_Scale.AutoSize = true;
      this.label_OS_Scale.Location = new Point(3, 90);
      this.label_OS_Scale.Name = "label_OS_Scale";
      this.label_OS_Scale.Size = new Size(119, 13);
      this.label_OS_Scale.TabIndex = 4;
      this.label_OS_Scale.Text = "Vertical Scale Multiplier:";
      this.checkBox_UseKeyboardColors.AutoSize = true;
      this.checkBox_UseKeyboardColors.Checked = true;
      this.checkBox_UseKeyboardColors.CheckState = CheckState.Checked;
      this.checkBox_UseKeyboardColors.Location = new Point(6, 65);
      this.checkBox_UseKeyboardColors.Name = "checkBox_UseKeyboardColors";
      this.checkBox_UseKeyboardColors.Size = new Size(164, 17);
      this.checkBox_UseKeyboardColors.TabIndex = 3;
      this.checkBox_UseKeyboardColors.Text = "Use Keyboard Lighting colors";
      this.checkBox_UseKeyboardColors.UseVisualStyleBackColor = true;
      this.checkBox_UseKeyboardColors.CheckedChanged += new EventHandler(this.checkBox_UseKeyboardColors_CheckedChanged);
      this.checkBox_HighQualityGraphics.AutoSize = true;
      this.checkBox_HighQualityGraphics.Checked = true;
      this.checkBox_HighQualityGraphics.CheckState = CheckState.Checked;
      this.checkBox_HighQualityGraphics.Location = new Point(6, 42);
      this.checkBox_HighQualityGraphics.Name = "checkBox_HighQualityGraphics";
      this.checkBox_HighQualityGraphics.Size = new Size(162, 17);
      this.checkBox_HighQualityGraphics.TabIndex = 2;
      this.checkBox_HighQualityGraphics.Text = "Enable High Quality graphics";
      this.checkBox_HighQualityGraphics.UseVisualStyleBackColor = true;
      this.checkBox_AutoConsole.AutoSize = true;
      this.checkBox_AutoConsole.Checked = true;
      this.checkBox_AutoConsole.CheckState = CheckState.Checked;
      this.checkBox_AutoConsole.Location = new Point(6, 19);
      this.checkBox_AutoConsole.Name = "checkBox_AutoConsole";
      this.checkBox_AutoConsole.Size = new Size(330, 17);
      this.checkBox_AutoConsole.TabIndex = 1;
      this.checkBox_AutoConsole.Text = "Automatically open Output Window when spectrogram is running";
      this.checkBox_AutoConsole.UseVisualStyleBackColor = true;
      this.groupBox_OS_Manual.Controls.Add((Control) this.button_OpenConsole);
      this.groupBox_OS_Manual.Location = new Point(14, 7);
      this.groupBox_OS_Manual.Name = "groupBox_OS_Manual";
      this.groupBox_OS_Manual.Size = new Size(452, 56);
      this.groupBox_OS_Manual.TabIndex = 2;
      this.groupBox_OS_Manual.TabStop = false;
      this.groupBox_OS_Manual.Text = "Manual Control";
      this.button_OpenConsole.Location = new Point(6, 19);
      this.button_OpenConsole.Name = "button_OpenConsole";
      this.button_OpenConsole.Size = new Size(170, 23);
      this.button_OpenConsole.TabIndex = 0;
      this.button_OpenConsole.Text = "Open Output Window";
      this.button_OpenConsole.UseVisualStyleBackColor = true;
      this.button_OpenConsole.Click += new EventHandler(this.button_OpenConsole_Click);
      this.tabPage3.AutoScroll = true;
      this.tabPage3.AutoScrollMinSize = new Size(0, 500);
      this.tabPage3.Controls.Add((Control) this.groupBox_SettingsFile);
      this.tabPage3.Controls.Add((Control) this.groupBox_SettingsGeneral);
      this.tabPage3.Controls.Add((Control) this.groupBox_SettingsSpectrogram);
      this.tabPage3.Location = new Point(4, 22);
      this.tabPage3.Name = "tabPage3";
      this.tabPage3.Size = new Size(481, 280);
      this.tabPage3.TabIndex = 2;
      this.tabPage3.Text = "Settings";
      this.tabPage3.UseVisualStyleBackColor = true;
      this.groupBox_SettingsFile.Controls.Add((Control) this.button_ImportSettingsVersion);
      this.groupBox_SettingsFile.Controls.Add((Control) this.button_RestoreSettings);
      this.groupBox_SettingsFile.Controls.Add((Control) this.button_ExportSettings);
      this.groupBox_SettingsFile.Controls.Add((Control) this.button_ImportSettings);
      this.groupBox_SettingsFile.Location = new Point(6, 381);
      this.groupBox_SettingsFile.Name = "groupBox_SettingsFile";
      this.groupBox_SettingsFile.Size = new Size(451, 87);
      this.groupBox_SettingsFile.TabIndex = 22;
      this.groupBox_SettingsFile.TabStop = false;
      this.groupBox_SettingsFile.Text = "Settings File";
      this.button_ImportSettingsVersion.Location = new Point(11, 19);
      this.button_ImportSettingsVersion.Name = "button_ImportSettingsVersion";
      this.button_ImportSettingsVersion.Size = new Size(203, 23);
      this.button_ImportSettingsVersion.TabIndex = 13;
      this.button_ImportSettingsVersion.Text = "Import Settings From Previous Version";
      this.button_ImportSettingsVersion.UseVisualStyleBackColor = true;
      this.button_ImportSettingsVersion.Click += new EventHandler(this.button_ImportSettingsVersion_Click);
      this.button_RestoreSettings.Location = new Point(11, 48);
      this.button_RestoreSettings.Name = "button_RestoreSettings";
      this.button_RestoreSettings.Size = new Size(203, 23);
      this.button_RestoreSettings.TabIndex = 10;
      this.button_RestoreSettings.Text = "Restore Default Settings";
      this.button_RestoreSettings.UseVisualStyleBackColor = true;
      this.button_RestoreSettings.Click += new EventHandler(this.button_RestoreSettings_Click);
      this.button_ExportSettings.Location = new Point(278, 48);
      this.button_ExportSettings.Name = "button_ExportSettings";
      this.button_ExportSettings.Size = new Size(155, 23);
      this.button_ExportSettings.TabIndex = 11;
      this.button_ExportSettings.Text = "Export Settings To File";
      this.button_ExportSettings.UseVisualStyleBackColor = true;
      this.button_ExportSettings.Click += new EventHandler(this.button_ExportSettings_Click);
      this.button_ImportSettings.Location = new Point(278, 19);
      this.button_ImportSettings.Name = "button_ImportSettings";
      this.button_ImportSettings.Size = new Size(155, 23);
      this.button_ImportSettings.TabIndex = 12;
      this.button_ImportSettings.Text = "Import Settings From File";
      this.button_ImportSettings.UseVisualStyleBackColor = true;
      this.button_ImportSettings.Click += new EventHandler(this.button_ImportSettings_Click);
      this.groupBox_SettingsGeneral.Controls.Add((Control) this.checkBox_MediaKeys);
      this.groupBox_SettingsGeneral.Controls.Add((Control) this.button_UpdateCheck);
      this.groupBox_SettingsGeneral.Controls.Add((Control) this.checkBox_UpdateCheck);
      this.groupBox_SettingsGeneral.Controls.Add((Control) this.label_KeyboardLayout);
      this.groupBox_SettingsGeneral.Controls.Add((Control) this.comboBox_KeyboardLayout);
      this.groupBox_SettingsGeneral.Controls.Add((Control) this.checkBox_AutoDefaultDevice);
      this.groupBox_SettingsGeneral.Controls.Add((Control) this.checkBox_DisableGLights);
      this.groupBox_SettingsGeneral.Controls.Add((Control) this.checkBox_MinimiseStartup);
      this.groupBox_SettingsGeneral.Controls.Add((Control) this.checkBox_DeviceLighting);
      this.groupBox_SettingsGeneral.Controls.Add((Control) this.checkBox_AutoStartup);
      this.groupBox_SettingsGeneral.Controls.Add((Control) this.checkBox_ARXApp);
      this.groupBox_SettingsGeneral.Location = new Point(6, 123);
      this.groupBox_SettingsGeneral.Name = "groupBox_SettingsGeneral";
      this.groupBox_SettingsGeneral.Size = new Size(451, 252);
      this.groupBox_SettingsGeneral.TabIndex = 21;
      this.groupBox_SettingsGeneral.TabStop = false;
      this.groupBox_SettingsGeneral.Text = "General";
      this.checkBox_MediaKeys.AutoSize = true;
      this.checkBox_MediaKeys.Checked = true;
      this.checkBox_MediaKeys.CheckState = CheckState.Checked;
      this.checkBox_MediaKeys.Location = new Point(11, 147);
      this.checkBox_MediaKeys.Name = "checkBox_MediaKeys";
      this.checkBox_MediaKeys.Size = new Size(215, 17);
      this.checkBox_MediaKeys.TabIndex = 24;
      this.checkBox_MediaKeys.Text = "Allow media keys to control spectrogram";
      this.checkBox_MediaKeys.UseVisualStyleBackColor = true;
      this.checkBox_MediaKeys.CheckedChanged += new EventHandler(this.checkBox_Settings_CheckedChanged);
      this.button_UpdateCheck.Location = new Point(278, 51);
      this.button_UpdateCheck.Name = "button_UpdateCheck";
      this.button_UpdateCheck.Size = new Size(155, 23);
      this.button_UpdateCheck.TabIndex = 23;
      this.button_UpdateCheck.Text = "Check for updates now";
      this.button_UpdateCheck.UseVisualStyleBackColor = true;
      this.button_UpdateCheck.Click += new EventHandler(this.button_UpdateCheck_Click);
      this.checkBox_UpdateCheck.AutoSize = true;
      this.checkBox_UpdateCheck.Checked = true;
      this.checkBox_UpdateCheck.CheckState = CheckState.Checked;
      this.checkBox_UpdateCheck.Location = new Point(11, 55);
      this.checkBox_UpdateCheck.Name = "checkBox_UpdateCheck";
      this.checkBox_UpdateCheck.Size = new Size(163, 17);
      this.checkBox_UpdateCheck.TabIndex = 22;
      this.checkBox_UpdateCheck.Text = "Check for updates on startup";
      this.checkBox_UpdateCheck.UseVisualStyleBackColor = true;
      this.checkBox_UpdateCheck.CheckedChanged += new EventHandler(this.checkBox_Settings_CheckedChanged);
      this.label_KeyboardLayout.AutoSize = true;
      this.label_KeyboardLayout.Location = new Point(8, 22);
      this.label_KeyboardLayout.Name = "label_KeyboardLayout";
      this.label_KeyboardLayout.Size = new Size(90, 13);
      this.label_KeyboardLayout.TabIndex = 21;
      this.label_KeyboardLayout.Text = "Keyboard Layout:";
      this.comboBox_KeyboardLayout.DropDownStyle = ComboBoxStyle.DropDownList;
      this.comboBox_KeyboardLayout.FormattingEnabled = true;
      this.comboBox_KeyboardLayout.Location = new Point(104, 19);
      this.comboBox_KeyboardLayout.Name = "comboBox_KeyboardLayout";
      this.comboBox_KeyboardLayout.Size = new Size(193, 21);
      this.comboBox_KeyboardLayout.TabIndex = 20;
      this.comboBox_KeyboardLayout.SelectedIndexChanged += new EventHandler(this.comboBox_KeyboardLayout_SelectedIndexChanged);
      this.checkBox_AutoDefaultDevice.AutoSize = true;
      this.checkBox_AutoDefaultDevice.Checked = true;
      this.checkBox_AutoDefaultDevice.CheckState = CheckState.Checked;
      this.checkBox_AutoDefaultDevice.Location = new Point(11, 78);
      this.checkBox_AutoDefaultDevice.Name = "checkBox_AutoDefaultDevice";
      this.checkBox_AutoDefaultDevice.Size = new Size(288, 17);
      this.checkBox_AutoDefaultDevice.TabIndex = 16;
      this.checkBox_AutoDefaultDevice.Text = "Automatically select the Default Input Device on startup";
      this.checkBox_AutoDefaultDevice.UseVisualStyleBackColor = true;
      this.checkBox_AutoDefaultDevice.CheckedChanged += new EventHandler(this.checkBox_Settings_CheckedChanged);
      this.checkBox_DisableGLights.AutoSize = true;
      this.checkBox_DisableGLights.Checked = true;
      this.checkBox_DisableGLights.CheckState = CheckState.Checked;
      this.checkBox_DisableGLights.Location = new Point(11, 170);
      this.checkBox_DisableGLights.Name = "checkBox_DisableGLights";
      this.checkBox_DisableGLights.Size = new Size(286, 17);
      this.checkBox_DisableGLights.TabIndex = 17;
      this.checkBox_DisableGLights.Text = "Disable G-Key and Logo lights when spectrogram starts\r\n";
      this.checkBox_DisableGLights.UseVisualStyleBackColor = true;
      this.checkBox_DisableGLights.CheckedChanged += new EventHandler(this.checkBox_Settings_CheckedChanged);
      this.checkBox_MinimiseStartup.AutoSize = true;
      this.checkBox_MinimiseStartup.Location = new Point(11, 124);
      this.checkBox_MinimiseStartup.Name = "checkBox_MinimiseStartup";
      this.checkBox_MinimiseStartup.Size = new Size(193, 17);
      this.checkBox_MinimiseStartup.TabIndex = 18;
      this.checkBox_MinimiseStartup.Text = "Minimize program to Tray on startup";
      this.checkBox_MinimiseStartup.UseVisualStyleBackColor = true;
      this.checkBox_MinimiseStartup.CheckedChanged += new EventHandler(this.checkBox_Settings_CheckedChanged);
      this.checkBox_DeviceLighting.AutoSize = true;
      this.checkBox_DeviceLighting.Checked = true;
      this.checkBox_DeviceLighting.CheckState = CheckState.Checked;
      this.checkBox_DeviceLighting.Location = new Point(11, 194);
      this.checkBox_DeviceLighting.Name = "checkBox_DeviceLighting";
      this.checkBox_DeviceLighting.Size = new Size(289, 17);
      this.checkBox_DeviceLighting.TabIndex = 18;
      this.checkBox_DeviceLighting.Text = "Enable Lighting Effects on Logitech Mice and Headsets";
      this.checkBox_DeviceLighting.UseVisualStyleBackColor = true;
      this.checkBox_DeviceLighting.CheckedChanged += new EventHandler(this.checkBox_Settings_CheckedChanged);
      this.checkBox_AutoStartup.AutoSize = true;
      this.checkBox_AutoStartup.Location = new Point(11, 101);
      this.checkBox_AutoStartup.Name = "checkBox_AutoStartup";
      this.checkBox_AutoStartup.Size = new Size(267, 17);
      this.checkBox_AutoStartup.TabIndex = 17;
      this.checkBox_AutoStartup.Text = "Automatically Start Spectrogram on program startup";
      this.checkBox_AutoStartup.UseVisualStyleBackColor = true;
      this.checkBox_AutoStartup.CheckedChanged += new EventHandler(this.checkBox_Settings_CheckedChanged);
      this.checkBox_ARXApp.AutoSize = true;
      this.checkBox_ARXApp.Checked = true;
      this.checkBox_ARXApp.CheckState = CheckState.Checked;
      this.checkBox_ARXApp.Location = new Point(11, 218);
      this.checkBox_ARXApp.Name = "checkBox_ARXApp";
      this.checkBox_ARXApp.Size = new Size(220, 17);
      this.checkBox_ARXApp.TabIndex = 19;
      this.checkBox_ARXApp.Text = "Enable ARX Control App (requires restart)";
      this.checkBox_ARXApp.UseVisualStyleBackColor = true;
      this.checkBox_ARXApp.CheckedChanged += new EventHandler(this.checkBox_Settings_CheckedChanged);
      this.groupBox_SettingsSpectrogram.Controls.Add((Control) this.label_SpectroScale);
      this.groupBox_SettingsSpectrogram.Controls.Add((Control) this.numericUpDown_SpectroScale);
      this.groupBox_SettingsSpectrogram.Controls.Add((Control) this.numericUpDown_FrequencyBoost);
      this.groupBox_SettingsSpectrogram.Controls.Add((Control) this.label_FrequencyBoost);
      this.groupBox_SettingsSpectrogram.Controls.Add((Control) this.label_AmplitudeScale);
      this.groupBox_SettingsSpectrogram.Controls.Add((Control) this.comboBox_AmplitudeScale);
      this.groupBox_SettingsSpectrogram.Controls.Add((Control) this.label_AmplitudeOffset);
      this.groupBox_SettingsSpectrogram.Controls.Add((Control) this.numericUpDown_AmplitudeOffset);
      this.groupBox_SettingsSpectrogram.Controls.Add((Control) this.label_RefreshDelay);
      this.groupBox_SettingsSpectrogram.Controls.Add((Control) this.numericUpDown_RefreshDelay);
      this.groupBox_SettingsSpectrogram.Location = new Point(6, 6);
      this.groupBox_SettingsSpectrogram.Name = "groupBox_SettingsSpectrogram";
      this.groupBox_SettingsSpectrogram.Size = new Size(451, 111);
      this.groupBox_SettingsSpectrogram.TabIndex = 20;
      this.groupBox_SettingsSpectrogram.TabStop = false;
      this.groupBox_SettingsSpectrogram.Text = "Spectrogram";
      this.label_SpectroScale.AutoSize = true;
      this.label_SpectroScale.Location = new Point(8, 24);
      this.label_SpectroScale.Name = "label_SpectroScale";
      this.label_SpectroScale.Size = new Size(101, 13);
      this.label_SpectroScale.TabIndex = 1;
      this.label_SpectroScale.Text = "Sensitivity Multiplier:";
      this.numericUpDown_SpectroScale.DecimalPlaces = 3;
      this.numericUpDown_SpectroScale.Increment = new Decimal(new int[4]
      {
        5,
        0,
        0,
        65536
      });
      this.numericUpDown_SpectroScale.Location = new Point(115, 22);
      this.numericUpDown_SpectroScale.Maximum = new Decimal(new int[4]
      {
        1000,
        0,
        0,
        0
      });
      this.numericUpDown_SpectroScale.Minimum = new Decimal(new int[4]
      {
        1,
        0,
        0,
        196608
      });
      this.numericUpDown_SpectroScale.Name = "numericUpDown_SpectroScale";
      this.numericUpDown_SpectroScale.Size = new Size(85, 20);
      this.numericUpDown_SpectroScale.TabIndex = 0;
      this.numericUpDown_SpectroScale.Value = new Decimal(new int[4]
      {
        1,
        0,
        0,
        0
      });
      this.numericUpDown_SpectroScale.TextChanged += new EventHandler(this.numericUpDown_SpectroScale_TextChanged);
      this.numericUpDown_FrequencyBoost.Location = new Point(115, 49);
      this.numericUpDown_FrequencyBoost.Maximum = new Decimal(new int[4]
      {
        (int) byte.MaxValue,
        0,
        0,
        0
      });
      this.numericUpDown_FrequencyBoost.Name = "numericUpDown_FrequencyBoost";
      this.numericUpDown_FrequencyBoost.Size = new Size(85, 20);
      this.numericUpDown_FrequencyBoost.TabIndex = 17;
      this.numericUpDown_FrequencyBoost.Value = new Decimal(new int[4]
      {
        30,
        0,
        0,
        0
      });
      this.numericUpDown_FrequencyBoost.ValueChanged += new EventHandler(this.numericUpDown_Settings_ValueChanged);
      this.label_FrequencyBoost.AutoSize = true;
      this.label_FrequencyBoost.Location = new Point(8, 51);
      this.label_FrequencyBoost.Name = "label_FrequencyBoost";
      this.label_FrequencyBoost.Size = new Size(90, 13);
      this.label_FrequencyBoost.TabIndex = 15;
      this.label_FrequencyBoost.Text = "Frequency Boost:";
      this.label_AmplitudeScale.AutoSize = true;
      this.label_AmplitudeScale.Location = new Point(8, 79);
      this.label_AmplitudeScale.Name = "label_AmplitudeScale";
      this.label_AmplitudeScale.Size = new Size(86, 13);
      this.label_AmplitudeScale.TabIndex = 10;
      this.label_AmplitudeScale.Text = "Amplitude Scale:";
      this.comboBox_AmplitudeScale.DropDownStyle = ComboBoxStyle.DropDownList;
      this.comboBox_AmplitudeScale.FormattingEnabled = true;
      this.comboBox_AmplitudeScale.Items.AddRange(new object[3]
      {
        (object) "Linear",
        (object) "Square Root",
        (object) "Log10"
      });
      this.comboBox_AmplitudeScale.Location = new Point(115, 76);
      this.comboBox_AmplitudeScale.Name = "comboBox_AmplitudeScale";
      this.comboBox_AmplitudeScale.Size = new Size(85, 21);
      this.comboBox_AmplitudeScale.TabIndex = 13;
      this.comboBox_AmplitudeScale.SelectedIndexChanged += new EventHandler(this.comboBox_AmplitudeScale_SelectedIndexChanged);
      this.label_AmplitudeOffset.AutoSize = true;
      this.label_AmplitudeOffset.Location = new Point(241, 24);
      this.label_AmplitudeOffset.Name = "label_AmplitudeOffset";
      this.label_AmplitudeOffset.Size = new Size(87, 13);
      this.label_AmplitudeOffset.TabIndex = 14;
      this.label_AmplitudeOffset.Text = "Amplitude Offset:";
      this.numericUpDown_AmplitudeOffset.Location = new Point(348, 22);
      this.numericUpDown_AmplitudeOffset.Maximum = new Decimal(new int[4]
      {
        (int) byte.MaxValue,
        0,
        0,
        0
      });
      this.numericUpDown_AmplitudeOffset.Minimum = new Decimal(new int[4]
      {
        (int) byte.MaxValue,
        0,
        0,
        int.MinValue
      });
      this.numericUpDown_AmplitudeOffset.Name = "numericUpDown_AmplitudeOffset";
      this.numericUpDown_AmplitudeOffset.Size = new Size(85, 20);
      this.numericUpDown_AmplitudeOffset.TabIndex = 15;
      this.numericUpDown_AmplitudeOffset.ValueChanged += new EventHandler(this.numericUpDown_Settings_ValueChanged);
      this.label_RefreshDelay.AutoSize = true;
      this.label_RefreshDelay.Location = new Point(241, 50);
      this.label_RefreshDelay.Name = "label_RefreshDelay";
      this.label_RefreshDelay.Size = new Size(99, 13);
      this.label_RefreshDelay.TabIndex = 2;
      this.label_RefreshDelay.Text = "Refresh Delay (ms):";
      this.numericUpDown_RefreshDelay.Location = new Point(348, 48);
      this.numericUpDown_RefreshDelay.Maximum = new Decimal(new int[4]
      {
        1000,
        0,
        0,
        0
      });
      this.numericUpDown_RefreshDelay.Minimum = new Decimal(new int[4]
      {
        1,
        0,
        0,
        0
      });
      this.numericUpDown_RefreshDelay.Name = "numericUpDown_RefreshDelay";
      this.numericUpDown_RefreshDelay.Size = new Size(85, 20);
      this.numericUpDown_RefreshDelay.TabIndex = 9;
      this.numericUpDown_RefreshDelay.Value = new Decimal(new int[4]
      {
        20,
        0,
        0,
        0
      });
      this.numericUpDown_RefreshDelay.ValueChanged += new EventHandler(this.numericUpDown_Settings_ValueChanged);
      this.tabPage4.Controls.Add((Control) this.pictureBox_Logo);
      this.tabPage4.Controls.Add((Control) this.linkLabel_A_Logitech);
      this.tabPage4.Controls.Add((Control) this.groupBox_A_Thanks);
      this.tabPage4.Controls.Add((Control) this.label_A_SDKVersion);
      this.tabPage4.Controls.Add((Control) this.label_A_ProgramVersion);
      this.tabPage4.Controls.Add((Control) this.label_A_ProgramAuthor);
      this.tabPage4.Controls.Add((Control) this.label_A_ProgramName);
      this.tabPage4.Location = new Point(4, 22);
      this.tabPage4.Name = "tabPage4";
      this.tabPage4.Size = new Size(481, 280);
      this.tabPage4.TabIndex = 3;
      this.tabPage4.Text = "About";
      this.tabPage4.UseVisualStyleBackColor = true;
      this.pictureBox_Logo.Image = (Image) Resources.logo;
      this.pictureBox_Logo.Location = new Point(72, 24);
      this.pictureBox_Logo.Name = "pictureBox_Logo";
      this.pictureBox_Logo.Size = new Size(100, 51);
      this.pictureBox_Logo.SizeMode = PictureBoxSizeMode.StretchImage;
      this.pictureBox_Logo.TabIndex = 7;
      this.pictureBox_Logo.TabStop = false;
      this.linkLabel_A_Logitech.AutoSize = true;
      this.linkLabel_A_Logitech.Location = new Point(162, 137);
      this.linkLabel_A_Logitech.Name = "linkLabel_A_Logitech";
      this.linkLabel_A_Logitech.Size = new Size(144, 39);
      this.linkLabel_A_Logitech.TabIndex = 6;
      this.linkLabel_A_Logitech.TabStop = true;
      this.linkLabel_A_Logitech.Text = "For more information visit the:\r\nOfficial Website\r\nLogitech Forums";
      this.linkLabel_A_Logitech.TextAlign = ContentAlignment.MiddleCenter;
      this.linkLabel_A_Logitech.LinkClicked += new LinkLabelLinkClickedEventHandler(this.linkLabel_A_Logitech_LinkClicked);
      this.groupBox_A_Thanks.Controls.Add((Control) this.label_A_Thanks);
      this.groupBox_A_Thanks.Location = new Point(53, 193);
      this.groupBox_A_Thanks.Name = "groupBox_A_Thanks";
      this.groupBox_A_Thanks.Size = new Size(372, 65);
      this.groupBox_A_Thanks.TabIndex = 4;
      this.groupBox_A_Thanks.TabStop = false;
      this.groupBox_A_Thanks.Text = "Thanks to";
      this.label_A_Thanks.AutoSize = true;
      this.label_A_Thanks.Location = new Point(6, 16);
      this.label_A_Thanks.Name = "label_A_Thanks";
      this.label_A_Thanks.Size = new Size(325, 39);
      this.label_A_Thanks.TabIndex = 0;
      this.label_A_Thanks.Text = "The developers of the CSCore Audio Library\r\nThe developers of the MouseKeyHook Library\r\nLogitech for creating great devices and providing easy to use SDKs";
      this.label_A_SDKVersion.AutoSize = true;
      this.label_A_SDKVersion.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label_A_SDKVersion.Location = new Point(150, 104);
      this.label_A_SDKVersion.Name = "label_A_SDKVersion";
      this.label_A_SDKVersion.Size = new Size(187, 13);
      this.label_A_SDKVersion.TabIndex = 3;
      this.label_A_SDKVersion.Text = "SDK Version could not be determined.";
      this.label_A_ProgramVersion.AutoSize = true;
      this.label_A_ProgramVersion.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label_A_ProgramVersion.Location = new Point(150, 91);
      this.label_A_ProgramVersion.Name = "label_A_ProgramVersion";
      this.label_A_ProgramVersion.Size = new Size(203, 13);
      this.label_A_ProgramVersion.TabIndex = 2;
      this.label_A_ProgramVersion.Text = "Program version could not be determined.";
      this.label_A_ProgramAuthor.AutoSize = true;
      this.label_A_ProgramAuthor.Font = new Font("Microsoft Sans Serif", 11.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label_A_ProgramAuthor.ForeColor = Color.FromArgb(64, 64, 64);
      this.label_A_ProgramAuthor.Location = new Point(334, 52);
      this.label_A_ProgramAuthor.Name = "label_A_ProgramAuthor";
      this.label_A_ProgramAuthor.Size = new Size(78, 18);
      this.label_A_ProgramAuthor.TabIndex = 1;
      this.label_A_ProgramAuthor.Text = "by dynftw";
      this.label_A_ProgramName.AutoSize = true;
      this.label_A_ProgramName.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label_A_ProgramName.Location = new Point(174, 27);
      this.label_A_ProgramName.Name = "label_A_ProgramName";
      this.label_A_ProgramName.Size = new Size(242, 25);
      this.label_A_ProgramName.TabIndex = 0;
      this.label_A_ProgramName.Text = "Logitech Spectrogram";
      this.statusStrip_Main.Items.AddRange(new ToolStripItem[1]
      {
        (ToolStripItem) this.toolStripStatusLabel1
      });
      this.statusStrip_Main.Location = new Point(0, 358);
      this.statusStrip_Main.Name = "statusStrip_Main";
      this.statusStrip_Main.Size = new Size(497, 22);
      this.statusStrip_Main.SizingGrip = false;
      this.statusStrip_Main.TabIndex = 6;
      this.statusStrip_Main.Text = "statusStrip1";
      this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
      this.toolStripStatusLabel1.Size = new Size(57, 17);
      this.toolStripStatusLabel1.Text = "Welcome";
      this.comboBox_InputDevice.DropDownStyle = ComboBoxStyle.DropDownList;
      this.comboBox_InputDevice.FormattingEnabled = true;
      this.comboBox_InputDevice.Location = new Point(229, 14);
      this.comboBox_InputDevice.Margin = new Padding(0, 3, 0, 3);
      this.comboBox_InputDevice.Name = "comboBox_InputDevice";
      this.comboBox_InputDevice.Size = new Size(203, 21);
      this.comboBox_InputDevice.TabIndex = 7;
      this.comboBox_InputDevice.SelectedIndexChanged += new EventHandler(this.comboBox_InputDevice_SelectedIndexChanged);
      this.label_InputDevice.AutoSize = true;
      this.label_InputDevice.Location = new Point(158, 17);
      this.label_InputDevice.Margin = new Padding(3, 0, 0, 0);
      this.label_InputDevice.Name = "label_InputDevice";
      this.label_InputDevice.Size = new Size(71, 13);
      this.label_InputDevice.TabIndex = 8;
      this.label_InputDevice.Text = "Input Device:";
      this.button_RefreshInputDevice.Location = new Point(435, 13);
      this.button_RefreshInputDevice.Margin = new Padding(3, 3, 0, 3);
      this.button_RefreshInputDevice.Name = "button_RefreshInputDevice";
      this.button_RefreshInputDevice.Size = new Size(59, 23);
      this.button_RefreshInputDevice.TabIndex = 9;
      this.button_RefreshInputDevice.Text = "Refresh";
      this.button_RefreshInputDevice.UseVisualStyleBackColor = true;
      this.button_RefreshInputDevice.Click += new EventHandler(this.button_RefreshInputDevice_Click);
      this.notifyIcon_Main.Icon = (Icon) componentResourceManager.GetObject("notifyIcon_Main.Icon");
      this.notifyIcon_Main.Text = "Logitech Spectrogram";
      this.notifyIcon_Main.Click += new EventHandler(this.notifyIcon_Main_Click);
      this.label1.AutoSize = true;
      this.label1.Location = new Point(43, 35);
      this.label1.Name = "label1";
      this.label1.Size = new Size(373, 13);
      this.label1.TabIndex = 16;
      this.label1.Text = "\tManual selection of horizontal gradient colors will be added in a future update.";
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(497, 380);
      this.Controls.Add((Control) this.button_RefreshInputDevice);
      this.Controls.Add((Control) this.label_InputDevice);
      this.Controls.Add((Control) this.comboBox_InputDevice);
      this.Controls.Add((Control) this.statusStrip_Main);
      this.Controls.Add((Control) this.tabControl_Main);
      this.Controls.Add((Control) this.button_StartSpectro);
      this.FormBorderStyle = FormBorderStyle.Fixed3D;
      this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
      this.MaximizeBox = false;
      this.Name = nameof (MainForm);
      this.Text = nameof (MainForm);
      this.Load += new EventHandler(this.MainForm_Load);
      this.Resize += new EventHandler(this.MainForm_Resize);
      this.trackBar_red.EndInit();
      this.trackBar_blue.EndInit();
      this.trackBar_green.EndInit();
      this.tabControl_Main.ResumeLayout(false);
      this.tabPage1.ResumeLayout(false);
      this.tabPage1.PerformLayout();
      this.panel_KL_HorizontalGradient.ResumeLayout(false);
      this.panel_KL_HorizontalGradient.PerformLayout();
      this.groupBox_HColorWave.ResumeLayout(false);
      this.groupBox_HColorWave.PerformLayout();
      this.numericUpDown_HColorWaveDelay.EndInit();
      this.panel_KL_SolidColor.ResumeLayout(false);
      this.groupBox_FGColor.ResumeLayout(false);
      this.groupBox_FGColor.PerformLayout();
      this.numericUpDown_CycleDelay.EndInit();
      this.numericUpDown_blue.EndInit();
      this.numericUpDown_red.EndInit();
      this.numericUpDown_green.EndInit();
      this.groupBox_BGColor.ResumeLayout(false);
      this.groupBox_BGColor.PerformLayout();
      this.numericUpDown_BGBlue.EndInit();
      this.numericUpDown_BGRed.EndInit();
      this.numericUpDown_BGGreen.EndInit();
      this.panel_KL_VerticalGradient.ResumeLayout(false);
      this.groupBox_VColorWave.ResumeLayout(false);
      this.groupBox_VColorWave.PerformLayout();
      this.numericUpDown_VColorWaveDelay.EndInit();
      this.groupBox_TransformVGradient.ResumeLayout(false);
      this.groupBox_VProfiles.ResumeLayout(false);
      this.tabPage2.ResumeLayout(false);
      this.groupBox_OS_Colors.ResumeLayout(false);
      this.groupBox_OS_Colors.PerformLayout();
      this.groupBox_OS_Settings.ResumeLayout(false);
      this.groupBox_OS_Settings.PerformLayout();
      this.numericUpDown_OS_Scale.EndInit();
      this.groupBox_OS_Manual.ResumeLayout(false);
      this.tabPage3.ResumeLayout(false);
      this.groupBox_SettingsFile.ResumeLayout(false);
      this.groupBox_SettingsGeneral.ResumeLayout(false);
      this.groupBox_SettingsGeneral.PerformLayout();
      this.groupBox_SettingsSpectrogram.ResumeLayout(false);
      this.groupBox_SettingsSpectrogram.PerformLayout();
      this.numericUpDown_SpectroScale.EndInit();
      this.numericUpDown_FrequencyBoost.EndInit();
      this.numericUpDown_AmplitudeOffset.EndInit();
      this.numericUpDown_RefreshDelay.EndInit();
      this.tabPage4.ResumeLayout(false);
      this.tabPage4.PerformLayout();
      ((ISupportInitialize) this.pictureBox_Logo).EndInit();
      this.groupBox_A_Thanks.ResumeLayout(false);
      this.groupBox_A_Thanks.PerformLayout();
      this.statusStrip_Main.ResumeLayout(false);
      this.statusStrip_Main.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();
    }

    public static class Global
    {
      public static string programVersion = Utilities.getProductVersion();
      public static string programArch = "";
      public static string SDKversion = "";
      public static bool outputWindowOpen = false;
      public static bool programReady = false;
      public static bool programActive = true;
      public static float scale = 1f;
      public static float OSverticalScale = 2f;
      public static int defaultSelectedIndex = 0;
      public static Color[] gradientColor = new Color[6];
      public static Color[] hGradientColor = new Color[23];
      public static string oldStatusBarMessage = "";
      public static bool loadSettings = true;
      public static int LogitechAllDevices = 7;
      public static bool ARXRunning = false;
      public static bool ARXActive = false;
      public static bool sendToARX = true;
      public static bool jQuerySetQueue = false;
      public static string jQuerySetQueuedCommands = "";
      public static int ARXCurrentTab = 0;
      public static int ARXOnScreen = 0;
      public static bool firstMinimize = true;
      public const string programDate = "2016-05-22";
      public const int numOfDefaultGradientProfiles = 5;
      public const int numOfCustomGradientProfiles = 10;
      public const int numOfGradientProfiles = 15;
      public static DateTime lastUpdateCheck;
    }

    public static class Utils
    {
      public static void TryLoad(Action v)
      {
        if (!MainForm.Global.loadSettings)
          return;
        try
        {
          v();
        }
        catch (Exception ex)
        {
          switch (MessageBox.Show("An error occurred while loading the saved program settings: " + ex.Message, "Loading Program Settings Error", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Hand))
          {
            case DialogResult.Abort:
              MainForm.Global.loadSettings = false;
              break;
            case DialogResult.Retry:
              MainForm.Utils.TryLoad(v);
              break;
          }
        }
      }
    }
  }
}
