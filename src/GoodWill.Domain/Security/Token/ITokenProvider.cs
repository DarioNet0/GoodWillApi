namespace GoodWill.Domain.Security.Token
{
    public interface ITokenProvider
    {
        string TokenOnRequest();
    }
}
