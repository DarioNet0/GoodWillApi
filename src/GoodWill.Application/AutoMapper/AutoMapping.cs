using AutoMapper;
using GoodWill.Communication.Requests.Campaign;
using GoodWill.Communication.Requests.Transfer;
using GoodWill.Communication.Requests.User;
using GoodWill.Communication.Responses.Campaign;
using GoodWill.Communication.Responses.Transfer;
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
            CreateMap<RequestUserJson, User>()
                .ForMember(dest => dest.Password, config => config.Ignore());
            CreateMap<RequestMakeTransferJson, Transfer>();
        }
        private void EntityToResponse()
        {
            CreateMap<Campaign, ResponseCreateCampaignJson>();
            CreateMap<RequestUserJson, User>();
            CreateMap<Campaign, ResponseShortCampaignJson>();
            CreateMap<Campaign, ResponseGetFullCampaignJson>();
            CreateMap<Transfer, ResponseMakeTransferJson>();
        }
    }
}
