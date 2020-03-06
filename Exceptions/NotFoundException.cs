using System.Net.Http;

namespace Modio
{
    public class NotFoundException : ApiException
    {
        public NotFoundException(HttpResponseMessage response) : base(response) { }
    }
}
