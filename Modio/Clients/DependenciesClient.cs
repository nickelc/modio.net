using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Modio.Http;
using Modio.Models;

namespace Modio;

/// <summary>
/// Client for the Dependencies API.
/// </summary>
public class DependenciesClient : ApiClient
{
    /// <summary>
    /// The game id of the endpoint.
    /// </summary>
    public uint GameId { get; private set; }

    /// <summary>
    /// The mod id of the endpoint.
    /// </summary>
    public uint ModId { get; private set; }

    internal DependenciesClient(IConnection connection, uint game, uint mod) : base(connection)
    {
        GameId = game;
        ModId = mod;
    }

    /// <summary>
    /// Get all dependencies the mod has selected.
    /// </summary>
    public async Task<IReadOnlyList<Dependency>> Get(bool recursive = false)
    {
        var route = Routes.GetModDependencies(GameId, ModId, recursive);
        var search = new SearchClient<Dependency>(Connection, route, null);
        return await search.ToList();
    }

    /// <summary>
    /// Add mod dependencies required by the corresponding mod.
    /// </summary>
    public async Task Add(params uint[] mods)
    {
        await Add((IEnumerable<uint>)mods);
    }

    /// <summary>
    /// Add mod dependencies required by the corresponding mod.
    /// </summary>
    public async Task Add(IEnumerable<uint> mods)
    {
        var content = mods.Select(m => ("dependencies[]", m.ToString())).ToContent();

        var (method, path) = Routes.AddModDependencies(GameId, ModId);
        var req = new Request(method, path, content);

        await Connection.Send<ApiMessage>(req);
    }

    /// <summary>
    /// Delete mod dependencies the corresponding mod has selected.
    /// </summary>
    public async Task Delete(params uint[] mods)
    {
        await Delete((IEnumerable<uint>)mods);
    }

    /// <summary>
    /// Delete mod dependencies the corresponding mod has selected.
    /// </summary>
    public async Task Delete(IEnumerable<uint> mods)
    {
        var content = mods.Select(m => ("dependencies[]", m.ToString())).ToContent();

        var (method, path) = Routes.DeleteModDependencies(GameId, ModId);
        var req = new Request(method, path, content);

        await Connection.Send<ApiMessage>(req);
    }
}