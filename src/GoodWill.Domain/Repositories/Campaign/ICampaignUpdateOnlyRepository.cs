namespace GoodWill.Domain.Repositories.Campaign
{
    public interface ICampaignUpdateOnlyRepository
    {
        void Update(Entities.Campaign updatedCampaign);
    }
}
