using System;
using System.Collections.Generic;
using System.Net.Http;

namespace PathOfExileWebApi.Http.Interfaces
{
    internal interface IRequest
    {
        Uri BaseAddress { get; }

        Uri Endpoint { get; }

        HttpMethod Method { get; }

        object Body { get; set; }

        IDictionary<string, string> Headers { get; }

        IDictionary<string, string> Parameters { get; }
    }
}
