using System;
using System.IO;
using System.Net.Http;

namespace Modio
{
    public class NewFile
    {
        public FileInfo File { get; private set; }

        public string? Version { get; set; }

        public string? Changelog { get; set; }

        public bool? Active { get; set; }

        public string? Filehash { get; set; }

        public string? MetadataBlob { get; set; }

        public NewFile(FileInfo file)
        {
            if (!file.Exists)
            {
                throw new ArgumentException("File does not exist");
            }
            File = file;
        }

        internal HttpContent ToContent()
        {
            var form = new MultipartFormDataContent();
            form.Add(File.ToContent(), "filedata", File.Name);
            if (Version is string version)
            {
                form.Add(version.ToContent(), "version");
            }
            if (Changelog is string changelog)
            {
                form.Add(changelog.ToContent(), "changelog");
            }
            if (Active is bool active)
            {
                form.Add((active ? "true" : "false").ToContent(), "active");
            }
            if (Filehash is string filehash)
            {
                form.Add(filehash.ToContent(), "filehash");
            }
            if (MetadataBlob is string metadata)
            {
                form.Add(metadata.ToContent(), "metadata_blob");
            }
            return form;
        }
    }
}
