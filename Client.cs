using System;

namespace Modio
{
    public class Client
    {
        public static readonly Uri ModioApiUrl = new Uri("https://api.mod.io/v1/");

        private IConnection connection;

        public GamesClient Games { get; private set; }

        public Client(Credentials credentials) : this(new Connection(ModioApiUrl, credentials))
        {
        }

        private Client(IConnection connection)
        {
            this.connection = connection;
            Games = new GamesClient(connection);
        }
    }
}
