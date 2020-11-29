using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Mime;

using PathOfExileWebApi.Extensions;
using PathOfExileWebApi.Http.Interfaces;

namespace PathOfExileWebApi.Http
{
    internal sealed class WebClient : IWebClient
    {
        private readonly HttpClient _httpClient;

        public WebClient()
        {
            _httpClient = new HttpClient();
        }

        #region Implementation IHttpClient

        public void SetRequestTimeout(TimeSpan timeout)
        {
            _httpClient.Timeout = timeout;
        }

        public async Task<IResponse> DoRequest(IRequest request)
        {
            using var requestMessage = BuildRequest(request);
            var responseMessage = await _httpClient
                .SendAsync(requestMessage, HttpCompletionOption.ResponseContentRead)
                .ConfigureAwait(false);
            var response = await BuildResponse(responseMessage).ConfigureAwait(false);

            return response;
        }

        #endregion

        #region Implementation IDisposable

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if(disposing)
            {
                _httpClient?.Dispose();
            }
        }

        #endregion

        #region Static

        private static void SetRequestHeaders(IRequest request, HttpRequestMessage requestMessage)
        {
            foreach (var header in request.Headers)
            {
                requestMessage.Headers.Add(header.Key, header.Value);
            }
        }

        private static void SetRequestBody(IRequest request, HttpRequestMessage requestMessage)
        {
            switch(request.Body)
            {
                case HttpContent body:
                    requestMessage.Content = body;
                    break;
                case Stream body:
                    requestMessage.Content = new StreamContent(body);
                    break;
                case string body:
                    requestMessage.Content = new StringContent(body, Encoding.UTF8, MediaTypeNames.Application.Json);
                    break;
            }
        }

        private static HttpRequestMessage BuildRequest(IRequest request)
        {
            var uri = new Uri(request.BaseAddress, request.Endpoint).ApplyParameters(request.Parameters);
            var requestMessage = new HttpRequestMessage(request.Method, uri);

            SetRequestHeaders(request, requestMessage);
            SetRequestBody(request, requestMessage);

            return requestMessage;
        }

        private static async Task<IResponse> BuildResponse(HttpResponseMessage responseMessage)
        {
            using var content = responseMessage.Content;
            var contentType = content?.Headers?.ContentType?.MediaType;
            var body = await content
                .ReadAsStringAsync()
                .ConfigureAwait(false);
            var headers = responseMessage.Headers.ToDictionary(item => item.Key, item => item.Value.FirstOrDefault());
            var response = new Response(responseMessage.StatusCode, contentType, body, headers);

            return response;
        }

        #endregion
    }
}
