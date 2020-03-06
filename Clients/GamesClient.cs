using System.Threading.Tasks;

using Modio.Filters;
using Modio.Models;

namespace Modio
{
    public class GamesClient : ApiClient
    {
        internal GamesClient(IConnection connection) : base(connection) { }

        public GameClient this[uint game] => new GameClient(Connection, game);

        public async Task<Result<Game>> List(Filter? filter = null)
        {
            var (method, path) = Routes.GetGames();
            var req = new Request(method, Connection.BaseAddress, path);

            if (filter != null)
            {
                req.Parameters.Extend(filter.ToParameters());
            }

            return await Connection.Send<Result<Game>>(req);
        }
    }
}
