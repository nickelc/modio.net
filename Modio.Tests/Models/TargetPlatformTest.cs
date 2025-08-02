using System.Text.Json;

namespace Modio.Models;

public class TargetPlatformTest
{
    public static TheoryData<TargetPlatform?, string> SerializationData
    {
        get
        {
            return [
                (TargetPlatform.Android, @"""android"""),
                (TargetPlatform.iOS, @"""ios"""),
                (TargetPlatform.Linux, @"""linux"""),
                (TargetPlatform.Mac, @"""mac"""),
                (TargetPlatform.Oculus, @"""oculus"""),
                (TargetPlatform.PlayStation4, @"""ps4"""),
                (TargetPlatform.PlayStation5, @"""ps5"""),
                (TargetPlatform.Source, @"""source"""),
                (TargetPlatform.Switch, @"""switch"""),
                (TargetPlatform.Windows, @"""windows"""),
                (TargetPlatform.XboxOne, @"""xboxone"""),
                (TargetPlatform.XboxSeriesX, @"""xboxseriesx"""),
                (null, "null"),
            ];
        }
    }

    [Theory]
    [MemberData(nameof(SerializationData))]
    public void TestSerialization(TargetPlatform? expected_platform, string expected_json)
    {
        TargetPlatform? platform = JsonSerializer.Deserialize<TargetPlatform>(expected_json);
        Assert.Same(expected_platform, platform);

        string value = JsonSerializer.Serialize(expected_platform);
        Assert.Equal(expected_json, value);
    }
}