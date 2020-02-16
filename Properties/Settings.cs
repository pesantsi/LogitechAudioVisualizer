//// Decompiled with JetBrains decompiler
//// Type: LogitechSpectrogram.Properties.Settings
//// Assembly: Logitech Spectrogram, Version=2.8.0.0, Culture=neutral, PublicKeyToken=null
//// MVID: 51487773-CCC1-46AA-85F4-7E087432A9E8
//// Assembly location: C:\Users\spesant\Downloads\Logitech Spectrogram v2.8.0 (64-bit)\Logitech Spectrogram.exe

//using System;
//using System.CodeDom.Compiler;
//using System.ComponentModel;
//using System.Configuration;
//using System.Diagnostics;
//using System.Drawing;
//using System.Runtime.CompilerServices;

//namespace LogitechSpectrogram.Properties
//{
//  [CompilerGenerated]
//  [GeneratedCode("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "14.0.0.0")]
//  internal sealed class Settings : ApplicationSettingsBase
//  {
//    private static Settings defaultInstance = (Settings) SettingsBase.Synchronized((SettingsBase) new Settings());

//    public static Settings Default
//    {
//      get
//      {
//        return Settings.defaultInstance;
//      }
//    }

//    [UserScopedSetting]
//    [DebuggerNonUserCode]
//    [DefaultSettingValue("True")]
//    public bool autoConsole
//    {
//      get
//      {
//        return (bool) this[nameof (autoConsole)];
//      }
//      set
//      {
//        this[nameof (autoConsole)] = (object) value;
//      }
//    }

//    [UserScopedSetting]
//    [DebuggerNonUserCode]
//    [DefaultSettingValue("20")]
//    public int cycleDelay
//    {
//      get
//      {
//        return (int) this[nameof (cycleDelay)];
//      }
//      set
//      {
//        this[nameof (cycleDelay)] = (object) value;
//      }
//    }

//    [UserScopedSetting]
//    [DebuggerNonUserCode]
//    [DefaultSettingValue("5")]
//    public Decimal spectroScale
//    {
//      get
//      {
//        return (Decimal) this[nameof (spectroScale)];
//      }
//      set
//      {
//        this[nameof (spectroScale)] = (object) value;
//      }
//    }

//    [UserScopedSetting]
//    [DebuggerNonUserCode]
//    [DefaultSettingValue("20")]
//    public int refreshDelay
//    {
//      get
//      {
//        return (int) this[nameof (refreshDelay)];
//      }
//      set
//      {
//        this[nameof (refreshDelay)] = (object) value;
//      }
//    }

//    [UserScopedSetting]
//    [DebuggerNonUserCode]
//    [DefaultSettingValue("255")]
//    public int FGRed
//    {
//      get
//      {
//        return (int) this[nameof (FGRed)];
//      }
//      set
//      {
//        this[nameof (FGRed)] = (object) value;
//      }
//    }

//    [UserScopedSetting]
//    [DebuggerNonUserCode]
//    [DefaultSettingValue("0")]
//    public int FGGreen
//    {
//      get
//      {
//        return (int) this[nameof (FGGreen)];
//      }
//      set
//      {
//        this[nameof (FGGreen)] = (object) value;
//      }
//    }

//    [UserScopedSetting]
//    [DebuggerNonUserCode]
//    [DefaultSettingValue("0")]
//    public int FGBlue
//    {
//      get
//      {
//        return (int) this[nameof (FGBlue)];
//      }
//      set
//      {
//        this[nameof (FGBlue)] = (object) value;
//      }
//    }

//    [UserScopedSetting]
//    [DebuggerNonUserCode]
//    [DefaultSettingValue("0")]
//    public int BGRed
//    {
//      get
//      {
//        return (int) this[nameof (BGRed)];
//      }
//      set
//      {
//        this[nameof (BGRed)] = (object) value;
//      }
//    }

//    [UserScopedSetting]
//    [DebuggerNonUserCode]
//    [DefaultSettingValue("0")]
//    public int BGGreen
//    {
//      get
//      {
//        return (int) this[nameof (BGGreen)];
//      }
//      set
//      {
//        this[nameof (BGGreen)] = (object) value;
//      }
//    }

