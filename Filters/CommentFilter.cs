namespace Modio.Filters
{
    public static class CommentFilter
    {
        public static readonly NumericField<uint> Id = new NumericField<uint>("id");
        public static readonly NumericField<uint> SubmittedBy = new NumericField<uint>("submitted_by");
        public static readonly TextField Content = new TextField("content");
    }
}
