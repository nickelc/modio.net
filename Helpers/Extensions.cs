using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Modio
{
    internal static class DictionaryExtensions
    {
        public static TValue GetOrCreate<TKey, TValue>(this IDictionary<TKey, TValue> dict, TKey key)
            where TKey : notnull
            where TValue : new()
        {
            TValue value;
            if (!dict.TryGetValue(key, out value)) {
                value = new TValue();
                dict.Add(key, value);
            }
            return value;
        }
    }

    internal static class StringExtensions
    {
        public static Uri FormatUri(this string pattern, params object[] args)
        {
            return new Uri(string.Format(CultureInfo.InvariantCulture, pattern, args), UriKind.Relative);
        }
    }

    internal static class UriExtensions
    {
        public static Uri ApplyParameters(this Uri uri, IDictionary<string, string> parameters)
        {
            Ensure.ArgumentNotNull(uri, nameof(uri));

            if (parameters == null || !parameters.Any()) return uri;

            IDictionary<string, string> p = new Dictionary<string, string>(parameters);

            var hasQueryString = uri.OriginalString.IndexOf("?", StringComparison.Ordinal);

            string uriWithoutQuery = hasQueryString == -1
                    ? uri.ToString()
                    : uri.OriginalString.Substring(0, hasQueryString);

            string queryString;
            if (uri.IsAbsoluteUri)
            {
                queryString = uri.Query;
            }
            else
            {
                queryString = hasQueryString == -1
                    ? ""
                    : uri.OriginalString.Substring(hasQueryString);
            }

            var values = queryString.Replace("?", "")
                                    .Split(new[] { '&' }, StringSplitOptions.RemoveEmptyEntries);

            var existingParameters = values.ToDictionary(
                        key => key.Substring(0, key.IndexOf('=')),
                        value => value.Substring(value.IndexOf('=') + 1));

            foreach (var existing in existingParameters)
            {
                if (!p.ContainsKey(existing.Key))
                {
                    p.Add(existing);
                }
            }

            Func<string, string, string> mapValueFunc = (key, value) => key == "q" ? value : Uri.EscapeDataString(value);

            string query = string.Join("&", p.Select(kvp => kvp.Key + "=" + mapValueFunc(kvp.Key, kvp.Value)));
            if (uri.IsAbsoluteUri)
            {
                var uriBuilder = new UriBuilder(uri)
                {
                    Query = query
                };
                return uriBuilder.Uri;
            }

            return new Uri(uriWithoutQuery + "?" + query, UriKind.Relative);
        }
    }
}
