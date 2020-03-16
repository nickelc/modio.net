using System.Net.Http;

namespace Modio
{
    public class GalaxyAuth
    {
        public string AppData { get; private set; }

        public string? Email { get; set; }

        public long? ExpiredAt { get; set; }

        public GalaxyAuth(string appData)
        {
            AppData = appData;
        }

        internal HttpContent ToContent()
        {
            var parameters = new Parameters {
                {"appdata", AppData},
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
