using System.Threading.Tasks;

using Modio.Filters;
using Modio.Models;

namespace Modio
{
    public class TeamsClient : ApiClient
    {
        public uint GameId { get; private set; }

        public uint ModId { get; private set; }

        internal TeamsClient(IConnection connection, uint game, uint mod) : base(connection)
        {
            GameId = game;
            ModId = mod;
        }

        public SearchClient<TeamMember> Search(Filter? filter = null)
        {
            var route = Routes.GetTeamMembers(GameId, ModId);
            return new SearchClient<TeamMember>(Connection, route, filter);
        }

        public async Task Add(string email, TeamLevel level, string? position = null)
        {
            Ensure.ArgumentNotNull(email, nameof(email));

            var (method, path) = Routes.AddTeamMember(GameId, ModId);
            var req = new Request(method, Connection.BaseAddress, path);

            var parameters = new Parameters {
                {"email", email},
                {"level", level.ToString()},
            };
            if (position != null)
            {
                parameters.Add("position", position);
            }
            req.Body = parameters.ToContent();
            await Connection.Send<ApiMessage>(req);
        }

        public async Task Edit(uint member, TeamLevel level, string? position = null)
        {
            var (method, path) = Routes.EditTeamMember(GameId, ModId, member);
            var req = new Request(method, Connection.BaseAddress, path);

            var parameters = new Parameters {
                {"level", level.ToString()},
            };
            if (position != null)
            {
                parameters.Add("position", position);
            }
            req.Body = parameters.ToContent();
            await Connection.Send<ApiMessage>(req);
        }

        public async Task Delete(uint member)
        {
            var (method, path) = Routes.DeleteTeamMember(GameId, ModId, member);
            var req = new Request(method, Connection.BaseAddress, path);

            await Connection.Send<ApiMessage>(req);
        }
    }
}
