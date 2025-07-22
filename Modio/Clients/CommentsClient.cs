using System.Threading.Tasks;

using Modio.Filters;
using Modio.Models;

namespace Modio;

/// <summary>
/// Client for the Comments API.
/// </summary>
public class CommentsClient : ApiClient
{
    /// <summary>
    /// The game id of the endpoint.
    /// </summary>
    public uint GameId { get; private set; }

    /// <summary>
    /// The mod id of the endpoint.
    /// </summary>
    public uint ModId { get; private set; }

    internal CommentsClient(IConnection connection, uint game, uint mod) : base(connection)
    {
        GameId = game;
        ModId = mod;
    }

    /// <summary>
    /// Get all comments posted in the mods profile.
    /// </summary>
    public SearchClient<Comment> Search(Filter? filter = null)
    {
        var route = Routes.GetComments(GameId, ModId);
        return new SearchClient<Comment>(Connection, route, filter);
    }

    /// <summary>
    /// Get a mod comment.
    /// </summary>
    public async Task<Comment> Get(uint id)
    {
        var (method, path) = Routes.GetComment(GameId, ModId, id);
        var req = new Request(method, path);
        var resp = await Connection.Send<Comment>(req);
        return resp.Body!;
    }

    /// <summary>
    /// Add a mod comment.
    /// </summary>
    public async Task<Comment> Add(string content, uint replyId = 0)
    {
        var parameters = new Parameters()
        {
            {"content", content},
            {"reply_id", replyId.ToString()},
        };
        var (method, path) = Routes.AddComment(GameId, ModId);
        var req = new Request(method, path, parameters.ToContent());
        var resp = await Connection.Send<Comment>(req);
        return resp.Body!;
    }

    /// <summary>
    /// Edit a mod comment.
    /// </summary>
    public async Task<Comment> Edit(uint id, string content)
    {
        var parameters = new Parameters()
        {
            {"content", content},
        };
        var (method, path) = Routes.EditComment(GameId, ModId, id);
        var req = new Request(method, path, parameters.ToContent());
        var resp = await Connection.Send<Comment>(req);
        return resp.Body!;
    }

    /// <summary>
    /// Delete a comment from a mod profile.
    /// </summary>
    public async Task Delete(uint id)
    {
        var (method, path) = Routes.DeleteComment(GameId, ModId, id);
        var req = new Request(method, path);
        await Connection.Send<ApiMessage>(req);
    }
}