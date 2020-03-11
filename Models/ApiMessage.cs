using System.Text.Json.Serialization;

namespace Modio.Models
{
    class ApiMessage
    {
        [JsonPropertyName("message")]
        public string? Message { get; set; }
    }
}
