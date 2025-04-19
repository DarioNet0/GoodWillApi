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
<<<<<<< HEAD
            CreateMap<RequestUserJson, User>()
                .ForMember(dest => dest.Password, config => config.Ignore());
=======
            CreateMap<RequestDeleteCampaignJson, Campaign>();
>>>>>>> dfc9f990b3330d0c512c3ff47b3b872303f83538
        }
        private void EntityToResponse()
        {
            CreateMap<Campaign, ResponseCreateCampaignJson>();
<<<<<<< HEAD
            CreateMap<RequestUserJson, User>();
=======
            CreateMap<Campaign, ResponseListCampaignJson>();

>>>>>>> dfc9f990b3330d0c512c3ff47b3b872303f83538
        }
    }
}
