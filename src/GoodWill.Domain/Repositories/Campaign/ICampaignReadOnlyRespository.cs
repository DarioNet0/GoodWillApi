namespace GoodWill.Domain.Repositories.Campaign
{
    public interface ICampaignReadOnlyRespository
    {
        Task<List<Domain.Entities.Campaign>> GetAll(Entities.User user);
        Task<Domain.Entities.Campaign?> GetById(Entities.User user, long id);
        Entities.Campaign? GetByIdNoSync(long searchCampaignId);

    }
}
