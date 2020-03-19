using System.Net.Http;

namespace Modio
{
    /// <summary>
    /// See <see cref="AuthClient.External(OculusAuth)"/>.
    /// </summary>
    ///
    /// <seealso>https://docs.mod.io/#authenticate-via-oculus</seealso>
    public class OculusAuth
    {
        /// <summary>
        /// The user's access token, providing by calling <c>ovr_User_GetAccessToken()</c> from the Oculus SDK.
        /// </summary>
        public string Token { get; private set; }

        /// <summary>
        /// The user's Oculus id providing by calling <c>ovr_GetLoggedInUserID()</c> from the Oculus SDK.
        /// </summary>
        public uint UserId { get; private set; }

        /// <summary>
        /// The nonce provided by calling <c>ovr_User_GetUserProof()</c> from the Oculus SDK.
        /// </summary>
        public string Nonce { get; private set; }

        /// <summary>
        /// The users email address.
        /// </summary>
        public string? Email { get; set; }

        /// <summary>
        /// Unix timestamp of date in which the returned token will expire.
        /// </summary>
        public long? ExpiredAt { get; set; }

        /// <summary>
        /// Initializes a new instance of <see cref="OculusAuth"/> with the required data.
        /// </summary>
        public OculusAuth(string token, uint userId, string nonce)
        {
            Token = token;
            UserId = userId;
            Nonce = nonce;
        }

        internal HttpContent ToContent()
        {
            var parameters = new Parameters {
                {"access_token", Token},
                {"user_id", UserId.ToString()},
                {"nonce", Nonce},
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
