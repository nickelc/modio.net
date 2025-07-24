using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Modio;

internal abstract class DelegatingStream(Stream @delegate) : Stream
{
    protected Stream Delegate { get => @delegate; }

    public override bool CanRead { get => @delegate.CanRead; }

    public override bool CanSeek { get => @delegate.CanSeek; }

    public override bool CanTimeout { get => @delegate.CanTimeout; }

    public override bool CanWrite { get => @delegate.CanWrite; }

    public override long Length { get => @delegate.Length; }

    public override long Position
    {
        get => @delegate.Position;
        set => @delegate.Position = value;
    }

    public override int ReadTimeout
    {
        get => @delegate.ReadTimeout;
        set => @delegate.ReadTimeout = value;
    }

    public override int WriteTimeout
    {
        get => @delegate.WriteTimeout;
        set => @delegate.WriteTimeout = value;
    }

    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            @delegate.Dispose();
        }
        base.Dispose(disposing);
    }

    public override void Close() => @delegate.Close();

    public override void Flush() => @delegate.Flush();

    public override Task FlushAsync(CancellationToken cancellationToken)
    {
        return @delegate.FlushAsync(cancellationToken);
    }

    public override IAsyncResult BeginRead(byte[] buffer, int offset, int count, AsyncCallback? callback, object? state)
    {
        return @delegate.BeginRead(buffer, offset, count, callback, state);
    }

    public override int EndRead(IAsyncResult asyncResult)
    {
        return @delegate.EndRead(asyncResult);
    }

    public override Task<int> ReadAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
    {
        return @delegate.ReadAsync(buffer, offset, count, cancellationToken);
    }

    public override IAsyncResult BeginWrite(byte[] buffer, int offset, int count, AsyncCallback? callback, object? state)
    {
        return @delegate.BeginWrite(buffer, offset, count, callback, state);
    }

    public override void EndWrite(IAsyncResult asyncResult)
    {
        @delegate.EndWrite(asyncResult);
    }

    public override Task WriteAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
    {
        return @delegate.WriteAsync(buffer, offset, count, cancellationToken);
    }

    public override int Read(byte[] buffer, int offset, int count)
    {
        return @delegate.Read(buffer, offset, count);
    }

    public override int ReadByte()
    {
        return @delegate.ReadByte();
    }

    public override void Write(byte[] buffer, int offset, int count)
    {
        @delegate.Write(buffer, offset, count);
    }

#if !NETSTANDARD2_0
    public override void Write(ReadOnlySpan<byte> buffer)
    {
        @delegate.Write(buffer);
    }
#endif

    public override void WriteByte(byte value)
    {
        @delegate.WriteByte(value);
    }

    public override long Seek(long offset, SeekOrigin origin)
    {
        return @delegate.Seek(offset, origin);
    }

    public override void SetLength(long value)
    {
        @delegate.SetLength(value);
    }
}