using Modio.Filters;
using Modio.Models;

namespace Modio
{
    public class FilesClient : ApiClient
    {
        public uint GameId { get; private set; }

        public uint ModId { get; private set; }

        internal FilesClient(IConnection connection, uint game, uint mod) : base(connection)
        {
            GameId = game;
            ModId = mod;
        }

        public FileClient this[uint file] => new FileClient(Connection, GameId, ModId, file);

        public SearchClient<File> Search(Filter? filter = null)
        {
            var route = Routes.GetFiles(GameId, ModId);
            return new SearchClient<File>(Connection, route, filter);
        }
    }
}
