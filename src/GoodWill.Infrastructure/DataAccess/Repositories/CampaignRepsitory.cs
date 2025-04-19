using GoodWill.Domain.Entities;
using GoodWill.Domain.Repositories.Campaign;
using Microsoft.EntityFrameworkCore;

namespace GoodWill.Infrastructure.DataAccess.Repositories
{

    internal class CampaignRepsitory : ICampaignReadOnlyRespository, ICampaignUpdateOnlyRepository, ICampaignWriteOnlyRepository
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

        public async Task<List<Campaign>> GetAll()
        {
            return await _dbContext.Campaigns.ToListAsync();
        }

        public async Task<List<Campaign>> GetById(long searchCampaignId)
        {
            return await _dbContext.Campaigns
                .Where(c => c.CampaignId == searchCampaignId).ToListAsync();
        }

        public async Task<bool> Delete(long searchCampaignId)
        {
            var campaignToDelete = await _dbContext.Campaigns
                .FirstOrDefaultAsync(c => c.CampaignId.Equals(searchCampaignId));

            _dbContext.Campaigns.Remove(campaignToDelete!);
            return true;
        }

        public Campaign? GetByIdNoSync(long searchCampaignId)
        {
            var campaign = _dbContext.Campaigns
                .FirstOrDefault(c => c.CampaignId.Equals(searchCampaignId));

            return campaign;
        }
        public void Update(Campaign updatedCampaign)
        {
            _dbContext.Update(updatedCampaign);
        }
    }
}

