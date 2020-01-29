// Decompiled with JetBrains decompiler
// Type: BackupSettings
// Assembly: Logitech Spectrogram, Version=2.8.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 51487773-CCC1-46AA-85F4-7E087432A9E8
// Assembly location: C:\Users\spesant\Downloads\Logitech Spectrogram v2.8.0 (64-bit)\Logitech Spectrogram.exe

using System;
using System.Configuration;
using System.IO;

public class BackupSettings
{
  public static bool backupSettings()
  {
    string filePath = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.PerUserRoamingAndLocal).FilePath;
    if (!File.Exists(filePath))
      return false;
    string destFileName = Path.GetDirectoryName(filePath) + "\\[backup " + DateTime.Now.ToString("yyyy-MM-dd HHmmss") + "] user.config";
    File.Move(filePath, destFileName);
    return true;
  }
}
