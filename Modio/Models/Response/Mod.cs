using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

using Modio.Models.Converters;

namespace Modio.Models
{
    /// <remarks>
    /// https://docs.mod.io/restapiref/#mod-object
    /// </remarks>
    public class Mod
    {
        /// <summary>
        /// Unique mod id.
        /// </summary>
        [JsonPropertyName("id")]
        public uint Id { get; set; }

        /// <summary>
        /// Unique game id.
        /// </summary>
        [JsonPropertyName("game_id")]
        public uint GameId { get; set; }

        /// <summary>
        /// Status of the mod.
        /// </summary>
        [JsonPropertyName("status")]
        public Status Status { get; set; }

        /// <summary>
        /// Visibility of the mod.
        /// </summary>
        [JsonPropertyName("visible")]
        public Visibility Visible { get; set; }

        /// <summary>
        /// The creator of the mod.
        /// </summary>
        [JsonPropertyName("submitted_by")]
        public User? SubmittedBy { get; set; }

        /// <summary>
        /// Unix timestamp of date mod was registered.
        /// </summary>
        [JsonPropertyName("date_added")]
        public long DateAdded { get; set; }

        /// <summary>
        /// Unix timestamp of date mod was updated.
        /// </summary>
        [JsonPropertyName("date_updated")]
        public long DateUpdated { get; set; }

        /// <summary>
        /// Unix timestamp of date mod was set live.
        /// </summary>
        [JsonPropertyName("date_live")]
        public long DateLive { get; set; }

        /// <summary>
        /// Name of the mod.
        /// </summary>
        [JsonPropertyName("name")]
        public string? Name { get; set; }

        /// <summary>
        /// Path for the mod on mod.io. For example: https://gamename.mod.io/mod-name-id-here
        /// </summary>
        [JsonPropertyName("name_id")]
        public string? NameId { get; set; }

        /// <summary>
        /// Detailed description of the mod which allows HTML.
        /// </summary>
        [JsonPropertyName("description")]
        public string? Description { get; set; }

        /// <summary>
        /// <c>Description</c> property converted into plaintext.
        /// </summary>
        [JsonPropertyName("description_plaintext")]
        public string? DescriptionPlaintext { get; set; }

        /// <summary>
        /// Summary of the mod.
        /// </summary>
        [JsonPropertyName("summary")]
        public string? Summary { get; set; }

        /// <summary>
        /// The mod's logo data.
        /// </summary>
        [JsonPropertyName("logo")]
        public Logo? Logo { get; set; }

        /// <summary>
        /// URL to the mod's mod.io profile.
        /// </summary>
        [JsonPropertyName("profile_url")]
        public Uri? ProfileUrl { get; set; }

        /// <summary>
        /// Official homepage of the mod.
        /// </summary>
        [JsonPropertyName("homepage_url")]
        public Uri? HomepageUrl { get; set; }

        /// <summary>
        /// Maturity options flagged by the mod developer.
        /// </summary>
        [JsonPropertyName("maturity_option")]
        public MaturityOption MaturityOption { get; set; }

        /// <summary>
        /// Key-value metadata.
        /// </summary>
        [JsonPropertyName("metadata_kvp")]
        public Metadata? Metadata { get; set; }

        /// <summary>
        /// Metadata stored by the game developer.
        /// </summary>
        [JsonPropertyName("metadata_blob")]
        public string? MetadataBlob { get; set; }

        /// <summary>
        /// The mod's media links.
        /// </summary>
        [JsonPropertyName("media")]
        public Media Media { get; set; } = new Media();

        /// <summary>
        /// List of tags assigned to the mod.
        /// </summary>
        [JsonPropertyName("tags")]
        public List<Tag> Tags { get; set; } = new List<Tag>();

        /// <summary>
        /// The mod's statistics.
        /// </summary>
        [JsonPropertyName("stats")]
        public Statistics? Stats { get; set; }

        /// <summary>
        /// The mod's primary mod file.
        /// </summary>
        [JsonPropertyName("modfile")]
        [JsonConverter(typeof(EmptyObjectConverter))]
        public File? Modfile { get; set; }
    }

    /// <summary>
    /// Visibility of the mod.
    /// </summary>
    public enum Visibility
    {
        /// <summary>
        /// Hidden
        /// </summary>
        Hidden = 0,

        /// <summary>
        /// Public
        /// </summary>
        Public = 1,
    }

    /// <summary>
    /// Maturity options flagged by the mod developer.
    /// </summary>
    [Flags]
    public enum MaturityOption : byte
    {
        /// <summary>
        /// None set (default)
        /// </summary>
        None = 0,

        /// <summary>
        /// Alcohol
        /// </summary>
        Alcohol = 0b0001,

        /// <summary>
        /// Drugs
        /// </summary>
        Drugs = 0b0010,

        /// <summary>
        /// Violence
        /// </summary>
        Violence = 0b0100,

        /// <summary>
        /// Explicit
        /// </summary>
        Explicit = 0b1000,
    }

    /// <summary>
    /// The mod's media links.
    /// </summary>
    /// <remarks>
    /// https://docs.mod.io/restapiref/#mod-media-object
    /// </remarks>
    public class Media
    {
        /// <summary>
        /// List of YouTube links.
        /// </summary>
        [JsonPropertyName("youtube")]
        public List<String> YouTube { get; set; } = new List<string>();

        /// <summary>
        /// List of SketchFab links.
        /// </summary>
        [JsonPropertyName("sketchfab")]
        public List<String> Sketchfab { get; set; } = new List<string>();

        /// <summary>
        /// List of image objects (a gallery).
        /// </summary>
        [JsonPropertyName("images")]
        public List<Image> Images { get; set; } = new List<Image>();
    }

