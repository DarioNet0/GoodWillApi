using GoodWill.Communication.Responses;

namespace GoodWill.Application.UseCases.Campaigns.List
{
    public interface IListAllCampaignUseCase
    {
        Task<ResponseListCampaignJson> Execute();

    }
}
