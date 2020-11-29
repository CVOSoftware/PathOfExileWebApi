using PathOfExileWebApi.Http.Interfaces;
using PathOfExileWebApi.Util;

namespace PathOfExileWebApi.Clients
{
    public abstract class ApiClient
    {
        protected ApiClient(IConnector connector)
        {
            Ensure.ArgumentNullException(connector, nameof(connector));

            _connector = connector;
        }

        protected IConnector _connector { get; }
    }
}
