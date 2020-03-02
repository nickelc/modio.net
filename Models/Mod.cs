using System.Text.Json.Serialization;

namespace Modio.Models
{
    public class Mod
    {
        [JsonPropertyName("id")]
        public uint Id { get; set; }

        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("metadata_kvp")]
        public Metadata? Metadata { get; set; }
    }
}
