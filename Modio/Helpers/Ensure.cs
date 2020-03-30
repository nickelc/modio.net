using System;

namespace Modio
{
    internal static class Ensure
    {
        public static void ArgumentNotNull(object value, string name)
        {
            if (value != null) return;

            throw new ArgumentNullException(name);
        }

        public static void ArgumentNotNullOrEmptyString(string value, string name)
        {
            ArgumentNotNull(value, name);

            if (!string.IsNullOrWhiteSpace(value)) return;

            throw new ArgumentException("String cannot be empty");
        }
    }
}
