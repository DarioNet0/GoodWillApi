namespace GoodWill.Domain.Repositories.Campaign
{
    public interface ICampaignReadOnlyRespository
    {
        Task<List<Entities.Campaign>> GetAll();
        Task<Entities.Campaign?> GetById(long id);
        Entities.Campaign? GetByIdNoSync(long searchCampaignId);

    }
}
