using GoodWill.Application.Validators;
using GoodWill.Communication.Requests.Transfer;
using GoodWill.Domain.Services.LoggedUsers;
using GoodWill.Exception.ExceptionBase;
using System.Runtime.InteropServices;

namespace GoodWill.Application.UseCases.Transfer
{
    public class MakeTransferUseCase : IMakeTransferUseCase
    {
        private readonly ILoggedUsers _loggedUsers;
        public MakeTransferUseCase(
            ILoggedUsers loggedUsers)
        {
            _loggedUsers = loggedUsers;
        }
        public Task Execute(RequestMakeTransferJson request)
        {
            Validate(request);


            throw new NotImplementedException();
        }
        private void Validate(RequestMakeTransferJson request)
        {
            var validator = new TransferValidator();

            var result = validator.Validate(request);

            if (result.IsValid == false)
            {
                var errorsMessages = result.Errors.Select(ex => ex.ErrorMessage).ToList();

                throw new ErrorOnValidationException(errorsMessages);
            }


        }
    }
}
