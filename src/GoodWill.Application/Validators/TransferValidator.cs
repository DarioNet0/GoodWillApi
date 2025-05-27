using FluentValidation;
using GoodWill.Communication.Requests.Transfer;
using GoodWill.Exception;

namespace GoodWill.Application.Validators
{
    public class TransferValidator : AbstractValidator<RequestMakeTransferJson>
    {
        public TransferValidator()
        {
            RuleFor(t => t.TransferType).IsInEnum().WithMessage(ResourceErrorMessages.INVALID_TRANSFER_TYPE);
            RuleFor(t => t.Amount).GreaterThan(0).WithMessage(ResourceErrorMessages.AMOUNT_MUST_BE_GREATER_THAN_ZERO);
        }
    }
}
