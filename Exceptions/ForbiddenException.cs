using System.Net.Http;

namespace Modio
{
    public class ForbiddenException : ApiException
    {
        public ForbiddenException(HttpResponseMessage response) : base(response) { }
    }
}
