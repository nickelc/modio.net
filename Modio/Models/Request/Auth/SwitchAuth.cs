using System.Net.Http;

namespace Modio
{
    /// <summary>
    /// See <see cref="AuthClient.External(SwitchAuth)"/>.
    /// </summary>
    ///
    /// <seealso>https://docs.mod.io/#authenticate-via-switch</seealso>
    public class SwitchAuth
    {
        /// <summary>
        /// The NSA ID supplied by the Nintendo Switch SDK.
        /// </summary>
        public string IdToken { get; private set; }

        /// <summary>
        /// The users email address.
        /// </summary>
        public string? Email { get; set; }

        /// <summary>
        /// Unix timestamp of date in which the returned token will expire.
        /// </summary>
        public long? ExpiredAt { get; set; }

        /// <summary>
        /// Initializes a new instance of <see cref="SwitchAuth"/> with the required NSA ID.
        /// </summary>
        public SwitchAuth(string idToken)
        {
            IdToken = idToken;
        }

        internal HttpContent ToContent()
        {
            var parameters = new Parameters {
                {"id_token", IdToken},
            };
            if (Email is string email)
            {
                parameters.Add("email", email);
            }
            if (ExpiredAt is long expiredAt)
            {
                parameters.Add("date_expires", expiredAt.ToString());
            }
            return parameters.ToContent();
        }
    }
}
