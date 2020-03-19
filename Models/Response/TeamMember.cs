using System;
using System.Text.Json.Serialization;

namespace Modio.Models
{
    /// <remarks>
    /// https://docs.mod.io/#team-member-object
    /// </remarks>
    public class TeamMember
    {
        /// <summary>
        /// Unique team member id.
        /// </summary>
        [JsonPropertyName("id")]
        public uint Id { get; set; }

        /// <summary>
        /// Unix timestamp of the date the user was added to the team.
        /// </summary>
        [JsonPropertyName("date_added")]
        public long DateAdded { get; set; }

        /// <summary>
        /// User details of the team member.
        /// </summary>
        [JsonPropertyName("user")]
        public User? User { get; set; }

        /// <summary>
        /// Level of permission the user has.
        /// </summary>
        [JsonPropertyName("level")]
        public TeamLevel Level { get; set; }

        /// <summary>
        /// Custom title given to the user in this team.
        /// </summary>
        [JsonPropertyName("position")]
        public string? Position { get; set; }
    }

    /// <summary>
    /// Level of permission the user has.
    /// </summary>
    [Flags]
    public enum TeamLevel : byte
    {
        /// <summary>
        /// Moderators can moderate comments and content attached.
        /// </summary>
        Moderator = 1,

        /// <summary>
        /// Moderator access, including uploading builds and editing settings except supply and team members.
        /// </summary>
        Manager = 4,

        /// <summary>
        /// Full access, including editing the supply and team.
        /// </summary>
        Admin = 8,
    }
}
