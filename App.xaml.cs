using LedCSharp;
using LogitechAudioVisualizer.Settings;
using System;
using System.Windows;

namespace LogitechAudioVisualizer
{
    public partial class App : Application
    {
        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            if (LogitechGSDK.LogiLedInit())
            {
                LogitechGSDK.LogiLedSetTargetDevice(LogitechGSDK.LOGI_DEVICETYPE_ALL);
                LogitechGSDK.LogiLedSaveCurrentLighting();

                UserSettingsManager.Instance.Init();

                LogitechGSDK.LogiLedRestoreLighting();
            }
            else
            {
                throw new Exception("Unable to log to Logitech G SDK.");
            }
        }

        protected override void OnExit(ExitEventArgs e)
        {
            LogitechGSDK.LogiLedShutdown();

            base.OnExit(e);
        }
    }
}