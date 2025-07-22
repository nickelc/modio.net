﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

using Modio.Filters;
using Modio.Models;

namespace Modio;

/// <summary>
/// Client to retrieve search results from various API endpoints.
/// </summary>
public class SearchClient<T> : ApiClient where T : class
{
    private (HttpMethod, Uri) route;
    private Filter? filter;

    internal SearchClient(IConnection connection, (HttpMethod, Uri) route, Filter? filter) : base(connection)
    {
        this.route = route;
        this.filter = filter;
    }

    /// <summary>
    /// Returns the first result of the search.
    /// </summary>
    public async Task<T?> First()
    {
        filter = filter != null ? filter.Limit(1) : Filter.WithLimit(1);
        var page = await FirstPage();
        return page.FirstOrDefault();
    }

    /// <summary>
    /// Returns the first page of the search result.
    /// </summary>
    public async Task<IReadOnlyList<T>> FirstPage()
    {
        await using (var enumerator = ToPagedEnumerable().GetAsyncEnumerator())
        {
            await enumerator.MoveNextAsync();
            return enumerator.Current ?? new List<T>().AsReadOnly();
        }
    }

    /// <summary>
    /// Returns the complete search result as <see cref="IReadOnlyList{T}"/>.
    /// </summary>
    public async Task<IReadOnlyList<T>> ToList()
    {
        var list = new List<T>();
        await foreach (var page in ToPagedEnumerable())
        {
            list.AddRange(page);
        }
        return list.AsReadOnly();
    }

    /// <summary>
    /// Returns the complete search result as <see cref="IAsyncEnumerable{T}"/>.
    /// </summary>
    public async IAsyncEnumerable<T> ToEnumerable()
    {
        await foreach (var page in ToPagedEnumerable())
        {
            foreach (var item in page)
            {
                yield return item;
            }
        }
    }

    /// <summary>
    /// Returns the complete search result by page as <see cref="IAsyncEnumerable{T}"/>.
    /// </summary>
    public async IAsyncEnumerable<IReadOnlyList<T>> ToPagedEnumerable()
    {
        var (method, path) = this.route;
        uint? remaining = null;
        do
        {
            var req = new Request(method, path);
            if (filter != null)
            {
                req.Parameters.Extend(filter.ToParameters());
            }
            var resp = await Connection.Send<Result<T>>(req);
            var result = resp.Body!;

            remaining ??= result.Total;
            remaining -= result.Count;

            var limit = result.Limit;
            var offset = result.Offset;

            filter = (filter ?? Filter.WithLimit(limit)).Offset(offset + limit);

            yield return result.Data.AsReadOnly();
        } while (remaining > 0);
    }
}