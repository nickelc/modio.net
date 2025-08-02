using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Modio.Models;

/// <summary>
/// Request header to signal the target platform where requests are originating from.
/// </summary>
///
/// <remarks>
/// https://docs.mod.io/restapiref/#targeting-a-platform
/// </remarks>
[JsonConverter(typeof(TargetPlatformConverter))]
public sealed class TargetPlatform
{
    internal const string ANDROID = "android";
    internal const string IOS = "ios";
    internal const string LINUX = "linux";
    internal const string MAC = "mac";
    internal const string OCULUS = "oculus";
    internal const string PLAYSTATION4 = "ps4";
    internal const string PLAYSTATION5 = "ps5";
    internal const string SOURCE = "source";
    internal const string SWITCH = "switch";
    internal const string WINDOWS = "windows";
    internal const string XBOXONE = "xboxone";
    internal const string XBOXSERIESX = "xboxseriesx";

    /// <summary>
    /// <c>X-Modio-Platform: android</c>
    /// </summary>
    public static readonly TargetPlatform Android = new(ANDROID);

    /// <summary>
    /// <c>X-Modio-Platform: ios</c>
    /// </summary>
    public static readonly TargetPlatform iOS = new(IOS);

    /// <summary>
    /// <c>X-Modio-Platform: linux</c>
    /// </summary>
    public static readonly TargetPlatform Linux = new(LINUX);

    /// <summary>
    /// <c>X-Modio-Platform: mac</c>
    /// </summary>
    public static readonly TargetPlatform Mac = new(MAC);

    /// <summary>
    /// <c>X-Modio-Platform: oculus</c>
    /// </summary>
    public static readonly TargetPlatform Oculus = new(OCULUS);

    /// <summary>
    /// <c>X-Modio-Platform: ps4</c>
    /// </summary>
    public static readonly TargetPlatform PlayStation4 = new(PLAYSTATION4);

    /// <summary>
    /// <c>X-Modio-Platform: ps5</c>
    /// </summary>
    public static readonly TargetPlatform PlayStation5 = new(PLAYSTATION5);

    /// <summary>
    /// <c>X-Modio-Platform: source</c>
    /// </summary>
    public static readonly TargetPlatform Source = new(SOURCE);

    /// <summary>
    /// <c>X-Modio-Platform: switch</c>
    /// </summary>
    public static readonly TargetPlatform Switch = new(SWITCH);

    /// <summary>
    /// <c>X-Modio-Platform: windows</c>
    /// </summary>
    public static readonly TargetPlatform Windows = new(WINDOWS);

    /// <summary>
    /// <c>X-Modio-Platform: xboxone</c>
    /// </summary>
    public static readonly TargetPlatform XboxOne = new(XBOXONE);

    /// <summary>
    /// <c>X-Modio-Platform: xboxseriesx</c>
    /// </summary>
    public static readonly TargetPlatform XboxSeriesX = new(XBOXSERIESX);

    /// <summary>
    /// String value of the header value.
    /// </summary>
    public string Value { get; }

    internal TargetPlatform(string value)
    {
        Value = value;
    }
}

class TargetPlatformConverter : JsonConverter<TargetPlatform>
{
    public override TargetPlatform? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        return reader.GetString() switch
        {
            null => null,
            TargetPlatform.ANDROID => TargetPlatform.Android,
            TargetPlatform.IOS => TargetPlatform.iOS,
            TargetPlatform.LINUX => TargetPlatform.Linux,
            TargetPlatform.MAC => TargetPlatform.Mac,
            TargetPlatform.OCULUS => TargetPlatform.Oculus,
            TargetPlatform.PLAYSTATION4 => TargetPlatform.PlayStation4,
            TargetPlatform.PLAYSTATION5 => TargetPlatform.PlayStation5,
            TargetPlatform.SOURCE => TargetPlatform.Source,
            TargetPlatform.SWITCH => TargetPlatform.Switch,
            TargetPlatform.WINDOWS => TargetPlatform.Windows,
            TargetPlatform.XBOXONE => TargetPlatform.XboxOne,
            TargetPlatform.XBOXSERIESX => TargetPlatform.XboxSeriesX,
            string value => new TargetPlatform(value),
        };
    }

    public override void Write(Utf8JsonWriter writer, TargetPlatform value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.Value);
    }
}