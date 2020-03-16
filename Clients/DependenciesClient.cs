using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

using Modio.Models;

namespace Modio
{
    public class DependenciesClient : ApiClient
    {
        public uint GameId { get; private set; }

        public uint ModId { get; private set; }

        internal DependenciesClient(IConnection connection, uint game, uint mod) : base(connection)
        {
            GameId = game;
            ModId = mod;
        }

        public async Task<IReadOnlyList<Dependency>> Get()
        {
            var route = Routes.GetModDependencies(GameId, ModId);
            var search = new SearchClient<Dependency>(Connection, route, null);
            return await search.ToList();
        }

        public async Task Add(params uint[] mods)
        {
            await Add((IEnumerable<uint>)mods);
        }

        public async Task Add(IEnumerable<uint> mods)
        {
            var content = mods.Select(m => ("dependencies[]", m.ToString())).ToContent();

            var (method, path) = Routes.AddModDependencies(GameId, ModId);
            var req = new Request(method, path, content);

            await Connection.Send<ApiMessage>(req);
        }

        public async Task Delete(params uint[] mods)
        {
            await Delete((IEnumerable<uint>)mods);
        }

        public async Task Delete(IEnumerable<uint> mods)
        {
            var content = mods.Select(m => ("dependencies[]", m.ToString())).ToContent();

            var (method, path) = Routes.DeleteModDependencies(GameId, ModId);
            var req = new Request(method, path, content);

            await Connection.Send<ApiMessage>(req);
        }
    }
}
