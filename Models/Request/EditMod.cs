using System;
using System.Net.Http;

using Modio.Models;

namespace Modio
{
    public class EditMod
    {
        public Status? Status { get; set; }

        public Visibility? Visible { get; set; }

        public string? Name { get; set; }

        public string? NameId { get; set; }

        public string? Summary { get; set; }

        public string? Description { get; set; }

        public Uri? HomepageUrl { get; set; }

        public uint? Stock { get; set; }

        public MaturityOption? MaturityOption { get; set; }

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
                parameters.Add("status", status.ToString());
            }
            if (Visible is Visibility visible)
            {
                parameters.Add("visible", visible.ToString());
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
                parameters.Add("maturity_option", maturityOption.ToString());
            }
            if (MetadataBlob is string metadata)
            {
                parameters.Add("metadata_blob", metadata);
            }
            return parameters.ToContent();
        }
    }
}
