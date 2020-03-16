using System.IO;
using System.Net.Http;

namespace Modio
{
    public class NewGameMedia
    {
        public FileInfo? Logo { get; set; }

        public FileInfo? Icon { get; set; }

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
}
