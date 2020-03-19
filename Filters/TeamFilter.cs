using Modio.Models;

namespace Modio.Filters
{
    /// <summary>
    /// Used to filter team members.
    /// </summary>
    public static class TeamFilter
    {
        /// <summary>
        /// Filter for member id.
        /// </summary>
        public static readonly NumericField<uint> Id = new NumericField<uint>("id");

        /// <summary>
        /// Filter for user id.
        /// </summary>
        public static readonly NumericField<uint> UserId = new NumericField<uint>("user_id");

        /// <summary>
        /// Filter for username.
        /// </summary>
        public static readonly TextField Username = new TextField("username");

        /// <summary>
        /// Filter for team level.
        /// </summary>
        public static readonly NumericField<TeamLevel> Level = new NumericField<TeamLevel>("level");
    }
}
