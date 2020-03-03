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

        public async Task<Result<Mod>> List(Filter? filter = null) {
            var (method, path) = Routes.GetMods(GameId);
            var req = new Request(method, Connection.BaseAddress, path);

            if (filter != null) {
                req.Parameters.Extend(filter.ToParameters());
            }

            return await Connection.Send<Result<Mod>>(req);
        }
    }
}
