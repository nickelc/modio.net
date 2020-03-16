using System.Threading.Tasks;

using Modio.Models;

namespace Modio
{
    public class FileClient : ApiClient
    {
        public uint GameId { get; private set; }

        public uint ModId { get; private set; }

        public uint FileId { get; private set; }

        internal FileClient(IConnection connection, uint game, uint mod, uint file) : base(connection)
        {
            GameId = game;
            ModId = mod;
            FileId = file;
        }

        public async Task<File> Get()
        {
            var (method, path) = Routes.GetFile(GameId, ModId, FileId);
            var req = new Request(method, path);
            var resp = await Connection.Send<File>(req);
            return resp.Body!;
        }

        public async Task<File> Edit(EditFile editFile)
        {
            using (var content = editFile.ToContent())
            {
                var (method, path) = Routes.EditFile(GameId, ModId, FileId);
                var req = new Request(method, path, content);

                var resp = await Connection.Send<File>(req);
                return resp.Body!;
            }
        }

        public async Task Delete()
        {
            var (method, path) = Routes.DeleteFile(GameId, ModId, FileId);
            var req = new Request(method, path);
            await Connection.Send<ApiMessage>(req);
        }
    }
}
