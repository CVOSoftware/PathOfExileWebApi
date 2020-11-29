using System;
using System.Collections.Generic;
using System.Net.Http;

using PathOfExileWebApi.Http.Interfaces;

namespace PathOfExileWebApi.Http
{
    internal class Request : IRequest
    {
        public Request(Uri baseAddress, Uri endpoint, HttpMethod method, object body, IDictionary<string, string> headers, IDictionary<string, string> parameters)
        {
            BaseAddress = baseAddress;
            Endpoint = endpoint;
            Method = method;
            Body = body;
            Headers = headers ?? new Dictionary<string, string>();
            Parameters = parameters ?? new Dictionary<string, string>();
        }

        #region Implementation IRequest

        public Uri BaseAddress { get; }

        public Uri Endpoint { get; }

        public HttpMethod Method { get; }

        public object Body { get; set; }

        public IDictionary<string, string> Headers { get; }

        public IDictionary<string, string> Parameters { get; }

        #endregion
    }
}
