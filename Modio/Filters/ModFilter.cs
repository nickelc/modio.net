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
        /// Filter for game id.
        /// </summary>
        public static readonly NumericField<uint> GameId = new NumericField<uint>("game_id");

        /// <summary>
        /// Filter for status.
        /// </summary>
        public static readonly NumericField<uint> Status = new NumericField<uint>("status");

        /// <summary>
        /// Filter for visble.
        /// </summary>
        public static readonly NumericField<uint> Visible = new NumericField<uint>("visible");

        /// <summary>
        /// Filter for submitted_by.
        /// </summary>
        public static readonly NumericField<uint> SubmitterId = new NumericField<uint>("submitted_by");

        /// <summary>
        /// Filter for date_added.
        /// </summary>
        public static readonly NumericField<uint> DateAdded = new NumericField<uint>("date_added");

        /// <summary>
        /// Filter for date_updated.
        /// </summary>
        public static readonly NumericField<uint> DateUpdated = new NumericField<uint>("date_updated");

        /// <summary>
        /// Filter for date_live.
        /// </summary>
        public static readonly NumericField<uint> DateLive = new NumericField<uint>("date_live");

        /// <summary>
        /// Filter for maturity_option.
        /// </summary>
        public static readonly NumericField<uint> MaturityOption = new NumericField<uint>("maturity_option");

        /// <summary>
        /// Filter for name.
        /// </summary>
        public static readonly TextField Name = new TextField("name");

        /// <summary>
        /// Filter for name_id.
        /// </summary>
        public static readonly TextField NameId = new TextField("name_id");

        /// <summary>
        /// Filter for summary.
        /// </summary>
        public static readonly TextField Summary = new TextField("summary");

        /// <summary>
        /// Filter for description.
        /// </summary>
        public static readonly TextField Description = new TextField("description");

        /// <summary>
        /// Filter for homepage_url.
        /// </summary>
        public static readonly TextField HomepageUrl = new TextField("homepage_url");

        /// <summary>
        /// Filter for modfile.
        /// </summary>
        public static readonly NumericField<uint> ModfileId = new NumericField<uint>("modfile");

        /// <summary>
        /// Filter for metadata_blob.
        /// </summary>
        public static readonly TextField MetadataBlob = new TextField("metadata_blob");

        /// <summary>
        /// Filter for metadata_kvp.
        /// </summary>
        public static readonly TextField MetadataKeyValue = new TextField("metadata_kvp");

        /// <summary>
        /// Filter for tags.
        /// </summary>
        public static readonly TextField Tags = new TextField("tags");

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
