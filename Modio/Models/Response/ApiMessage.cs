using System.Text.Json.Serialization;

namespace Modio.Models;

class ApiMessage
{
    [JsonPropertyName("code")]
    public uint? Code { get; set; }

    [JsonPropertyName("message")]
    public string? Message { get; set; }
}