using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;

namespace Modio;

internal static class DictionaryExtensions
{
    public static TValue GetOrCreate<TKey, TValue>(this IDictionary<TKey, TValue> dict, TKey key)
        where TKey : notnull
        where TValue : new()
    {
        TValue value;
        if (!dict.TryGetValue(key, out value))
        {
            value = new TValue();
            dict.Add(key, value);
        }
        return value;
    }

    public static void Extend<T, K, V>(this T dict, params IDictionary<K, V>[] others)
        where T : IDictionary<K, V>
        where K : notnull
    {
        foreach (var other in others)
        {
            foreach (var (key, value) in other)
            {
                dict[key] = value;
            }
        }
    }
}

internal static class FileInfoExtensions
{
    public static StreamContent ToContent(this FileInfo fileInfo)
    {
        return new StreamContent(fileInfo.OpenRead());
    }
}

internal static class KeyValuePairExtensions
{
#if NETSTANDARD2_0
    public static void Deconstruct<T, V>(this KeyValuePair<T, V> kvp, out T key, out V value)
    {
        key = kvp.Key;
        value = kvp.Value;
    }
#endif
}

internal static class StringExtensions
{
    public static StringContent ToContent(this string content)
    {
        return new StringContent(content);
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
                                .Split(new[] { "&" }, StringSplitOptions.RemoveEmptyEntries);

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

        string query = string.Join("&", p.Select(kvp => kvp.Key + '=' + Uri.EscapeDataString(kvp.Value)));
        if (uri.IsAbsoluteUri)
        {
            var uriBuilder = new UriBuilder(uri)
            {
                Query = query
            };
            return uriBuilder.Uri;
        }

        return new Uri(uriWithoutQuery + '?' + query, UriKind.Relative);
    }
}