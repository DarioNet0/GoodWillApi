using AutoMapper;
using GoodWill.Communication.Requests;
using GoodWill.Communication.Responses;
using GoodWill.Domain;
using GoodWill.Domain.Repositories.User;
using GoodWill.Exception.ExceptionBase;
using System.Runtime.CompilerServices;

namespace GoodWill.Application.UseCases.User.Create
{
    public class CreateUserUseCase : ICreateUserUseCase
    {
        private readonly IUnityOfWork _unityOfWork;
        private readonly IUserWriteOnlyRepository _userWriteOnlyRepository;
        private readonly IMapper _mappper;
        public CreateUserUseCase(
            IUnityOfWork unityOfWork,
            IUserWriteOnlyRepository userWriteOnlyRepository,
            IMapper mapper)
        {
            _mappper = mapper;
            _unityOfWork = unityOfWork;
            _userWriteOnlyRepository = userWriteOnlyRepository;
        }
        public Task<ResponseUserJson> Execute(RequestUserJson request)
        {
            Validate(request);
        }
        private void Validate(RequestUserJson request)
        {
            var validator = new UserValidator();

            var result = validator.Validate(request);

            if (result.IsValid == false)
            {

                var errorMessages = result.Errors.Select(error => error.ErrorMessage).ToList();

                throw new ErrorOnValidationException(errorMessages);
            }
        }
    }
}
