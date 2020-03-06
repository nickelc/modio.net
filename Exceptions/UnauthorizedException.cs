using System.Net.Http;

namespace Modio
{
    public class UnauthorizedException : ApiException
    {
        public UnauthorizedException(HttpResponseMessage response) : base(response) { }
    }
}
