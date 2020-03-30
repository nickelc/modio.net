namespace Modio.Filters
{
    /// <summary>
    /// Used to filter comments.
    /// </summary>
    public static class CommentFilter
    {
        /// <summary>
        /// Filter for comment id.
        /// </summary>
        public static readonly NumericField<uint> Id = new NumericField<uint>("id");

        /// <summary>
        /// Filter for user id.
        /// </summary>
        public static readonly NumericField<uint> SubmittedBy = new NumericField<uint>("submitted_by");

        /// <summary>
        /// Filter for content of the comment.
        /// </summary>
        public static readonly TextField Content = new TextField("content");
    }
}
