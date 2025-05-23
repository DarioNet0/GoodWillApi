using AutoMapper;
using GoodWill.Communication.Responses.Campaign;
using GoodWill.Domain.Repositories.Campaign;
using GoodWill.Domain.Services.LoggedUsers;

namespace GoodWill.Application.UseCases.Campaigns.ListById
{
    public class GetByIdCampaignUseCase : IGetByIdCampaignUseCase
    {

        private readonly ICampaignReadOnlyRespository _repositoryReadOnly;
        private readonly IMapper _mapper;

        public GetByIdCampaignUseCase(
            ICampaignReadOnlyRespository repositoryReadOnly,
            IMapper mapper,
            ILoggedUsers loggedUsers
            )
        {
            _repositoryReadOnly = repositoryReadOnly;
            _mapper = mapper;
        }
        public async Task<ResponseGetFullCampaignJson> Execute(long searchCampaignId)
        {
            var result = await _repositoryReadOnly.GetById(searchCampaignId);

            return _mapper.Map<ResponseGetFullCampaignJson>(result);
        }
    }
}
