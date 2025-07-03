using System.Text.Json;
using System.Text.Json.Serialization;

namespace Modio.Models.Converters
{

    public class Mod
    {
        [JsonPropertyName("id")]
        public uint Id { get; set; }

        [JsonPropertyName("modfile")]
        [JsonConverter(typeof(EmptyObjectConverter))]
        public File? Modfile { get; set; }

        public override bool Equals(object? other)
        {
            return other is Mod m && (m.Id, m.Modfile).Equals((Id, Modfile));
        }

        public override int GetHashCode()
        {
            return (Id, Modfile).GetHashCode();
        }
    }

    public class File
    {
        [JsonPropertyName("id")]
        public uint Id { get; set; }

        [JsonPropertyName("mod_id")]
        public uint ModId { get; set; }

        public override bool Equals(object? other)
        {
            return other is File f && (f.Id, f.ModId).Equals((Id, ModId));
        }

        public override int GetHashCode()
        {
            return (Id, ModId).GetHashCode();
        }
    }

    public class EmptyObjectConverterTest
    {
        [Fact]
        public void TestDeserializeEmptyObject()
        {
            Mod expected = new()
            {
                Id = 123,
                Modfile = null,
            };

            Assert.Equal(expected, JsonSerializer.Deserialize<Mod>("""{"id":123}"""));
            Assert.Equal(expected, JsonSerializer.Deserialize<Mod>("""{"id":123,"modfile":null}"""));
            Assert.Equal(expected, JsonSerializer.Deserialize<Mod>("""{"id":123,"modfile":{}}"""));
        }

        [Fact]
        public void TestSerializeModfile()
        {
            Mod mod = new()
            {
                Id = 123,
                Modfile = new()
                {
                    Id = 456,
                    ModId = 123,
                },
            };

            Assert.Equal("""{"id":123,"modfile":{"id":456,"mod_id":123}}""", JsonSerializer.Serialize(mod));
        }

        [Fact]
        public void TestSerializeModfileNull()
        {
            Mod mod = new()
            {
                Id = 123,
                Modfile = null,
            };

            Assert.Equal("""{"id":123,"modfile":null}""", JsonSerializer.Serialize(mod));
        }
    }
}
