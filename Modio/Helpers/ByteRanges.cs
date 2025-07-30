using System;
using System.Linq;

namespace Modio;

internal static class ByteRanges
{
    public static (int, (long, long))[] Create(long length, long partSize)
    {
        var count = Math.DivRem(length, partSize, out long remainder);

        return Enumerable.Range(0, (int)count)
            .Select(i => (i, (i * partSize, (i + 1) * partSize - 1)))
            .Append(((int)count, (count * partSize, count * partSize - 1 + remainder)))
            .ToArray();
    }
}