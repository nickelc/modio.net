using System.Collections.Generic;
using System.Net.Http;

namespace Modio
{
    internal class Parameters : List<KeyValuePair<string, string>>
    {
        public Parameters() { }

        public Parameters(IEnumerable<(string, string)> values)
        {
            foreach (var (name, value) in values)
            {
                Add(name, value);
            }
        }

        public void Add(string name, string value)
        {
            Add(new KeyValuePair<string, string>(name, value));
        }

        public HttpContent ToContent()
        {
            return new FormUrlEncodedContent(this);
        }
    }

    internal static class ParametersExtensions
    {
        public static HttpContent ToContent(this IEnumerable<(string, string)> values)
        {
            return new Parameters(values).ToContent();
        }
    }
}
