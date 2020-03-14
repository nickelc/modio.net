using System;
using System.Collections.Generic;
using System.Net.Http;

using Modio.Models;

namespace Modio
{
    using Parameter = KeyValuePair<string, string>;

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
            var parameters = new List<Parameter>();
            if (Name is string name)
            {
                parameters.Add(new Parameter("name", name));
            }
            if (NameId is string nameId)
            {
                parameters.Add(new Parameter("name_id", nameId));
            }
            if (Status is Status status)
            {
                parameters.Add(new Parameter("status", status.ToString()));
            }
            if (Visible is Visibility visible)
            {
                parameters.Add(new Parameter("visible", visible.ToString()));
            }
            if (Summary is string summary)
            {
                parameters.Add(new Parameter("summary", summary));
            }
            if (Description is string desc)
            {
                parameters.Add(new Parameter("description", desc));
            }
            if (HomepageUrl is Uri uri)
            {
                parameters.Add(new Parameter("homepage_url", uri.ToString()));
            }
            if (Stock is uint stock)
            {
                parameters.Add(new Parameter("stock", stock.ToString()));
            }
            if (MaturityOption is MaturityOption maturityOption)
            {
                parameters.Add(new Parameter("maturity_option", maturityOption.ToString()));
            }
            if (MetadataBlob is string metadata)
            {
                parameters.Add(new Parameter("metadata_blob", metadata));
            }
            return new FormUrlEncodedContent(parameters);
        }
    }
}
