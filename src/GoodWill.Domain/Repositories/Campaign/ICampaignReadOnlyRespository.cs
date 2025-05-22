namespace GoodWill.Domain.Repositories.Campaign
{
    public interface ICampaignReadOnlyRespository
    {
        Task<List<Entities.Campaign>> GetAll(Entities.User user);
        Task<Entities.Campaign?> GetById(Entities.User user, long id);
        Entities.Campaign? GetByIdNoSync(long searchCampaignId);

    }
}
