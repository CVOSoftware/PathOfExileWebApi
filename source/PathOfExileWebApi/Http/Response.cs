using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net;

using PathOfExileWebApi.Http.Interfaces;

namespace PathOfExileWebApi.Http
{
    internal class Response : IResponse
    {
        public Response(HttpStatusCode statusCode, string contentType, object body, IDictionary<string, string> headers)
        {
            StatusCode = statusCode;
            ContentType = contentType;
            Body = body;
            Headers = new ReadOnlyDictionary<string, string>(headers);
        }

        #region Implementation IResponse

        public HttpStatusCode StatusCode { get; }

        public string ContentType { get; }

        public object Body { get; }

        public IReadOnlyDictionary<string, string> Headers { get; }

        #endregion
    }
}
