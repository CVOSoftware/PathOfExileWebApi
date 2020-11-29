using System;

namespace PathOfExileWebApi
{
    internal abstract class BaseEndpoint
    {
        protected Uri Uri(string endpoint) => new Uri(endpoint, UriKind.Relative);
    }
}
