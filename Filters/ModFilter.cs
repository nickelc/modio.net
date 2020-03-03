namespace Modio.Filters
{
    public static class ModFilter
    {
        public static readonly FullTextField FullText = new FullTextField();
        public static readonly NumericField<uint> Id = new NumericField<uint>("id");
        public static readonly TextField Name = new TextField("name");
        public static readonly TextField NameId = new TextField("name_id");
    }
}
