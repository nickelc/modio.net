using System.Net.Http;

namespace Modio;

/// <summary>
/// Used to rate a Mod.
/// </summary>
public enum NewRating
{
    /// <summary>
    /// Submits a positive rating.
    /// </summary>
    Positive = 1,

    /// <summary>
    /// Submits a negative rating.
    /// </summary>
    Negative = -1,

    /// <summary>
    /// Reset a rating.
    /// </summary>
    None = 0,
}

internal static class NewRatingMethods
{
    public static HttpContent ToContent(this NewRating rating)
    {
        var parameters = new Parameters
        {
            {"rating", ((int)rating).ToString()},
        };
        return parameters.ToContent();
    }
}