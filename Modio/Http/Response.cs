using System.Collections.Generic;
using System.Net;

namespace Modio.Http;

internal class Response<T>
    where T : class
{
    public HttpStatusCode StatusCode { get; private set; }

    public IReadOnlyDictionary<string, string> Headers { get; private set; }

    public object? HttpContent { get; private set; }

    public T? Body { get; private set; }

    public Response(HttpStatusCode statusCode, IReadOnlyDictionary<string, string> headers)
    {
        StatusCode = statusCode;
        Headers = headers;
    }

    public Response(HttpStatusCode statusCode, IReadOnlyDictionary<string, string> headers, object? httpContent, T? body)
    {
        StatusCode = statusCode;
        Headers = headers;
        HttpContent = httpContent;
        Body = body;
    }
}