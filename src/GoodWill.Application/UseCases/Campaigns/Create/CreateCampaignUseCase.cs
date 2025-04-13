using AutoMapper;
using GoodWill.Communication.Requests;
using GoodWill.Communication.Responses;
using GoodWill.Domain;
using GoodWill.Domain.Entities;
using GoodWill.Domain.Repositories.Campaign;

namespace GoodWill.Application.UseCases.Campaigns.Create
{
    public class CreateCampaignUseCase : ICreateCampaignUseCase
    {
        private readonly ICampaignWriteOnlyRepository _repository;
        private readonly IUnityOfWork _unityOfWork;
        private readonly IMapper _mapper;
        public CreateCampaignUseCase(
            ICampaignWriteOnlyRepository repository,
            IUnityOfWork unityOfWork,
            IMapper mapper)
        {
            _repository = repository;
            _unityOfWork = unityOfWork; 
            _mapper = mapper;
        }
        public async Task<ResponseCreateCampaignJson> Execute(RequestCreateCampaignJson request)
        {
            var entity = _mapper.Map<Campaign>(request);

            await _repository.Add(entity);

            var response = _mapper.Map<ResponseCreateCampaignJson>(entity);

            return response;
        }
    }
}
