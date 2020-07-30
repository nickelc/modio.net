using System.Net.Http;

namespace Modio
{
    /// <summary>
    /// See <see cref="AuthClient.External(XboxAuth)"/>.
    /// </summary>
    ///
    /// <seealso>https://docs.mod.io/#authenticate-via-xbox-live</seealso>
    public class XboxAuth
    {
        /// <summary>
        /// The Xbox Live token returned from calling <c>GetTokenAndSignatureAsync("POST", "https://api.mod.io")</c>.
        /// </summary>
        public string Token { get; private set; }

        /// <summary>
        /// The users email address.
        /// </summary>
        public string? Email { get; set; }

        /// <summary>
        /// Unix timestamp of date in which the returned token will expire.
        /// </summary>
        public long? ExpiredAt { get; set; }

        /// <summary>
        /// Initializes a new instance of <see cref="XboxAuth"/> with the required data.
        /// </summary>
        public XboxAuth(string token)
        {
            Token = token;
        }

        internal HttpContent ToContent()
        {
            var parameters = new Parameters {
                {"xbox_token", Token},
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
