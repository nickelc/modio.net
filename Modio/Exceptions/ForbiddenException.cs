using System.Net.Http;

namespace Modio;

/// <summary>
/// Represents a HTTP 403 - Forbidden response returned from the API.
/// </summary>
public class ForbiddenException : ApiException
{
    /// <summary>
    /// Initializes a new instance of ForbiddenException.
    /// </summary>
    public ForbiddenException(HttpResponseMessage response) : base(response) { }
}