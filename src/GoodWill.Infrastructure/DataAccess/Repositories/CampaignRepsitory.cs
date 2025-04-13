using GoodWill.Domain.Entities;
using GoodWill.Domain.Repositories.Campaign;

namespace GoodWill.Infrastructure.DataAccess.Repositories
{
    
    internal class CampaignRepsitory : ICampaignReadOnelyRespository, ICampaignUpdateOnlyRepository, ICampaignWriteOnlyRepository
    {
        private readonly GoodWillDbContext _dbContext;
        public CampaignRepsitory(GoodWillDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task Add(Campaign campaign)
        {
            await _dbContext.Campaigns.AddAsync(campaign);
        }
    }
}

