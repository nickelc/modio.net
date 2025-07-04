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
        public static readonly NumericField<uint> Id = new("id");

        /// <summary>
        /// Filter for user id.
        /// </summary>
        public static readonly NumericField<uint> SubmittedBy = new("submitted_by");

        /// <summary>
        /// Filter for content of the comment.
        /// </summary>
        public static readonly TextField Content = new("content");
    }
}
