using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

namespace Modio.Http;

internal class ByteRangeContent : HttpContent
{
    const int BUFFER_SIZE = 64 * 1024;

    private readonly Stream source;
    private readonly long start;
    private readonly long end;

    public int BufferSize { get; set; } = BUFFER_SIZE;
    public long Length { get => end - start + 1; }
    public IProgress<long>? Progress { get; set; }

    public ByteRangeContent(Stream source, long start, long end, long total)
    {
        this.source = source;
        this.start = start;
        this.end = end;

        source.Position = start;

        var contentRangeValue = new ContentRangeHeaderValue(start, end, total);
        Headers.Add("Content-Range", contentRangeValue.ToString());
    }

    protected override Task SerializeToStreamAsync(Stream stream, TransportContext? context)
    {
        return Streams.CopyToAsync(source, stream, Length, BufferSize, CancellationToken.None, Progress);
    }

#if !NETSTANDARD2_0_OR_GREATER
    protected override Task SerializeToStreamAsync(Stream stream, TransportContext? context, CancellationToken cancellationToken)
    {
        return Streams.CopyToAsync(source, stream, Length, BufferSize, cancellationToken, Progress);
    }
#endif

    protected override bool TryComputeLength(out long length)
    {
        length = Length;
        return true;
    }

#if !NETSTANDARD2_0_OR_GREATER
    protected override Stream CreateContentReadStream(CancellationToken cancellationToken)
    {
        if (source.CanSeek)
        {
            source.Position = start;
        }
        return new ReadOnlyStream(source);
    }
#endif

    protected override Task<Stream> CreateContentReadStreamAsync()
    {
        if (source.CanSeek)
        {
            source.Position = start;
        }
        return Task.FromResult<Stream>(new ReadOnlyStream(source));
    }
}