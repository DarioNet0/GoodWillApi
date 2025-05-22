using FluentValidation;
using GoodWill.Communication.Requests.Campaign;
using GoodWill.Exception;

namespace GoodWill.Application.Validators
{
    public class CampaignValidator : AbstractValidator<RequestCreateCampaignJson>
    {
        public CampaignValidator()
        {
            RuleFor(campaign => campaign.Title)
                .NotEmpty().WithMessage(ResourceErrorMessages.TITLE_EMPTY);
            RuleFor(campaign => campaign.Description)
                .NotEmpty().WithMessage(ResourceErrorMessages.DESCRIPTION_EMPTY);
            RuleFor(campaign => campaign.TargetValue)
                .GreaterThan(0).WithMessage(ResourceErrorMessages.TAGET_VALUE_MUST_BE_GREATER_THAN_ZERO);
        }
    }
}
