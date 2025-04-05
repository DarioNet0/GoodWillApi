
using System.Runtime.CompilerServices;

namespace GoodWill.Exception.ExceptionBase
{
    public class ErrorOnValidationException : GoodWillException
    {
        private readonly List<string> _errors;
        public ErrorOnValidationException(List<string> errorMessages) : base(string.Empty)
        {
            _errors = errorMessages;
        }

        public override int StatusCode => 400;

        public override List<string> GetErrors()
        {
            return _errors;
        }
    }
}
