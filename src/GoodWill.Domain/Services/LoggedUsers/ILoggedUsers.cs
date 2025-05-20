using GoodWill.Domain.Entities;

namespace GoodWill.Domain.Services.LoggedUsers
{
    public interface ILoggedUsers
    {
        Task<User> Get();
    }
}
