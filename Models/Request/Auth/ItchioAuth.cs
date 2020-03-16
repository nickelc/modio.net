using System.Net.Http;

namespace Modio
{
    public class ItchioAuth
    {
        public string Token { get; private set; }

        public string? Email { get; set; }

        public long? ExpiredAt { get; set; }

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
            if (ExpiredAt is long expiredAt)
            {
                parameters.Add("date_expires", expiredAt.ToString());
            }
            return parameters.ToContent();
        }
    }
}
