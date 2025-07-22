using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Modio;

/// <summary>
/// Exception thrown when mod.io API Rate limits are exceeded.
/// </summary>
public class RateLimitExceededException : ApiException
{
    /// <summary>
    /// The maximum number of requests that the consumer is permitted to make per minute.
    /// </summary>
    public int Limit { get; private set; }

    /// <summary>
    /// The number of requests remaining in the current rate limit window.
    /// </summary>
    public int Remaining { get; private set; }

    /// <summary>
    /// The number of seconds until the current rate limit window resets.
    /// </summary>
    public int RetryAfter { get; private set; }

    /// <summary>
    /// Creates a new instance of RateLimitExceededException.
    /// </summary>
    public RateLimitExceededException(HttpResponseMessage response) : base(response)
    {
        Limit = GetValueAsInt32(response.Headers, "X-RateLimit-Limit");
        Remaining = GetValueAsInt32(response.Headers, "X-RateLimit-Remaining");
        RetryAfter = GetValueAsInt32(response.Headers, "X-RateLimit-RetryAfter");
    }

    static int GetValueAsInt32(HttpResponseHeaders headers, string key)
    {
        IEnumerable<string>? values = null;
        if (headers.TryGetValues(key, out values))
        {
            int value;
            int.TryParse(values.First(), out value);
            return value;
        }
        return 0;
    }
}