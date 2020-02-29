using System;
using System.Collections.Generic;
using System.Net.Http;

namespace Modio
{
    internal class Request
    {
        public Request(HttpMethod method, Uri baseAddress, Uri endpoint)
        {
            Method = method;
            BaseAddress = baseAddress;
            Endpoint = endpoint;
            Headers = new Dictionary<string, string>();
            Parameters = new Dictionary<string, string>();
        }

        public IDictionary<string, string> Headers { get; private set; }
        public HttpMethod Method { get; set; }
        public Uri BaseAddress { get; set; }
        public Uri Endpoint { get; set; }
        public IDictionary<string, string> Parameters { get; private set; }
        public object? Body { get; set; }
        public string? ContentType { get; set; }
    }
}
