using GoodWill.Communication.Responses.Campaign;

namespace GoodWill.Application.UseCases.Campaigns.List
{
    public interface IGetAllCampaignUseCase
    {
        Task<ResponseGetAllCampaignJson> Execute();

    }
}
