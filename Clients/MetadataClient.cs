using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

using Modio.Models;

namespace Modio
{
    using Parameter = KeyValuePair<string, string>;

    public class MetadataClient : ApiClient
    {
        public uint GameId { get; private set; }

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

        public async Task Add(Metadata metadata)
        {
            var (method, path) = Routes.AddModMetadata(GameId, ModId);
            var req = new Request(method, Connection.BaseAddress, path);
            req.Body = metadata.ToContent();

            await Connection.Send<ApiMessage>(req);
        }

        public async Task Delete(Metadata metadata)
        {
            var (method, path) = Routes.DeleteModMetadata(GameId, ModId);
            var req = new Request(method, Connection.BaseAddress, path);
            req.Body = metadata.ToContent();

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
                    0 => new[] { new Parameter(name, kvp.Key) },
                    _ => kvp.Value
                        .Select(v => string.Format("{0}:{1}", kvp.Key, v))
                        .Select(v => new Parameter(name, v)),
                }
            );
            return new FormUrlEncodedContent(parameters);
        }
    }
}
