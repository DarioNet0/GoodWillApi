using AutoMapper;
using GoodWill.Communication.Responses.Campaign;
using GoodWill.Domain;
using GoodWill.Domain.Repositories.Campaign;
using GoodWill.Domain.Services.LoggedUsers;

namespace GoodWill.Application.UseCases.Campaigns.ListById
{
    public class ListByIdCampaignUseCase : IListByIdCampaignUseCase
    {

        private readonly ICampaignReadOnlyRespository _repositoryReadOnly;
        private readonly IMapper _mapper;
        private readonly ILoggedUsers _loggedUsers;

        public ListByIdCampaignUseCase(
            ICampaignReadOnlyRespository repositoryReadOnly,
            IMapper mapper,
            ILoggedUsers loggedUsers
            )
        {
            _repositoryReadOnly = repositoryReadOnly;
            _mapper = mapper;
            _loggedUsers = loggedUsers;
        }
        public async Task<ResponseListCampaignJson> Execute(long searchCampaignId)
        {
            var loggedUser = await _loggedUsers.Get();

            var result = await _repositoryReadOnly.GetAll(loggedUser);

            return new ResponseListCampaignJson
            {
                ResponseListCampaign = new List<CampaignJson>
        {
            _mapper.Map<CampaignJson>(result)
            }
            };
        }
    }
}
