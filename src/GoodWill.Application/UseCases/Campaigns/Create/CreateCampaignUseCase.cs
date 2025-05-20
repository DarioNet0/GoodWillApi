using AutoMapper;
using GoodWill.Communication.Requests.Campaign;
using GoodWill.Communication.Responses.Campaign;
using GoodWill.Domain;
using GoodWill.Domain.Entities;
using GoodWill.Domain.Repositories.Campaign;
using GoodWill.Domain.Services.LoggedUsers;

namespace GoodWill.Application.UseCases.Campaigns.Create
{
    public class CreateCampaignUseCase : ICreateCampaignUseCase
    {
        private readonly ICampaignWriteOnlyRepository _repository;
        private readonly IUnityOfWork _unityOfWork;
        private readonly IMapper _mapper;
        private readonly ILoggedUsers _loggedUsers;
        public CreateCampaignUseCase(
            ICampaignWriteOnlyRepository repository,
            IUnityOfWork unityOfWork,
            IMapper mapper,
            ILoggedUsers loggedUsers
            )
        {
            _repository = repository;
            _unityOfWork = unityOfWork; 
            _mapper = mapper;
            _loggedUsers = loggedUsers;
        }
        public async Task<ResponseCreateCampaignJson> Execute(RequestCreateCampaignJson request)
        {
            var loggedUser = await _loggedUsers.Get();

            var campaign = _mapper.Map<Campaign>(request);
            campaign.UserId = loggedUser.UserId;

            await _repository.Add(campaign);
            await _unityOfWork.Commit();

            return _mapper.Map<ResponseCreateCampaignJson>(campaign);
        }
    }
}
