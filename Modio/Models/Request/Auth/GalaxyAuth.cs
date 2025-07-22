using System.Net.Http;

namespace Modio
{
    /// <summary>
    /// See <see cref="AuthClient.External(GalaxyAuth)"/>.
    /// </summary>
    ///
    /// <seealso>https://docs.mod.io/restapiref/#gog-galaxy</seealso>
    public class GalaxyAuth
    {
        /// <summary>
        /// GOG Galaxy's Encrypted App Ticket
        /// </summary>
        public string AppData { get; private set; }

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
        /// Initializes a new instance of <see cref="GalaxyAuth"/> with the required Encrypted App Ticket.
        /// </summary>
        public GalaxyAuth(string appData)
        {
            AppData = appData;
        }

        internal HttpContent ToContent()
        {
            var parameters = new Parameters
            {
                {"appdata", AppData},
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
