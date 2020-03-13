using System;
using System.Text.Json.Serialization;

namespace Modio.Models
{
    public class TeamMember
    {
        [JsonPropertyName("id")]
        public uint Id { get; set; }

        [JsonPropertyName("date_added")]
        public long DateAdded { get; set; }

        [JsonPropertyName("user")]
        public User? User { get; set; }

        [JsonPropertyName("level")]
        public TeamLevel Level { get; set; }

        [JsonPropertyName("position")]
        public string? Position { get; set; }
    }

    [Flags]
    public enum TeamLevel : byte
    {
        Moderator = 1,
        Manager = 4,
        Admin = 8,
    }
}
