using AutoMapper;
using GoodWill.Application.Validators;
using GoodWill.Communication.Enums;
using GoodWill.Communication.Requests.Transfer;
using GoodWill.Communication.Responses.Transfer;
using GoodWill.Domain;
using GoodWill.Domain.Repositories.Campaign;
using GoodWill.Domain.Repositories.Transfer;
using GoodWill.Domain.Services.LoggedUsers;
using GoodWill.Exception.ExceptionBase;

namespace GoodWill.Application.UseCases.Transfer
{
    public class MakeTransferUseCase : IMakeTransferUseCase
    {
        private readonly ICampaignReadOnlyRespository _campaignReadOnlyRespository;
        private readonly ILoggedUsers _loggedUsers;
        private readonly ITransferWriteOnlyRepository _transferWriteOnlyRepository;
        private readonly IUnityOfWork _unityOfWork;
        private readonly IMapper _mapper;
        public MakeTransferUseCase(
            ILoggedUsers loggedUsers,
            ICampaignReadOnlyRespository campaignReadOnlyRespository,
            ITransferWriteOnlyRepository transferWriteOnlyRepository,
            IUnityOfWork unityOfWork,
            IMapper mapper)
        {
            _loggedUsers = loggedUsers;
            _campaignReadOnlyRespository = campaignReadOnlyRespository;
            _transferWriteOnlyRepository = transferWriteOnlyRepository;
            _unityOfWork = unityOfWork;
            _mapper = mapper;
        }
        public async Task<ResponseMakeTransferJson> Execute(RequestMakeTransferJson request)
        {
            ValidateRequest(request);

            var user = await _loggedUsers.Get();

            await ValidateCampaing(request.CampaignId, user.UserId);

            switch (request.TransferType)
            {
                case TransferTypes.Pix:
                    await HandlePixTransfer(request.CampaignId, request.Amount);
                    break;
                case TransferTypes.CreditCard:
                    break;
                case TransferTypes.Boleto:
                    break;
                case TransferTypes.Ad:
                    break;
            }

            var transfer = _mapper.Map<Domain.Entities.Transfer>(request);

            transfer.UserId = user.UserId;

            await _transferWriteOnlyRepository.InsertTransferHistory(transfer);

            await _unityOfWork.Commit();

            return _mapper.Map<ResponseMakeTransferJson>(transfer);

        }
        private void ValidateRequest(RequestMakeTransferJson request)
        {
            var validator = new TransferValidator();

            var result = validator.Validate(request);

            if (result.IsValid == false)
            {
                var errorsMessages = result.Errors.Select(ex => ex.ErrorMessage).ToList();

                throw new ErrorOnValidationException(errorsMessages);
            }
        }
        private async Task ValidateCampaing(long campaignId, long userId)
        {
            var campaign = await _campaignReadOnlyRespository.GetById(campaignId);

            if (campaign is null)
            {
                throw new NotFoundException();
            }

            if (campaign.UserId != userId && campaign.TargetValue == campaign.AmountCollected)
            {
                throw new ForbidException();
            }
        }
        private async Task HandlePixTransfer(long campaignId, decimal Amount)
        {
            try
            {
                await _transferWriteOnlyRepository.UpdateBalance(campaignId, Amount);
            }
            catch
            {
                throw new ErrorOnTransferException();
            }
        }
    }
}
