using FluentValidation;
using GoodWill.Communication.Requests.Transfer;
using GoodWill.Exception;

namespace GoodWill.Application.Validators
{
    public class CreditCardValidator : AbstractValidator<RequestCreditCardTransferJson>
    {
        public CreditCardValidator()
        {
            RuleFor(c => c.CardHolderName)
                .NotEmpty().WithMessage("O nome do titular do cartão não pode estar vazio");

            RuleFor(c => c.CardNumber.ToString())
                .Length(13, 19).WithMessage("Número de cartão inválido")
                .Must(BeValidCardNumber).WithMessage("Número de cartão inválido");

            RuleFor(c => c.ExpirationDate)
                .Must(BeValidExpirationDate).WithMessage("Data de expiração inválida");

            RuleFor(c => c.ExpirationDate)
                .Must(NotBeExpired).WithMessage("Cartão expirado");

            RuleFor(c => c.Cvv.ToString())
                .Length(3, 4).WithMessage("Código de segurança (CVV) inválido");

            RuleFor(c => c.Amount)
                .GreaterThan(0).WithMessage(ResourceErrorMessages.AMOUNT_MUST_BE_GREATER_THAN_ZERO);
        }

        private bool BeValidCardNumber(string cardNumber)
        {
            return !string.IsNullOrWhiteSpace(cardNumber) && cardNumber.All(char.IsDigit);
        }

        private bool BeValidExpirationDate(DateTime expirationDate)
        {
            int month = expirationDate.Month;
            return month >= 1 && month <= 12;
        }

        private bool NotBeExpired(DateTime expirationDate)
        {
            var lastDayOfExpirationMonth = new DateTime(
                expirationDate.Year,
                expirationDate.Month,
                DateTime.DaysInMonth(expirationDate.Year, expirationDate.Month),
                23, 59, 59);

            return lastDayOfExpirationMonth >= DateTime.Today;
        }
    }
}
