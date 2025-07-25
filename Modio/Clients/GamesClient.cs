using System.Threading.Tasks;

using Modio.Filters;
using Modio.Http;
using Modio.Models;

namespace Modio;

/// <summary>
/// Client for the Games API.
/// </summary>
public class GamesClient : ApiClient
{
    internal GamesClient(IConnection connection) : base(connection) { }

    /// <summary>
    /// Gets the client for a specific game.
    /// </summary>
    public GameClient this[uint game] => new(Connection, game);

    /// <summary>
    /// Get all games.
    /// </summary>
    public SearchClient<Game> Search(Filter? filter = null)
    {
        var route = Routes.GetGames();
        return new SearchClient<Game>(Connection, route, filter);
    }

    /// <summary>
    /// Edit details for a game.
    /// </summary>
    public async Task<Game?> Edit(uint game, EditGame editGame)
    {
        return await this[game].Edit(editGame);
    }
}