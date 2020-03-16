using System;
using System.Net.Http;
using System.Threading.Tasks;

using Modio.Models;

namespace Modio
{
    public class AuthClient : ApiClient
    {
        internal AuthClient(IConnection connection) : base(connection) { }

        public async Task RequestEmail(string api_key, string email)
        {
            var parameters = new Parameters {
                {"api_key", api_key},
                {"email", email},
            };
            var (method, path) = Routes.AuthEmailRequest();
            var req = new Request(method, path, parameters.ToContent());

            await Connection.Send<ApiMessage>(req);
        }

        public async Task<AccessToken> SecurityCode(string api_key, string code)
        {
            var parameters = new Parameters {
                {"api_key", api_key},
                {"security_code", code},
            };
            var route = Routes.AuthEmailExchange();
            return await RequestToken(route, parameters.ToContent());
        }

        public async Task<AccessToken> External(SteamAuth options)
        {
            var route = Routes.ExternalSteam();
            return await RequestToken(route, options.ToContent());
        }

        public async Task<AccessToken> External(GalaxyAuth options)
        {
            var route = Routes.ExternalGalaxy();
            return await RequestToken(route, options.ToContent());
        }

        public async Task<AccessToken> External(ItchioAuth options)
        {
            var route = Routes.ExternalItchio();
            return await RequestToken(route, options.ToContent());
        }

        public async Task<AccessToken> External(OculusAuth options)
        {
            var route = Routes.ExternalOculus();
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
