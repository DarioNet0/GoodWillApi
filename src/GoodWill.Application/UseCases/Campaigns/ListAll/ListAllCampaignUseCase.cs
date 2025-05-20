using AutoMapper;
using GoodWill.Communication.Responses.Campaign;
using GoodWill.Domain;
using GoodWill.Domain.Repositories.Campaign;
using GoodWill.Domain.Services.LoggedUsers;

namespace GoodWill.Application.UseCases.Campaigns.List
{
    internal class ListCampaignUseCase : IListAllCampaignUseCase

    {
        private readonly ICampaignReadOnlyRespository _repositoryReadOnly;
        private readonly IMapper _mapper;
        private readonly ILoggedUsers _loggedUsers;

        public ListCampaignUseCase(
            ICampaignReadOnlyRespository repositoryReadOnly,
            IMapper mapper,
            ILoggedUsers loggedUsers
            )
        {
            _repositoryReadOnly = repositoryReadOnly;
            _mapper = mapper;
            _loggedUsers = loggedUsers;
        }


        public async Task<ResponseListCampaignJson> Execute()
        {
            var loggedUser = await _loggedUsers.Get();

            var result = await _repositoryReadOnly.GetAll(loggedUser);

            var response = new ResponseListCampaignJson
            {
                ResponseListCampaign = _mapper.Map<List<CampaignJson>>(result)
            };
            return response;
        }
    }
}
