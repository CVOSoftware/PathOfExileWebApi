using PathOfExileWebApi.Http.Interfaces;

namespace PathOfExileWebApi.Http
{
    internal class SerializableResponse<T> : ISerializableResponse<T>
    {
        public SerializableResponse(IResponse response, T body = default)
        {
            Body = body;
            Response = response;
        }

        public T Body { get; }

        public IResponse Response { get; }
    }
}
