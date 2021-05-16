using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Modio.Models
{
    /// <remarks>
    /// https://docs.mod.io/#metadata-kvp-object
    /// </remarks>
    [JsonConverter(typeof(MetadataConverter))]
    public class Metadata : Dictionary<string, List<string>> { }

    internal class MetadataConverter : JsonConverter<Metadata>
    {
        class KVP
        {
            [JsonPropertyName("metakey")]
            public string? Key { get; set; }
            [JsonPropertyName("metavalue")]
            public string? Value { get; set; }
        }

        public override Metadata Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType != JsonTokenType.StartArray)
            {
                throw new JsonException("json array expected");
            }

            var value = new Metadata();

            while (reader.Read())
            {
                if (reader.TokenType == JsonTokenType.EndArray)
                {
                    return value;
                }

                var kvp = JsonSerializer.Deserialize<KVP>(ref reader);

                if (kvp!.Key == null || kvp.Value == null)
                {
                    throw new JsonException("invalid metadata kvp entry");
                }

                value.GetOrCreate(kvp.Key).Add(kvp.Value);
            }

            throw new JsonException();
        }

        public override void Write(Utf8JsonWriter writer, Metadata value, JsonSerializerOptions options)
        {
            writer.WriteStartArray();
            foreach (var (key, list) in value)
            {
                foreach (var v in list)
                {
                    var kvp = new KVP { Key = key, Value = v };
                    JsonSerializer.Serialize<KVP>(writer, kvp, options);
                }
            }
            writer.WriteEndArray();
        }
    }
}
