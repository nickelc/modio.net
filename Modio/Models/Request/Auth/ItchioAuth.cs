using System.Net.Http;

namespace Modio
{
    /// <summary>
    /// See <see cref="AuthClient.External(ItchioAuth)"/>.
    /// </summary>
    ///
    /// <seealso>https://docs.mod.io/#authenticate-via-itch-io</seealso>
    public class ItchioAuth
    {
        /// <summary>
        /// The JWT Token provided by the itch.io desktop app.
        /// </summary>
        public string Token { get; private set; }

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
        /// Initializes a new instance of <see cref="ItchioAuth"/> with the required JWT Token.
        /// </summary>
        public ItchioAuth(string token)
        {
            Token = token;
        }

        internal HttpContent ToContent()
        {
            var parameters = new Parameters {
                {"itchio_token", Token},
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
}
