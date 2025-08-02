using System.Net.Http;

using Modio.Models;

namespace Modio;

public partial class Client
{
    /// <summary>
    /// Returns a builder for configuring a <see cref="Client"/>.
    /// </summary>
    public static Builder GetBuilder(string apiKey) => new(apiKey);

    /// <summary>
    /// A fluent builder class for <see cref="Client"/>.
    /// </summary>
    public class Builder
    {
        private readonly Options options;

        internal Builder(string apiKey)
        {
            options = new Options(apiKey);
        }

        /// <summary>
        /// Set OAuth2 authentication token.
        /// </summary>
        public Builder WithToken(string token)
        {
            options.Token = token;
            return this;
        }

        /// <summary>
        /// Use the default API host ("https://api.mod.io/v1")
        /// </summary>
        public Builder WithDefaultHost()
        {
            options.BaseUrl = ModioApiUrl;
            return this;
        }

        /// <summary>
        /// Use the test API host ("https://api.test.mod.io/v1")
        /// </summary>
        public Builder WithTestHost()
        {
            options.BaseUrl = ModioApiTestUrl;
            return this;
        }

        /// <summary>
        /// Use a specifc user API host ("https://u-XXXX.modapi.io/v1").
        /// </summary>
        public Builder WithUserHost(int userId)
        {
            options.BaseUrl = new($"https://u-{userId}.modapi.io/v1");
            return this;
        }

        /// <summary>
        /// Use a specifc game API host ("https://g-XXXX.modapi.io/v1").
        /// </summary>
        public Builder WithGameHost(int gameId)
        {
            options.BaseUrl = new($"https://g-{gameId}.modapi.io/v1");
            return this;
        }

        /// <summary>
        /// Set the platform the API requests are originating from.
        /// </summary>
        ///
        /// <remarks>
        /// https://docs.mod.io/restapiref/#targeting-a-platform
        /// </remarks>
        public Builder WithTargetPlatform(TargetPlatform platform)
        {
            options.TargetPlatform = platform;
            return this;
        }

        /// <summary>
        /// Set custom <see cref="HttpClient"/> instance.
        /// </summary>
        public Builder WithHttpClient(HttpClient httpClient)
        {
            options.HttpClient = httpClient;
            return this;
        }

        /// <summary>
        /// Returns the configured <see cref="Client"/>.
        /// </summary>
        public Client Build() => new(options);
    }
}