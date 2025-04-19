using GoodWill.Communication.Requests.Campaign;

namespace GoodWill.Application.UseCases.Campaigns.Update
{
    public interface IEditCampaignUseCase
    {
        public void Execute(long searchCampaignId, RequestCreateCampaignJson updatedCampaign);
    }
}

