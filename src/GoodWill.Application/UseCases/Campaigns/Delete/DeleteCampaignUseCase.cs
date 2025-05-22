using GoodWill.Domain;
using GoodWill.Domain.Repositories.Campaign;
using GoodWill.Domain.Services.LoggedUsers;
using GoodWill.Exception.ExceptionBase;

namespace GoodWill.Application.UseCases.Campaigns.Delete
{
    internal class DeleteCampaignUseCase : IDeleteCampaignUseCase
    {
        private readonly ICampaignWriteOnlyRepository _repositoryWriteOnly;
        private readonly ICampaignReadOnlyRespository _repositoryReadOnly;
        private readonly IUnityOfWork _unityOfWork;
        private readonly ILoggedUsers _loggedUsers;

        public DeleteCampaignUseCase(
            ICampaignWriteOnlyRepository repositoryWriteOnly,
            ICampaignReadOnlyRespository repositoryReadOnly,
            IUnityOfWork unityOfWork,
            ILoggedUsers loggedUsers
            )
        {
            _repositoryWriteOnly = repositoryWriteOnly;
            _repositoryReadOnly = repositoryReadOnly;
            _unityOfWork = unityOfWork;
            _loggedUsers = loggedUsers;
        }
        public async Task<bool> Execute(long searchCampaignId)
        {
            var loggedUser = await _loggedUsers.Get();

            var campaign = await _repositoryReadOnly.GetById(loggedUser, searchCampaignId);

            if (campaign?.UserId != loggedUser.UserId)
            {
                throw new ForbidException();
            }

            if (campaign is null)
            {
                throw new NotFoundException();
            }

            var isDeleted = await _repositoryWriteOnly.Delete(searchCampaignId);
            await _unityOfWork.Commit();
            return isDeleted;

        }
    }
}