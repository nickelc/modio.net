using System.Net.Http;

namespace Modio
{
    /// <summary>
    /// Represents a HTTP 401 - Unauthorized response returned from the API.
    /// </summary>
    public class UnauthorizedException : ApiException
    {
        /// <summary>
        /// Creates a new instance of UnauthorizedException.
        /// </summary>
        public UnauthorizedException(HttpResponseMessage response) : base(response) { }
    }
}