//    [UserScopedSetting]
//    [DebuggerNonUserCode]
//    [DefaultSettingValue("0")]
//    public int BGBlue
//    {
//      get
//      {
//        return (int) this[nameof (BGBlue)];
//      }
//      set
//      {
//        this[nameof (BGBlue)] = (object) value;
//      }
//    }

//    [UserScopedSetting]
//    [DebuggerNonUserCode]
//    public int[] customColors
//    {
//      get
//      {
//        return (int[]) this[nameof (customColors)];
//      }
//      set
//      {
//        this[nameof (customColors)] = (object) value;
//      }
//    }

//    [UserScopedSetting]
//    [DebuggerNonUserCode]
//    public object inputDevice
//    {
//      get
//      {
//        return this[nameof (inputDevice)];
//      }
//      set
//      {
//        this[nameof (inputDevice)] = value;
//      }
//    }

//    [UserScopedSetting]
//    [DebuggerNonUserCode]
//    [DefaultSettingValue("0")]
//    public int colorMode
//    {
//      get
//      {
//        return (int) this[nameof (colorMode)];
//      }
//      set
//      {
//        this[nameof (colorMode)] = (object) value;
//      }
//    }

//    [UserScopedSetting]
//    [DebuggerNonUserCode]
//    [DefaultSettingValue("<?xml version=\"1.0\" encoding=\"utf-16\"?>\r\n<ArrayOfInt xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\">\r\n  <int>16711680</int>\r\n  <int>16718080</int>\r\n  <int>16724736</int>\r\n  <int>16731136</int>\r\n  <int>16737792</int>\r\n  <int>16744448</int>\r\n</ArrayOfInt>")]
//    public int[] gradientColor
//    {
//      get
//      {
//        return (int[]) this[nameof (gradientColor)];
//      }
//      set
//      {
//        this[nameof (gradientColor)] = (object) value;
//      }
//    }

//    [UserScopedSetting]
//    [DebuggerNonUserCode]
//    [DefaultSettingValue("<?xml version=\"1.0\" encoding=\"utf-16\"?>\r\n<ArrayOfString xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\">\r\n  <string>16711680</string>\r\n  <string>16711680</string>\r\n  <string>16749312</string>\r\n  <string>16749312</string>\r\n  <string>65280</string>\r\n  <string>65280</string>\r\n  <string>Peak Meter</string>\r\n  <string>255</string>\r\n  <string>13311</string>\r\n  <string>26367</string>\r\n  <string>39423</string>\r\n  <string>52479</string>\r\n  <string>65535</string>\r\n  <string>Ocean</string>\r\n  <string>65344</string>\r\n  <string>1703782</string>\r\n  <string>3407756</string>\r\n  <string>5046194</string>\r\n  <string>6750168</string>\r\n  <string>8454143</string>\r\n  <string>Aquamarine</string>\r\n  <string>16711680</string>\r\n  <string>16718080</string>\r\n  <string>16724736</string>\r\n  <string>16731136</string>\r\n  <string>16737792</string>\r\n  <string>16744448</string>\r\n  <string>Flame</string>\r\n  <string>16711807</string>\r\n  <string>16056473</string>\r\n  <string>15466675</string>\r\n  <string>14811340</string>\r\n  <string>14221542</string>\r\n  <string>13631743</string>\r\n  <string>Pink to Purple</string>\r\n  <string>0</string>\r\n  <string>0</string>\r\n  <string>0</string>\r\n  <string>0</string>\r\n  <string>0</string>\r\n  <string>0</string>\r\n  <string>Custom Profile 1</string>\r\n  <string>0</string>\r\n  <string>0</string>\r\n  <string>0</string>\r\n  <string>0</string>\r\n  <string>0</string>\r\n  <string>0</string>\r\n  <string>Custom Profile 2</string>\r\n  <string>0</string>\r\n  <string>0</string>\r\n  <string>0</string>\r\n  <string>0</string>\r\n  <string>0</string>\r\n  <string>0</string>\r\n  <string>Custom Profile 3</string>\r\n  <string>0</string>\r\n  <string>0</string>\r\n  <string>0</string>\r\n  <string>0</string>\r\n  <string>0</string>\r\n  <string>0</string>\r\n  <string>Custom Profile 4</string>\r\n  <string>0</string>\r\n  <string>0</string>\r\n  <string>0</string>\r\n  <string>0</string>\r\n  <string>0</string>\r\n  <string>0</string>\r\n  <string>Custom Profile 5</string>\r\n  <string>0</string>\r\n  <string>0</string>\r\n  <string>0</string>\r\n  <string>0</string>\r\n  <string>0</string>\r\n  <string>0</string>\r\n  <string>Custom Profile 6</string>\r\n  <string>0</string>\r\n  <string>0</string>\r\n  <string>0</string>\r\n  <string>0</string>\r\n  <string>0</string>\r\n  <string>0</string>\r\n  <string>Custom Profile 7</string>\r\n  <string>0</string>\r\n  <string>0</string>\r\n  <string>0</string>\r\n  <string>0</string>\r\n  <string>0</string>\r\n  <string>0</string>\r\n  <string>Custom Profile 8</string>\r\n  <string>0</string>\r\n  <string>0</string>\r\n  <string>0</string>\r\n  <string>0</string>\r\n  <string>0</string>\r\n  <string>0</string>\r\n  <string>Custom Profile 9</string>\r\n  <string>0</string>\r\n  <string>0</string>\r\n  <string>0</string>\r\n  <string>0</string>\r\n  <string>0</string>\r\n  <string>0</string>\r\n  <string>Custom Profile 10</string>\r\n</ArrayOfString>")]
//    public string[] verticalProfiles
//    {
//      get
//      {
//        return (string[]) this[nameof (verticalProfiles)];
//      }
//      set
//      {
//        this[nameof (verticalProfiles)] = (object) value;
//      }
//    }

