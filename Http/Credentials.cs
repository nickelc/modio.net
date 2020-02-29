namespace Modio
{
    public class Credentials
    {
        public string ApiKey { get; private set; }

        public string? Token { get; private set; }

        public Credentials(string apiKey)
        {
            Ensure.ArgumentNotNullOrEmptyString(apiKey, nameof(apiKey));

            ApiKey = apiKey;
        }

        public Credentials(string apiKey, string token) : this(apiKey)
        {
            Ensure.ArgumentNotNullOrEmptyString(token, nameof(token));

            Token = token;
        }
    }
}
