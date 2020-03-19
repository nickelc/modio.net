using System.Text.Json.Serialization;

namespace Modio.Models
{
    /// <remarks>
    /// https://docs.mod.io/#comment-object
    /// </remarks>
    public class Comment
    {
        /// <summary>
        /// Unique id of the comment.
        /// </summary>
        [JsonPropertyName("id")]
        public uint Id { get; set; }

        /// <summary>
        /// Unique id of the parent mod.
        /// </summary>
        [JsonPropertyName("mod_id")]
        public uint ModId { get; set; }

        /// <summary>
        /// User details of the author.
        /// </summary>
        [JsonPropertyName("user")]
        public User? SubmittedBy { get; set; }

        /// <summary>
        /// Unix timestamp of date the comment was posted.
        /// </summary>
        [JsonPropertyName("date_added")]
        public long DateAdded { get; set; }

        /// <summary>
        /// Id of the parent comment this comment is replying to.
        /// </summary>
        [JsonPropertyName("reply_id")]
        public uint ReplyId { get; set; }

        /// <summary>
        /// Levels of nesting in a comment thread.
        /// </summary>
        [JsonPropertyName("thread_position")]
        public string? ThreadPosition { get; set; }

        /// <summary>
        /// Karma received for the comment.
        /// </summary>
        [JsonPropertyName("karma")]
        public int Karma { get; set; }

        /// <summary>
        /// Content of the comment.
        /// </summary>
        [JsonPropertyName("content")]
        public string? Content { get; set; }
    }
}
