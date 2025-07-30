using System;
using System.Buffers;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Modio;

internal static class Streams
{
    public static async Task CopyToAsync(Stream source, Stream destination, long? count, int bufferSize, CancellationToken cancellationToken, IProgress<long>? progress = null)
    {
        var bytesRemaining = count;

        var buffer = ArrayPool<byte>.Shared.Rent(bufferSize);

        try
        {
            while (true)
            {
                if (bytesRemaining != null && bytesRemaining <= 0)
                {
                    return;
                }

                cancellationToken.ThrowIfCancellationRequested();

                var readLength = (int)Math.Min(bytesRemaining ?? bufferSize, bufferSize);

#if NETSTANDARD2_0
                var read = await source.ReadAsync(buffer, 0, readLength, cancellationToken);
#else
                var read = await source.ReadAsync(buffer.AsMemory(0, readLength), cancellationToken);
#endif

                bytesRemaining -= read;

                if (read == 0)
                {
                    return;
                }

                cancellationToken.ThrowIfCancellationRequested();

#if NETSTANDARD2_0
                await destination.WriteAsync(buffer, 0, read, cancellationToken);
#else
                await destination.WriteAsync(buffer.AsMemory(0, read), cancellationToken);
#endif

                progress?.Report(read);
            }
        }
        finally
        {
            ArrayPool<byte>.Shared.Return(buffer);
        }
    }
}