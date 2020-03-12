namespace Modio.Filters
{
    public static class FileFilter
    {
        public static readonly NumericField<uint> Id = new NumericField<uint>("id");
        public static readonly TextField Filename = new TextField("filename");
        public static readonly NumericField<uint> Filesize = new NumericField<uint>("filesize");
        public static readonly TextField Filehash = new TextField("filehash");
        public static readonly TextField Version = new TextField("version");
        public static readonly TextField Changelog = new TextField("changelog");
        public static readonly TextField MetadataBlob = new TextField("metadata_blob");
    }
}
