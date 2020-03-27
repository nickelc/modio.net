using System;
using System.Net;
using System.Net.Http;
using System.Text.Json;

using Modio.Models;

namespace Modio
{
    public class ApiException : Exception
    {
        public HttpStatusCode StatusCode { get; private set; }
        public ApiError? ApiError { get; private set; }

        public ApiException(HttpResponseMessage response)
        {
            Ensure.ArgumentNotNull(response, nameof(response));

            StatusCode = response.StatusCode;
            ApiError = GetApiError(response);
        }

        public override string Message
        {
            get
            {
                if (!string.IsNullOrWhiteSpace(ApiError?.Message))
                {
                    return ApiError.Message;
                }
                return "An error occurred with this API request";
            }
        }

        static ApiError GetApiError(HttpResponseMessage response)
        {
            string? content = response?.Content.ReadAsStringAsync().Result;
            return GetApiError(content);
        }

        static ApiError GetApiError(string? message)
        {
            try
            {
                if (!string.IsNullOrEmpty(message))
                {
                    var error = JsonSerializer.Deserialize<ApiErrorResponse>(message);
                    return error.Error ?? new ApiError(message);
                }
            }
            catch (Exception)
            {
            }
            return new ApiError(message);
        }
    }
}
