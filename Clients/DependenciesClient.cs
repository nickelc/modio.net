using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

using Modio.Models;

namespace Modio
{
    using Parameter = KeyValuePair<string, string>;

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
            var (method, path) = Routes.AddModDependencies(GameId, ModId);
            var req = new Request(method, Connection.BaseAddress, path);

            var parameters = mods.Select(m => new Parameter("dependencies[]", m.ToString()));
            req.Body = new FormUrlEncodedContent(parameters);

            await Connection.Send<ApiMessage>(req);
        }

        public async Task Delete(params uint[] mods)
        {
            await Delete((IEnumerable<uint>)mods);
        }

        public async Task Delete(IEnumerable<uint> mods)
        {
            var (method, path) = Routes.DeleteModDependencies(GameId, ModId);
            var req = new Request(method, Connection.BaseAddress, path);

            var parameters = mods.Select(m => new Parameter("dependencies[]", m.ToString()));
            req.Body = new FormUrlEncodedContent(parameters);

            await Connection.Send<ApiMessage>(req);
        }
    }
}
