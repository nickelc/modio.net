using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

using Modio.Models;

namespace Modio
{
    /// <summary>
    /// Client for the Metadata API.
    /// </summary>
    public class MetadataClient : ApiClient
    {
        /// <summary>
        /// The game id of the endpoint.
        /// </summary>
        public uint GameId { get; private set; }

        /// <summary>
        /// The mod id of the endpoint.
        /// </summary>
        public uint ModId { get; private set; }

        internal MetadataClient(IConnection connection, uint game, uint mod) : base(connection)
        {
            GameId = game;
            ModId = mod;
        }

        class KVP
        {
            public string? metakey { get; set; }
            public string? metavalue { get; set; }
        }

        /// <summary>
        /// Returns the metadata key-value pair of the mod.
        /// </summary>
        public async Task<Metadata> Get()
        {
            var route = Routes.GetModMetadata(GameId, ModId);
            var search = new SearchClient<KVP>(Connection, route, null);
            var metadata = new Metadata();
            await foreach (var item in search.ToEnumerable())
            {
                metadata.GetOrCreate(item.metakey!).Add(item.metavalue!);
            }
            return metadata;
        }

        /// <summary>
        /// Adds new key-value pairs to the mod's metadata.
        /// </summary>
        public async Task Add(Metadata metadata)
        {
            var (method, path) = Routes.AddModMetadata(GameId, ModId);
            var req = new Request(method, path, metadata.ToContent());

            await Connection.Send<ApiMessage>(req);
        }

        /// <summary>
        /// Deletes key-value pairs from the mod's metadata.
        /// </summary>
        public async Task Delete(Metadata metadata)
        {
            var (method, path) = Routes.DeleteModMetadata(GameId, ModId);
            var req = new Request(method, path, metadata.ToContent());

            await Connection.Send<ApiMessage>(req);
        }
    }

    internal static class MetadataExtensions
    {
        public static HttpContent ToContent(this Metadata metadata)
        {
            var name = "metadata[]";
            var parameters = metadata.SelectMany(kvp => kvp.Value.Count switch
                {
                    0 => new[] { (name, kvp.Key) },
                    _ => kvp.Value
                        .Select(v => string.Format("{0}:{1}", kvp.Key, v))
                        .Select(v => (name, v)),
                }
            );
            return parameters.ToContent();
        }
    }
}
