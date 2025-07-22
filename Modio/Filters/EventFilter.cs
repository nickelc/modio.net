using Modio.Models;

namespace Modio.Filters;

/// <summary>
/// Used to filter mod events.
/// </summary>
public static class ModEventFilter
{
    /// <summary>
    /// Filter for event id.
    /// </summary>
    public static readonly NumericField<uint> Id = new("id");

    /// <summary>
    /// Filter for mod id.
    /// </summary>
    public static readonly NumericField<uint> ModId = new("mod_id");

    /// <summary>
    /// Filter for user id who performed the action.
    /// </summary>
    public static readonly NumericField<uint> UserId = new("user_id");

    /// <summary>
    /// Filter for unix timestamp of date the mod event occured.
    /// </summary>
    public static readonly NumericField<long> DateAdded = new("date_added");

    /// <summary>
    /// Filter for type of mod event that occured.
    /// </summary>
    public static readonly GenericTextField<ModEventType> EventType = new("event_type");
}

/// <summary>
/// Used to filter user events.
/// </summary>
public static class UserEventFilter
{
    /// <summary>
    /// Filter for event id.
    /// </summary>
    public static readonly NumericField<uint> Id = new("id");

    /// <summary>
    /// Filter for game id.
    /// </summary>
    public static readonly NumericField<uint> GameId = new("game_id");

    /// <summary>
    /// Filter for mod id.
    /// </summary>
    public static readonly NumericField<uint> ModId = new("mod_id");

    /// <summary>
    /// Filter for user id who performed the action.
    /// </summary>
    public static readonly NumericField<uint> UserId = new("user_id");

    /// <summary>
    /// Filter for unix timestamp of date the user event occured.
    /// </summary>
    public static readonly NumericField<long> DateAdded = new("date_added");

    /// <summary>
    /// Filter for type of user event that occured.
    /// </summary>
    public static readonly GenericTextField<UserEventType> EventType = new("event_type");
}