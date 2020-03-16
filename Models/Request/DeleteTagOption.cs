using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

namespace Modio
{
    public class DeleteTagOption
    {
        public string Name { get; private set; }

        public IEnumerable<string> Tags { get; private set; }

        private DeleteTagOption(string name, IEnumerable<string> tags)
        {
            Name = name;
            Tags = tags;
        }

        public static DeleteTagOption All(string name)
        {
            return new DeleteTagOption(name, new string[0]);
        }

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
