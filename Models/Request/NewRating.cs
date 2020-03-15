using System.Collections.Generic;
using System.Net.Http;

namespace Modio
{
    using Parameter = KeyValuePair<string, string>;

    public enum NewRating
    {
        Positive = 1,
        Negative = -1,
    }

    internal static class NewRatingMethods
    {
        public static HttpContent ToContent(this NewRating rating)
        {
            var parameter = new Parameter("rating", ((int)rating).ToString());
            return new FormUrlEncodedContent(new[] { parameter });
        }
    }
}
