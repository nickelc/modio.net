using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;

using Modio.Http;

namespace Modio;

/// <summary>
/// Used to upload new media to a mod.
/// </summary>
public class NewModMedia
{
    /// <summary>
    /// Image file which will represent the mods logo.
    /// </summary>
    public FileInfo? Logo { get; set; }

    /// <summary>
    /// Zip archive of images to add to the mods gallery.
    /// </summary>
    public FileInfo? ImagesZip { get; set; }

    /// <summary>
    /// Images to add to the mods gallery.
    /// </summary>
    public IEnumerable<FileInfo>? Images { get; set; }

    /// <summary>
    /// YouTube links to add to the mod.
    /// </summary>
    public IEnumerable<Uri>? YouTube { get; set; }

    /// <summary>
    /// Sketchfab links to add to the mod.
    /// </summary>
    public IEnumerable<Uri>? Sketchfab { get; set; }

    internal HttpContent ToContent()
    {
        var form = new MultipartFormDataContent();
        if (Logo is FileInfo logo)
        {
            form.Add(logo.ToContent(), "logo", Logo.Name);
        }
        if (ImagesZip is FileInfo imagesZip)
        {
            form.Add(imagesZip.ToContent(), "images", "images.zip");
        }
        if (Images is IEnumerable<FileInfo> images)
        {
            var it = images.Select((img, i) => (img, "image" + i));
            foreach (var (img, name) in it)
            {
                form.Add(img.ToContent(), name, img.Name);
            }
        }
        if (YouTube is IEnumerable<Uri> yt)
        {
            foreach (var uri in yt)
            {
                form.Add(uri.ToString().ToContent(), "youtube[]");
            }
        }
        if (Sketchfab is IEnumerable<Uri> sketch)
        {
            foreach (var uri in sketch)
            {
                form.Add(uri.ToString().ToContent(), "sketchfab[]");
            }
        }
        return form;
    }
}