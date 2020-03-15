using Modio.Models;

namespace Modio.Filters
{
    public static class ModEventFilter
    {
        public static readonly NumericField<uint> Id = new NumericField<uint>("id");
        public static readonly NumericField<uint> ModId = new NumericField<uint>("mod_id");
        public static readonly NumericField<uint> UserId = new NumericField<uint>("user_id");
        public static readonly NumericField<long> DateAdded = new NumericField<long>("date_added");
        public static readonly GenericTextField<ModEventType> EventType = new GenericTextField<ModEventType>("event_type");
    }

    public static class UserEventFilter
    {
        public static readonly NumericField<uint> Id = new NumericField<uint>("id");
        public static readonly NumericField<uint> GameId = new NumericField<uint>("game_id");
        public static readonly NumericField<uint> ModId = new NumericField<uint>("mod_id");
        public static readonly NumericField<uint> UserId = new NumericField<uint>("user_id");
        public static readonly NumericField<long> DateAdded = new NumericField<long>("date_added");
        public static readonly GenericTextField<UserEventType> EventType = new GenericTextField<UserEventType>("event_type");
    }
}
