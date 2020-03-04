using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Modio.Models
{
    public class Game
    {
        [JsonPropertyName("id")]
        public uint Id { get; set; }

        [JsonPropertyName("status")]
        public Status Status { get; set; }

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

        [JsonPropertyName("ugc_name")]
        public string? UgcName { get; set; }

        [JsonPropertyName("summary")]
        public string? Summary { get; set; }

        [JsonPropertyName("instructions")]
        public string? Instructions { get; set; }

        [JsonPropertyName("instructions_url")]
        public Uri? InstructionsUrl { get; set; }

        [JsonPropertyName("profile_url")]
        public Uri? ProfileUrl { get; set; }

        [JsonPropertyName("icon")]
        public Icon? Icon { get; set; }

        [JsonPropertyName("logo")]
        public Logo? Logo { get; set; }

        [JsonPropertyName("header")]
        public Header? Header { get; set; }

        [JsonPropertyName("presentation_option")]
        public PresentationOption PresentationOption { get; set; }

        [JsonPropertyName("submission_option")]
        public SubmissionOption SubmissionOption { get; set; }

        [JsonPropertyName("curation_option")]
        public CurationOption CurationOption { get; set; }

        [JsonPropertyName("community_options")]
        public byte CommunityOptions { get; set; }

        [JsonPropertyName("revenue_options")]
        public byte RevenueOptions { get; set; }

        [JsonPropertyName("api_access_options")]
        public byte ApiAccessOptions { get; set; }

        [JsonPropertyName("tag_options")]
        public List<TagOption> TagOptions { get; set; } = new List<TagOption>();
    }

    public class Icon
    {
        [JsonPropertyName("filename")]
        public string? Filename { get; set; }

        [JsonPropertyName("original")]
        public Uri? Original { get; set; }

        [JsonPropertyName("thumb_64x64")]
        public Uri? Thumb64x64 { get; set; }

        [JsonPropertyName("thumb_128x128")]
        public Uri? Thumb128x128 { get; set; }

        [JsonPropertyName("thumb_256x256")]
        public Uri? Thumb256x256 { get; set; }
    }

    public class Header
    {
        [JsonPropertyName("filename")]
        public string? Filename { get; set; }

        [JsonPropertyName("original")]
        public Uri? Original { get; set; }
    }

    public enum PresentationOption
    {
        GridView = 0,
        TableView = 1,
    }

    public enum SubmissionOption
    {
        ApiOnly = 0,
        Anywhere = 1,
    }

    public enum CurationOption
    {
        No = 0,
        Paid = 1,
        Full = 2,
    }
    public enum MaturityOptions
    {
        NotAllowed = 0,
        Allowed = 1,
    }

    public class TagOption
    {
        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("type")]
        public string? Type { get; set; }

        [JsonPropertyName("hidden")]
        public bool Hidden { get; set; }

        [JsonPropertyName("tags")]
        public List<string> Tags { get; set; } = new List<string>();
    }
}
