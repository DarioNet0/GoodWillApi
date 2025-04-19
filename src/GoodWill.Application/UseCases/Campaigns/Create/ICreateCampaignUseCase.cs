using GoodWill.Communication.Requests.Campaign;
using GoodWill.Communication.Responses.Campaign;

namespace GoodWill.Application.UseCases.Campaigns.Create
{
    public interface ICreateCampaignUseCase
    {
        Task<ResponseCreateCampaignJson> Execute(RequestCreateCampaignJson request);    
    }
}
