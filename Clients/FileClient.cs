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
            var req = new Request(method, Connection.BaseAddress, path);

            return await Connection.Send<File>(req);
        }
    }
}
