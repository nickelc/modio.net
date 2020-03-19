using System.Text.Json.Serialization;

namespace Modio.Models
{
    /// See <see cref="UserClient.GetEvents(Filters.Filter?)"/>.
    public class UserEvent
    {
        /// <summary>
        /// Unique id of the event object.
        /// </summary>
        [JsonPropertyName("id")]
        public uint Id { get; set; }

        /// <summary>
        /// Unique id of the parent game.
        /// </summary>
        [JsonPropertyName("game_id")]
        public uint GameId { get; set; }

        /// <summary>
        /// Unique id of the parent mod.
        /// </summary>
        [JsonPropertyName("mod_id")]
        public uint ModId { get; set; }

        /// <summary>
        /// Unique id of the user who performed the action.
        /// </summary>
        [JsonPropertyName("user_id")]
        public uint UserId { get; set; }

        /// <summary>
        /// Unix timestamp of date mod was updated.
        /// </summary>
        [JsonPropertyName("date_added")]
        public long DateAdded { get; set; }

        /// <summary>
        /// Type of change that occurred.
        /// </summary>
        [JsonPropertyName("event_type")]
        public UserEventType EventType { get; set; }
    }

    /// <summary>
    /// Type of user event that occurred.
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum UserEventType
    {
        /// <summary>
        /// The user has joined a mod team.
        /// </summary>
        USER_TEAM_JOIN,

        /// <summary>
        /// The user has left a mod team.
        /// </summary>
        USER_TEAM_LEAVE,

        /// <summary>
        /// The user has subscribed to a mod.
        /// </summary>
        USER_SUBSCRIBE,

        /// <summary>
        /// The user has un-subscribed from a mod.
        /// </summary>
        USER_UNSUBSCRIBE,
    }
}
