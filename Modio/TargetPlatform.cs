using System;

namespace Modio;

/// <summary>
/// Request header to signal the target platform where requests are originating from.
/// </summary>
///
/// <remarks>
/// https://docs.mod.io/restapiref/#targeting-a-platform
/// </remarks>
public sealed class TargetPlatform
{
    /// <summary>
    /// <c>X-Modio-Platform: android</c>
    /// </summary>
    public static readonly TargetPlatform Android = new("android");

    /// <summary>
    /// <c>X-Modio-Platform: ios</c>
    /// </summary>
    public static readonly TargetPlatform iOS = new("ios");

    /// <summary>
    /// <c>X-Modio-Platform: linux</c>
    /// </summary>
    public static readonly TargetPlatform Linux = new("linux");

    /// <summary>
    /// <c>X-Modio-Platform: mac</c>
    /// </summary>
    public static readonly TargetPlatform Mac = new("mac");

    /// <summary>
    /// <c>X-Modio-Platform: oculus</c>
    /// </summary>
    public static readonly TargetPlatform Oculus = new("oculus");

    /// <summary>
    /// <c>X-Modio-Platform: ps4</c>
    /// </summary>
    public static readonly TargetPlatform PlayStation4 = new("ps4");

    /// <summary>
    /// <c>X-Modio-Platform: ps5</c>
    /// </summary>
    public static readonly TargetPlatform PlayStation5 = new("ps5");

    /// <summary>
    /// <c>X-Modio-Platform: source</c>
    /// </summary>
    public static readonly TargetPlatform Source = new("source");

    /// <summary>
    /// <c>X-Modio-Platform: switch</c>
    /// </summary>
    public static readonly TargetPlatform Switch = new("switch");

    /// <summary>
    /// <c>X-Modio-Platform: windows</c>
    /// </summary>
    public static readonly TargetPlatform Windows = new("windows");

    /// <summary>
    /// <c>X-Modio-Platform: xboxone</c>
    /// </summary>
    public static readonly TargetPlatform XboxOne = new("xboxone");

    /// <summary>
    /// <c>X-Modio-Platform: xboxseriesx</c>
    /// </summary>
    public static readonly TargetPlatform XboxSeriesX = new("xboxseriesx");

    /// <summary>
    /// String value of the header value.
    /// </summary>
    public string Value { get; }

    private TargetPlatform(string value)
    {
        Value = value;
    }
}