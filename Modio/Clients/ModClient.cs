using System.Net;
using System.Threading.Tasks;

using Modio.Filters;
using Modio.Http;
using Modio.Models;

namespace Modio;

/// <summary>
/// Client for a specific mod.
/// </summary>
public class ModClient : ApiClient
{
    /// <summary>
    /// The game id of the endpoint.
    /// </summary>
    public uint GameId { get; private set; }

    /// <summary>
    /// The mod id of the endpoint.
    /// </summary>
    public uint ModId { get; private set; }

    /// <summary>
    /// Client for the Tags API.
    /// </summary>
    public TagsClient Tags { get; private set; }

    /// <summary>
    /// Client for the Dependencies API.
    /// </summary>
    public DependenciesClient Dependencies { get; private set; }

    /// <summary>
    /// Client for the Metadata API.
    /// </summary>
    public MetadataClient Metadata { get; private set; }

    /// <summary>
    /// Client for the Modfiles API.
    /// </summary>
    public FilesClient Files { get; private set; }

    /// <summary>
    /// Client for the Comments API.
    /// </summary>
    public CommentsClient Comments { get; private set; }

    /// <summary>
    /// Client for the Team API.
    /// </summary>
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

    /// <summary>
    /// Get a mod.
    /// </summary>
    public async Task<Mod> Get()
    {
        var (method, path) = Routes.GetMod(GameId, ModId);
        var req = new Request(method, path);
        var resp = await Connection.Send<Mod>(req);
        return resp.Body!;
    }

    /// <summary>
    /// Edit details for a mod.
    /// </summary>
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

    /// <summary>
    /// Delete a mod.
    /// </summary>
    public async Task Delete()
    {
        var (method, path) = Routes.DeleteMod(GameId, ModId);
        var req = new Request(method, path);
        await Connection.Send<ApiMessage>(req);
    }

    /// <summary>
    /// Upload new media to a mod.
    /// </summary>
    public async Task AddMedia(NewModMedia media)
    {
        using (var content = media.ToContent())
        {
            var (method, path) = Routes.AddModMedia(GameId, ModId);
            var req = new Request(method, path, content);

            await Connection.Send<ApiMessage>(req);
        }
    }

    /// <summary>
    /// Delete media from a mod.
    /// </summary>
    public async Task DeleteMedia(DeleteModMedia media)
    {
        using (var content = media.ToContent())
        {
            var (method, path) = Routes.DeleteModMedia(GameId, ModId);
            var req = new Request(method, path, content);

            await Connection.Send<ApiMessage>(req);
        }
    }

    /// <summary>
    /// Get the event log for the mod, showing changes made sorted by latest event first.
    /// </summary>
    public SearchClient<ModEvent> GetEvents(Filter? filter = null)
    {
        var route = Routes.GetModEvents(GameId, ModId);
        return new SearchClient<ModEvent>(Connection, route, filter);
    }

    /// <summary>
    /// Get mod stats for the corresponding mod.
    /// </summary>
    public async Task<Statistics> GetStatistics()
    {
        var (method, path) = Routes.GetModStats(GameId, ModId);
        var req = new Request(method, path);
        var resp = await Connection.Send<Statistics>(req);
        return resp.Body!;
    }

    /// <summary>
    /// Subscribe the authenticated user to the corresponding mod.
    /// </summary>
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
            // The endpoint returns 400 & error_ref=15004 if the user
            // is already subscribed
            if (!e.Is(HttpStatusCode.BadRequest, 15004))
            {
                throw;
            }
        }
    }

    /// <summary>
    /// Unsubscribe the authenticated user from the corresponding mod.
    /// </summary>
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
            // The endpoint returns 400 & error_ref=15005 if the user
            // was not subscribed
            if (!e.Is(HttpStatusCode.BadRequest, 15005))
            {
                throw;
            }
        }
    }

    /// <summary>
    /// Submit a positive or negative rating for the mod.
    /// </summary>
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
                // The endpoint returns 400 & error_ref=15028 if the user
                // already submitted a positive or negative rating
                //
                // The endpoint returns 400 & error_ref=15043 if the user
                // is trying to revert a rating that doesn't exist
                if (!e.Is(HttpStatusCode.BadRequest, 15028)
                    && !e.Is(HttpStatusCode.BadRequest, 15043))
                {
                    throw;
                }
            }
        }
    }
}