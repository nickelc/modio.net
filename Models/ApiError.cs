using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Modio.Models
{
    public class ApiError
    {
        public ApiError() { }

        public ApiError(string? message)
        {
            Message = message;
        }

        [JsonPropertyName("message")]
        public string? Message { get; set; }

        [JsonPropertyName("errors")]
        public IDictionary<string, string>? Errors { get; set; }
    }

    class ApiErrorResponse
    {
        [JsonPropertyName("error")]
        public ApiError? Error { get; set; }
    }
}
