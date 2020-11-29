namespace PathOfExileWebApi.Http.Interfaces
{
    internal interface ISerializer
    {
        void SerializeRequest(IRequest request);

        ISerializableResponse<T> DeserializeResponse<T>(IResponse response);
    }
}
