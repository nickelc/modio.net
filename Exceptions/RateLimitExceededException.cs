using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Modio
{
    public class RateLimitExceededException : ApiException
    {
        public int Limit { get; private set; }

        public int Remaining { get; private set; }

        public int RetryAfter { get; private set; }

        public RateLimitExceededException(HttpResponseMessage response) : base(response)
        {
            Limit = GetValueAsInt32(response.Headers, "X-RateLimit-Limit");
            Remaining = GetValueAsInt32(response.Headers, "X-RateLimit-Remaining");
            RetryAfter = GetValueAsInt32(response.Headers, "X-RateLimit-RetryAfter");
        }

        static int GetValueAsInt32(HttpResponseHeaders headers, string key) {
            IEnumerable<string>? values = null;
            if (headers.TryGetValues(key, out values)) {
                int value;
                int.TryParse(values.First(), out value);
                return value;
            }
            return 0;
        }
    }
}
