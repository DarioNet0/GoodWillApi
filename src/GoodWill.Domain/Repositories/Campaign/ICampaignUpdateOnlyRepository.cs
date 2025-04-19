namespace GoodWill.Domain.Repositories.Campaign
{
    public interface ICampaignUpdateOnlyRepository
    {
        public void Update(Entities.Campaign updatedCampaign);
    }
}
