using System;

namespace Modio
{
    public class Client
    {
        public static readonly Uri ModioApiUrl = new Uri("https://api.mod.io/v1/");
        public static readonly Uri ModioApiTestUrl = new Uri("https://api.test.mod.io/v1/");

        private IConnection connection;

        public GamesClient Games { get; private set; }

        public UserClient User { get; private set; }

        public Client(Credentials credentials) : this(new Connection(ModioApiUrl, credentials))
        {
        }

        public Client(Uri baseUrl, Credentials credentials) : this(new Connection(FixBaseUrl(baseUrl), credentials))
        {
        }

        private Client(IConnection connection)
        {
            this.connection = connection;
            Games = new GamesClient(connection);
            User = new UserClient(connection);
        }

        static Uri FixBaseUrl(Uri uri)
        {
            Ensure.ArgumentNotNull(uri, nameof(uri));
            if (uri.Host.Equals("api.mod.io"))
            {
                return ModioApiUrl;
            }
            if (uri.Host.Equals("api.test.mod.io"))
            {
                return ModioApiTestUrl;
            }

            return new Uri(uri, new Uri("/v1/", UriKind.Relative));
        }
    }
}
