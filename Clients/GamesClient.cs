using System.Threading.Tasks;

using Modio.Filters;
using Modio.Models;

namespace Modio
{
    public class GamesClient : ApiClient
    {
        internal GamesClient(IConnection connection) : base(connection) { }

        public GameClient this[uint game] => new GameClient(Connection, game);

        public SearchClient<Game> Search(Filter? filter = null)
        {
            var route = Routes.GetGames();
            return new SearchClient<Game>(Connection, route, filter);
        }
    }
}
