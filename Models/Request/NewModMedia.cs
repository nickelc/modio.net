using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;

namespace Modio
{
    public class NewModMedia
    {
        public FileInfo? Logo { get; set; }

        public FileInfo? ImagesZip { get; set; }

        public IEnumerable<FileInfo>? Images { get; set; }

        public IEnumerable<Uri>? YouTube { get; set; }

        public IEnumerable<Uri>? Sketchfab { get; set; }

        internal HttpContent ToContent()
        {
            var form = new MultipartFormDataContent();
            if (Logo is FileInfo logo)
            {
                form.Add(logo.ToContent(), "logo");
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
}
