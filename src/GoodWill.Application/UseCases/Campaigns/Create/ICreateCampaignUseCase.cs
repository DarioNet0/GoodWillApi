using GoodWill.Communication.Requests;
using GoodWill.Communication.Responses;

namespace GoodWill.Application.UseCases.Campaigns.Create
{
    public interface ICreateCampaignUseCase
    {
        Task<ResponseCreateCampaignJson> Execute(RequestCreateCampaignJson request);    
    }
}
