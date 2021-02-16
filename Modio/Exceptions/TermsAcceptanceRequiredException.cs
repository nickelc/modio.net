using System.Net;
using System.Net.Http;

using Modio.Models;

namespace Modio
{
    /// <summary>
    /// The acceptance of the Terms of Use is required.
    ///
    /// Represents a HTTP 400 with a error ref code <code>11051</code>.
    /// </summary>
    public class TermsAcceptanceRequiredException : ApiException
    {
        /// <summary>
        /// Creates a new instance of TermsAcceptanceRequiredException.
        /// </summary>
        public TermsAcceptanceRequiredException(HttpStatusCode status, ApiError error) : base(status, error) { }
    }
}
