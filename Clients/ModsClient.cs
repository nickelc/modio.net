using System.Threading.Tasks;

using Modio.Filters;
using Modio.Models;

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

        public SearchClient<Mod> Search(Filter? filter = null)
        {
            var route = Routes.GetMods(GameId);
            return new SearchClient<Mod>(Connection, route, filter);
        }

        public SearchClient<Statistics> Statistics(Filter? filter = null)
        {
            var route = Routes.GetAllModStats(GameId);
            return new SearchClient<Statistics>(Connection, route, filter);
        }
    }
}
