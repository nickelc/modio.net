using System.Threading.Tasks;

using Modio.Filters;
using Modio.Models;

namespace Modio
{
    public class FilesClient : ApiClient
    {
        public uint GameId { get; private set; }

        public uint ModId { get; private set; }

        internal FilesClient(IConnection connection, uint game, uint mod) : base(connection)
        {
            GameId = game;
            ModId = mod;
        }

        public FileClient this[uint file] => new FileClient(Connection, GameId, ModId, file);

        public SearchClient<File> Search(Filter? filter = null)
        {
            var route = Routes.GetFiles(GameId, ModId);
            return new SearchClient<File>(Connection, route, filter);
        }

        public async Task<File> Add(NewFile newFile)
        {
            using (var content = newFile.ToContent())
            {
                var (method, path) = Routes.AddFile(GameId, ModId);
                var req = new Request(method, path, content);

                var resp = await Connection.Send<File>(req);
                return resp.Body!;
            }
        }

        public async Task<File?> Edit(uint file, EditFile editFile)
        {
            return await this[file].Edit(editFile);
        }

        public async Task Delete(uint file)
        {
            await this[file].Delete();
        }
    }
}
