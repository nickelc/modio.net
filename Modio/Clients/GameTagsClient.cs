using System.Collections.Generic;
using System.Threading.Tasks;

using Modio.Models;

namespace Modio
{
    /// <summary>
    /// Client for the Game Tags API.
    /// </summary>
    public class GameTagsClient : ApiClient
    {
        /// <summary>
        /// The game id of the endpoint.
        /// </summary>
        public uint GameId { get; private set; }

        internal GameTagsClient(IConnection connection, uint game) : base(connection)
        {
            GameId = game;
        }

        /// <summary>
        /// Returns all tag option of the game.
        /// </summary>
        public async Task<IReadOnlyList<TagOption>> Get()
        {
            var route = Routes.GetGameTags(GameId);
            var search = new SearchClient<TagOption>(Connection, route, null);
            return await search.ToList();
        }

        /// <summary>
        /// Adds a new tag option to the game.
        /// </summary>
        public async Task Add(NewTagOption tag)
        {
            using (var content = tag.ToContent())
            {
                var (method, path) = Routes.AddGameTags(GameId);
                var req = new Request(method, path, content);

                await Connection.Send<ApiMessage>(req);
            }
        }

        /// <summary>
        /// Deletes a tag option from the game.
        /// </summary>
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
