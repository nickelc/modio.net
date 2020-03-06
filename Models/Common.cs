using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

using Modio.Models.Converters;

namespace Modio.Models
{
    public class Result<T>
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

    public class User
    {
        [JsonPropertyName("id")]
        public uint Id { get; set; }

        [JsonPropertyName("name_id")]
        public string? NameId { get; set; }

        [JsonPropertyName("username")]
        public string? Username { get; set; }

        [JsonPropertyName("avatar")]
        [JsonConverter(typeof(EmptyObjectConverter))]
        public Avatar? Avatar { get; set; }

        [JsonPropertyName("profile_url")]
        public Uri? ProfileUrl { get; set; }
    }

    public class Avatar
    {
        [JsonPropertyName("filename")]
        public string? Filename { get; set; }

        [JsonPropertyName("original")]
        public Uri? Original { get; set; }

        [JsonPropertyName("thumb_50x50")]
        public Uri? Thumb50x50 { get; set; }

        [JsonPropertyName("thumb_100x100")]
        public Uri? Thumb100x100 { get; set; }
    }

    public class Logo
    {
        [JsonPropertyName("filename")]
        public string? Filename { get; set; }

        [JsonPropertyName("original")]
        public Uri? Original { get; set; }

        [JsonPropertyName("thumb_320x180")]
        public Uri? Thumb320x180 { get; set; }

        [JsonPropertyName("thumb_640x360")]
        public Uri? Thumb640x360 { get; set; }

        [JsonPropertyName("thumb_1280x720")]
        public Uri? Thumb1280x720 { get; set; }
    }

    public enum Status
    {
        NotAccepted = 0,
        Accepted = 1,
        Deleted = 3,
    }
}
