using System.Threading.Tasks;

using Modio.Filters;
using Modio.Models;

namespace Modio;

/// <summary>
/// Client for the User API.
/// </summary>
public class UserClient : ApiClient
{
    internal UserClient(IConnection connection) : base(connection) { }

    /// <summary>
    /// Get the authenticated user details.
    /// </summary>
    public async Task<User> GetCurrentUser()
    {
        var (method, path) = Routes.CurrentUser();
        var req = new Request(method, path);

        var resp = await Connection.Send<User>(req);
        return resp.Body!;
    }

    /// <summary>
    /// Get all mod's the authenticated user is subscribed to.
    /// </summary>
    public SearchClient<Mod> GetSubscriptions(Filter? filter = null)
    {
        var route = Routes.UserSubscriptions();
        return new SearchClient<Mod>(Connection, route, filter);
    }

    /// <summary>
    /// Get events that have been fired specific to the user.
    /// </summary>
    public SearchClient<UserEvent> GetEvents(Filter? filter = null)
    {
        var route = Routes.UserEvents();
        return new SearchClient<UserEvent>(Connection, route, filter);
    }

    /// <summary>
    /// Get all games the authenticated user added or is a team member of.
    /// </summary>
    public SearchClient<Game> GetGames(Filter? filter = null)
    {
        var route = Routes.UserGames();
        return new SearchClient<Game>(Connection, route, filter);
    }

    /// <summary>
    /// Get all mods the authenticated user added or is a team member of.
    /// </summary>
    public SearchClient<Mod> GetMods(Filter? filter = null)
    {
        var route = Routes.UserMods();
        return new SearchClient<Mod>(Connection, route, filter);
    }

    /// <summary>
    /// Get all modfiles the authenticated user uploaded.
    /// </summary>
    public SearchClient<File> GetFiles(Filter? filter = null)
    {
        var route = Routes.UserFiles();
        return new SearchClient<File>(Connection, route, filter);
    }

    /// <summary>
    /// Get all mod rating's submitted by the authenticated user.
    /// </summary>
    public SearchClient<Rating> GetRatings(Filter? filter = null)
    {
        var route = Routes.UserRatings();
        return new SearchClient<Rating>(Connection, route, filter);
    }
}