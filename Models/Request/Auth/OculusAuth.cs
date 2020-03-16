using System.Net.Http;

namespace Modio
{
    public class OculusAuth
    {
        public string Token { get; private set; }

        public uint UserId { get; private set; }

        public string Nonce { get; private set; }

        public string? Email { get; set; }

        public long? ExpiredAt { get; set; }

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
