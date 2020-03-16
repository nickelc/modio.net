using System.Net.Http;

namespace Modio
{
    public class NewGameReport : NewReport
    {
        public NewGameReport(uint id, ReportType type) : base("games", id, type) { }
    }

    public class NewModReport : NewReport
    {
        public NewModReport(uint id, ReportType type) : base("mods", id, type) { }
    }

    public class NewUserReport : NewReport
    {
        public NewUserReport(uint id, ReportType type) : base("users", id, type) { }
    }

    public abstract class NewReport
    {
        protected string Resource { get; set; }

        public uint Id { get; private set; }

        public ReportType Type { get; private set; }

        public string? Name { get; set; }

        public string? Contact { get; set; }

        public string? Summary { get; set; }

        internal NewReport(string resource, uint id, ReportType type)
        {
            Resource = resource;
            Id = id;
            Type = type;
        }

        internal HttpContent ToContent()
        {
            var parameters = new Parameters {
                {"resource", Resource},
                {"id", Id.ToString()},
                {"type", ((int)Type).ToString()},
            };
            if (Name is string name)
            {
                parameters.Add("name", name);
            }
            if (Contact is string contact)
            {
                parameters.Add("contact", contact);
            }
            if (Summary is string summary)
            {
                parameters.Add("summary", summary);
            }
            return parameters.ToContent();
        }
    }

    public enum ReportType
    {
        Generic = 0,
        DMCA = 1,
        NotWorking = 2,
        RudeContent = 3,
        IllegalContent = 4,
        StolenContent = 5,
        FalseInformation = 6,
        Other = 7,
    }
}
