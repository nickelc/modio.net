namespace Modio;

public class ByteRangesTest
{
    [Fact]
    public void TestCreateByteRanges()
    {
        const long CHUNK_SIZE = 50 * 1024 * 1024; // 50MB
        const long SIZE = 522 * 1024 * 1024;

        (int, (long, long))[] expected = [
            (0, (0, 52428799)),
            (1, (52428800, 104857599)),
            (2, (104857600, 157286399)),
            (3, (157286400, 209715199)),
            (4, (209715200, 262143999)),
            (5, (262144000, 314572799)),
            (6, (314572800, 367001599)),
            (7, (367001600, 419430399)),
            (8, (419430400, 471859199)),
            (9, (471859200, 524287999)),
            (10, (524288000, 547356671)),
        ];

        var ranges = ByteRanges.Create(SIZE, CHUNK_SIZE);

        Assert.Equal(11, ranges.Length);
        Assert.Equal(expected, ranges);
    }
}