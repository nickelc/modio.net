using System.Text.Json.Serialization;

namespace Modio
{
    public class AccessToken
    {
        [JsonPropertyName("access_token")]
        public string? Value { get; set; }

        [JsonPropertyName("date_expires")]
        public long? ExpiredAt { get; set; }
    }
}
