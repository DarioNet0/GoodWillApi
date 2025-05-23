using GoodWill.Domain.Entities;
using GoodWill.Domain.Repositories.Campaign;
using Microsoft.EntityFrameworkCore;

namespace GoodWill.Infrastructure.DataAccess.Repositories
{

    internal class CampaignRepository : ICampaignReadOnlyRespository, ICampaignUpdateOnlyRepository, ICampaignWriteOnlyRepository
    {
        private readonly GoodWillDbContext _dbContext;
        public CampaignRepository(GoodWillDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Add(Campaign campaign)
        {
            await _dbContext.Campaigns.AddAsync(campaign);
        }

        public async Task<List<Campaign>> GetAll()
        {
            return await _dbContext.Campaigns.AsNoTracking().ToListAsync();
        }

        public async Task<Campaign?> GetById(long id)
        {
            return await _dbContext.Campaigns
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.CampaignId.Equals(id));
        }

        public async Task<bool> Delete(long searchCampaignId)
        {
            var campaignToDelete = await _dbContext.Campaigns
                .FirstOrDefaultAsync(c => c.CampaignId == searchCampaignId);

            if (campaignToDelete == null)
                return false;

            _dbContext.Campaigns.Remove(campaignToDelete);
            return true;
        }

        public Campaign? GetByIdNoSync(long searchCampaignId)
        {
            return _dbContext.Campaigns
                .FirstOrDefault(c => c.CampaignId == searchCampaignId);
        }

        public void Update(Campaign updatedCampaign)
        {
            _dbContext.Update(updatedCampaign);
        }
    }
}

