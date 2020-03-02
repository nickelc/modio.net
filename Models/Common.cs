using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Modio.Models
{
    public class Result<T>
    {
        [JsonPropertyName("result_count")]
        public uint Count { get; set; }
        [JsonPropertyName("result_offset")]
        public uint Offset { get; set; }
        [JsonPropertyName("result_limit")]
        public uint Limit { get; set; }
        [JsonPropertyName("result_total")]
        public uint Total { get; set; }
        [JsonPropertyName("data")]
        public List<T> Data
        {
            get
            {
                if (Data == null)
                {
                    Data = new List<T>();
                }
                return Data;
            }
            set => Data = value;
        }
    }
}