//    [UserScopedSetting]
//    [DebuggerNonUserCode]
//    [DefaultSettingValue("True")]
//    public bool OS_highQuality
//    {
//      get
//      {
//        return (bool) this[nameof (OS_highQuality)];
//      }
//      set
//      {
//        this[nameof (OS_highQuality)] = (object) value;
//      }
//    }

//    [UserScopedSetting]
//    [DebuggerNonUserCode]
//    [DefaultSettingValue("True")]
//    public bool OS_keyboardColors
//    {
//      get
//      {
//        return (bool) this[nameof (OS_keyboardColors)];
//      }
//      set
//      {
//        this[nameof (OS_keyboardColors)] = (object) value;
//      }
//    }

//    [UserScopedSetting]
//    [DebuggerNonUserCode]
//    [DefaultSettingValue("2")]
//    public Decimal OS_verticalScale
//    {
//      get
//      {
//        return (Decimal) this[nameof (OS_verticalScale)];
//      }
//      set
//      {
//        this[nameof (OS_verticalScale)] = (object) value;
//      }
//    }

//    [UserScopedSetting]
//    [DebuggerNonUserCode]
//    [DefaultSettingValue("Red")]
//    public Color OS_FG
//    {
//      get
//      {
//        return (Color) this[nameof (OS_FG)];
//      }
//      set
//      {
//        this[nameof (OS_FG)] = (object) value;
//      }
//    }

//    [UserScopedSetting]
//    [DebuggerNonUserCode]
//    [DefaultSettingValue("Black")]
//    public Color OS_BG
//    {
//      get
//      {
//        return (Color) this[nameof (OS_BG)];
//      }
//      set
//      {
//        this[nameof (OS_BG)] = (object) value;
//      }
//    }

//    [UserScopedSetting]
//    [DebuggerNonUserCode]
//    [DefaultSettingValue("30")]
//    public int frequencyBoost
//    {
//      get
//      {
//        return (int) this[nameof (frequencyBoost)];
//      }
//      set
//      {
//        this[nameof (frequencyBoost)] = (object) value;
//      }
//    }

//    [UserScopedSetting]
//    [DebuggerNonUserCode]
//    [DefaultSettingValue("0")]
//    public int amplitudeScale
//    {
//      get
//      {
//        return (int) this[nameof (amplitudeScale)];
//      }
//      set
//      {
//        this[nameof (amplitudeScale)] = (object) value;
//      }
//    }

//    [UserScopedSetting]
//    [DebuggerNonUserCode]
//    [DefaultSettingValue("0")]
//    public int amplitudeOffset
//    {
//      get
//      {
//        return (int) this[nameof (amplitudeOffset)];
//      }
//      set
//      {
//        this[nameof (amplitudeOffset)] = (object) value;
//      }
//    }

