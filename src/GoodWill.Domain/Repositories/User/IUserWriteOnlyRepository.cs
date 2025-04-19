using GoodWill.Domain.Entities;

namespace GoodWill.Domain.Repositories.User
{
    public interface IUserWriteOnlyRepository
    {
        Task AddUser(Domain.Entities.User user);
    }
}
