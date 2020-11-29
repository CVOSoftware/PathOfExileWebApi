using System;
using System.IO;
using System.Text.Json;
using System.Net.Http;
using System.Net.Mime;

using PathOfExileWebApi.Http.Interfaces;

namespace PathOfExileWebApi.Http
{
    internal class Serializer : ISerializer
    {
        #region Implementation ISerializer

        public void SerializeRequest(IRequest request)
        {
            var result = CheckContentBody(request.Body);

            if (result)
            {
                return;
            }

            request.Body = JsonSerializer.Serialize(request.Body);
        }

        public ISerializableResponse<T> DeserializeResponse<T>(IResponse response)
        {
            var result = CheckContentType(response.ContentType);

            if(result)
            {
                var body = JsonSerializer.Deserialize<T>(response.Body as string ?? string.Empty);

                return new SerializableResponse<T>(response, body);
            }

            return new SerializableResponse<T>(response);
        }

        #endregion

        #region Static

        private static bool CheckContentBody(object body)
        {
            return body is null
                || body is string
                || body is Stream
                || body is HttpContent;
        }

        private static bool CheckContentType(string  contentType)
        {
            return contentType == null
                || contentType.Equals(MediaTypeNames.Application.Json, StringComparison.Ordinal);
        }

        #endregion
    }
}
