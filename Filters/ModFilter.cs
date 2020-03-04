namespace Modio.Filters
{
    public static class ModFilter
    {
        public static readonly FullTextField FullText = new FullTextField();
        public static readonly NumericField<uint> Id = new NumericField<uint>("id");
        public static readonly TextField Name = new TextField("name");
        public static readonly TextField NameId = new TextField("name_id");

        public static readonly SortField Downloads = new SortField("downloads");
        public static readonly SortField Popular = new SortField("popular");
        public static readonly SortField Rating = new SortField("rating");
        public static readonly SortField Subscribers = new SortField("subscribers");
    }
}
