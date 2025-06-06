using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Modio.Models
{
    /// <remarks>
    /// https://docs.mod.io/restapiref/#game-object
    /// </remarks>
    public class Game
    {
        /// <summary>
        /// Unique game id.
        /// </summary>
        [JsonPropertyName("id")]
        public uint Id { get; set; }

        /// <summary>
        /// Status of the game.
        /// </summary>
        [JsonPropertyName("status")]
        public Status Status { get; set; }

        /// <summary>
        /// The creator of the game.
        /// </summary>
        [JsonPropertyName("submitted_by")]
        public User? SubmittedBy { get; set; }

        /// <summary>
        /// Unix timestamp of date game was registered.
        /// </summary>
        [JsonPropertyName("date_added")]
        public long DateAdded { get; set; }

        /// <summary>
        /// Unix timestamp of date game was updated.
        /// </summary>
        [JsonPropertyName("date_updated")]
        public long DateUpdated { get; set; }

        /// <summary>
        /// Unix timestamp of date game was set live.
        /// </summary>
        [JsonPropertyName("date_live")]
        public long DateLive { get; set; }

        /// <summary>
        /// Name of the game.
        /// </summary>
        [JsonPropertyName("name")]
        public string? Name { get; set; }

        /// <summary>
        /// Subdomain for the game on mod.io. For example: https://gamename.mod.io
        /// </summary>
        [JsonPropertyName("name_id")]
        public string? NameId { get; set; }

        /// <summary>
        /// Word used to describe user-generated content (mods, items, addons etc).
        /// </summary>
        [JsonPropertyName("ugc_name")]
        public string? UgcName { get; set; }

        /// <summary>
        /// Summary of the games mod support.
        /// </summary>
        [JsonPropertyName("summary")]
        public string? Summary { get; set; }

        /// <summary>
        /// A guide about creating and uploading mods for this game to mod.io.
        /// </summary>
        [JsonPropertyName("instructions")]
        public string? Instructions { get; set; }

        /// <summary>
        /// Link to a mod.io guide, your modding wiki or a page where modders can learn how to make and submit mods to your games profile.
        /// </summary>
        [JsonPropertyName("instructions_url")]
        public Uri? InstructionsUrl { get; set; }

        /// <summary>
        /// URL to the game's mod.io page.
        /// </summary>
        [JsonPropertyName("profile_url")]
        public Uri? ProfileUrl { get; set; }

        /// <summary>
        /// The game's icon data.
        /// </summary>
        [JsonPropertyName("icon")]
        public Icon? Icon { get; set; }

        /// <summary>
        /// The game's logo data.
        /// </summary>
        [JsonPropertyName("logo")]
        public Logo? Logo { get; set; }

        /// <summary>
        /// The game's header data.
        /// </summary>
        [JsonPropertyName("header")]
        public Header? Header { get; set; }

        /// <summary>
        /// Presentation style used on the mod.io website.
        /// </summary>
        [JsonPropertyName("presentation_option")]
        public PresentationOption PresentationOption { get; set; }

        /// <summary>
        /// Submission process modders must follow.
        /// </summary>
        [JsonPropertyName("submission_option")]
        public SubmissionOption SubmissionOption { get; set; }

        /// <summary>
        /// Curation process used to approve mods.
        /// </summary>
        [JsonPropertyName("curation_option")]
        public CurationOption CurationOption { get; set; }

        /// <summary>
        /// Community features enabled on the mod.io website.
        /// </summary>
        [JsonPropertyName("community_options")]
        public CommunityOptions CommunityOptions { get; set; }

        /// <summary>
        /// Switch to allow developers to select if they flag their mods as containing mature content.
        /// </summary>
        [JsonPropertyName("maturity_options")]
        public MaturityOptions MaturityOptions { get; set; }

        /// <summary>
        /// Revenue capabilities mods can enable.
        /// </summary>
        [JsonPropertyName("revenue_options")]
        public RevenueOptions RevenueOptions { get; set; }

        /// <summary>
        /// Level of API access allowed by this game.
        /// </summary>
        [JsonPropertyName("api_access_options")]
        public ApiAccessOptions ApiAccessOptions { get; set; }

        /// <summary>
        /// Groups of tags configured by the game developer, that mods can select.
        /// </summary>
        [JsonPropertyName("tag_options")]
        public List<TagOption> TagOptions { get; set; } = new List<TagOption>();
    }

    /// <remarks>
    /// https://docs.mod.io/restapiref/#icon-object
    /// </remarks>
    public class Icon
    {
        /// <summary>
        /// Icon filename including extension.
        /// </summary>
        [JsonPropertyName("filename")]
        public string? Filename { get; set; }

        /// <summary>
        /// URL to the full-sized icon.
        /// </summary>
        [JsonPropertyName("original")]
        public Uri? Original { get; set; }

        /// <summary>
        /// URL to the small icon thumbnail.
        /// </summary>
        [JsonPropertyName("thumb_64x64")]
        public Uri? Thumb64x64 { get; set; }

        /// <summary>
        /// URL to the medium icon thumbnail.
        /// </summary>
        [JsonPropertyName("thumb_128x128")]
        public Uri? Thumb128x128 { get; set; }

        /// <summary>
        /// URL to the large icon thumbnail.
        /// </summary>
        [JsonPropertyName("thumb_256x256")]
        public Uri? Thumb256x256 { get; set; }
    }

    /// <remarks>
    /// https://docs.mod.io/restapiref/#header-image-object
    /// </remarks>
    public class Header
    {
        /// <summary>
        /// Header image filename including extension.
        /// </summary>
        [JsonPropertyName("filename")]
        public string? Filename { get; set; }

        /// <summary>
        /// URL to the full-sized header image.
        /// </summary>
        [JsonPropertyName("original")]
        public Uri? Original { get; set; }
    }

    /// <summary>
    /// Presentation style used on the mod.io website.
    /// </summary>
    public enum PresentationOption
    {
        /// <summary>
        /// Displays mods in a grid.
        /// </summary>
        GridView = 0,

        /// <summary>
        /// Displays mods in a table.
        /// </summary>
        TableView = 1,
    }

    /// <summary>
    /// Submission process modders must follow.
    /// </summary>
    public enum SubmissionOption
    {
        /// <summary>
        /// Mod uploads must occur via the API using a tool created by the game developers.
        /// </summary>
        ApiOnly = 0,

        /// <summary>
        /// Mod uploads can occur from anywhere, including the website and API.
        /// </summary>
        Anywhere = 1,
    }

    /// <summary>
    /// Curation process used to approve mods.
    /// </summary>
    public enum CurationOption
    {
        /// <summary>
        /// No curation: Mods are immediately available to play.
        /// </summary>
        No = 0,

        /// <summary>
        /// Paid curation: Mods are immediately available to play unless they choose to receive donations. These mods must be accepted to be listed.
        /// </summary>
        Paid = 1,

        /// <summary>
        /// Full curation: All mods must be accepted by someone to be listed.
        /// </summary>
        Full = 2,
    }

    /// <summary>
    /// Switch to allow developers to select if they flag their mods as containing mature content.
    /// </summary>
    public enum MaturityOptions
    {
        /// <summary>
        /// Don't allow (default).
        /// </summary>
        NotAllowed = 0,

        /// <summary>
        /// Allow
        /// </summary>
        Allowed = 1,
    }

    /// <summary>
    /// Community features enabled on the mod.io website.
    /// </summary>
    [Flags]
    public enum CommunityOptions : UInt32
    {
        /// <summary>
        /// All of the options below are disabled.
        /// </summary>
        NONE = 0,

        /// <summary>
        /// Enable comments.
        /// </summary>
        [Obsolete("Flag is replaced by `ALLOW_COMMENTS`.")]
        COMMENTS = 0b0001,

        /// <summary>
        /// Allow comments on mods.
        /// </summary>
        ALLOW_COMMENTS = 1,

        /// <summary>
        /// Enable guides.
        /// </summary>
        [Obsolete("Flag is replaced by `ALLOW_GUIDES`.")]
        GUIDES = 0b0010,

        /// <summary>
        /// Allow guides.
        /// </summary>
        ALLOW_GUIDES = 2,

        /// <summary>
        /// Disable website "subscribe to install" text.
        /// </summary>
        [Obsolete("Flag is replaced by `PIN_ON_HOMEPAGE`.")]
        DISABLE_SUBSCRIBE = 0b0100,

        /// <summary>
        /// Pin on homepage.
        /// </summary>
        PIN_ON_HOMEPAGE = 4,

        /// <summary>
        /// Show on homepage.
        /// </summary>
        SHOW_ON_HOMEPAGE = 8,

        /// <summary>
        /// Show more on homepage.
        /// </summary>
        SHOW_MORE_ON_HOMEPAGE = 16,

        /// <summary>
        /// Allow change status.
        /// </summary>
        ALLOW_CHANGE_STATUS = 32,

        /// <summary>
        /// Enable previews (Game must be hidden).
        /// </summary>
        ENABLE_PREVIEWS = 64,

        /// <summary>
        /// Enable preview URLs (preview must be enabled).
        /// </summary>
        ENABLE_PREVIEW_URLS = 128,

        /// <summary>
        /// Allow negative mod ratings.
        /// </summary>
        ALLOW_NEGATIVE_RATINGS = 256,

        /// <summary>
        /// Allow mods to be edited via web.
        /// </summary>
        ALLOW_WEB_EDIT_MODS = 512,

        /// <summary>
        /// Allow mod dependencies.
        /// </summary>
        ALLOW_MOD_DEPENDENCIES = 1024,

        /// <summary>
        /// Allow comments on guides.
        /// </summary>
        ALLOW_GUIDES_COMMENTS = 2048,
    }

    /// <summary>
    /// Revenue capabilities mods can enable.
    /// </summary>
    [Flags]
    public enum RevenueOptions : byte
    {
        /// <summary>
        /// All of the options below are disabled.
        /// </summary>
        NONE = 0,

        /// <summary>
        /// Allow mods to be sold.
        /// </summary>
        SELL = 0b0001,

        /// <summary>
        /// Allow mods to receive donations.
        /// </summary>
        DONATIONS = 0b0010,

        /// <summary>
        /// Allow mods to be traded.
        /// </summary>
        TRADE = 0b0100,

        /// <summary>
        /// Allow mods to control supply and scarcity.
        /// </summary>
        SCARCITY = 0b1000,
    }

    /// <summary>
    /// Level of API access allowed by a game.
    /// </summary>
    [Flags]
    public enum ApiAccessOptions : byte
    {
        /// <summary>
        /// All of the options below are disabled.
        /// </summary>
        NONE = 0,

        /// <summary>
        /// Allow 3rd parties to access this games API endpoints.
        /// </summary>
        ALLOW_THIRD_PARTY = 0b0001,

        /// <summary>
        /// Allow mods to be downloaded directly.
        /// </summary>
        ALLOW_DIRECT_DOWNLOADS = 0b0010,
    }

    /// <remarks>
    /// https://docs.mod.io/restapiref/#game-tag-option-object
    /// </remarks>
    public class TagOption
    {
        /// <summary>
        /// Name of the tag group.
        /// </summary>
        [JsonPropertyName("name")]
        public string? Name { get; set; }

        /// <summary>
        /// Can multiple tags be selected via 'checkboxes' or should only a single tag be selected via a 'dropdown'.
        /// </summary>
        [JsonPropertyName("type")]
        public string? Type { get; set; }

        /// <summary>
        /// Hidden tag group.
        /// </summary>
        [JsonPropertyName("hidden")]
        public bool Hidden { get; set; }

        /// <summary>
        /// List of tags in this group
        /// </summary>
        [JsonPropertyName("tags")]
        public List<string> Tags { get; set; } = new List<string>();
    }
}
