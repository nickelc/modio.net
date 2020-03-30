namespace Modio.Filters
{
    /// <summary>
    /// Used to filter games.
    /// </summary>
    public class GameFilter
    {
        /// <summary>
        /// Full-text filter for the name field.
        /// </summary>
        public static readonly FullTextField FullText = new FullTextField();

        /// <summary>
        /// Filter for game id.
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
    }
}
