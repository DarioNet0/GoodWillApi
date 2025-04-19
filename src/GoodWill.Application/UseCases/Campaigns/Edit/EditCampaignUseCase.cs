using AutoMapper;
using GoodWill.Communication.Requests.Campaign;
using GoodWill.Domain;
using GoodWill.Domain.Repositories.Campaign;

namespace GoodWill.Application.UseCases.Campaigns.Update
{
    public class EditCampaignUseCase : IEditCampaignUseCase
    {
        private readonly ICampaignUpdateOnlyRepository _repositoryUpdate;
        private readonly ICampaignReadOnlyRespository _repositoryRead;
        private readonly IMapper _mapper;
        private readonly IUnityOfWork _unityOfWork;
        public EditCampaignUseCase(
            ICampaignUpdateOnlyRepository repositoryUpdate,
            ICampaignReadOnlyRespository repositoryRead,
            IMapper mapper,
            IUnityOfWork unityOfWork
        )
        {
            _repositoryRead = repositoryRead;
            _repositoryUpdate = repositoryUpdate;
            _mapper = mapper;
            _unityOfWork = unityOfWork;
        }


        public void Execute(long searchCampaignId, RequestCreateCampaignJson updatedCampaign)
        {
            var campaign = _repositoryRead.GetByIdNoSync(searchCampaignId);
            _mapper.Map<RequestCreateCampaignJson>(campaign);
            _repositoryUpdate.Update(campaign!);

            _unityOfWork.Commit();
        }
    }
}