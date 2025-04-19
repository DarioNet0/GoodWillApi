using AutoMapper;
using GoodWill.Communication.Responses.Campaign;
using GoodWill.Domain;
using GoodWill.Domain.Repositories.Campaign;

namespace GoodWill.Application.UseCases.Campaigns.List
{
<<<<<<< HEAD
    internal class ListCampaignUseCase : IListAllCampaignUseCase
=======
    internal class ListAllCampaignUseCase : IListAllCampaignUseCase
>>>>>>> dfc9f990b3330d0c512c3ff47b3b872303f83538
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
