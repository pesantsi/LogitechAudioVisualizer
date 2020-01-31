using LedCSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogitechAudioVisualizer.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private LogiLedSdkVersion SdkVersion { get; set; }

        public string Greeting => "Hello World!";
        public string SdkVersionString => SdkVersion.ToString();

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
                if (LogitechGSDK.LogiLedInit())
                {
                    SdkVersion = new LogiLedSdkVersion();
                    LogitechGSDK.LogiLedGetSdkVersion(ref SdkVersion.MajorNum, ref SdkVersion.MinorNum, ref SdkVersion.BuildNum);

                    //    this.toolStripStatusLabel1.Text = "Ready";
                    //    int[] numArray = new int[3];
                    //   
                    //    MainForm.Global.SDKversion = numArray[0].ToString() + "." + numArray[1].ToString() + "." + numArray[2].ToString();
                    //    this.label_A_SDKVersion.Text = "LED SDK Version:          " + MainForm.Global.SDKversion;
                    //    LogitechGSDK.LogiLedSetTargetDevice(MainForm.Global.LogitechAllDevices);
                    //    LogitechGSDK.LogiLedSaveCurrentLighting();
                }
                else
                {
                    //this.toolStripStatusLabel1.Text = "Failed to connect to Logitech Gaming Software";
                    //this.button_StartSpectro.Enabled = false;
                }
            }
            catch (DllNotFoundException ex)
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
    }

}
