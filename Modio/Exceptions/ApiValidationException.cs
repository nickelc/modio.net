using System.Collections.Generic;
using System.Net.Http;

namespace Modio
{
    /// <summary>
    /// Represents a HTTP 422 - Unprocessable Entity response returned from the API.
    /// </summary>
    public class ApiValidationException : ApiException
    {
        /// <summary>
        /// Initializes a new instance of ApiValidationException.
        /// </summary>
        public ApiValidationException(HttpResponseMessage response) : base(response) { }

        /// <summary>
        /// Validation errors.
        /// </summary>
        public IReadOnlyDictionary<string, string> Errors
        {
            get
            {
                var errors = ApiError?.Errors ?? new Dictionary<string, string>();
                return (IReadOnlyDictionary<string, string>)errors;
            }
        }
    }
}
