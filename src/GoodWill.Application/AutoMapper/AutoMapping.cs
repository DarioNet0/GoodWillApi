using AutoMapper;
using GoodWill.Communication.Requests;
using GoodWill.Communication.Responses;
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
        }
        private void EntityToResponse()
        {
            CreateMap<Campaign, ResponseCreateCampaignJson>();
            CreateMap<RequestUserJson, User>();
        }
    }
}
