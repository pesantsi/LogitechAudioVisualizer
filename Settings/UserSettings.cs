using System;
using System.Collections.Generic;

using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace LogitechAudioVisualizer.Settings
{
    public class RootObject
    {
        [JsonProperty("userSettings")]
        public UserSettings UserSettings { get; set; }

        public static RootObject FromJson(string json) => JsonConvert.DeserializeObject<RootObject>(json, Converter.Settings);

        public static string ToJson(RootObject self) => JsonConvert.SerializeObject(self, Converter.Settings);
    }

    public partial class UserSettings
    {
        [JsonProperty("setting")]
        public List<Setting> Setting { get; set; }
    }

    public partial class Setting
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("serializeAs")]
        public SerializeAs SerializeAs { get; set; }

        [JsonProperty("value", NullValueHandling = NullValueHandling.Ignore)]
        public ValueUnion? Value { get; set; }
    }

    public partial class ValueClass
    {
        [JsonProperty("ArrayOfInt", NullValueHandling = NullValueHandling.Ignore)]
        public ArrayOfInt ArrayOfInt { get; set; }

        [JsonProperty("ArrayOfString", NullValueHandling = NullValueHandling.Ignore)]
        public ArrayOfString ArrayOfString { get; set; }
    }

    public partial class ArrayOfInt
    {
        [JsonProperty("-xmlns:xsi")]
        public Uri XmlnsXsi { get; set; }

        [JsonProperty("-xmlns:xsd")]
        public Uri XmlnsXsd { get; set; }

        [JsonProperty("int")]
        [JsonConverter(typeof(DecodeArrayConverter))]
        public List<long> Int { get; set; }
    }

    public partial class ArrayOfString
    {
        [JsonProperty("-xmlns:xsi")]
        public Uri XmlnsXsi { get; set; }

        [JsonProperty("-xmlns:xsd")]
        public Uri XmlnsXsd { get; set; }

        [JsonProperty("string")]
        public List<string> String { get; set; }
    }

    public enum SerializeAs { String, Xml };

    public enum ValueEnum { Black, False, Red, True };

    public partial struct ValueUnion
    {
        public ValueEnum? Enum;
        public long? Integer;
        public ValueClass ValueClass;

        public static implicit operator ValueUnion(ValueEnum Enum) => new ValueUnion { Enum = Enum };
        public static implicit operator ValueUnion(long Integer) => new ValueUnion { Integer = Integer };
        public static implicit operator ValueUnion(ValueClass ValueClass) => new ValueUnion { ValueClass = ValueClass };
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                SerializeAsConverter.Singleton,
                ValueUnionConverter.Singleton,
                ValueEnumConverter.Singleton,
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }

    internal class SerializeAsConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(SerializeAs) || t == typeof(SerializeAs?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "String":
                    return SerializeAs.String;
                case "Xml":
                    return SerializeAs.Xml;
            }
            throw new Exception("Cannot unmarshal type SerializeAs");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (SerializeAs)untypedValue;
            switch (value)
            {
                case SerializeAs.String:
                    serializer.Serialize(writer, "String");
                    return;
                case SerializeAs.Xml:
                    serializer.Serialize(writer, "Xml");
                    return;
            }
            throw new Exception("Cannot marshal type SerializeAs");
        }

        public static readonly SerializeAsConverter Singleton = new SerializeAsConverter();
    }

    internal class ValueUnionConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(ValueUnion) || t == typeof(ValueUnion?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            switch (reader.TokenType)
            {
                case JsonToken.String:
                case JsonToken.Date:
                    var stringValue = serializer.Deserialize<string>(reader);
                    switch (stringValue)
                    {
                        case "Black":
                            return new ValueUnion { Enum = ValueEnum.Black };
                        case "False":
                            return new ValueUnion { Enum = ValueEnum.False };
                        case "Red":
                            return new ValueUnion { Enum = ValueEnum.Red };
                        case "True":
                            return new ValueUnion { Enum = ValueEnum.True };
                    }
                    long l;
                    if (Int64.TryParse(stringValue, out l))
                    {
                        return new ValueUnion { Integer = l };
                    }
                    break;
                case JsonToken.StartObject:
                    var objectValue = serializer.Deserialize<ValueClass>(reader);
                    return new ValueUnion { ValueClass = objectValue };
            }
            throw new Exception("Cannot unmarshal type ValueUnion");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            var value = (ValueUnion)untypedValue;
            if (value.Enum != null)
            {
                switch (value.Enum)
                {
                    case ValueEnum.Black:
                        serializer.Serialize(writer, "Black");
                        return;
                    case ValueEnum.False:
                        serializer.Serialize(writer, "False");
                        return;
                    case ValueEnum.Red:
                        serializer.Serialize(writer, "Red");
                        return;
                    case ValueEnum.True:
                        serializer.Serialize(writer, "True");
                        return;
                }
            }
            if (value.Integer != null)
            {
                serializer.Serialize(writer, value.Integer.Value.ToString());
                return;
            }
            if (value.ValueClass != null)
            {
                serializer.Serialize(writer, value.ValueClass);
                return;
            }
            throw new Exception("Cannot marshal type ValueUnion");
        }

        public static readonly ValueUnionConverter Singleton = new ValueUnionConverter();
    }

    internal class DecodeArrayConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(List<long>);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            reader.Read();
            var value = new List<long>();
            while (reader.TokenType != JsonToken.EndArray)
            {
                var converter = ParseStringConverter.Singleton;
                var arrayItem = (long)converter.ReadJson(reader, typeof(long), null, serializer);
                value.Add(arrayItem);
                reader.Read();
            }
            return value;
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            var value = (List<long>)untypedValue;
            writer.WriteStartArray();
            foreach (var arrayItem in value)
            {
                var converter = ParseStringConverter.Singleton;
                converter.WriteJson(writer, arrayItem, serializer);
            }
            writer.WriteEndArray();
            return;
        }

        public static readonly DecodeArrayConverter Singleton = new DecodeArrayConverter();
    }

    internal class ParseStringConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(long) || t == typeof(long?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            long l;
            if (Int64.TryParse(value, out l))
            {
                return l;
            }
            throw new Exception("Cannot unmarshal type long");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (long)untypedValue;
            serializer.Serialize(writer, value.ToString());
            return;
        }

        public static readonly ParseStringConverter Singleton = new ParseStringConverter();
    }

    internal class ValueEnumConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(ValueEnum) || t == typeof(ValueEnum?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "Black":
                    return ValueEnum.Black;
                case "False":
                    return ValueEnum.False;
                case "Red":
                    return ValueEnum.Red;
                case "True":
                    return ValueEnum.True;
            }
            throw new Exception("Cannot unmarshal type ValueEnum");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (ValueEnum)untypedValue;
            switch (value)
            {
                case ValueEnum.Black:
                    serializer.Serialize(writer, "Black");
                    return;
                case ValueEnum.False:
                    serializer.Serialize(writer, "False");
                    return;
                case ValueEnum.Red:
                    serializer.Serialize(writer, "Red");
                    return;
                case ValueEnum.True:
                    serializer.Serialize(writer, "True");
                    return;
            }
            throw new Exception("Cannot marshal type ValueEnum");
        }

        public static readonly ValueEnumConverter Singleton = new ValueEnumConverter();
    }
}