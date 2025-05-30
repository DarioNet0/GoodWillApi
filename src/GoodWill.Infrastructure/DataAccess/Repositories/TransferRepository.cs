using GoodWill.Domain.Entities;
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

        public async Task InsertTransferHistory(Transfer transfer)
        {
            await _dbContext
                .Transfers
                .AddAsync(transfer);
        }

        public async Task UpdateBalance(long campaignId, decimal amount)
        {
            using var transaction = await _dbContext.Database.BeginTransactionAsync();

            await _dbContext
                .Database
                .ExecuteSqlRawAsync(
                "CALL SpAtualizaSaldo({0}, {1})",
                campaignId, amount);

            await transaction.CommitAsync();
        }
    }
}
