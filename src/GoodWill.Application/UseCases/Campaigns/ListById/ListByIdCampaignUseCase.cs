using AutoMapper;
using GoodWill.Communication.Responses;
using GoodWill.Domain.Repositories.Campaign;
using GoodWill.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodWill.Application.UseCases.Campaigns.ListById
{
    public class ListByIdCampaignUseCase : IListByIdCampaignUseCase
    {

        private readonly ICampaignReadOnelyRespository _repository;
        private readonly IMapper _mapper;
        private readonly IUnityOfWork _unityOfWork;

        public ListByIdCampaignUseCase(
            ICampaignReadOnelyRespository repository,
            IMapper mapper,
            IUnityOfWork unityOfWork
            )
        {
            _repository = repository;
            _mapper = mapper;
            _unityOfWork = unityOfWork;
        }
        public async Task<ResponseListCampaignJson> Execute(long searchCampaignId)
        {
            var campaign = await _repository.GetById(searchCampaignId);

            return new ResponseListCampaignJson
            {
                ResponseListCampaign = new List<CampaignJson>
        {
            _mapper.Map<CampaignJson>(campaign)
            };
        }
    }
}
