using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace Modio
{
    using ExceptionMap = Dictionary<HttpStatusCode, Func<HttpResponseMessage, ApiException>>;

    internal interface IConnection
    {
        Uri BaseAddress { get; }

        Task<Response<T>> Send<T>(Request request) where T : class;
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

        public async Task<Response<T>> Send<T>(Request request)
            where T : class
        {
            Ensure.ArgumentNotNull(request, nameof(request));

            var httpRequest = BuildRequest(request);
            var resp = await http.SendAsync(httpRequest);
            HandleErrors(resp);
            return await BuildResponse<T>(resp);
        }

        private HttpRequestMessage BuildRequest(Request request)
        {
            Ensure.ArgumentNotNull(request, nameof(request));

            HttpRequestMessage? req = null;
            try
            {
                var parameters = new Dictionary<string, string>(request.Parameters)
                {
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

                if (request.Body is HttpContent content)
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

        private async Task<Response<T>> BuildResponse<T>(HttpResponseMessage httpResponse)
            where T : class
        {
            var headers = httpResponse.Headers.ToDictionary(k => k.Key, v => v.Value.First());
            if (httpResponse.StatusCode == HttpStatusCode.NoContent)
            {
                return new Response<T>(
                    httpResponse.StatusCode,
                    headers
                );
            }
            else
            {
                var content = await httpResponse.Content.ReadAsStreamAsync();
                var obj = await JsonSerializer.DeserializeAsync<T>(content);
                return new Response<T>(
                    httpResponse.StatusCode,
                    headers,
                    httpResponse.Content,
                    obj
                );
            }
        }

        static readonly ExceptionMap EXCEPTION_MAP = new ExceptionMap {
            {HttpStatusCode.Unauthorized, resp => new UnauthorizedException(resp)},
            {HttpStatusCode.Forbidden, resp => new ForbiddenException(resp)},
            {HttpStatusCode.NotFound, resp => new NotFoundException(resp)},
            {HttpStatusCode.UnprocessableEntity, resp => new ApiValidationException(resp)},
            {HttpStatusCode.TooManyRequests, resp => new RateLimitExceededException(resp)}
        };

        static void HandleErrors(HttpResponseMessage response)
        {
            Func<HttpResponseMessage, ApiException>? func;
            if (EXCEPTION_MAP.TryGetValue(response.StatusCode, out func))
            {
                throw func(response);
            }

            if ((int)response.StatusCode >= 400)
            {
                throw new ApiException(response);
            }
        }
    }
}
