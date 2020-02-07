using System;
using System.Collections.Generic;

using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace LogitechAudioVisualizer.Settings
{
    public partial class UserSettings
    {
        [JsonProperty("autoConsole")]
        public BoolClass AutoConsole { get; set; }

        [JsonProperty("cycleDelay")]
        public IntClass CycleDelay { get; set; }

        [JsonProperty("spectroScale")]
        public IntClass SpectroScale { get; set; }

        [JsonProperty("refreshDelay")]
        public IntClass RefreshDelay { get; set; }

        [JsonProperty("FGRed")]
        public IntClass FgRed { get; set; }

        [JsonProperty("FGGreen")]
        public IntClass FgGreen { get; set; }

        [JsonProperty("FGBlue")]
        public IntClass FgBlue { get; set; }

        [JsonProperty("BGRed")]
        public IntClass BgRed { get; set; }

        [JsonProperty("BGGreen")]
        public IntClass BgGreen { get; set; }

        [JsonProperty("BGBlue")]
        public IntClass BgBlue { get; set; }

        [JsonProperty("colorMode")]
        public IntClass ColorMode { get; set; }

        [JsonProperty("gradientColor")]
        public IntListClass GradientColor { get; set; }

        [JsonProperty("verticalProfiles")]
        public StringListClass VerticalProfiles { get; set; }

        [JsonProperty("OS_highQuality")]
        public BoolClass OsHighQuality { get; set; }

        [JsonProperty("OS_keyboardColors")]
        public BoolClass OsKeyboardColors { get; set; }

        [JsonProperty("OS_verticalScale")]
        public IntClass OsVerticalScale { get; set; }

        [JsonProperty("OS_FG")]
        public StringClass OsFg { get; set; }

        [JsonProperty("OS_BG")]
        public StringClass OsBg { get; set; }

        [JsonProperty("frequencyBoost")]
        public IntClass FrequencyBoost { get; set; }

        [JsonProperty("amplitudeScale")]
        public IntClass AmplitudeScale { get; set; }

        [JsonProperty("amplitudeOffset")]
        public IntClass AmplitudeOffset { get; set; }

        [JsonProperty("defaultDevice")]
        public BoolClass DefaultDevice { get; set; }

        [JsonProperty("disableGLights")]
        public BoolClass DisableGLights { get; set; }

        [JsonProperty("deviceLighting")]
        public BoolClass DeviceLighting { get; set; }

        [JsonProperty("autoStartup")]
        public BoolClass AutoStartup { get; set; }

        [JsonProperty("minimiseStartup")]
        public BoolClass MinimiseStartup { get; set; }

        [JsonProperty("ARXApp")]
        public BoolClass ArxApp { get; set; }

        [JsonProperty("cycleColors")]
        public BoolClass CycleColors { get; set; }

        [JsonProperty("upgradeRequired")]
        public BoolClass UpgradeRequired { get; set; }

        [JsonProperty("keyboardLayout")]
        public IntClass KeyboardLayout { get; set; }

        [JsonProperty("lastUpdateCheck")]
        public DateTimeClass LastUpdateCheck { get; set; }

        [JsonProperty("updateCheck")]
        public BoolClass UpdateCheck { get; set; }

        [JsonProperty("mediaKeys")]
        public BoolClass MediaKeys { get; set; }

        [JsonProperty("vColorWaveEnable")]
        public BoolClass VColorWaveEnable { get; set; }

        [JsonProperty("vColorWaveDelay")]
        public IntClass VColorWaveDelay { get; set; }

        [JsonProperty("vColorWaveSpacing")]
        public IntClass VColorWaveSpacing { get; set; }

        [JsonProperty("vColorWaveDirection")]
        public IntClass VColorWaveDirection { get; set; }

        [JsonProperty("hColorWaveEnable")]
        public BoolClass HColorWaveEnable { get; set; }

        [JsonProperty("hColorWaveDelay")]
        public IntClass HColorWaveDelay { get; set; }

        [JsonProperty("hColorWaveSpacing")]
        public IntClass HColorWaveSpacing { get; set; }

        [JsonProperty("hColorWaveDirection")]
        public IntClass HColorWaveDirection { get; set; }

        [JsonProperty("hGradientColor")]
        public IntListClass HGradientColor { get; set; }

        public static UserSettings FromJson(string json) => JsonConvert.DeserializeObject<UserSettings>(json, Converter.Settings);

        public static string ToJson(UserSettings self) => JsonConvert.SerializeObject(self, Converter.Settings);
    }

    public partial class IntClass
    {
        [JsonProperty("value")]
        public int Value { get; set; }
    }

    public partial class BoolClass
    {
        [JsonProperty("value")]
        public bool Value { get; set; }
    }

    public partial class IntListClass
    {
        [JsonProperty("value")]
        public List<int> Value { get; set; }
    }

    public partial class StringClass
    {
        [JsonProperty("value")]
        public string Value { get; set; }
    }

    public partial class StringListClass
    {
        [JsonProperty("value")]
        public List<string> Value { get; set; }
    }

    public partial class DateTimeClass
    {
        [JsonProperty("value")]
        public DateTime Value { get; set; }
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
}