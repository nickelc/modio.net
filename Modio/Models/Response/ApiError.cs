using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Modio.Models;

/// <remarks>
/// https://docs.mod.io/restapiref/#error-object
/// </remarks>
public class ApiError
{
    /// Creates a new instance of ApiError.
    public ApiError() { }

    internal ApiError(string? message)
    {
        Message = message;
    }

    /// <summary>
    /// The mod.io error code.
    /// </summary>
    [JsonPropertyName("error_ref")]
    public int ErrorRef { get; set; }

    /// <summary>
    /// Error message returned by the mod.io API.
    /// </summary>
    [JsonPropertyName("message")]
    public string? Message { get; set; }

    /// <summary>
    /// Validation errors
    /// </summary>
    [JsonPropertyName("errors")]
    public IDictionary<string, string>? Errors { get; set; }
}

class ApiErrorResponse
{
    [JsonPropertyName("error")]
    public ApiError? Error { get; set; }
}