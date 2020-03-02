using System.Text.Json.Serialization;

namespace Modio.Models
{
    public class File
    {
        [JsonPropertyName("id")]
        public uint Id { get; set; }

        [JsonPropertyName("filename")]
        public string? Filename { get; set; }
    }
}
