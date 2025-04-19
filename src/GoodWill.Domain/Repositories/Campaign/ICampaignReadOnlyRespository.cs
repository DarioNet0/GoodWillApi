namespace GoodWill.Domain.Repositories.Campaign
{
    public interface ICampaignReadOnlyRespository
    {
        Task<List<Domain.Entities.Campaign>> GetAll();
        Task<List<Domain.Entities.Campaign>> GetById(long searchCampaignId);
        Domain.Entities.Campaign? GetByIdNoSync(long searchCampaignId);

    }
}
