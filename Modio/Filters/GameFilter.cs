namespace Modio.Filters;

/// <summary>
/// Used to filter games.
/// </summary>
public class GameFilter
{
    /// <summary>
    /// Full-text filter for the name field.
    /// </summary>
    public static readonly FullTextField FullText = new();

    /// <summary>
    /// Filter for game id.
    /// </summary>
    public static readonly NumericField<uint> Id = new("id");

    /// <summary>
    /// Filter for name.
    /// </summary>
    public static readonly TextField Name = new("name");

    /// <summary>
    /// Filter for name_id.
    /// </summary>
    public static readonly TextField NameId = new("name_id");
}