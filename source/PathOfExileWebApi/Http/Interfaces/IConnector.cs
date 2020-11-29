using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PathOfExileWebApi.Http.Interfaces
{
    public interface IConnector
    {
        Task<T> Get<T>(Uri uri);

        Task<T> Get<T>(Uri uri, IDictionary<string, string> parameters);
    }
}
