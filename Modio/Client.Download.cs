using System.Net.Http;
using System.Threading.Tasks;

using FileInfo = System.IO.FileInfo;
using Stream = System.IO.Stream;

using Modio.Models;

namespace Modio
{
    public partial class Client
    {
        /// <summary>
        /// Downloads the mod's primary file to <paramref name="dest"/>.
        /// </summary>
        public async Task Download(uint gameId, uint modId, FileInfo dest)
        {
            var mod = await GetModForDownload(gameId, modId);
            await Download(mod, dest);
        }

        /// <summary>
        /// Downloads the mod's primary file to <paramref name="stream"/>.
        /// </summary>
        public async Task Download(uint gameId, uint modId, Stream stream)
        {
            var mod = await GetModForDownload(gameId, modId);
            await Download(mod, stream);
        }

        /// <summary>
        /// Downloads the mod file to <paramref name="dest"/>.
        /// </summary>
        public async Task Download(uint gameId, uint modId, uint fileId, FileInfo dest)
        {
            var file = await Games[gameId].Mods[modId].Files[fileId].Get();
            await Download(file, dest);
        }

        /// <summary>
        /// Downloads the mod file to <paramref name="stream"/>.
        /// </summary>
        public async Task Download(uint gameId, uint modId, uint fileId, Stream stream)
        {
            var file = await GetFileForDownload(gameId, modId, fileId);
            await Download(file, stream);
        }

        /// <summary>
        /// Downloads the mod's primary file to <paramref name="dest"/>.
        /// </summary>
        public async Task Download(Mod mod, FileInfo dest)
        {
            if (mod.Modfile is File file)
            {
                await Download(file, dest);
            }
            else
            {
                await Download(mod.GameId, mod.Id, dest);
            }
        }

        /// <summary>
        /// Downloads the mod's primary file to <paramref name="stream"/>.
        /// </summary>
        public async Task Download(Mod mod, Stream stream)
        {
            if (mod.Modfile is File file)
            {
                await Download(file, stream);
            }
            else
            {
                await Download(mod.GameId, mod.Id, stream);
            }
        }

        /// <summary>
        /// Downloads the mod file to <paramref name="dest"/>.
        /// </summary>
        public async Task Download(File file, FileInfo dest)
        {
            using (var fs = dest.Create())
            {
                await Download(file, fs);
            }
        }

        /// <summary>
        /// Downloads the mod file to <paramref name="stream"/>.
        /// </summary>
        public async Task Download(File file, Stream stream)
        {
            var client = new HttpClient();
            try
            {
                using (var input = await client.GetStreamAsync(file.Download?.BinaryUrl))
                {
                    await input.CopyToAsync(stream);
                }
            }
            catch (NotFoundException ex)
            {
                throw new DownloadException("Failed to download the file.", ex);
            }
        }

        async Task<Mod> GetModForDownload(uint gameId, uint modId)
        {
            try
            {
                var mod = await Games[gameId].Mods[modId].Get();
                if (mod.Modfile == null)
                {
                    throw new NoPrimaryFileException();
                }
                return mod;
            }
            catch (NotFoundException ex)
            {
                throw new DownloadException("Failed to retrieve the mod.", ex);
            }
        }

        async Task<File> GetFileForDownload(uint gameId, uint modId, uint fileId)
        {
            try
            {
                return await Games[gameId].Mods[modId].Files[fileId].Get();
            }
            catch (NotFoundException ex)
            {
                throw new DownloadException("Failed to retrieve the file.", ex);
            }
        }
    }
}
