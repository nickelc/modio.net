using System.Collections.Generic;
using System.Net.Http;

namespace Modio
{
    public class ApiValidationException : ApiException
    {
        public ApiValidationException(HttpResponseMessage response) : base(response) { }

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
