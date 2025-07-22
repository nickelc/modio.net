using System.Threading;
using System.Threading.Tasks;

using Modio.Filters;
using Modio.Models;

namespace Modio;

/// <summary>
/// Client for the Modfiles API.
/// </summary>
public class FilesClient : ApiClient
{
    /// <summary>
    /// The game id of the endpoint.
    /// </summary>
    public uint GameId { get; private set; }

    /// <summary>
    /// The mod id of the endpoint.
    /// </summary>
    public uint ModId { get; private set; }

    internal FilesClient(IConnection connection, uint game, uint mod) : base(connection)
    {
        GameId = game;
        ModId = mod;
    }

    /// <summary>
    /// Gets the client for a specific modfile.
    /// </summary>
    public FileClient this[uint file] => new(Connection, GameId, ModId, file);

    /// <summary>
    /// Get all files that are published for the corresponding mod.
    /// </summary>
    public SearchClient<File> Search(Filter? filter = null)
    {
        var route = Routes.GetFiles(GameId, ModId);
        return new SearchClient<File>(Connection, route, filter);
    }

    /// <summary>
    /// Upload a file for the corresponding mod.
    /// </summary>
    public async Task<File> Add(NewFile newFile, CancellationToken cancellationToken = default)
    {
        using (var content = newFile.ToContent())
        {
            var (method, path) = Routes.AddFile(GameId, ModId);
            var req = new Request(method, path, content);

            var resp = await Connection.Send<File>(req, cancellationToken);
            return resp.Body!;
        }
    }

    /// <summary>
    /// Edit the details of a published file.
    /// </summary>
    public async Task<File?> Edit(uint file, EditFile editFile)
    {
        return await this[file].Edit(editFile);
    }

    /// <summary>
    /// Delete a modfile.
    /// </summary>
    public async Task Delete(uint file)
    {
        await this[file].Delete();
    }
}