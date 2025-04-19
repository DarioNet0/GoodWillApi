using GoodWill.Domain.Entities;
using GoodWill.Domain.Repositories.User;
using Microsoft.EntityFrameworkCore;

namespace GoodWill.Infrastructure.DataAccess.Repositories
{
    
    internal class UserRepository : IUserReadOnlyRepository, IUserUpdateOnlyRepository, IUserWriteOnlyRepository
    {
        private readonly GoodWillDbContext _dbContext;
        public UserRepository(GoodWillDbContext dbContext)
        {
            _dbContext = dbContext; 
        }

        public async Task AddUser(User user)
        {
            await _dbContext.Users.AddAsync(user);
        }

        public async Task<User?> GetUserByEmail(string email)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(x => x.Email == email);

            return user;
        }

        public async Task<bool> VerifyEmailDisponibility(string email)
        {
            return await _dbContext.Users.AnyAsync(user => user.Email.Equals(email));
        }
    }
}
