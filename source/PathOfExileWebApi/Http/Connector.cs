using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

using PathOfExileWebApi.Http.Interfaces;

namespace PathOfExileWebApi.Http
{
    internal sealed class Connector : IConnector
    {
        private Uri _baseAddress;

        private ISerializer _serializer;

        private IWebClient _webClient;

        public Connector(Uri baseAddress, ISerializer serializer, IWebClient webClient)
        {
            _baseAddress = baseAddress;
            _serializer = serializer;
            _webClient = webClient;
        }

        #region Implementation IConnector

        public async Task<T> Get<T>(Uri uri)
        {
            return await SendRequest<T>(uri, HttpMethod.Get).ConfigureAwait(false);
        }

        public async Task<T> Get<T>(Uri uri, IDictionary<string, string> parameters)
        {
            return await SendRequest<T>(uri, HttpMethod.Get, parameters: parameters).ConfigureAwait(false);
        }

        #endregion

        private async Task<T> SendRequest<T>(Uri endpoint, HttpMethod method, object body = null, IDictionary<string, string> headers = null, IDictionary<string, string> parameters = null)
        {
            var request = new Request(_baseAddress, endpoint, method, body, headers, parameters);
            var response = await DoRequest<T>(request).ConfigureAwait(false);

            return response.Body;
        }

        private async Task<ISerializableResponse<T>> DoRequest<T>(IRequest request)
        {
            _serializer.SerializeRequest(request);

            var response = await _webClient.DoRequest(request).ConfigureAwait(false);
            var deserializedResponse = _serializer.DeserializeResponse<T>(response);

            return deserializedResponse;
        }
    }
}
