// Decompiled with JetBrains decompiler
// Type: LogitechArx
// Assembly: Logitech Spectrogram, Version=2.8.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 51487773-CCC1-46AA-85F4-7E087432A9E8
// Assembly location: C:\Users\spesant\Downloads\Logitech Spectrogram v2.8.0 (64-bit)\Logitech Spectrogram.exe

using System;
using System.Runtime.InteropServices;

public class LogitechArx
{
  public const int LOGI_ARX_ORIENTATION_PORTRAIT = 1;
  public const int LOGI_ARX_ORIENTATION_LANDSCAPE = 16;
  public const int LOGI_ARX_EVENT_FOCUS_ACTIVE = 1;
  public const int LOGI_ARX_EVENT_FOCUS_INACTIVE = 2;
  public const int LOGI_ARX_EVENT_TAP_ON_TAG = 4;
  public const int LOGI_ARX_EVENT_MOBILEDEVICE_ARRIVAL = 8;
  public const int LOGI_ARX_EVENT_MOBILEDEVICE_REMOVAL = 16;
  public const int LOGI_ARX_DEVICETYPE_IPHONE = 1;
  public const int LOGI_ARX_DEVICETYPE_IPAD = 2;
  public const int LOGI_ARX_DEVICETYPE_ANDROID_SMALL = 3;
  public const int LOGI_ARX_DEVICETYPE_ANDROID_NORMAL = 4;
  public const int LOGI_ARX_DEVICETYPE_ANDROID_LARGE = 5;
  public const int LOGI_ARX_DEVICETYPE_ANDROID_XLARGE = 6;
  public const int LOGI_ARX_DEVICETYPE_ANDROID_OTHER = 7;

  [DllImport("LogitechGArxControlEnginesWrapper.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
  public static extern bool LogiArxInit(
    string identifier,
    string friendlyName,
    ref LogitechArx.logiArxCbContext callback);

  [DllImport("LogitechGArxControlEnginesWrapper.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
  public static extern bool LogiArxAddFileAs(string filePath, string fileName, string mimeType = "");

  [DllImport("LogitechGArxControlEnginesWrapper.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
  public static extern bool LogiArxAddContentAs(
    byte[] content,
    int size,
    string fileName,
    string mimeType = "");

  [DllImport("LogitechGArxControlEnginesWrapper.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
  public static extern bool LogiArxAddUTF8StringAs(
    string stringContent,
    string fileName,
    string mimeType = "");

  [DllImport("LogitechGArxControlEnginesWrapper.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
  public static extern bool LogiArxAddImageFromBitmap(
    byte[] bitmap,
    int width,
    int height,
    string fileName);

  [DllImport("LogitechGArxControlEnginesWrapper.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
  public static extern bool LogiArxSetIndex(string fileName);

  [DllImport("LogitechGArxControlEnginesWrapper.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
  public static extern bool LogiArxSetTagPropertyById(string tagId, string prop, string newValue);

  [DllImport("LogitechGArxControlEnginesWrapper.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
  public static extern bool LogiArxSetTagsPropertyByClass(
    string tagsClass,
    string prop,
    string newValue);

  [DllImport("LogitechGArxControlEnginesWrapper.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
  public static extern bool LogiArxSetTagContentById(string tagId, string newContent);

  [DllImport("LogitechGArxControlEnginesWrapper.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
  public static extern bool LogiArxSetTagsContentByClass(string tagsClass, string newContent);

  [DllImport("LogitechGArxControlEnginesWrapper.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
  public static extern int LogiArxGetLastError();

  [DllImport("LogitechGArxControlEnginesWrapper.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
  public static extern void LogiArxShutdown();

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate void logiArxCB(int eventType, int eventValue, [MarshalAs(UnmanagedType.LPWStr)] string eventArg, IntPtr context);

  public struct logiArxCbContext
  {
    public LogitechArx.logiArxCB arxCallBack;
    public IntPtr arxContext;
  }
}
