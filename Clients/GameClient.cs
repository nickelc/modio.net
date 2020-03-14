using System.Threading.Tasks;

using Modio.Models;

namespace Modio
{
    public class GameClient : ApiClient
    {
        public uint GameId { get; private set; }

        public Mods Mods { get; private set; }

        internal GameClient(IConnection connection, uint game) : base(connection)
        {
            GameId = game;
            Mods = new Mods(connection, game);
        }

        public async Task<Game> Get()
        {
            var (method, path) = Routes.GetGame(GameId);
            var req = new Request(method, Connection.BaseAddress, path);
            var resp = await Connection.Send<Game>(req);
            return resp.Body!;
        }

        public async Task<Game> Edit(EditGame editGame)
        {
            using (var content = editGame.ToContent())
            {
                var (method, path) = Routes.EditGame(GameId);
                var req = new Request(method, Connection.BaseAddress, path);
                req.Body = content;

                var resp = await Connection.Send<Game>(req);
                return resp.Body!;
            }
        }
    }
}
