using GoodWill.Communication.Responses.Campaign;

namespace GoodWill.Application.UseCases.Campaigns.List
{
    public interface IListAllCampaignUseCase
    {
        Task<ResponseListCampaignJson> Execute();

    }
}
