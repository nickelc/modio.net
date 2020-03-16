using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

namespace Modio
{
    public class NewTagOption
    {
        public string Name { get; private set; }

        public string Type { get; private set; }

        public IEnumerable<string> Tags { get; private set; }

        public bool? Hidden { get; set; }

        private NewTagOption(string name, string type, IEnumerable<string> tags, bool? hidden)
        {
            Ensure.ArgumentNotNull(name, nameof(name));
            Ensure.ArgumentNotNull(tags, nameof(tags));

            Name = name;
            Type = type;
            Tags = tags;
            Hidden = hidden;
        }

        public static NewTagOption CreateCheckbox(string name, IEnumerable<string> tags, bool? hidden = null)
        {
            return new NewTagOption(name, "checkboxes", tags, hidden);
        }

        public static NewTagOption CreateDropdown(string name, IEnumerable<string> tags, bool? hidden = null)
        {
            return new NewTagOption(name, "dropdown", tags, hidden);
        }

        internal HttpContent ToContent()
        {
            var tags = Tags.Select(t => ("tags[]", t));
            var parameters = new Parameters(tags)
            {
                {"name", Name},
                {"type", Type},
            };
            if (Hidden is bool hidden)
            {
                parameters.Add("hidden", hidden ? "true" : "false");
            }
            return parameters.ToContent();
        }
    }
}
