using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PathOfExileWebApi.Extensions
{
    internal static class UriExtension
    {
        private const string Separator = "&";

        public static Uri ApplyParameters(this Uri uri, IDictionary<string, string> parameters)
        {
            if (parameters == null || parameters.Any() == false)
            {
                return uri;
            }

            var parameterParts = parameters.Select(CreateByTemplate);
            var query = string.Join(Separator, parameterParts);
            var uriBuilder = new UriBuilder(uri)
            {
                Query = query
            };

            return uriBuilder.Uri;
        }

        private static string CreateByTemplate(KeyValuePair<string, string> parameter) => $"{parameter.Key}={HttpUtility.UrlEncode(parameter.Value)}";
    }
}
