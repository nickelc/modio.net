using System.Net.Http;

namespace Modio;

/// <summary>
/// Used to report a game.
/// </summary>
public class NewGameReport : NewReport
{
    /// <summary>
    /// Creates a new instance of NewGameReport.
    /// </summary>
    public NewGameReport(uint id, ReportType type) : base("games", id, type) { }
}

/// <summary>
/// Used to report a mod.
/// </summary>
public class NewModReport : NewReport
{
    /// <summary>
    /// Creates a new instance of NewModReport.
    /// </summary>
    public NewModReport(uint id, ReportType type) : base("mods", id, type) { }
}

/// <summary>
/// Used to report a user.
/// </summary>
public class NewUserReport : NewReport
{
    /// <summary>
    /// Creates a new instance of NewUserReport.
    /// </summary>
    public NewUserReport(uint id, ReportType type) : base("users", id, type) { }
}

/// <summary>
/// Base class for the different report types.
/// </summary>
public abstract class NewReport
{
    /// <summary>
    /// Type of resource that is reported.
    /// </summary>
    protected string Resource { get; set; }

    /// <summary>
    /// Unique id of the resource that is reported.
    /// </summary>
    public uint Id { get; private set; }

    /// <summary>
    /// Type of report.
    /// </summary>
    public ReportType Type { get; private set; }

    /// <summary>
    /// Name of the user submitting the report.
    /// </summary>
    public string? Name { get; set; }

    /// <summary>
    /// Contact details of the user submitting the report.
    /// </summary>
    public string? Contact { get; set; }

    /// <summary>
    /// Detailed description of your report.
    /// </summary>
    public string? Summary { get; set; }

    internal NewReport(string resource, uint id, ReportType type)
    {
        Resource = resource;
        Id = id;
        Type = type;
    }

    internal HttpContent ToContent()
    {
        var parameters = new Parameters
        {
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

/// <summary>
/// Type of report.
/// </summary>
public enum ReportType
{
    /// <summary>
    /// Generic
    /// </summary>
    Generic = 0,

    /// <summary>
    /// DMCA
    /// </summary>
    DMCA = 1,

    /// <summary>
    /// Not Working
    /// </summary>
    NotWorking = 2,

    /// <summary>
    /// Rude Content
    /// </summary>
    RudeContent = 3,

    /// <summary>
    /// Illegal Content
    /// </summary>
    IllegalContent = 4,

    /// <summary>
    /// Stolen Content
    /// </summary>
    StolenContent = 5,

    /// <summary>
    /// False Information
    /// </summary>
    FalseInformation = 6,

    /// <summary>
    /// Other
    /// </summary>
    Other = 7,
}