using System.Threading.Tasks;

using Modio.Filters;
using Modio.Models;

namespace Modio
{
    public class CommentsClient : ApiClient
    {
        public uint GameId { get; private set; }

        public uint ModId { get; private set; }

        internal CommentsClient(IConnection connection, uint game, uint mod) : base(connection)
        {
            GameId = game;
            ModId = mod;
        }

        public SearchClient<Comment> Search(Filter? filter = null)
        {
            var route = Routes.GetComments(GameId, ModId);
            return new SearchClient<Comment>(Connection, route, filter);
        }

        public async Task<Comment> Get(uint id)
        {
            var (method, path) = Routes.GetComment(GameId, ModId, id);
            var req = new Request(method, path);
            var resp = await Connection.Send<Comment>(req);
            return resp.Body!;
        }

        public async Task Delete(uint id)
        {
            var (method, path) = Routes.DeleteComment(GameId, ModId, id);
            var req = new Request(method, path);
            await Connection.Send<ApiMessage>(req);
        }
    }
}
