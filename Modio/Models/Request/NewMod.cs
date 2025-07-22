using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;

using Modio.Models;

namespace Modio;

/// <summary>
/// Used to create a new Mod.
/// </summary>
public class NewMod
{
    /// <summary>
    /// Name of the mod.
    /// </summary>
    public string Name { get; private set; }

    /// <summary>
    /// Summary for the mod, giving a brief overview of what it's about.
    /// </summary>
    public string Summary { get; private set; }

    /// <summary>
    /// Image file which will represent your mods logo.
    /// </summary>
    public FileInfo Logo { get; private set; }

    /// <summary>
    /// Visibility of the mod.
    /// </summary>
    public Visibility? Visible { get; set; }

    /// <summary>
    /// Path for the mod on mod.io. For example: https://gamename.mod.io/mod-name-id-here.
    /// </summary>
    public string? NameId { get; set; }

    /// <summary>
    /// Description of the mod.
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// Official homepage for your mod. Must be a valid URL.
    /// </summary>
    public Uri? HomepageUrl { get; set; }

    /// <summary>
    /// Maximium number of subscribers for this mod.
    /// </summary>
    public uint? Stock { get; set; }

    /// <summary>
    /// MaturityOption of the mod.
    /// </summary>
    public MaturityOption? MaturityOption { get; set; }

    /// <summary>
    /// Metadata blob of the mod.
    /// </summary>
    public string? MetadataBlob { get; set; }

    /// <summary>
    /// An array of strings that represent what the mod has been tagged as.
    /// </summary>
    public List<string> Tags { get; private set; } = [];

    /// <summary>
    /// Creates a new mod.
    /// </summary>
    public NewMod(string name, string summary, FileInfo logo)
    {
        Ensure.ArgumentNotNullOrEmptyString(name, nameof(name));
        Ensure.ArgumentNotNullOrEmptyString(summary, nameof(summary));
        Ensure.ArgumentNotNull(logo, nameof(logo));
        Ensure.FileExists(logo, "Logo file does not exist");

        Name = name;
        Summary = summary;
        Logo = logo;
    }

    internal HttpContent ToContent()
    {
        var form = new MultipartFormDataContent
        {
            { Name.ToContent(), "name" },
            { Summary.ToContent(), "summary" },
            { Logo.ToContent(), "logo", Logo.Name }
        };

        if (NameId is string nameId)
        {
            form.Add(nameId.ToContent(), "name_id");
        }
        if (Description is string desc)
        {
            form.Add(desc.ToContent(), "description");
        }
        if (Visible is Visibility visible)
        {
            form.Add(((int)visible).ToString().ToContent(), "visible");
        }
        if (HomepageUrl is Uri uri)
        {
            form.Add(uri.ToString().ToContent(), "homepage_url");
        }
        if (Stock is uint stock)
        {
            form.Add(stock.ToString().ToContent(), "stock");
        }
        if (MaturityOption is MaturityOption maturity)
        {
            form.Add(((int)maturity).ToString().ToContent(), "maturity_option");
        }
        if (MetadataBlob is string metadata)
        {
            form.Add(metadata.ToContent(), "metadata_blob");
        }
        foreach (var tag in Tags)
        {
            form.Add(tag.ToContent(), "tags[]");
        }

        return form;
    }
}