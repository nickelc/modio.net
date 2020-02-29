namespace Modio
{

    public class Mods : ApiClient
    {
        public uint GameId { get; private set; }

        internal Mods(IConnection connection, uint game) : base(connection)
        {
            GameId = game;
        }

        public ModClient this[uint mod] => new ModClient(Connection, GameId, mod);
    }
}
