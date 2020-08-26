using System;
using System.Net;
using System.Net.Http;
using System.Text.Json;

using Modio.Models;

namespace Modio
{
    /// <summary>
    /// Represents errors that occur from the mod.io API.
    /// </summary>
    public class ApiException : Exception
    {
        /// <summary>
        /// The HTTP status code associated with the response.
        /// </summary>
        public HttpStatusCode StatusCode { get; private set; }

        /// <summary>
        /// The raw exception payload from the response.
        /// </summary>
        public ApiError ApiError { get; private set; }

        /// <summary>
        /// Creates a new instance of ApiException.
        /// </summary>
        public ApiException(HttpResponseMessage response)
        {
            Ensure.ArgumentNotNull(response, nameof(response));

            StatusCode = response.StatusCode;
            ApiError = GetApiError(response);
        }

        /// <inheritdoc/>
        public override string Message
        {
            get
            {
                if (!string.IsNullOrWhiteSpace(ApiError.Message))
                {
                    return ApiError.Message!;
                }
                return "An error occurred with this API request";
            }
        }

        internal bool Is(HttpStatusCode status, int errorRef)
        {
            return StatusCode == status && ApiError.ErrorRef == errorRef;
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
