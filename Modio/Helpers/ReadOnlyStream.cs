using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Modio;

internal sealed class ReadOnlyStream(Stream @delegate) : DelegatingStream(@delegate)
{
    public override bool CanWrite => false;

    public override void Flush() { }

    public override Task FlushAsync(CancellationToken cancellationToken) => Task.CompletedTask;

    public override void SetLength(long value) => throw NotSupportedException();

    public override IAsyncResult BeginWrite(byte[] buffer, int offset, int count, AsyncCallback? callback, object? state) =>
        throw NotSupportedException();

    public override void EndWrite(IAsyncResult asyncResult) => throw NotSupportedException();

    public override void Write(byte[] buffer, int offset, int count) => throw NotSupportedException();

    public override void WriteByte(byte value) => throw NotSupportedException();

    public override Task WriteAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken) =>
        throw NotSupportedException();

#if !NETSTANDARD2_0
        public override void Write(ReadOnlySpan<byte> buffer) => throw NotSupportedException();

        public override ValueTask WriteAsync(ReadOnlyMemory<byte> buffer, CancellationToken cancellationToken = default) =>
            throw NotSupportedException();
#endif

    public override int WriteTimeout
    {
        get => throw new InvalidOperationException("The stream does not support writing.");
        set => throw new InvalidOperationException("The stream does not support writing.");
    }

    private static NotSupportedException NotSupportedException()
    {
        return new NotSupportedException("The stream does not support writing.");
    }
}