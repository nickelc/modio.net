using System.Threading.Tasks;

using Modio.Filters;
using Modio.Models;

namespace Modio
{

    public class ModsClient : ApiClient
    {
        public uint GameId { get; private set; }

        internal ModsClient(IConnection connection, uint game) : base(connection)
        {
            GameId = game;
        }

        public ModClient this[uint mod] => new ModClient(Connection, GameId, mod);

        public SearchClient<Mod> Search(Filter? filter = null)
        {
            var route = Routes.GetMods(GameId);
            return new SearchClient<Mod>(Connection, route, filter);
        }

        public SearchClient<ModEvent> GetEvents(Filter? filter = null)
        {
            var route = Routes.GetAllModEvents(GameId);
            return new SearchClient<ModEvent>(Connection, route, filter);
        }

        public SearchClient<Statistics> GetStatistics(Filter? filter = null)
        {
            var route = Routes.GetAllModStats(GameId);
            return new SearchClient<Statistics>(Connection, route, filter);
        }

        public async Task<Mod> Add(NewMod newMod)
        {
            using (var content = newMod.ToContent())
            {
                var (method, path) = Routes.AddMod(GameId);
                var req = new Request(method, path, content);

                var resp = await Connection.Send<Mod>(req);
                return resp.Body!;
            }
        }

        public async Task<Mod> Edit(uint mod, EditMod editMod)
        {
            return await this[mod].Edit(editMod);
        }

        public async Task Delete(uint mod)
        {
            await this[mod].Delete();
        }

        public async Task Subscribe(uint mod)
        {
            await this[mod].Subscribe();
        }

        public async Task Unsubscribe(uint mod)
        {
            await this[mod].Unsubscribe();
        }

        public async Task Rate(uint mod, NewRating rating)
        {
            await this[mod].Rate(rating);
        }
    }
}
