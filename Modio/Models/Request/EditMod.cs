using System;
using System.Net.Http;

using Modio.Models;

namespace Modio;

/// <summary>
/// Used to edit a Mod.
/// </summary>
public class EditMod
{
    /// <summary>
    /// Status of the mod.
    /// </summary>
    public Status? Status { get; set; }

    /// <summary>
    /// Visibility of the mod.
    /// </summary>
    public Visibility? Visible { get; set; }

    /// <summary>
    /// Name of the mod.
    /// </summary>
    public string? Name { get; set; }

    /// <summary>
    /// Path for the mod on mod.io. For example: https://gamename.mod.io/mod-name-id-here.
    /// </summary>
    public string? NameId { get; set; }

    /// <summary>
    /// Summary for the mod, giving a brief overview of what it's about.
    /// </summary>
    public string? Summary { get; set; }

    /// <summary>
    /// Description of the mod.
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// Official homepage for the mod.
    /// </summary>
    public Uri? HomepageUrl { get; set; }

    /// <summary>
    /// Maximium number of subscribers for this mod.
    /// </summary>
    public uint? Stock { get; set; }

    /// <summary>
    /// Maturity options of the mod.
    /// </summary>
    public MaturityOption? MaturityOption { get; set; }

    /// <summary>
    /// Metadata blob of the mod.
    /// </summary>
    public string? MetadataBlob { get; set; }

    internal HttpContent ToContent()
    {
        var parameters = new Parameters();
        if (Name is string name)
        {
            parameters.Add("name", name);
        }
        if (NameId is string nameId)
        {
            parameters.Add("name_id", nameId);
        }
        if (Status is Status status)
        {
            parameters.Add("status", ((int)status).ToString());
        }
        if (Visible is Visibility visible)
        {
            parameters.Add("visible", ((int)visible).ToString());
        }
        if (Summary is string summary)
        {
            parameters.Add("summary", summary);
        }
        if (Description is string desc)
        {
            parameters.Add("description", desc);
        }
        if (HomepageUrl is Uri uri)
        {
            parameters.Add("homepage_url", uri.ToString());
        }
        if (Stock is uint stock)
        {
            parameters.Add("stock", stock.ToString());
        }
        if (MaturityOption is MaturityOption maturityOption)
        {
            parameters.Add("maturity_option", ((int)maturityOption).ToString());
        }
        if (MetadataBlob is string metadata)
        {
            parameters.Add("metadata_blob", metadata);
        }
        return parameters.ToContent();
    }
}