    /// <summary>
    /// The mod's image object (a gallery).
    /// </summary>
    /// <remarks>
    /// https://docs.mod.io/restapiref/#image-object
    /// </remarks>
    public class Image
    {
        /// <summary>
        /// Image filename including extension.
        /// </summary>
        [JsonPropertyName("filename")]
        public string? Filename { get; set; }

        /// <summary>
        /// URL to the full-sized image.
        /// </summary>
        [JsonPropertyName("original")]
        public Uri? Original { get; set; }

        /// <summary>
        /// URL to the image thumbnail.
        /// </summary>
        [JsonPropertyName("thumb_320x180")]
        public Uri? Thumb320x180 { get; set; }
    }

    /// <remarks>
    /// https://docs.mod.io/restapiref/#mod-dependencies-object
    /// </remarks>
    public class Dependency
    {
        /// <summary>
        /// Unique id of the mod that is the dependency.
        /// </summary>
        [JsonPropertyName("mod_id")]
        public uint ModId { get; set; }

        /// <summary>
        /// Unix timestamp of date the dependency was added.
        /// </summary>
        [JsonPropertyName("date_added")]
        public long DateAdded { get; set; }
    }

    /// <remarks>
    /// https://docs.mod.io/restapiref/#mod-tag-object
    /// </remarks>
    public class Tag
    {
        /// <summary>
        /// Tag name.
        /// </summary>
        [JsonPropertyName("name")]
        public string? Name { get; set; }

        /// <summary>
        /// Unix timestamp of date tag was applied.
        /// </summary>
        [JsonPropertyName("date_added")]
        public long DateAdded { get; set; }
    }

    /// <remarks>
    /// https://docs.mod.io/restapiref/#mod-stats-object
    /// </remarks>
    public class Statistics
    {
        /// <summary>
        /// Unique mod id.
        /// </summary>
        [JsonPropertyName("mod_id")]
        public uint ModId { get; set; }

        /// <summary>
        /// Number of total mod downloads.
        /// </summary>
        [JsonPropertyName("downloads_total")]
        public uint TotalDownloads { get; set; }

        /// <summary>
        /// Number of total users who have subscribed to the mod.
        /// </summary>
        [JsonPropertyName("subscribers_total")]
        public uint TotalSubscribers { get; set; }

        /// <summary>
        /// Current rank of the mod.
        /// </summary>
        [JsonPropertyName("popularity_rank_position")]
        public uint PopularityRank { get; set; }

        /// <summary>
        /// Number of ranking spots the current rank is measured against.
        /// </summary>
        [JsonPropertyName("popularity_rank_total_mods")]
        public uint PopularityTotal { get; set; }

        /// <summary>
        /// Number of times this mod has been rated.
        /// </summary>
        [JsonPropertyName("ratings_total")]
        public uint TotalRatings { get; set; }

        /// <summary>
        /// Number of positive ratings.
        /// </summary>
        [JsonPropertyName("ratings_positive")]
        public uint PositiveRatings { get; set; }

        /// <summary>
        /// Number of negative ratings.
        /// </summary>
        [JsonPropertyName("ratings_negative")]
        public uint NegativeRatings { get; set; }

        /// <summary>
        /// Number of positive ratings, divided by the total ratings to determine it’s percentage score.
        /// </summary>
        [JsonPropertyName("ratings_percentage_positive")]
        public uint PrecentageScore { get; set; }

        /// <summary>
        /// Overall rating of this item calculated using the Wilson score confidence interval.
        /// </summary>
        [JsonPropertyName("ratings_weighted_aggregate")]
        public float WeightedAggregate { get; set; }

        /// <summary>
        /// Textual representation of the rating in format:
        /// - Overwhelmingly Positive
        /// - Very Positive
        /// - Positive
        /// - Mostly Positive
        /// - Mixed
        /// - Negative
        /// - Mostly Negative
        /// - Very Negative
        /// - Overwhelmingly Negative
        /// - Unrated
        /// </summary>
        [JsonPropertyName("ratings_display_text")]
        public string? DisplayText { get; set; }

        /// <summary>
        /// Unix timestamp until this mods's statistics are considered stale.
        /// </summary>
        [JsonPropertyName("date_expires")]
        public long ExpiredAt { get; set; }
    }

    /// See <see cref="ModClient.GetEvents(Filters.Filter?)"/>.
    /// See <see cref="ModsClient.GetEvents(Filters.Filter?)"/>.
    public class ModEvent
    {
        /// <summary>
        /// Unique id of the event object.
        /// </summary>
        [JsonPropertyName("id")]
        public uint Id { get; set; }

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
        /// Unix timestamp of date the event occurred.
        /// </summary>
        [JsonPropertyName("date_added")]
        public long DateAdded { get; set; }

        /// <summary>
        /// Type of event that was triggered.
        /// </summary>
        [JsonPropertyName("event_type")]
        public ModEventType EventType { get; set; }
    }

    /// <summary>
    /// Type of mod event that was triggered.
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum ModEventType
    {
        /// <summary>
        /// The primary mod file of the mod was changed.
        /// </summary>
        MODFILE_CHANGED,

        /// <summary>
        /// A new mod is available.
        /// </summary>
        MOD_AVAILABLE,

        /// <summary>
        /// A mod is  no longer available.
        /// </summary>
        MOD_UNAVAILABLE,

        /// <summary>
        /// A mod was edited.
        /// </summary>
        MOD_EDITED,

        /// <summary>
        /// A mod was deleted.
        /// </summary>
        MOD_DELETED,

        /// <summary>
        /// A user has joined or left the mod team.
        /// </summary>
        MOD_TEAM_CHANGED,
    }
}
