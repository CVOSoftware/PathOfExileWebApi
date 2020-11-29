using System;
using System.Collections.Generic;
using System.Linq;

namespace PathOfExileWebApi.Util
{
    internal static class Ensure
    {
        private const string NullOrEmptyStringErrorMessage = "String is empty or null";

        private const string NullOrEmptyCollectionErrorMessage = "Collection is empty or null";

        public static void ArgumentNullException(object value, string name)
        {
            if (value != null)
            {
                return;
            }

            throw new ArgumentNullException(name);
        }

        public static void ArgumentNotNullOrEmptyString(string value, string name)
        {
            if(string.IsNullOrEmpty(value) == false)
            {
                return;
            }

            throw new ArgumentException(NullOrEmptyStringErrorMessage, name);
        }

        public static void ArgumentNotNullOrEmptyCollection<T>(IEnumerable<T> value, string name)
        {
            if(value != null && value.Any())
            {
                return;
            }

            throw new ArgumentException(NullOrEmptyCollectionErrorMessage, name);
        }
    }
}