//    [UserScopedSetting]
//    [DebuggerNonUserCode]
//    [DefaultSettingValue("True")]
//    public bool defaultDevice
//    {
//      get
//      {
//        return (bool) this[nameof (defaultDevice)];
//      }
//      set
//      {
//        this[nameof (defaultDevice)] = (object) value;
//      }
//    }

//    [UserScopedSetting]
//    [DebuggerNonUserCode]
//    [DefaultSettingValue("True")]
//    public bool disableGLights
//    {
//      get
//      {
//        return (bool) this[nameof (disableGLights)];
//      }
//      set
//      {
//        this[nameof (disableGLights)] = (object) value;
//      }
//    }

//    [UserScopedSetting]
//    [DebuggerNonUserCode]
//    [DefaultSettingValue("True")]
//    public bool deviceLighting
//    {
//      get
//      {
//        return (bool) this[nameof (deviceLighting)];
//      }
//      set
//      {
//        this[nameof (deviceLighting)] = (object) value;
//      }
//    }

//    [UserScopedSetting]
//    [DebuggerNonUserCode]
//    [DefaultSettingValue("False")]
//    public bool autoStartup
//    {
//      get
//      {
//        return (bool) this[nameof (autoStartup)];
//      }
//      set
//      {
//        this[nameof (autoStartup)] = (object) value;
//      }
//    }

//    [UserScopedSetting]
//    [DebuggerNonUserCode]
//    [DefaultSettingValue("False")]
//    public bool minimiseStartup
//    {
//      get
//      {
//        return (bool) this[nameof (minimiseStartup)];
//      }
//      set
//      {
//        this[nameof (minimiseStartup)] = (object) value;
//      }
//    }

//    [UserScopedSetting]
//    [DebuggerNonUserCode]
//    [DefaultSettingValue("True")]
//    public bool ARXApp
//    {
//      get
//      {
//        return (bool) this[nameof (ARXApp)];
//      }
//      set
//      {
//        this[nameof (ARXApp)] = (object) value;
//      }
//    }

//    [UserScopedSetting]
//    [DebuggerNonUserCode]
//    [DefaultSettingValue("False")]
//    public bool cycleColors
//    {
//      get
//      {
//        return (bool) this[nameof (cycleColors)];
//      }
//      set
//      {
//        this[nameof (cycleColors)] = (object) value;
//      }
//    }

//    [UserScopedSetting]
//    [DebuggerNonUserCode]
//    [DefaultSettingValue("True")]
//    public bool upgradeRequired
//    {
//      get
//      {
//        return (bool) this[nameof (upgradeRequired)];
//      }
//      set
//      {
//        this[nameof (upgradeRequired)] = (object) value;
//      }
//    }

//    [UserScopedSetting]
//    [DebuggerNonUserCode]
//    [DefaultSettingValue("0")]
//    public int keyboardLayout
//    {
//      get
//      {
//        return (int) this[nameof (keyboardLayout)];
//      }
//      set
//      {
//        this[nameof (keyboardLayout)] = (object) value;
//      }
//    }

//    [UserScopedSetting]
//    [DebuggerNonUserCode]
//    public DateTime lastUpdateCheck
//    {
//      get
//      {
//        return (DateTime) this[nameof (lastUpdateCheck)];
//      }
//      set
//      {
//        this[nameof (lastUpdateCheck)] = (object) value;
//      }
//    }

//    [UserScopedSetting]
//    [DebuggerNonUserCode]
//    [DefaultSettingValue("True")]
//    public bool updateCheck
//    {
//      get
//      {
//        return (bool) this[nameof (updateCheck)];
//      }
//      set
//      {
//        this[nameof (updateCheck)] = (object) value;
//      }
//    }

//    [UserScopedSetting]
//    [DebuggerNonUserCode]
//    [DefaultSettingValue("True")]
//    public bool mediaKeys
//    {
//      get
//      {
//        return (bool) this[nameof (mediaKeys)];
//      }
//      set
//      {
//        this[nameof (mediaKeys)] = (object) value;
//      }
//    }

