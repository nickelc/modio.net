using System.IO;
using System.Net.Http;

namespace Modio;

/// <summary>
/// Used to upload new media to a game.
/// </summary>
public class NewGameMedia
{
    /// <summary>
    /// Logo file to upload.
    /// </summary>
    public FileInfo? Logo { get; set; }

    /// <summary>
    /// Icon file to upload.
    /// </summary>
    public FileInfo? Icon { get; set; }

    /// <summary>
    /// Header image file to upload.
    /// </summary>
    public FileInfo? Header { get; set; }

    internal HttpContent ToContent()
    {
        var form = new MultipartFormDataContent();
        if (Logo is FileInfo logo)
        {
            form.Add(logo.ToContent(), "logo", logo.Name);
        }
        if (Icon is FileInfo icon)
        {
            form.Add(icon.ToContent(), "icon", icon.Name);
        }
        if (Header is FileInfo header)
        {
            form.Add(header.ToContent(), "header", header.Name);
        }
        return form;
    }
}