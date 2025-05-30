using FluentValidation;
using FluentValidation.Validators;
using GoodWill.Exception;
using System.Text.RegularExpressions;

namespace GoodWill.Application.UseCases.User.Create
{
    public class PasswordValidator<T> : PropertyValidator<T, string>
    {
        private const string ERROR_MESSAGE_KEY = "ErrorMessage";

        private static readonly Regex UpperCaseLetter = new(@"[A-Z]+", RegexOptions.Compiled);
        private static readonly Regex LowerCaseLetter = new(@"[a-z]+", RegexOptions.Compiled);
        private static readonly Regex Numbers = new(@"[0-9]+", RegexOptions.Compiled);
        private static readonly Regex SpecialSymbols = new(@"[\!\?\*\.\@]+", RegexOptions.Compiled);

        public override string Name => "PassWordValidator";

        protected override string GetDefaultMessageTemplate(string errorCode)
        {
            return $"{{{ERROR_MESSAGE_KEY}}}";
        }

        public override bool IsValid(ValidationContext<T> context, string password)
        {
            if (string.IsNullOrWhiteSpace(password))
            {
                context.MessageFormatter.AppendArgument(ERROR_MESSAGE_KEY, ResourceErrorMessages.INVALID_PASSWORD);
                return false;
            }

            if (password.Length < 8)
            {
                context.MessageFormatter.AppendArgument(ERROR_MESSAGE_KEY, ResourceErrorMessages.INVALID_PASSWORD);
                return false;
            }

            if (!UpperCaseLetter.IsMatch(password))
            {
                context.MessageFormatter.AppendArgument(ERROR_MESSAGE_KEY, ResourceErrorMessages.INVALID_PASSWORD);
                return false;
            }

            if (!LowerCaseLetter.IsMatch(password))
            {
                context.MessageFormatter.AppendArgument(ERROR_MESSAGE_KEY, ResourceErrorMessages.INVALID_PASSWORD);
                return false;
            }

            if (!Numbers.IsMatch(password))
            {
                context.MessageFormatter.AppendArgument(ERROR_MESSAGE_KEY, ResourceErrorMessages.INVALID_PASSWORD);
                return false;
            }

            if (!SpecialSymbols.IsMatch(password))
            {
                context.MessageFormatter.AppendArgument(ERROR_MESSAGE_KEY, ResourceErrorMessages.INVALID_PASSWORD);
                return false;
            }

            return true;
        }
    }
}