//    [UserScopedSetting]
//    [DebuggerNonUserCode]
//    [DefaultSettingValue("False")]
//    public bool vColorWaveEnable
//    {
//      get
//      {
//        return (bool) this[nameof (vColorWaveEnable)];
//      }
//      set
//      {
//        this[nameof (vColorWaveEnable)] = (object) value;
//      }
//    }

//    [UserScopedSetting]
//    [DebuggerNonUserCode]
//    [DefaultSettingValue("15")]
//    public int vColorWaveDelay
//    {
//      get
//      {
//        return (int) this[nameof (vColorWaveDelay)];
//      }
//      set
//      {
//        this[nameof (vColorWaveDelay)] = (object) value;
//      }
//    }

//    [UserScopedSetting]
//    [DebuggerNonUserCode]
//    [DefaultSettingValue("0")]
//    public int vColorWaveSpacing
//    {
//      get
//      {
//        return (int) this[nameof (vColorWaveSpacing)];
//      }
//      set
//      {
//        this[nameof (vColorWaveSpacing)] = (object) value;
//      }
//    }

//    [UserScopedSetting]
//    [DebuggerNonUserCode]
//    [DefaultSettingValue("0")]
//    public int vColorWaveDirection
//    {
//      get
//      {
//        return (int) this[nameof (vColorWaveDirection)];
//      }
//      set
//      {
//        this[nameof (vColorWaveDirection)] = (object) value;
//      }
//    }

//    [UserScopedSetting]
//    [DebuggerNonUserCode]
//    [DefaultSettingValue("False")]
//    public bool hColorWaveEnable
//    {
//      get
//      {
//        return (bool) this[nameof (hColorWaveEnable)];
//      }
//      set
//      {
//        this[nameof (hColorWaveEnable)] = (object) value;
//      }
//    }

//    [UserScopedSetting]
//    [DebuggerNonUserCode]
//    [DefaultSettingValue("15")]
//    public int hColorWaveDelay
//    {
//      get
//      {
//        return (int) this[nameof (hColorWaveDelay)];
//      }
//      set
//      {
//        this[nameof (hColorWaveDelay)] = (object) value;
//      }
//    }

//    [UserScopedSetting]
//    [DebuggerNonUserCode]
//    [DefaultSettingValue("0")]
//    public int hColorWaveSpacing
//    {
//      get
//      {
//        return (int) this[nameof (hColorWaveSpacing)];
//      }
//      set
//      {
//        this[nameof (hColorWaveSpacing)] = (object) value;
//      }
//    }

//    [UserScopedSetting]
//    [DebuggerNonUserCode]
//    [DefaultSettingValue("1")]
//    public int hColorWaveDirection
//    {
//      get
//      {
//        return (int) this[nameof (hColorWaveDirection)];
//      }
//      set
//      {
//        this[nameof (hColorWaveDirection)] = (object) value;
//      }
//    }

//    [UserScopedSetting]
//    [DebuggerNonUserCode]
//    [DefaultSettingValue("<?xml version=\"1.0\" encoding=\"utf-16\"?>\r\n<ArrayOfInt xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\">\r\n  <int>16719360</int>\r\n  <int>16711725</int>\r\n  <int>16711800</int>\r\n  <int>16711875</int>\r\n  <int>15728895</int>\r\n  <int>10813695</int>\r\n  <int>5898495</int>\r\n  <int>983295</int>\r\n  <int>15615</int>\r\n  <int>34815</int>\r\n  <int>54015</int>\r\n  <int>65505</int>\r\n  <int>65430</int>\r\n  <int>65355</int>\r\n  <int>65280</int>\r\n  <int>4980480</int>\r\n  <int>9895680</int>\r\n  <int>14810880</int>\r\n  <int>16765440</int>\r\n  <int>16746240</int>\r\n  <int>16727040</int>\r\n  <int>16711695</int>\r\n  <int>16711770</int>\r\n</ArrayOfInt>")]
//    public int[] hGradientColor
//    {
//      get
//      {
//        return (int[]) this[nameof (hGradientColor)];
//      }
//      set
//      {
//        this[nameof (hGradientColor)] = (object) value;
//      }
//    }

//    private void SettingChangingEventHandler(object sender, SettingChangingEventArgs e)
//    {
//    }

//    private void SettingsSavingEventHandler(object sender, CancelEventArgs e)
//    {
//    }
//  }
//}
