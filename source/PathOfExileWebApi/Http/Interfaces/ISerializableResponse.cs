namespace PathOfExileWebApi.Http.Interfaces
{
    internal interface ISerializableResponse<out T>
    {
        T Body { get; }

        IResponse Response { get; }
    }
}
