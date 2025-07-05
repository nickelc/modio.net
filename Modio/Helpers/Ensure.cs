using System;
using System.IO;

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

        public static void FileExists(FileInfo file, string message)
        {
            if (!file.Exists)
            {
                throw new ArgumentException(message);
            }
        }
    }
}
