using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

using Modio.Models.Converters;

namespace Modio.Models
{
    public class Mod
    {
        [JsonPropertyName("id")]
        public uint Id { get; set; }

        [JsonPropertyName("game_id")]
        public uint GameId { get; set; }

        [JsonPropertyName("status")]
        public Status Status { get; set; }

        [JsonPropertyName("visible")]
        public Visibility Visible { get; set; }

        [JsonPropertyName("submitted_by")]
        public User? SubmittedBy { get; set; }

        [JsonPropertyName("date_added")]
        public long DateAdded { get; set; }

        [JsonPropertyName("date_updated")]
        public long DateUpdated { get; set; }

        [JsonPropertyName("date_live")]
        public long DateLive { get; set; }

        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("name_id")]
        public string? NameId { get; set; }

        [JsonPropertyName("description")]
        public string? Description { get; set; }

        [JsonPropertyName("description_plaintext")]
        public string? DescriptionPlaintext { get; set; }

        [JsonPropertyName("summary")]
        public string? Summary { get; set; }

        [JsonPropertyName("logo")]
        public Logo? Logo { get; set; }

        [JsonPropertyName("profile_url")]
        public Uri? ProfileUrl { get; set; }

        [JsonPropertyName("homepage_url")]
        public Uri? HomepageUrl { get; set; }

        [JsonPropertyName("maturity_option")]
        public MaturityOption MaturityOption { get; set; }

        [JsonPropertyName("metadata_kvp")]
        public Metadata? Metadata { get; set; }

        [JsonPropertyName("metadata_blob")]
        public string? MetadataBlob { get; set; }

        [JsonPropertyName("media")]
        public Media Media { get; set; } = new Media();

        [JsonPropertyName("tags")]
        public List<Tag> Tags { get; set; } = new List<Tag>();

        [JsonPropertyName("stats")]
        public Statistics? Stats { get; set; }

        [JsonPropertyName("modfile")]
        [JsonConverter(typeof(EmptyObjectConverter))]
        public File? Modfile { get; set; }
    }

    public enum Visibility
    {
        Hidden = 0,
        Public = 1,
    }

    [Flags]
    public enum MaturityOption : byte
    {
        None = 0,
        Alcohol = 0b0001,
        Drugs = 0b0010,
        Violence = 0b0100,
        Explicit = 0b1000,
    }

    public class Media
    {
        [JsonPropertyName("youtube")]
        public List<String> YouTube { get; set; } = new List<string>();

        [JsonPropertyName("sketchfab")]
        public List<String> Sketchfab { get; set; } = new List<string>();

        [JsonPropertyName("images")]
        public List<Image> Images { get; set; } = new List<Image>();

    }

    public class Image
    {
        [JsonPropertyName("filename")]
        public string? Filename { get; set; }

        [JsonPropertyName("original")]
        public Uri? Original { get; set; }

        [JsonPropertyName("thumb_320x180")]
        public Uri? Thumb320x180 { get; set; }
    }

    public class Dependency
    {
        public uint ModId { get; set; }

        public long DateAdded { get; set; }
    }

    public class Tag
    {
        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("date_added")]
        public long DateAdded { get; set; }
    }

    public class Statistics
    {
        [JsonPropertyName("mod_id")]
        public uint ModId { get; set; }

        [JsonPropertyName("downloads_total")]
        public uint TotalDownloads { get; set; }

        [JsonPropertyName("subscribers_total")]
        public uint TotalSubscribers { get; set; }

        [JsonPropertyName("popularity_rank_position")]
        public uint PopularityRank { get; set; }

        [JsonPropertyName("popularity_rank_total_mods")]
        public uint PopularityTotal { get; set; }

        [JsonPropertyName("ratings_total")]
        public uint TotalRatings { get; set; }

        [JsonPropertyName("ratings_positive")]
        public uint PositiveRatings { get; set; }

        [JsonPropertyName("ratings_negative")]
        public uint NegativeRatings { get; set; }

        [JsonPropertyName("ratings_percentage_positive")]
        public uint PrecentageScore { get; set; }

        [JsonPropertyName("ratings_weighted_aggregate")]
        public float WeightedAggregate { get; set; }

        [JsonPropertyName("ratings_display_text")]
        public string? DisplayText { get; set; }

        [JsonPropertyName("date_expires")]
        public long ExpiredAt { get; set; }
    }

    public class ModEvent
    {
        [JsonPropertyName("id")]
        public uint Id { get; set; }

        [JsonPropertyName("mod_id")]
        public uint ModId { get; set; }

        [JsonPropertyName("user_id")]
        public uint UserId { get; set; }

        [JsonPropertyName("date_added")]
        public long DateAdded { get; set; }

        [JsonPropertyName("event_type")]
        public ModEventType EventType { get; set; }
    }

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum ModEventType
    {
        MODFILE_CHANGED,
        MOD_AVAILABLE,
        MOD_UNAVAILABLE,
        MOD_EDITED,
        MOD_DELETED,
        MOD_TEAM_CHANGED,
    }
}
