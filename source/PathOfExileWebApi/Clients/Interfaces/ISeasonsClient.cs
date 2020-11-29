using System.Collections.Generic;
using System.Threading.Tasks;

using PathOfExileWebApi.Contracts.Response;

namespace PathOfExileWebApi.Clients.Interfaces
{
    public interface ISeasonsClient
    {
        Task<IEnumerable<SeasonModel>> Get();
    }
}
