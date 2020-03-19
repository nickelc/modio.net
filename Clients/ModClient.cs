using System.Net;
using System.Threading.Tasks;

using Modio.Filters;
using Modio.Models;

namespace Modio
{
    public class ModClient : ApiClient
    {
        public uint GameId { get; private set; }

        public uint ModId { get; private set; }

        public TagsClient Tags { get; private set; }

        public DependenciesClient Dependencies { get; private set; }

        public MetadataClient Metadata { get; private set; }

        public FilesClient Files { get; private set; }

        public CommentsClient Comments { get; private set; }

        public TeamsClient Team { get; private set; }

        internal ModClient(IConnection connection, uint game, uint mod) : base(connection)
        {
            GameId = game;
            ModId = mod;
            Tags = new TagsClient(connection, game, mod);
            Dependencies = new DependenciesClient(connection, game, mod);
            Metadata = new MetadataClient(connection, game, mod);
            Files = new FilesClient(connection, game, mod);
            Comments = new CommentsClient(connection, game, mod);
            Team = new TeamsClient(connection, game, mod);
        }

        public async Task<Mod> Get()
        {
            var (method, path) = Routes.GetMod(GameId, ModId);
            var req = new Request(method, path);
            var resp = await Connection.Send<Mod>(req);
            return resp.Body!;
        }

        public async Task<Mod?> Edit(EditMod editMod)
        {
            using (var content = editMod.ToContent())
            {
                var (method, path) = Routes.EditMod(GameId, ModId);
                var req = new Request(method, path, content);

                var resp = await Connection.Send<EditResult<Mod>>(req);
                return resp.Body!.Object;
            }
        }

        public async Task Delete()
        {
            var (method, path) = Routes.DeleteMod(GameId, ModId);
            var req = new Request(method, path);
            await Connection.Send<ApiMessage>(req);
        }

        public async Task AddMedia(NewModMedia media)
        {
            using (var content = media.ToContent())
            {
                var (method, path) = Routes.AddModMedia(GameId, ModId);
                var req = new Request(method, path, content);

                await Connection.Send<ApiMessage>(req);
            }
        }

        public async Task DeleteMedia(DeleteModMedia media)
        {
            using (var content = media.ToContent())
            {
                var (method, path) = Routes.DeleteModMedia(GameId, ModId);
                var req = new Request(method, path, content);

                await Connection.Send<ApiMessage>(req);
            }
        }

        public SearchClient<ModEvent> GetEvents(Filter? filter = null)
        {
            var route = Routes.GetModEvents(GameId, ModId);
            return new SearchClient<ModEvent>(Connection, route, filter);
        }

        public async Task<Statistics> GetStatistics()
        {
            var (method, path) = Routes.GetModStats(GameId, ModId);
            var req = new Request(method, path);
            var resp = await Connection.Send<Statistics>(req);
            return resp.Body!;
        }

        public async Task Subscribe()
        {
            var (method, path) = Routes.Subscribe(GameId, ModId);
            var req = new Request(method, path, new NoHttpContent());

            try
            {
                await Connection.Send<Mod>(req);
            }
            catch (ApiException e)
            {
                // The endpoint returns 400 if the user is already subscribed
                if (e.StatusCode != HttpStatusCode.BadRequest)
                {
                    throw;
                }
            }
        }

        public async Task Unsubscribe()
        {
            var (method, path) = Routes.Unsubscribe(GameId, ModId);
            var req = new Request(method, path, new NoHttpContent());

            try
            {
                await Connection.Send<ApiMessage>(req);
            }
            catch (ApiException e)
            {
                // The endpoint returns 400 if the user was not subscribed
                if (e.StatusCode != HttpStatusCode.BadRequest)
                {
                    throw;
                }
            }
        }

        public async Task Rate(NewRating rating)
        {
            using (var content = rating.ToContent())
            {
                var (method, path) = Routes.RateMod(GameId, ModId);
                var req = new Request(method, path, content);

                try
                {
                    await Connection.Send<ApiMessage>(req);
                }
                catch (ApiException e)
                {
                    // The endpoint returns 400 if the user already submitted
                    // a positive or negative rating
                    if (e.StatusCode != HttpStatusCode.BadRequest)
                    {
                        throw;
                    }
                }
            }
        }
    }
}
