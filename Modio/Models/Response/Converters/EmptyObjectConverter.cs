using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Modio.Models.Converters;

/// Deserialize empty objects for optional properties as `null`.
///
/// The mod.io API returns `"field": {}` for some optional properties instead of
/// returning `"field": null` or omitting the field.
///
/// This behaviour results in deserialization issues with mods without files
/// and user profiles without avatars.
internal class EmptyObjectConverter : JsonConverter<object?>
{
    public override bool CanConvert(Type typeToConvert)
    {
        return true;
    }

    public override object? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var restore = reader;
        if (reader.Read() && reader.TokenType == JsonTokenType.EndObject)
        {
            return null;
        }
        reader = restore;
        return JsonSerializer.Deserialize(ref reader, typeToConvert, options);
    }

    public override void Write(Utf8JsonWriter writer, object? value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value, options);
    }
}