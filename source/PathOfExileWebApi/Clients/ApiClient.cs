using PathOfExileWebApi.Http.Interfaces;
using PathOfExileWebApi.Util;

namespace PathOfExileWebApi.Clients
{
    public abstract class ApiClient
    {
        protected ApiClient(IConnector apiConnector)
        {
            Ensure.ArgumentNullException(apiConnector, nameof(apiConnector));

            ApiConnector = apiConnector;
        }

        protected IConnector ApiConnector { get; }
    }
}
