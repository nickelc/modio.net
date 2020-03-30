using System;
using System.Collections.Generic;
using System.Net.Http;

namespace Modio
{
    internal class Request
    {
        public Request(HttpMethod method, Uri endpoint, HttpContent? body = null)
        {
            Method = method;
            Endpoint = endpoint;
            Body = body;
            Headers = new Dictionary<string, string>();
            Parameters = new Dictionary<string, string>();
        }

        public IDictionary<string, string> Headers { get; private set; }
        public HttpMethod Method { get; set; }
        public Uri Endpoint { get; set; }
        public IDictionary<string, string> Parameters { get; private set; }
        public HttpContent? Body { get; set; }
    }
}
