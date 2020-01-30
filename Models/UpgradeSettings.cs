//// Decompiled with JetBrains decompiler
//// Type: UpgradeSettings
//// Assembly: Logitech Spectrogram, Version=2.8.0.0, Culture=neutral, PublicKeyToken=null
//// MVID: 51487773-CCC1-46AA-85F4-7E087432A9E8
//// Assembly location: C:\Users\spesant\Downloads\Logitech Spectrogram v2.8.0 (64-bit)\Logitech Spectrogram.exe

//using LogitechSpectrogram;
//using System;
//using System.Configuration;
//using System.IO;
//using System.Windows.Forms;

//public class UpgradeSettings
//{
//  public static bool upgradeSettings(out string importPath)
//  {
//    string[] files = Directory.GetFiles(Path.GetFullPath(Path.Combine(Path.GetDirectoryName(ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.PerUserRoamingAndLocal).FilePath), "..\\..\\")), "user.config", SearchOption.AllDirectories);
//    string[] settingsFilesVersion = new string[files.Length];
//    string[] settingsFilesLastModified = new string[files.Length];
//    importPath = "";
//    if (files.Length != 0)
//    {
//      for (int index = 0; index < files.Length; ++index)
//      {
//        settingsFilesVersion[index] = Path.GetFileName(Path.GetDirectoryName(files[index]));
//        DateTime lastWriteTime = File.GetLastWriteTime(files[index]);
//        settingsFilesLastModified[index] = lastWriteTime.ToString("yyyy-MM-dd HH:mm    (") + lastWriteTime.ToString("D") + " " + lastWriteTime.ToString("t") + ")";
//      }
//      using (UpgradeSettingsForm upgradeSettingsForm = new UpgradeSettingsForm(files, settingsFilesVersion, settingsFilesLastModified))
//      {
//        if (upgradeSettingsForm.ShowDialog() == DialogResult.OK)
//        {
//          importPath = upgradeSettingsForm.importPath;
//          return true;
//        }
//      }
//    }
//    return false;
//  }
//}
