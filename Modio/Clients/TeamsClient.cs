using System.Threading.Tasks;

using Modio.Filters;
using Modio.Models;

namespace Modio;

/// <summary>
/// Client for the Team API.
/// </summary>
public class TeamsClient : ApiClient
{
    /// <summary>
    /// The game id of the endpoint.
    /// </summary>
    public uint GameId { get; private set; }

    /// <summary>
    /// The mod id of the endpoint.
    /// </summary>
    public uint ModId { get; private set; }

    internal TeamsClient(IConnection connection, uint game, uint mod) : base(connection)
    {
        GameId = game;
        ModId = mod;
    }

    /// <summary>
    /// Get all users that are part of a mod team.
    /// </summary>
    public SearchClient<TeamMember> Search(Filter? filter = null)
    {
        var route = Routes.GetTeamMembers(GameId, ModId);
        return new SearchClient<TeamMember>(Connection, route, filter);
    }

    /// <summary>
    /// Add a user to a mod team.
    /// </summary>
    public async Task Add(string email, TeamLevel level, string? position = null)
    {
        Ensure.ArgumentNotNull(email, nameof(email));

        var parameters = new Parameters
        {
            {"email", email},
            {"level", level.ToString()},
        };
        if (position != null)
        {
            parameters.Add("position", position);
        }

        var (method, path) = Routes.AddTeamMember(GameId, ModId);
        var req = new Request(method, path, parameters.ToContent());

        await Connection.Send<ApiMessage>(req);
    }

    /// <summary>
    /// Edit a mod team members details.
    /// </summary>
    public async Task Edit(uint member, TeamLevel level, string? position = null)
    {
        var parameters = new Parameters
        {
            {"level", level.ToString()},
        };
        if (position != null)
        {
            parameters.Add("position", position);
        }

        var (method, path) = Routes.EditTeamMember(GameId, ModId, member);
        var req = new Request(method, path, parameters.ToContent());

        await Connection.Send<ApiMessage>(req);
    }

    /// <summary>
    /// Delete a user from a mod team.
    /// </summary>
    public async Task Delete(uint member)
    {
        var (method, path) = Routes.DeleteTeamMember(GameId, ModId, member);
        var req = new Request(method, path);

        await Connection.Send<ApiMessage>(req);
    }
}