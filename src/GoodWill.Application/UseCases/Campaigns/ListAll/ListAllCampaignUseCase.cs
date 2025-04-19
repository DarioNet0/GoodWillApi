using AutoMapper;
using GoodWill.Communication.Responses.Campaign;
using GoodWill.Domain;
using GoodWill.Domain.Repositories.Campaign;

namespace GoodWill.Application.UseCases.Campaigns.List
{
    internal class ListAllCampaignUseCase : IListAllCampaignUseCase
    {
        private readonly ICampaignReadOnlyRespository _repository;
        private readonly IMapper _mapper;
        private readonly IUnityOfWork _unityOfWork;

        public ListAllCampaignUseCase(
            ICampaignReadOnlyRespository repository,
            IMapper mapper,
            IUnityOfWork unityOfWork
            )
        {
            _repository = repository;
            _mapper = mapper;
            _unityOfWork = unityOfWork;
        }


        public async Task<ResponseListCampaignJson> Execute()
        {
            var allCampaign = await _repository.GetAll();
            var response = new ResponseListCampaignJson
            {
                ResponseListCampaign = _mapper.Map<List<CampaignJson>>(allCampaign)
            };
            return response;
        }
    }
}
