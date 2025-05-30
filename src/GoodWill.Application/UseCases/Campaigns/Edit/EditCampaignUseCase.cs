using AutoMapper;
using GoodWill.Application.Validators;
using GoodWill.Communication.Requests.Campaign;
using GoodWill.Domain;
using GoodWill.Domain.Repositories.Campaign;
using GoodWill.Domain.Services.LoggedUsers;
using GoodWill.Exception.ExceptionBase;

namespace GoodWill.Application.UseCases.Campaigns.Update
{
    public class EditCampaignUseCase : IEditCampaignUseCase
    {
        private readonly ICampaignUpdateOnlyRepository _repositoryUpdate;
        private readonly ICampaignReadOnlyRespository _readRepository;
        private readonly IMapper _mapper;
        private readonly IUnityOfWork _unityOfWork;
        private readonly ILoggedUsers _loggedUsers;
        public EditCampaignUseCase(
            ICampaignUpdateOnlyRepository repositoryUpdate,
            ICampaignReadOnlyRespository readOnlyRespository,
            IMapper mapper,
            IUnityOfWork unityOfWork,
            ILoggedUsers loggedUsers

        )
        {
            _repositoryUpdate = repositoryUpdate;
            _mapper = mapper;
            _unityOfWork = unityOfWork;
            _loggedUsers = loggedUsers;
            _readRepository = readOnlyRespository;
        }


        public async Task Execute(long searchCampaignId, RequestCreateCampaignJson updatedCampaign)
        {
            Validate(updatedCampaign);

            var loggedUser = await _loggedUsers.Get();

            var campaign = await _readRepository.GetById(searchCampaignId);

            if (campaign?.UserId != loggedUser.UserId)
            {
                throw new ForbidException();
            }

            if (campaign is null)
            {
                throw new NotFoundException();
            }

            _mapper.Map<RequestCreateCampaignJson>(campaign);
            _repositoryUpdate.Update(campaign!);

            await _unityOfWork.Commit();
        }
        private void Validate(RequestCreateCampaignJson request)
        {
            var validator = new CampaignValidator();

            var result = validator.Validate(request);

            if (result.IsValid == false)
            {
                var errorMessages = result.Errors.Select(x => x.ErrorMessage).ToList();

                throw new ErrorOnValidationException(errorMessages);
            }
        }
    }
}