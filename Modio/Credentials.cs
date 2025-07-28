namespace Modio;

/// <summary>
/// Credentials used for API authentication.
/// </summary>
public class Credentials
{
    /// <summary>
    /// The required API key.
    /// </summary>
    public string ApiKey { get; private set; }

    /// <summary>
    /// The Optional OAuth2 access token.
    /// </summary>
    public string? Token { get; private set; }

    /// <summary>
    /// Initializes a new instance of <see cref="Credentials"/> with an API key.
    /// </summary>
    public Credentials(string apiKey)
    {
        Ensure.ArgumentNotNullOrEmptyString(apiKey, nameof(apiKey));

        ApiKey = apiKey;
    }

    /// <summary>
    /// Initializes a new instance of <see cref="Credentials"/> with an API key
    /// and an OAuth2 access token.
    /// </summary>
    public Credentials(string apiKey, string token) : this(apiKey)
    {
        Ensure.ArgumentNotNullOrEmptyString(token, nameof(token));

        Token = token;
    }
}