using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

namespace Modio
{
    /// <summary>
    /// Used to create a new TagOption.
    /// </summary>
    public class NewTagOption
    {
        /// <summary>
        /// Name of the tag group.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Type of the tag group.
        /// </summary>
        public string Type { get; private set; }

        /// <summary>
        /// Tags of the tag group.
        /// </summary>
        public IEnumerable<string> Tags { get; private set; }

        /// <summary>
        /// Defines the tag group as hidden.
        /// </summary>
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

        /// <summary>
        /// Creates a new <c>checkbox</c> TagOption.
        /// </summary>
        public static NewTagOption CreateCheckbox(string name, IEnumerable<string> tags, bool? hidden = null)
        {
            return new NewTagOption(name, "checkboxes", tags, hidden);
        }

        /// <summary>
        /// Creates a new <c>dropdown</c> TagOption.
        /// </summary>
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
