using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;

namespace Modio.Http;

internal static class HttpContentExtensions
{
    public static StringContent ToContent(this string content)
    {
        return new StringContent(content);
    }

    public static StreamContent ToContent(this FileInfo fileInfo)
    {
        return new StreamContent(fileInfo.OpenRead());
    }

    public static FileContent ToContent(this FileInfo fileInfo, IProgress<long>? progress)
    {
        return new FileContent(fileInfo.OpenRead(), progress);
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