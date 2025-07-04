using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

namespace Modio
{
    /// <summary>
    /// Used to delete TagOption's.
    /// </summary>
    public class DeleteTagOption
    {
        /// <summary>
        /// Name of the tag group.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Tags to delete from the tag group. (Empty when deleting the whole group.)
        /// </summary>
        public IEnumerable<string> Tags { get; private set; }

        private DeleteTagOption(string name, IEnumerable<string> tags)
        {
            Name = name;
            Tags = tags;
        }

        /// <summary>
        /// Delete the whole TagOption.
        /// </summary>
        public static DeleteTagOption All(string name)
        {
            return new DeleteTagOption(name, []);
        }

        /// <summary>
        /// Delete tags from the TagOption.
        /// </summary>
        public static DeleteTagOption Some(string name, IEnumerable<string> tags)
        {
            Ensure.ArgumentNotNull(tags, nameof(tags));
            if (!tags.Any())
            {
                throw new ArgumentException("empty tags");
            }
            return new DeleteTagOption(name, tags);
        }

        internal HttpContent ToContent()
        {
            var tags = Tags
                .DefaultIfEmpty("")
                .Select(t => ("tags[]", t));

            var parameters = new Parameters(tags) {
                {"name", Name},
            };
            return parameters.ToContent();
        }
    }
}
