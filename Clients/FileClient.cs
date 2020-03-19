using System.Threading.Tasks;

using Modio.Models;

namespace Modio
{
    /// <summary>
    /// Client for a specific modfile.
    /// </summary>
    public class FileClient : ApiClient
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
        /// The file id of the endpoint.
        /// </summary>
        public uint FileId { get; private set; }

        internal FileClient(IConnection connection, uint game, uint mod, uint file) : base(connection)
        {
            GameId = game;
            ModId = mod;
            FileId = file;
        }

        /// <summary>
        /// Get a file.
        /// </summary>
        public async Task<File> Get()
        {
            var (method, path) = Routes.GetFile(GameId, ModId, FileId);
            var req = new Request(method, path);
            var resp = await Connection.Send<File>(req);
            return resp.Body!;
        }

        /// <summary>
        /// Edit the details of a published file.
        /// </summary>
        public async Task<File?> Edit(EditFile editFile)
        {
            using (var content = editFile.ToContent())
            {
                var (method, path) = Routes.EditFile(GameId, ModId, FileId);
                var req = new Request(method, path, content);

                var resp = await Connection.Send<EditResult<File>>(req);
                return resp.Body!.Object;
            }
        }

        /// <summary>
        /// Delete a modfile.
        /// </summary>
        public async Task Delete()
        {
            var (method, path) = Routes.DeleteFile(GameId, ModId, FileId);
            var req = new Request(method, path);
            await Connection.Send<ApiMessage>(req);
        }
    }
}
