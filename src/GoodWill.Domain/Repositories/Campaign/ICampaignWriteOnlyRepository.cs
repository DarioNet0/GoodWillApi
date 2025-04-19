namespace GoodWill.Domain.Repositories.Campaign
{
    public interface ICampaignWriteOnlyRepository
    {
        Task Add(Entities.Campaign campaign);

        Task<bool> Delete(long searchCampaignId);
    }
}
