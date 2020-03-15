using System.Text.Json.Serialization;

namespace Modio.Models
{
    public class Rating
    {
        [JsonPropertyName("game_id")]
        public uint GameId { get; set; }

        [JsonPropertyName("mod_id")]
        public uint ModId { get; set; }

        [JsonPropertyName("rating")]
        public int Value { get; set; }

        [JsonPropertyName("date_added")]
        public long DateAdded { get; set; }
    }
}
