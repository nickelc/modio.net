using System.Text.Json.Serialization;

namespace Modio.Models
{
    public class Comment
    {
        [JsonPropertyName("id")]
        public uint Id { get; set; }

        [JsonPropertyName("mod_id")]
        public uint ModId { get; set; }

        [JsonPropertyName("user")]
        public User? SubmittedBy { get; set; }

        [JsonPropertyName("date_added")]
        public long DateAdded { get; set; }

        [JsonPropertyName("reply_id")]
        public uint ReplyId { get; set; }

        [JsonPropertyName("thread_position")]
        public string? ThreadPosition { get; set; }

        [JsonPropertyName("karma")]
        public int Karma { get; set; }

        [JsonPropertyName("content")]
        public string? Content { get; set; }
    }
}
