using System.Net.Http;

namespace Modio;

/// <summary>
/// Used to edit a File.
/// </summary>
public class EditFile
{
    /// <summary>
    /// Version of the file release.
    /// </summary>
    public string? Version { get; set; }

    /// <summary>
    /// Changelog of this release.
    /// </summary>
    public string? Changelog { get; set; }

    /// <summary>
    /// Flag this upload as the current release.
    /// </summary>
    public bool? Active { get; set; }

    /// <summary>
    /// Metadata stored by the game developer for this release.
    /// </summary>
    public string? MetadataBlob { get; set; }

    internal HttpContent ToContent()
    {
        var parameters = new Parameters();
        if (Version is string version)
        {
            parameters.Add("version", version);
        }
        if (Changelog is string changelog)
        {
            parameters.Add("changelog", changelog);
        }
        if (Active is bool active)
        {
            parameters.Add("active", active ? "true" : "false");
        }
        if (MetadataBlob is string metadata)
        {
            parameters.Add("metadata_blob", metadata);
        }
        return parameters.ToContent();
    }
}