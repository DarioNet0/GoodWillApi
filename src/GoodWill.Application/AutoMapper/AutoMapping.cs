using AutoMapper;
using GoodWill.Communication.Requests.Campaign;
using GoodWill.Communication.Responses.Campaign;
using GoodWill.Domain.Entities;

namespace GoodWill.Application.AutoMapper
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            RequestToEntity();
            EntityToResponse();
        }
        private void RequestToEntity()
        {
            CreateMap<RequestCreateCampaignJson, Campaign>();
            CreateMap<RequestDeleteCampaignJson, Campaign>();
        }
        private void EntityToResponse()
        {
            CreateMap<Campaign, ResponseCreateCampaignJson>();
            CreateMap<Campaign, ResponseListCampaignJson>();

        }
    }
}
