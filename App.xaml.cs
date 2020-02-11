using LedCSharp;
using LogitechAudioVisualizer.Settings;
using LogitechAudioVisualizer.ViewModels;
using LogitechAudioVisualizer.Views;
using System.Windows;

namespace LogitechAudioVisualizer
{
    public partial class App : Application
    {
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
        }

        protected override void OnExit(ExitEventArgs e)
        {
            LogitechGSDK.LogiLedShutdown();

            base.OnExit(e);
        }
    }
}