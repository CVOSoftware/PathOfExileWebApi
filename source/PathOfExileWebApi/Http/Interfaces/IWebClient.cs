using System;
using System.Threading.Tasks;

namespace PathOfExileWebApi.Http.Interfaces
{
    internal interface IWebClient : IDisposable
    {
        void SetRequestTimeout(TimeSpan timeout);

        Task<IResponse> DoRequest(IRequest request);
    }
}
