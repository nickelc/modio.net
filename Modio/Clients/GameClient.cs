using System.Threading.Tasks;

using Modio.Models;

namespace Modio;

/// <summary>
/// Client for a specific game.
/// </summary>
public class GameClient : ApiClient
{
    /// <summary>
    /// The game id of the endpoint.
    /// </summary>
    public uint GameId { get; private set; }

    /// <summary>
    /// Client for the Mods API.
    /// </summary>
    public ModsClient Mods { get; private set; }

    /// <summary>
    /// Client for the Game Tags API.
    /// </summary>
    public GameTagsClient Tags { get; private set; }

    internal GameClient(IConnection connection, uint game) : base(connection)
    {
        GameId = game;
        Mods = new ModsClient(connection, game);
        Tags = new GameTagsClient(connection, game);
    }

    /// <summary>
    /// Get a game.
    /// </summary>
    public async Task<Game> Get()
    {
        var (method, path) = Routes.GetGame(GameId);
        var req = new Request(method, path);
        var resp = await Connection.Send<Game>(req);
        return resp.Body!;
    }

    /// <summary>
    /// Edit details for a game.
    /// </summary>
    public async Task<Game?> Edit(EditGame editGame)
    {
        using (var content = editGame.ToContent())
        {
            var (method, path) = Routes.EditGame(GameId);
            var req = new Request(method, path, content);

            var resp = await Connection.Send<EditResult<Game>>(req);
            return resp.Body!.Object;
        }
    }

    /// <summary>
    /// Add new media to a game.
    /// </summary>
    public async Task AddMedia(NewGameMedia media)
    {
        using (var content = media.ToContent())
        {
            var (method, path) = Routes.AddGameMedia(GameId);
            var req = new Request(method, path, content);

            await Connection.Send<ApiMessage>(req);
        }
    }
}