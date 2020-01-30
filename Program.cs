// Decompiled with JetBrains decompiler
// Type: LogitechSpectrogram.Program
// Assembly: Logitech Spectrogram, Version=2.8.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 51487773-CCC1-46AA-85F4-7E087432A9E8
// Assembly location: C:\Users\spesant\Downloads\Logitech Spectrogram v2.8.0 (64-bit)\Logitech Spectrogram.exe

using System;

namespace LogitechSpectrogram
{
    using System;
    using Avalonia;
    using Avalonia.Controls;
    using Avalonia.Controls.ApplicationLifetimes;
    using Avalonia.Logging.Serilog;
    using LogitechAudioVisualizer;

    class Program
        {
            // Initialization code. Don't use any Avalonia, third-party APIs or any
            // SynchronizationContext-reliant code before AppMain is called: things aren't initialized
            // yet and stuff might break.
            public static void Main(string[] args) => BuildAvaloniaApp()
                .StartWithClassicDesktopLifetime(args);

            // Avalonia configuration, don't remove; also used by visual designer.
            public static AppBuilder BuildAvaloniaApp()
                => AppBuilder.Configure<App>()
                    .UsePlatformDetect()
                    .LogToDebug();
        }
}
