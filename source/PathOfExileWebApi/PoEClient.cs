using System;

using PathOfExileWebApi.Clients;
using PathOfExileWebApi.Clients.Interfaces;
using PathOfExileWebApi.Http; 
using PathOfExileWebApi.Http.Interfaces;

namespace PathOfExileWebApi
{
    public sealed class PoEClient : IPoEClient
    {
        #region Clients field

        private ISeasonsClient _seasons;

        #endregion

        private readonly IConnector _connector;

        public PoEClient()
        {
            var baseUri = new Uri("https://www.pathofexile.com");
            var webClient = new WebClient();
            var serializer = new Serializer();

            _connector = new Connector(baseUri, serializer, webClient);
        }

        #region Implementation IPoeClient

        public ISeasonsClient Seasons => _seasons ??= new SeasonsClient(_connector);

        #endregion
    }
}
