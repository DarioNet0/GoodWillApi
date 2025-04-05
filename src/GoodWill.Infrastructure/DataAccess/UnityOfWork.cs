using GoodWill.Domain;

namespace GoodWill.Infrastructure.DataAccess
{
    public class UnityOfWork : IUnityOfWork
    {
        private readonly GoodWillDbContext _dbContext;
        public UnityOfWork(GoodWillDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task Commit()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
