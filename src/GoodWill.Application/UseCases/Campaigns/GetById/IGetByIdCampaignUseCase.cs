using GoodWill.Communication.Responses.Campaign;

namespace GoodWill.Application.UseCases.Campaigns.ListById
{
    public interface IGetByIdCampaignUseCase
    {
        Task<ResponseGetFullCampaignJson> Execute(long searchCampaignId);

    }
}
