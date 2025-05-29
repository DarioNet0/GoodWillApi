using GoodWill.Application.Validators;
using GoodWill.Communication.Requests.Transfer;
using GoodWill.Domain.Repositories.Campaign;
using GoodWill.Domain.Services.LoggedUsers;
using GoodWill.Exception.ExceptionBase;

namespace GoodWill.Application.UseCases.Transfer
{
    public class MakeTransferUseCase : IMakeTransferUseCase
    {
        private readonly ICampaignReadOnlyRespository _campaignReadOnlyRespository;
        private readonly ILoggedUsers _loggedUsers;
        public MakeTransferUseCase(
            ILoggedUsers loggedUsers,
            ICampaignReadOnlyRespository campaignReadOnlyRespository)
        {
            _loggedUsers = loggedUsers;
            _campaignReadOnlyRespository = campaignReadOnlyRespository;
        }
        public async Task Execute(RequestMakeTransferJson request)
        {
            ValidateRequest(request);

            await ValidateCampaing(request.CampaignId);



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
        private async Task ValidateCampaing(long campaignId)
        {
            var campaign = await _campaignReadOnlyRespository.GetById(campaignId);

            if (campaign is null)
            {
                throw new NotFoundException();
            }
        }
    }
}
