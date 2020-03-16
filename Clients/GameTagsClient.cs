using System.Collections.Generic;
using System.Threading.Tasks;

using Modio.Models;

namespace Modio
{
    public class GameTagsClient : ApiClient
    {
        public uint GameId { get; private set; }

        internal GameTagsClient(IConnection connection, uint game) : base(connection)
        {
            GameId = game;
        }

        public async Task<IReadOnlyList<TagOption>> Get()
        {
            var route = Routes.GetGameTags(GameId);
            var search = new SearchClient<TagOption>(Connection, route, null);
            return await search.ToList();
        }

        public async Task Add(NewTagOption tag)
        {
            using (var content = tag.ToContent())
            {
                var (method, path) = Routes.AddGameTags(GameId);
                var req = new Request(method, path, content);

                await Connection.Send<ApiMessage>(req);
            }
        }

        public async Task Delete(DeleteTagOption tag)
        {
            using (var content = tag.ToContent())
            {
                var (method, path) = Routes.DeleteGameTags(GameId);
                var req = new Request(method, path, content);

                await Connection.Send<ApiMessage>(req);
            }
        }
    }
}
