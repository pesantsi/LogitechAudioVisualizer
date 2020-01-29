// Decompiled with JetBrains decompiler
// Type: UpdateChecker
// Assembly: Logitech Spectrogram, Version=2.8.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 51487773-CCC1-46AA-85F4-7E087432A9E8
// Assembly location: C:\Users\spesant\Downloads\Logitech Spectrogram v2.8.0 (64-bit)\Logitech Spectrogram.exe

using LogitechSpectrogram;
using System;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Xml.XPath;

public class UpdateChecker
{
  public static bool checkForUpdate(bool manualCheck, bool checkUpdatesCurrent)
  {
    bool flag1 = checkUpdatesCurrent;
    try
    {
      bool flag2 = false;
      if (!manualCheck)
      {
        DateTime now = DateTime.Now;
        DateTime lastUpdateCheck = MainForm.Global.lastUpdateCheck;
        if (now.Subtract(lastUpdateCheck).TotalDays > 1.0)
        {
          double totalDays = now.Subtract(lastUpdateCheck).TotalDays;
          flag2 = true;
        }
      }
      else
        flag2 = true;
      if (flag2)
      {
        XDocument node = XDocument.Load("http://dynftw.tk/spectrogram/version.xml");
        string str = node.XPathSelectElement("//program/version[1]").Value;
        if (str != null)
        {
          int num1 = new Version(MainForm.Global.programVersion).CompareTo(new Version(str));
          if (num1 > 0)
          {
            if (manualCheck)
            {
              int num2 = (int) MessageBox.Show("An error occurred while checking for updates.", "Error");
            }
          }
          else if (num1 < 0)
          {
            string message = node.XPathSelectElement("//program/message[1]").Value;
            string downloadURL = node.XPathSelectElement("//program/link[1]").Value;
            string changelogURL = node.XPathSelectElement("//program/changelog[1]").Value;
            using (UpdateForm updateForm = new UpdateForm(message, MainForm.Global.programVersion, str, downloadURL, changelogURL, checkUpdatesCurrent))
            {
              int num3 = (int) updateForm.ShowDialog();
              flag1 = updateForm.checkUpdatesOnStartup;
            }
          }
          else if (manualCheck)
          {
            int num4 = (int) MessageBox.Show("This is the latest version (no update available at this time).", "No update available");
          }
          MainForm.Global.lastUpdateCheck = DateTime.Now;
        }
      }
      return flag1;
    }
    catch (Exception ex)
    {
      int num = (int) MessageBox.Show("An error occurred while checking for updates.\n\n" + ex.Message + "\n\n" + (object) ex.TargetSite, "Update Check Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
      return flag1;
    }
  }
}
