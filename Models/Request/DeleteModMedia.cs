using System;
using System.Collections.Generic;
using System.Net.Http;

namespace Modio
{
    public class DeleteModMedia
    {
        public IEnumerable<string>? Images { get; set; }

        public IEnumerable<Uri>? YouTube { get; set; }

        public IEnumerable<Uri>? Sketchfab { get; set; }

        internal HttpContent ToContent()
        {
            var parameters = new Parameters();
            if (Images is IEnumerable<string> images)
            {
                foreach (var image in images)
                {
                    parameters.Add("images[]", image);
                }
            }
            if (YouTube is IEnumerable<Uri> yt)
            {
                foreach (var uri in yt)
                {
                    parameters.Add("youtube[]", uri.ToString());
                }
            }
            if (Sketchfab is IEnumerable<Uri> sketch)
            {
                foreach (var uri in sketch)
                {
                    parameters.Add("youtube[]", uri.ToString());
                }
            }
            return parameters.ToContent();
        }
    }
}
