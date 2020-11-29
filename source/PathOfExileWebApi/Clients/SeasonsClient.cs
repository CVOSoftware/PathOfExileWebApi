using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using PathOfExileWebApi.Contracts.Response;
using PathOfExileWebApi.Clients.Interfaces;
using PathOfExileWebApi.Http.Interfaces;

namespace PathOfExileWebApi.Clients
{
    public sealed class SeasonsClient : ApiClient, ISeasonsClient
    {
        public SeasonsClient(IConnector connector) : base(connector)
        {
            _endpoint = new Endpoint();
        }

        #region Implementation ISeasonsClient

        public async Task<IEnumerable<SeasonModel>> Get()
        {
            return await _connector.Get<IEnumerable<SeasonModel>>(_endpoint.Seasons()).ConfigureAwait(false);
        }

        #endregion

        #region Endpoint

        private Endpoint _endpoint;

        private sealed class Endpoint : BaseEndpoint
        {
            public Uri Seasons() => Uri("api/seasons");
        }

        #endregion
    }
}
