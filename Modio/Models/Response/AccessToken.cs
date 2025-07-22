using System.Text.Json.Serialization;

namespace Modio;

/// The user's access token and its expiry date.
public class AccessToken
{
    /// The user's access token.
    [JsonPropertyName("access_token")]
    public string? Value { get; set; }

    /// Unix timestamp of the date this token will expire.
    /// Default is one year from issue date.
    [JsonPropertyName("date_expires")]
    public long? ExpiredAt { get; set; }
}