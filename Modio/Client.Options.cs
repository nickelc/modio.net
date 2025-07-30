using System;
using System.Net.Http;

namespace Modio;

public partial class Client
{
    /// <summary>
    /// Configuration options for the Mod.io API client.
    /// </summary>
    public record Options
    {
        /// <summary>
        /// The required API key.
        /// </summary>
        public string ApiKey { get; set; }

        /// <summary>
        /// The optional OAuth2 access token.
        /// </summary>
        public string? Token { get; set; }

        /// <summary>
        /// The optional OAuth2 access token.
        /// </summary>
        public Uri? BaseUrl { get; set; }

        /// <summary>
        /// Custom <see cref="HttpClient"/> instance.
        /// </summary>
        public HttpClient? HttpClient { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Options"/> class.
        /// </summary>
        public Options(string apiKey)
        {
            ApiKey = apiKey;
        }

        /// <summary>
        /// Create a new instance of the <see cref="Options"/> class from a <see cref="Credentials"/> instance.
        /// </summary>
        public static Options FromCredentials(Credentials credentials)
        {
            Ensure.ArgumentNotNull(credentials, nameof(credentials));

            return new Options(credentials.ApiKey)
            {
                Token = credentials.Token,
            };
        }
    }
}