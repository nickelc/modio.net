using System.Net.Http;

namespace Modio
{
    public class EditFile
    {
        public string? Version { get; set; }

        public string? Changelog { get; set; }

        public bool? Active { get; set; }

        public string? MetadataBlob { get; set; }

        internal HttpContent ToContent()
        {
            var parameters = new Parameters();
            if (Version is string version)
            {
                parameters.Add("version", version);
            }
            if (Changelog is string changelog)
            {
                parameters.Add("changelog", changelog);
            }
            if (Active is bool active)
            {
                parameters.Add("active", active ? "true" : "false");
            }
            if (MetadataBlob is string metadata)
            {
                parameters.Add("metadata_blob", metadata);
            }
            return parameters.ToContent();
        }
    }
}
