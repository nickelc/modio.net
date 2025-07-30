namespace Modio;

public class StreamsTest
{
    class Progress : IProgress<long>
    {
        public long Total = 0;
        public void Report(long value)
        {
            Total += value;
        }
    }

    public static TheoryData<long, long?, long, string> CopyBoundsData
    {
        get
        {
            return new TheoryData<long, long?, long, string>
            {
                {0, 26, 26, "abcdefghijklmnopqrstuvwxyz"},
                {0, null, 26, "abcdefghijklmnopqrstuvwxyz"},
                {5, null, 21, "fghijklmnopqrstuvwxyz"},
                {12, 10, 10, "mnopqrstuv"},
            };
        }
    }

    [Theory]
    [MemberData(nameof(CopyBoundsData))]
    public async Task TestCopyToAsync(long start, long? count, long total, string expected)
    {
        var token = TestContext.Current.CancellationToken;
        var originalText = "abcdefghijklmnopqrstuvwxyz";

        using (var innerStream = new MemoryStream())
        using (var writer = new StreamWriter(innerStream))
        using (var targetStream = new MemoryStream())
        using (var reader = new StreamReader(targetStream))
        {
            await writer.WriteAsync(originalText);
            await writer.FlushAsync(token);

            var progress = new Progress();

            innerStream.Position = start;
            await Streams.CopyToAsync(innerStream, targetStream, count, bufferSize: 5, token, progress);

            targetStream.Position = 0;
            var text = await reader.ReadToEndAsync(token);
            Assert.Equal(expected, text);
            Assert.Equal(total, progress.Total);
        }
    }
}