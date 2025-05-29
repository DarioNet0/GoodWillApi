namespace GoodWill.Domain.Repositories.User
{
    public interface IUserReadOnlyRepository
    {
        Task<bool> VerifyEmailDisponibility(string email);
        Task<Entities.User?> GetUserByEmail(string email);
    }
}
