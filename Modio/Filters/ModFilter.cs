using System.Collections.Generic;
using System.Linq;

namespace Modio.Filters;

/// <summary>
/// Used to filter mods.
/// </summary>
public static class ModFilter
{
    /// <summary>
    /// Full-text filter for the name field.
    /// </summary>
    public static readonly FullTextField FullText = new();

    /// <summary>
    /// Filter for mod id.
    /// </summary>
    public static readonly NumericField<uint> Id = new("id");

    /// <summary>
    /// Filter for game id.
    /// </summary>
    public static readonly NumericField<uint> GameId = new("game_id");

    /// <summary>
    /// Filter for status.
    /// </summary>
    public static readonly NumericField<uint> Status = new("status");

    /// <summary>
    /// Filter for visble.
    /// </summary>
    public static readonly NumericField<uint> Visible = new("visible");

    /// <summary>
    /// Filter for submitted_by.
    /// </summary>
    public static readonly NumericField<uint> SubmitterId = new("submitted_by");

    /// <summary>
    /// Filter for date_added.
    /// </summary>
    public static readonly NumericField<uint> DateAdded = new("date_added");

    /// <summary>
    /// Filter for date_updated.
    /// </summary>
    public static readonly NumericField<uint> DateUpdated = new("date_updated");

    /// <summary>
    /// Filter for date_live.
    /// </summary>
    public static readonly NumericField<uint> DateLive = new("date_live");

    /// <summary>
    /// Filter for maturity_option.
    /// </summary>
    public static readonly NumericField<uint> MaturityOption = new("maturity_option");

    /// <summary>
    /// Filter for name.
    /// </summary>
    public static readonly TextField Name = new("name");

    /// <summary>
    /// Filter for name_id.
    /// </summary>
    public static readonly TextField NameId = new("name_id");

    /// <summary>
    /// Filter for summary.
    /// </summary>
    public static readonly TextField Summary = new("summary");

    /// <summary>
    /// Filter for description.
    /// </summary>
    public static readonly TextField Description = new("description");

    /// <summary>
    /// Filter for homepage_url.
    /// </summary>
    public static readonly TextField HomepageUrl = new("homepage_url");

    /// <summary>
    /// Filter for modfile.
    /// </summary>
    public static readonly NumericField<uint> ModfileId = new("modfile");

    /// <summary>
    /// Filter for metadata_blob.
    /// </summary>
    public static readonly TextField MetadataBlob = new("metadata_blob");

    /// <summary>
    /// Filter for metadata_kvp.
    /// </summary>
    public static readonly MetadataField MetadataKeyValue = new();

    /// <summary>
    /// Filter for tags.
    /// </summary>
    public static readonly TextField Tags = new("tags");

    /// <summary>
    /// Sort results by most downloads.
    /// </summary>
    public static readonly SortField Downloads = new("downloads");

    /// <summary>
    /// Sort results by popularity.
    /// </summary>
    public static readonly SortField Popular = new("popular");

    /// <summary>
    /// Sort results by weighted rating.
    /// </summary>
    public static readonly SortField Rating = new("rating");

    /// <summary>
    /// Sort results by most subscribers.
    /// </summary>
    public static readonly SortField Subscribers = new("subscribers");
}

/// <summary>
/// Specialized field for the `metadata_kvp` filter.
/// </summary>
public sealed class MetadataField : FilterField
{
    internal MetadataField() : base("metadata_kvp") { }

    /// <summary>
    /// Returns a new Filter for <paramref name="key"/> and <paramref name="value"/>.
    /// </summary>
    public Filter HasKeyValue(string key, string value)
    {
        var name = Operator.Equal.ToName(Field);
        return new Filter(name, $"{key}:{value}");
    }

    /// <summary>
    /// Returns a new Filter for the tuples.
    /// </summary>
    public Filter HasKeyValue(IEnumerable<(string Key, string Value)> pairs)
    {
        var name = Operator.Equal.ToName(Field);
        var values = pairs.Select(kvp => string.Format("{0}:{1}", kvp.Key, kvp.Value));
        return new Filter(name, string.Join(",", values));
    }

    /// <summary>
    /// Returns a new Filter for entries of the dictionary.
    /// </summary>
    public Filter HasKeyValue(IDictionary<string, string> pairs)
    {
        var name = Operator.Equal.ToName(Field);
        var values = pairs.Select(kvp => string.Format("{0}:{1}", kvp.Key, kvp.Value));
        return new Filter(name, string.Join(",", values));
    }
}