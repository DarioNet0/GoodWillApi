using AutoMapper;
using GoodWill.Communication.Requests;
using GoodWill.Communication.Responses;
using GoodWill.Domain;
using GoodWill.Domain.Repositories.Campaign;

namespace GoodWill.Application.UseCases.Campaigns.List
{
    internal class ListCampaignUseCase : IListAllCampaignUseCase
    {
        private readonly ICampaignReadOnelyRespository _repository;
        private readonly IMapper _mapper;
        private readonly IUnityOfWork _unityOfWork;

        public ListCampaignUseCase(
            ICampaignReadOnelyRespository repository,
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
