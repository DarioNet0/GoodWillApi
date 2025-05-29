using GoodWill.Domain.Repositories.Transfer;
using Microsoft.EntityFrameworkCore;

namespace GoodWill.Infrastructure.DataAccess.Repositories
{
    public class TransferRepository : ITransferReadOnlyRespository, ITransferWriteOnlyRepository
    {
        private readonly GoodWillDbContext _dbContext;
        public TransferRepository(GoodWillDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Task UpdateBalance(long campaignId)
        {
            _dbContext.Database.ExecuteSqlRaw(
                "");
        }
    }
}
