using System;
using System.Text.Json.Serialization;

namespace Modio.Models
{
    /// <remarks>
    /// https://docs.mod.io/#terms-object
    /// </remarks>
    public class Terms
    {
        /// <summary>
        /// Terms text in plaintext formatting.
        /// </summary>
        [JsonPropertyName("plaintext")]
        public string? Plaintext { get; set; }

        /// <summary>
        /// Terms text in HTML formatting.
        /// </summary>
        [JsonPropertyName("html")]
        public string? Html { get; set; }

        /// <summary>
        /// Links to embed into the Terms.
        /// </summary>
        [JsonPropertyName("links")]
        public Links? Links { get; set; }
    }

    /// <remarks>
    /// https://docs.mod.io/#terms-object
    /// </remarks>
    public class Links
    {
        /// <summary>
        /// Link to the mod.io website
        /// </summary>
        [JsonPropertyName("website")]
        public Link? Website { get; set; }

        /// <summary>
        /// Link to the Terms of Use.
        /// </summary>
        [JsonPropertyName("terms")]
        public Link? Terms { get; set; }

        /// <summary>
        /// Link to the privacy policy.
        /// </summary>
        [JsonPropertyName("privacy")]
        public Link? Privacy { get; set; }

        /// <summary>
        /// Link to manage the user account.
        /// </summary>
        [JsonPropertyName("manage")]
        public Link? Manage { get; set; }
    }

    /// <remarks>
    /// https://docs.mod.io/#terms-object
    /// </remarks>
    public class Link
    {
        /// <summary>
        /// Text for the link.
        /// </summary>
        [JsonPropertyName("text")]
        public string? Text { get; set; }

        /// <summary>
        /// The link to the website.
        /// </summary>
        [JsonPropertyName("url")]
        public Uri? Url { get; set; }

        /// <summary>
        /// Is the link required.
        /// </summary>
        [JsonPropertyName("required")]
        public bool Required { get; set; }
    }
}
