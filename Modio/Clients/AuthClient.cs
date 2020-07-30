using System;
using System.Net.Http;
using System.Threading.Tasks;

using Modio.Models;

namespace Modio
{
    /// <summary>
    /// Auth client to request OAuth access tokens.
    /// </summary>
    public class AuthClient : ApiClient
    {
        internal AuthClient(IConnection connection) : base(connection) { }

        /// <summary>
        /// Request a security code be sent to the email of the user.
        /// </summary>
        public async Task RequestCode(string api_key, string email)
        {
            var parameters = new Parameters {
                {"api_key", api_key},
                {"email", email},
            };
            var (method, path) = Routes.AuthEmailRequest();
            var req = new Request(method, path, parameters.ToContent());

            await Connection.Send<ApiMessage>(req);
        }

        /// <summary>
        /// Request an acccess token from for a security code.
        /// </summary>
        public async Task<AccessToken> SecurityCode(string api_key, string code)
        {
            var parameters = new Parameters {
                {"api_key", api_key},
                {"security_code", code},
            };
            var route = Routes.AuthEmailExchange();
            return await RequestToken(route, parameters.ToContent());
        }

        /// <summary>
        /// Request an access token on behalf of a Steam user.
        /// </summary>
        public async Task<AccessToken> External(SteamAuth options)
        {
            var route = Routes.ExternalSteam();
            return await RequestToken(route, options.ToContent());
        }

        /// <summary>
        /// Request an access token on behalf of a GOG Galaxy user.
        /// </summary>
        public async Task<AccessToken> External(GalaxyAuth options)
        {
            var route = Routes.ExternalGalaxy();
            return await RequestToken(route, options.ToContent());
        }

        /// <summary>
        /// Request an access token on behalf of an itch.io user via the itch.io desktop app.
        /// </summary>
        public async Task<AccessToken> External(ItchioAuth options)
        {
            var route = Routes.ExternalItchio();
            return await RequestToken(route, options.ToContent());
        }

        /// <summary>
        /// Request an access token on behalf of an Oculus user.
        /// </summary>
        public async Task<AccessToken> External(OculusAuth options)
        {
            var route = Routes.ExternalOculus();
            return await RequestToken(route, options.ToContent());
        }

        /// <summary>
        /// Request an access token on behalf of an Xbox Live user.
        /// </summary>
        public async Task<AccessToken> External(XboxAuth options)
        {
            var route = Routes.ExternalXbox();
            return await RequestToken(route, options.ToContent());
        }

        /// <summary>
        /// Request an access token on behalf of a Discord user.
        /// </summary>
        public async Task<AccessToken> External(DiscordAuth options)
        {
            var route = Routes.ExternalDiscord();
            return await RequestToken(route, options.ToContent());
        }

        private async Task<AccessToken> RequestToken((HttpMethod, Uri) route, HttpContent content)
        {
            var (method, path) = route;
            var req = new Request(method, path, content);
            var resp = await Connection.Send<AccessToken>(req);
            return resp.Body!;
        }
    }
}
