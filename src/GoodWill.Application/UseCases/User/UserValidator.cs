using FluentValidation;
using GoodWill.Application.UseCases.User.Create;
using GoodWill.Communication.Requests;

namespace GoodWill.Application.UseCases.User
{
    public class UserValidator : AbstractValidator<RequestUserJson>
    {
        public UserValidator()
        {
            RuleFor(user => user.Cpf).MinimumLength(11).WithMessage("");

            RuleFor(user => user.Name).NotEmpty().WithMessage("");

            RuleFor(user => user.Email).EmailAddress().WithMessage("");
            RuleFor(user => user.Email).NotEmpty().WithMessage("");

            RuleFor(user => user.BirthDate).NotEmpty().WithMessage("");
            RuleFor(user => user.BirthDate).LessThan(DateTime.UtcNow).WithMessage("");

            RuleFor(user => user.Password).SetValidator(new PasswordValidator<RequestUserJson>());
        }
    }
}
