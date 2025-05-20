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

        public async Task<List<Campaign>> GetAll(User user)
        {
            return await _dbContext.Campaigns
                .Where(c => c.UserId == user.UserId)
                .ToListAsync();
        }

        public async Task<Campaign?> GetById(User user, long id)
        {
            return await _dbContext.Campaigns
                .Where(c => c.UserId == user.UserId && c.CampaignId == id)
                .FirstOrDefaultAsync();
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

