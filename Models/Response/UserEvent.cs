using System.Text.Json.Serialization;

namespace Modio.Models
{
    public class UserEvent
    {
        [JsonPropertyName("id")]
        public uint Id { get; set; }

        [JsonPropertyName("game_id")]
        public uint GameId { get; set; }

        [JsonPropertyName("mod_id")]
        public uint ModId { get; set; }

        [JsonPropertyName("user_id")]
        public uint UserId { get; set; }

        [JsonPropertyName("date_added")]
        public long DateAdded { get; set; }

        [JsonPropertyName("event_type")]
        public UserEventType EventType { get; set; }
    }

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum UserEventType
    {
        USER_TEAM_JOIN,
        USER_TEAM_LEAVE,
        USER_SUBSCRIBE,
        USER_UNSUBSCRIBE,
    }
}
