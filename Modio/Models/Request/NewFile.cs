using System.IO;

namespace Modio;

/// <summary>
/// Used to upload a new File.
/// </summary>
public class NewFile
{
    /// <summary>
    /// File to upload.
    /// </summary>
    public FileInfo File { get; private set; }

    /// <summary>
    /// Version of the file.
    /// </summary>
    public string? Version { get; set; }

    /// <summary>
    /// Changelog of the file.
    /// </summary>
    public string? Changelog { get; set; }

    /// <summary>
    /// Primary file of the mod. (default: <c>True</c>)
    /// </summary>
    public bool? Active { get; set; }

    /// <summary>
    /// Precalculated md5 hash which is checked after upload.
    /// </summary>
    public string? Filehash { get; set; }

    /// <summary>
    /// Metadata blob of the file.
    /// </summary>
    public string? MetadataBlob { get; set; }

    /// <summary>
    /// Create a new File.
    /// </summary>
    public NewFile(FileInfo file)
    {
        Ensure.FileExists(file, "File does not exist");

        File = file;
    }
}