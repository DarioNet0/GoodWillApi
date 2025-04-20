using FluentValidation;
using GoodWill.Application.UseCases.User.Create;
using GoodWill.Communication.Requests.User;

namespace GoodWill.Application.UseCases.User
{
    public class UserValidator : AbstractValidator<RequestUserJson>
    {
        public UserValidator()
        {
            RuleFor(user => user.Cpf).MinimumLength(11).WithMessage("TESTE 1");

            RuleFor(user => user.Name).NotEmpty().WithMessage("TESTE");

            RuleFor(user => user.Email).EmailAddress().WithMessage("TESTE");
            RuleFor(user => user.Email).NotEmpty().WithMessage("TESTE");

            RuleFor(user => user.BirthDate).NotEmpty().WithMessage("TESTE");
            RuleFor(user => user.BirthDate).LessThan(DateTime.UtcNow).WithMessage("TESTE");

            RuleFor(user => user.Password).SetValidator(new PasswordValidator<RequestUserJson>());
        }
    }
}
