using System.Collections.Generic;
using System.Net;

namespace PathOfExileWebApi.Http.Interfaces
{
    internal interface IResponse
    {
        HttpStatusCode StatusCode { get; }

        string ContentType { get; }

        object Body { get; }

        IReadOnlyDictionary<string, string> Headers { get; }
    }
}
