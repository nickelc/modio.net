namespace Modio.Filters
{
    /// <summary>
    /// Used to filter mod files.
    /// </summary>
    public static class FileFilter
    {
        /// <summary>
        /// Filter for file id.
        /// </summary>
        public static readonly NumericField<uint> Id = new NumericField<uint>("id");

        /// <summary>
        /// Filter for filename.
        /// </summary>
        public static readonly TextField Filename = new TextField("filename");

        /// <summary>
        /// Filter for file size.
        /// </summary>
        public static readonly NumericField<uint> Filesize = new NumericField<uint>("filesize");

        /// <summary>
        /// Filter for MD5 hash.
        /// </summary>
        public static readonly TextField Filehash = new TextField("filehash");

        /// <summary>
        /// Filter for file version.
        /// </summary>
        public static readonly TextField Version = new TextField("version");

        /// <summary>
        /// Filter for changelog.
        /// </summary>
        public static readonly TextField Changelog = new TextField("changelog");

        /// <summary>
        /// Filter for metadata.
        /// </summary>
        public static readonly TextField MetadataBlob = new TextField("metadata_blob");
    }
}
