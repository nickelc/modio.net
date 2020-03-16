using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;

using Modio.Models;

namespace Modio
{
    public class NewMod
    {
        public string Name { get; private set; }

        public string Summary { get; private set; }

        public FileInfo Logo { get; private set; }

        public Visibility? Visible { get; set; }

        public string? NameId { get; set; }

        public string? Description { get; set; }

        public Uri? HomepageUrl { get; set; }

        public uint? Stock { get; set; }

        public MaturityOption? MaturityOption { get; set; }

        public string? MetadataBlob { get; set; }

        public List<string> Tags { get; set; } = new List<string>();

        public NewMod(string name, string summary, FileInfo logo)
        {
            Ensure.ArgumentNotNullOrEmptyString(name, nameof(name));
            Ensure.ArgumentNotNullOrEmptyString(summary, nameof(summary));
            Ensure.ArgumentNotNull(logo, nameof(logo));

            if (!logo.Exists)
            {
                throw new ArgumentException("Logo file does not exist");
            }

            Name = name;
            Summary = summary;
            Logo = logo;
        }

        internal HttpContent ToContent()
        {
            var form = new MultipartFormDataContent();
            form.Add(Name.ToContent(), "name");
            form.Add(Summary.ToContent(), "summary");
            form.Add(Logo.ToContent(), "logo", Logo.Name);

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
}
