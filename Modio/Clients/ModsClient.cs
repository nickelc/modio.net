using System.Threading.Tasks;

using Modio.Filters;
using Modio.Http;
using Modio.Models;

namespace Modio;

/// <summary>
/// Client for the Mods API.
/// </summary>
public class ModsClient : ApiClient
{
    /// <summary>
    /// The game id of the endpoint.
    /// </summary>
    public uint GameId { get; private set; }

    internal ModsClient(IConnection connection, uint game) : base(connection)
    {
        GameId = game;
    }

    /// <summary>
    /// Gets the client for a specific mod.
    /// </summary>
    public ModClient this[uint mod] => new(Connection, GameId, mod);

    /// <summary>
    /// Get all mods for the corresponding game.
    /// </summary>
    public SearchClient<Mod> Search(Filter? filter = null)
    {
        var route = Routes.GetMods(GameId);
        return new SearchClient<Mod>(Connection, route, filter);
    }

    /// <summary>
    /// Get all mods events for the corresponding game sorted by latest event first.
    /// </summary>
    public SearchClient<ModEvent> GetEvents(Filter? filter = null)
    {
        var route = Routes.GetAllModEvents(GameId);
        return new SearchClient<ModEvent>(Connection, route, filter);
    }

    /// <summary>
    /// Get all mod stats for mods of the corresponding game.
    /// </summary>
    public SearchClient<Statistics> GetStatistics(Filter? filter = null)
    {
        var route = Routes.GetAllModStats(GameId);
        return new SearchClient<Statistics>(Connection, route, filter);
    }

    /// <summary>
    /// Add a mod.
    /// </summary>
    public async Task<Mod> Add(NewMod newMod)
    {
        using (var content = newMod.ToContent())
        {
            var (method, path) = Routes.AddMod(GameId);
            var req = new Request(method, path, content);

            var resp = await Connection.Send<Mod>(req);
            return resp.Body!;
        }
    }

    /// <summary>
    /// Edit details for a mod.
    /// </summary>
    public async Task<Mod?> Edit(uint mod, EditMod editMod)
    {
        return await this[mod].Edit(editMod);
    }

    /// <summary>
    /// Delete a mod.
    /// </summary>
    public async Task Delete(uint mod)
    {
        await this[mod].Delete();
    }

    /// <summary>
    /// Subscribe the authenticated user to the corresponding mod.
    /// </summary>
    public async Task Subscribe(uint mod)
    {
        await this[mod].Subscribe();
    }

    /// <summary>
    /// Unsubscribe the authenticated user from the corresponding mod.
    /// </summary>
    public async Task Unsubscribe(uint mod)
    {
        await this[mod].Unsubscribe();
    }

    /// <summary>
    /// Submit a positive or negative rating for the mod.
    /// </summary>
    public async Task Rate(uint mod, NewRating rating)
    {
        await this[mod].Rate(rating);
    }
}