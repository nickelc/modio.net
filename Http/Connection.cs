using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;

namespace Modio
{
    internal interface IConnection
    {
        Uri BaseAddress { get; }

        Task<T> Send<T>(Request request);
    }

    internal class Connection : IConnection
    {
        readonly HttpClient http;

        public Uri BaseAddress { get; private set; }

        public Credentials Credentials { get; set; }

        public Connection(Uri baseAddress, Credentials credentials)
        {
            http = new HttpClient();
            BaseAddress = baseAddress;
            Credentials = credentials;
        }

        public async Task<T> Send<T>(Request request)
        {
            Ensure.ArgumentNotNull(request, nameof(request));

            var httpRequest = BuildRequest(request);
            var resp = await http.SendAsync(httpRequest);
            HandleErrors(resp);
            var content = await resp.Content.ReadAsStreamAsync();
            return await JsonSerializer.DeserializeAsync<T>(content);
        }

        private HttpRequestMessage BuildRequest(Request request)
        {
            Ensure.ArgumentNotNull(request, nameof(request));

            HttpRequestMessage? req = null;
            try
            {
                var parameters = new Dictionary<string, string>(request.Parameters) {
                    ["api_key"] = Credentials.ApiKey,
                };
                var uri = new Uri(request.BaseAddress, request.Endpoint)
                    .ApplyParameters(parameters);

                req = new HttpRequestMessage(request.Method, uri);
                foreach (var header in request.Headers)
                {
                    req.Headers.Add(header.Key, header.Value);
                }
                if (Credentials.Token != null)
                {
                    req.Headers.Authorization = new AuthenticationHeaderValue("Bearer", Credentials.Token);
                }

                var content = request.Body as HttpContent;
                if (content != null)
                {
                    req.Content = content;
                }
            }
            catch (Exception)
            {
                if (req != null) req.Dispose();
                throw;
            }
            return req;
        }

        static void HandleErrors(HttpResponseMessage response) {
            if ((int) response.StatusCode >= 400) {
                throw new ApiException(response);
            }
        }
    }
}
