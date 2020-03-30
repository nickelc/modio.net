using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Modio.Models;

namespace Modio
{
    /// <summary>
    /// Client for the Tags API.
    /// </summary>
    public class TagsClient : ApiClient
    {
        /// <summary>
        /// The game id of the endpoint.
        /// </summary>
        public uint GameId { get; private set; }

        /// <summary>
        /// The mod id of the endpoint.
        /// </summary>
        public uint ModId { get; private set; }

        internal TagsClient(IConnection connection, uint game, uint mod) : base(connection)
        {
            GameId = game;
            ModId = mod;
        }

        /// <summary>
        /// Get all tags for the corresponding mod.
        /// </summary>
        public async Task<IReadOnlyList<Tag>> Get()
        {
            var route = Routes.GetModTags(GameId, ModId);
            var search = new SearchClient<Tag>(Connection, route, null);
            return await search.ToList();
        }

        /// <summary>
        /// Add tags to a mod's profile.
        /// </summary>
        public async Task Add(params string[] tags)
        {
            await Add((IEnumerable<string>)tags);
        }

        /// <summary>
        /// Add tags to a mod's profile.
        /// </summary>
        public async Task Add(IEnumerable<string> tags)
        {
            var content = tags.Select(t => ("tags[]", t)).ToContent();

            var (method, path) = Routes.AddModTags(GameId, ModId);
            var req = new Request(method, path, content);

            await Connection.Send<ApiMessage>(req);
        }

        /// <summary>
        /// Delete tags from a mod's profile.
        /// </summary>
        public async Task Delete(params string[] tags)
        {
            await Delete((IEnumerable<string>)tags);
        }

        /// <summary>
        /// Delete tags from a mod's profile.
        /// </summary>
        public async Task Delete(IEnumerable<string> tags)
        {
            var content = tags.Select(t => ("tags[]", t)).ToContent();

            var (method, path) = Routes.DeleteModTags(GameId, ModId);
            var req = new Request(method, path, content);

            await Connection.Send<ApiMessage>(req);
        }
    }
}
