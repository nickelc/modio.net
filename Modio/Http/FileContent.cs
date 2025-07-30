using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Modio.Http;

internal class FileContent(Stream source, IProgress<long>? progress) : HttpContent
{
    const int BUFFER_SIZE = 64 * 1024;

    public int BufferSize { get; set; } = BUFFER_SIZE;

    protected override Task SerializeToStreamAsync(Stream stream, TransportContext? context)
    {
        return Streams.CopyToAsync(source, stream, null, BufferSize, CancellationToken.None, progress);
    }

#if !NETSTANDARD2_0_OR_GREATER
    protected override Task SerializeToStreamAsync(Stream stream, TransportContext? context, CancellationToken cancellationToken)
    {
        return Streams.CopyToAsync(source, stream, null, BufferSize, cancellationToken, progress);
    }
#endif

    protected override bool TryComputeLength(out long length)
    {
        length = source.Length;
        return true;
    }

#if !NETSTANDARD2_0_OR_GREATER
    protected override Stream CreateContentReadStream(CancellationToken cancellationToken)
    {
        if (source.CanSeek)
        {
            source.Position = 0;
        }
        return new ReadOnlyStream(source);
    }
#endif

    protected override Task<Stream> CreateContentReadStreamAsync()
    {
        if (source.CanSeek)
        {
            source.Position = 0;
        }
        return Task.FromResult<Stream>(new ReadOnlyStream(source));
    }
}