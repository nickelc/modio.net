using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Modio
{
    internal class NoHttpContent : HttpContent
    {
        public NoHttpContent() : this("application/x-www-form-urlencoded") { }

        public NoHttpContent(string mediaType)
        {
            Headers.ContentType = new MediaTypeHeaderValue(mediaType);
        }

        protected override Task SerializeToStreamAsync(Stream stream, TransportContext? context)
        {
            return Task.CompletedTask;
        }

        protected override bool TryComputeLength(out long length)
        {
            length = 0;
            return true;
        }
    }
}
