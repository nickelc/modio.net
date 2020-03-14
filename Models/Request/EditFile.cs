using System.Collections.Generic;
using System.Net.Http;

namespace Modio
{
    using Parameter = KeyValuePair<string, string>;

    public class EditFile
    {
        public string? Version { get; set; }

        public string? Changelog { get; set; }

        public bool? Active { get; set; }

        public string? MetadataBlob { get; set; }

        public HttpContent ToContent()
        {
            var parameters = new List<Parameter>();
            if (Version is string version)
            {
                parameters.Add(new Parameter("version", version));
            }
            if (Changelog is string changelog)
            {
                parameters.Add(new Parameter("changelog", changelog));
            }
            if (Active is bool active)
            {
                parameters.Add(new Parameter("active", active ? "true" : "false"));
            }
            if (MetadataBlob is string metadata)
            {
                parameters.Add(new Parameter("metadata_blob", metadata));
            }
            return new FormUrlEncodedContent(parameters);
        }
    }
}
