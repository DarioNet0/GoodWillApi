namespace GoodWill.Domain.Repositories.Campaign
{
    public interface ICampaignUpdateOnlyRepository
    {
        void Update(Entities.Campaign updatedCampaign);
        Task<Entities.Campaign> GetById(Entities.User user, long id);
    }
}
