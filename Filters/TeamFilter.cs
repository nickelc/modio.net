using Modio.Models;

namespace Modio.Filters
{
    public static class TeamFilter
    {
        public static readonly NumericField<uint> Id = new NumericField<uint>("id");
        public static readonly NumericField<uint> UserId = new NumericField<uint>("user_id");
        public static readonly TextField Username = new TextField("username");
        public static readonly NumericField<TeamLevel> Level = new NumericField<TeamLevel>("level");
    }
}
