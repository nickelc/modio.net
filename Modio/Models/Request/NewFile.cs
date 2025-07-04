using System;
using System.IO;
using System.Net.Http;

namespace Modio
{
    /// <summary>
    /// Used to upload a new File.
    /// </summary>
    public class NewFile
    {
        /// <summary>
        /// File to upload.
        /// </summary>
        public FileInfo File { get; private set; }

        /// <summary>
        /// Version of the file.
        /// </summary>
        public string? Version { get; set; }

        /// <summary>
        /// Changelog of the file.
        /// </summary>
        public string? Changelog { get; set; }

        /// <summary>
        /// Primary file of the mod. (default: <c>True</c>)
        /// </summary>
        public bool? Active { get; set; }

        /// <summary>
        /// Precalculated md5 hash which is checked after upload.
        /// </summary>
        public string? Filehash { get; set; }

        /// <summary>
        /// Metadata blob of the file.
        /// </summary>
        public string? MetadataBlob { get; set; }

        /// <summary>
        /// Create a new File.
        /// </summary>
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
            var form = new MultipartFormDataContent
            {
                { File.ToContent(), "filedata", File.Name },
            };
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
