using AutoMapper;
using GoodWill.Communication.Responses.Campaign;
using GoodWill.Domain.Repositories.Campaign;
using GoodWill.Domain.Services.LoggedUsers;

namespace GoodWill.Application.UseCases.Campaigns.List
{
    internal class GetAllCampaignUseCase : IGetAllCampaignUseCase

    {
        private readonly ICampaignReadOnlyRespository _repositoryReadOnly;
        private readonly IMapper _mapper;

        public GetAllCampaignUseCase(
            ICampaignReadOnlyRespository repositoryReadOnly,
            IMapper mapper,
            ILoggedUsers loggedUsers
            )
        {
            _repositoryReadOnly = repositoryReadOnly;
            _mapper = mapper;
        }


        public async Task<ResponseGetAllCampaignJson> Execute()
        {
            var result = await _repositoryReadOnly.GetAll();

            var response = new ResponseGetAllCampaignJson
            {
                Campaigns = _mapper.Map<List<ResponseShortCampaignJson>>(result)
            };
            return response;
        }
    }
}
