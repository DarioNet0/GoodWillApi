using GoodWill.Domain.Entities;

namespace GoodWill.Domain.Security.Token
{
    public interface IAccessTokenGenerator
    {
        string GenerateToken(User user);
    }
}
