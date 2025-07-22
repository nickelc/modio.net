using System.Net.Http;

namespace Modio;

/// <summary>
/// See <see cref="AuthClient.External(EpicGamesAuth)"/>.
/// </summary>
///
/// <seealso>https://docs.mod.io/restapiref/#epic-games</seealso>
public class EpicGamesAuth
{
    /// <summary>
    /// The ID token supplied by the EOS SDK.
    /// </summary>
    public string IdToken { get; private set; }

    /// <summary>
    /// The users email address.
    /// </summary>
    public string? Email { get; set; }

    /// <summary>
    /// Has the user accepted the Terms of Use.
    /// </summary>
    public bool? TermsAccepted { get; set; }

    /// <summary>
    /// Unix timestamp of date in which the returned token will expire.
    /// </summary>
    public long? ExpiredAt { get; set; }

    /// <summary>
    /// Initializes a new instance of <see cref="EpicGamesAuth"/> with the required NSA ID.
    /// </summary>
    public EpicGamesAuth(string idToken)
    {
        IdToken = idToken;
    }

    internal HttpContent ToContent()
    {
        var parameters = new Parameters
        {
            {"id_token", IdToken},
        };
        if (Email is string email)
        {
            parameters.Add("email", email);
        }
        if (TermsAccepted is bool termsAccepted)
        {
            parameters.Add("terms_agreed", (termsAccepted ? "true" : "false"));
        }
        if (ExpiredAt is long expiredAt)
        {
            parameters.Add("date_expires", expiredAt.ToString());
        }
        return parameters.ToContent();
    }
}