using AutoMapper;
using GoodWill.Communication.Requests.Campaign;
using GoodWill.Domain;
using GoodWill.Domain.Repositories.Campaign;
using GoodWill.Domain.Services.LoggedUsers;

namespace GoodWill.Application.UseCases.Campaigns.Update
{
    public class EditCampaignUseCase : IEditCampaignUseCase
    {
        private readonly ICampaignUpdateOnlyRepository _repositoryUpdate;
        private readonly IMapper _mapper;
        private readonly IUnityOfWork _unityOfWork;
        private readonly ILoggedUsers _loggedUsers;
        public EditCampaignUseCase(
            ICampaignUpdateOnlyRepository repositoryUpdate,
            IMapper mapper,
            IUnityOfWork unityOfWork,
            ILoggedUsers loggedUsers

        )
        {
            _repositoryUpdate = repositoryUpdate;
            _mapper = mapper;
            _unityOfWork = unityOfWork;
            _loggedUsers = loggedUsers;
        }


        public async Task Execute(long searchCampaignId, RequestCreateCampaignJson updatedCampaign)
        {
            var loggedUser = await _loggedUsers.Get();

            var campaign = await _repositoryUpdate.GetById(loggedUser, searchCampaignId);

            if (campaign is null)
            {
                throw new System.Exception("Campaign not found");
            }

            _mapper.Map<RequestCreateCampaignJson>(campaign);
            _repositoryUpdate.Update(campaign!);

            await _unityOfWork.Commit();
        }
    }
}