using System.Net.Http;

namespace Modio;

/// <summary>
/// Represents a HTTP 404 - Not Found response returned from the API.
/// </summary>
public class NotFoundException : ApiException
{
    /// <summary>
    /// Initializes a new instance of NotFoundException.
    /// </summary>
    public NotFoundException(HttpResponseMessage response) : base(response) { }
}