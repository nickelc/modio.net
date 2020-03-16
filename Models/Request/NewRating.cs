using System.Net.Http;

namespace Modio
{
    public enum NewRating
    {
        Positive = 1,
        Negative = -1,
    }

    internal static class NewRatingMethods
    {
        public static HttpContent ToContent(this NewRating rating)
        {
            var parameters = new Parameters {
                {"rating", ((int)rating).ToString()},
            };
            return parameters.ToContent();
        }
    }
}
