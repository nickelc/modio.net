using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

using Modio.Models.Converters;

namespace Modio.Models
{
    class Result<T>
    {
        [JsonPropertyName("result_count")]
        public uint Count { get; set; }

        [JsonPropertyName("result_offset")]
        public uint Offset { get; set; }

        [JsonPropertyName("result_limit")]
        public uint Limit { get; set; }

        [JsonPropertyName("result_total")]
        public uint Total { get; set; }

        [JsonPropertyName("data")]
        public List<T> Data { get; set; } = new List<T>();
    }

    /// <remarks>
    /// https://docs.mod.io/#user-object
    /// </remarks>
    public class User
    {
        /// <summary>
        /// Unique id of the user.
        /// </summary>
        [JsonPropertyName("id")]
        public uint Id { get; set; }

        /// <summary>
        /// Path for the user on mod.io. For example: https://mod.io/members/name-id-here
        /// </summary>
        [JsonPropertyName("name_id")]
        public string? NameId { get; set; }

        /// <summary>
        /// Username of the user.
        /// </summary>
        [JsonPropertyName("username")]
        public string? Username { get; set; }

        /// <summary>
        /// The user's avatar data.
        /// </summary>
        [JsonPropertyName("avatar")]
        [JsonConverter(typeof(EmptyObjectConverter))]
        public Avatar? Avatar { get; set; }

        /// <summary>
        /// URL to the user's mod.io profile.
        /// </summary>
        [JsonPropertyName("profile_url")]
        public Uri? ProfileUrl { get; set; }
    }

    /// <summary>
    /// The user's avatar data.
    /// </summary>
    /// <remarks>
    /// https://docs.mod.io/#avatar-object
    /// </remarks>
    public class Avatar
    {
        /// <summary>
        /// Avatar filename including extension.
        /// </summary>
        [JsonPropertyName("filename")]
        public string? Filename { get; set; }

        /// <summary>
        /// URL to the full-sized avatar.
        /// </summary>
        [JsonPropertyName("original")]
        public Uri? Original { get; set; }

        /// <summary>
        /// URL to the small avatar thumbnail.
        /// </summary>
        [JsonPropertyName("thumb_50x50")]
        public Uri? Thumb50x50 { get; set; }

        /// <summary>
        /// URL to the medium avatar thumbnail.
        /// </summary>
        [JsonPropertyName("thumb_100x100")]
        public Uri? Thumb100x100 { get; set; }
    }

    /// <remarks>
    /// https://docs.mod.io/#logo-object
    /// </remarks>
    public class Logo
    {
        /// <summary>
        /// Logo filename including extension.
        /// </summary>
        [JsonPropertyName("filename")]
        public string? Filename { get; set; }

        /// <summary>
        /// URL to the full-sized logo.
        /// </summary>
        [JsonPropertyName("original")]
        public Uri? Original { get; set; }

        /// <summary>
        /// URL to the small logo thumbnail.
        /// </summary>
        [JsonPropertyName("thumb_320x180")]
        public Uri? Thumb320x180 { get; set; }

        /// <summary>
        /// URL to the medium logo thumbnail.
        /// </summary>
        [JsonPropertyName("thumb_640x360")]
        public Uri? Thumb640x360 { get; set; }

        /// <summary>
        /// URL to the large logo thumbnail.
        /// </summary>
        [JsonPropertyName("thumb_1280x720")]
        public Uri? Thumb1280x720 { get; set; }
    }

    /// <summary>
    /// Status of the game or mod.
    /// </summary>
    public enum Status
    {
        /// <summary>
        /// Resource is not accepted and not returned when browsing.
        /// </summary>
        NotAccepted = 0,

        /// <summary>
        /// Resource is accepted and returned via all endpoints.
        /// </summary>
        Accepted = 1,

        /// <summary>
        /// Resource is deleted and only returned via the <see cref="UserClient">User</see> endpoints.
        /// </summary>
        Deleted = 3,
    }
}
