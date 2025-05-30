using FluentValidation;
using GoodWill.Application.UseCases.User.Create;
using GoodWill.Communication.Requests.User;
using GoodWill.Exception;

namespace GoodWill.Application.Validators
{
    public class UserValidator : AbstractValidator<RequestUserJson>
    {
        public UserValidator()
        {
            RuleFor(user => user.Cpf).MinimumLength(11).WithMessage(ResourceErrorMessages.INVALID_CPF);

            RuleFor(user => user.Name).NotEmpty().WithMessage(ResourceErrorMessages.INVALID_NAME);

            RuleFor(user => user.Email).EmailAddress().WithMessage(ResourceErrorMessages.INVALID_EMAIL);
            RuleFor(user => user.Email).NotEmpty().WithMessage(ResourceErrorMessages.EMPTY_EMAIL);

            RuleFor(user => user.BirthDate).NotEmpty().WithMessage(ResourceErrorMessages.EMPTY_BIRTHDATE);
            RuleFor(user => user.BirthDate).LessThan(DateTime.UtcNow).WithMessage(ResourceErrorMessages.FUTURE_BIRTH_DATE);

            RuleFor(user => user.Password).SetValidator(new PasswordValidator<RequestUserJson>());
        }
    }
}
