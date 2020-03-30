namespace Modio.Filters
{
    /// <summary>
    /// Used to filter mods.
    /// </summary>
    public static class ModFilter
    {
        /// <summary>
        /// Full-text filter for the name field.
        /// </summary>
        public static readonly FullTextField FullText = new FullTextField();

        /// <summary>
        /// Filter for mod id.
        /// </summary>
        public static readonly NumericField<uint> Id = new NumericField<uint>("id");

        /// <summary>
        /// Filter for name.
        /// </summary>
        public static readonly TextField Name = new TextField("name");

        /// <summary>
        /// Filter for name_id.
        /// </summary>
        public static readonly TextField NameId = new TextField("name_id");

        /// <summary>
        /// Sort results by most downloads.
        /// </summary>
        public static readonly SortField Downloads = new SortField("downloads");

        /// <summary>
        /// Sort results by popularity.
        /// </summary>
        public static readonly SortField Popular = new SortField("popular");

        /// <summary>
        /// Sort results by weighted rating.
        /// </summary>
        public static readonly SortField Rating = new SortField("rating");

        /// <summary>
        /// Sort results by most subscribers.
        /// </summary>
        public static readonly SortField Subscribers = new SortField("subscribers");
    }
}
