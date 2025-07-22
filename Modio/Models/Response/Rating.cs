using System.Text.Json.Serialization;

namespace Modio.Models;

/// <remarks>
/// https://docs.mod.io/restapiref/#rating-object
/// </remarks>
public class Rating
{
    /// <summary>
    /// Unique game id.
    /// </summary>
    [JsonPropertyName("game_id")]
    public uint GameId { get; set; }

    /// <summary>
    /// Unique mod id.
    /// </summary>
    [JsonPropertyName("mod_id")]
    public uint ModId { get; set; }

    /// <summary>
    /// Mod rating value.
    ///  1 = Positive Rating
    /// -1 = Negative Rating
    /// </summary>
    [JsonPropertyName("rating")]
    public int Value { get; set; }

    /// <summary>
    /// Unix timestamp of date rating was submitted.
    /// </summary>
    [JsonPropertyName("date_added")]
    public long DateAdded { get; set; }
}