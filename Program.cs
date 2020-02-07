using Avalonia;
using Avalonia.Logging.Serilog;
using LedCSharp;
using LogitechAudioVisualizer;
using LogitechAudioVisualizer.Settings;

namespace LogitechSpectrogram
{
    class Program
    {
        // Initialization code. Don't use any Avalonia, third-party APIs or any
        // SynchronizationContext-reliant code before AppMain is called: things aren't initialized
        // yet and stuff might break.
        public static int Main(string[] args)
        {
            if (LogitechGSDK.LogiLedInit())
            {
                LogitechGSDK.LogiLedSetTargetDevice(LogitechGSDK.LOGI_DEVICETYPE_ALL);
                LogitechGSDK.LogiLedSaveCurrentLighting();

                UserSettingsManager.Instance.Init();

                BuildAvaloniaApp().StartWithClassicDesktopLifetime(args);
                
                LogitechGSDK.LogiLedRestoreLighting();
                return 0;
            }

            return 1;
        }

        // Avalonia configuration, don't remove; also used by visual designer.
        public static AppBuilder BuildAvaloniaApp()
        {
            return AppBuilder.Configure<App>()
                .UsePlatformDetect()
                .LogToDebug();
        }
    }
}
