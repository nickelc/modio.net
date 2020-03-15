using System.Threading.Tasks;

using Modio.Filters;
using Modio.Models;

namespace Modio
{
    public class UserClient : ApiClient
    {
        internal UserClient(IConnection connection) : base(connection) { }

        public async Task<User> GetCurrentUser()
        {
            var (method, path) = Routes.CurrentUser();
            var req = new Request(method, Connection.BaseAddress, path);

            var resp = await Connection.Send<User>(req);
            return resp.Body!;
        }

        public SearchClient<Mod> GetSubscriptions(Filter? filter = null)
        {
            var route = Routes.UserSubscriptions();
            return new SearchClient<Mod>(Connection, route, filter);
        }

        public SearchClient<UserEvent> GetEvents(Filter? filter = null)
        {
            var route = Routes.UserEvents();
            return new SearchClient<UserEvent>(Connection, route, filter);
        }

        public SearchClient<Game> GetGames(Filter? filter = null)
        {
            var route = Routes.UserGames();
            return new SearchClient<Game>(Connection, route, filter);
        }

        public SearchClient<Mod> GetMods(Filter? filter = null)
        {
            var route = Routes.UserMods();
            return new SearchClient<Mod>(Connection, route, filter);
        }

        public SearchClient<File> GetFiles(Filter? filter = null)
        {
            var route = Routes.UserFiles();
            return new SearchClient<File>(Connection, route, filter);
        }

        public SearchClient<Rating> GetRatings(Filter? filter = null)
        {
            var route = Routes.UserRatings();
            return new SearchClient<Rating>(Connection, route, filter);
        }
    }
}
