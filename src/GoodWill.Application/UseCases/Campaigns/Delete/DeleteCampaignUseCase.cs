using AutoMapper;
using GoodWill.Domain;
using GoodWill.Domain.Repositories.Campaign;

namespace GoodWill.Application.UseCases.Campaigns.Delete
{
    internal class DeleteCampaignUseCase : IDeleteCampaignUseCase
    {
        private readonly ICampaignWriteOnlyRepository _repository;
        private readonly IMapper _mapper;
        private readonly IUnityOfWork _unityOfWork;

        public DeleteCampaignUseCase(
            ICampaignWriteOnlyRepository repository,
            IMapper mapper,
            IUnityOfWork unityOfWork
            )
        {
            _repository = repository;
            _mapper = mapper;
            _unityOfWork = unityOfWork;
        }
        public async Task<bool> Execute(long searchCampaignId)
        {
            var isDeleted = await _repository.Delete(searchCampaignId);

            await _unityOfWork.Commit();

            return isDeleted;
        }
    }
}
