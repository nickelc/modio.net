using System.Text.Json.Serialization;

namespace Modio.Models
{
    public class Game
    {
        [JsonPropertyName("id")]
        public uint Id { get; set; }

        [JsonPropertyName("name")]
        public string? Name { get; set; }
    }
}
