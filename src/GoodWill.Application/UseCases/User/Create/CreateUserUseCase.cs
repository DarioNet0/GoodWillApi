using AutoMapper;
using GoodWill.Communication.Requests;
using GoodWill.Communication.Responses;
using GoodWill.Domain;
using GoodWill.Domain.Repositories.User;
using GoodWill.Domain.Security.Cryptography;
using GoodWill.Domain.Security.Token;
using GoodWill.Exception;
using GoodWill.Exception.ExceptionBase;
using System.Runtime.CompilerServices;

namespace GoodWill.Application.UseCases.User.Create
{
    public class CreateUserUseCase : ICreateUserUseCase
    {
        private readonly IUnityOfWork _unityOfWork;
        private readonly IUserWriteOnlyRepository _userWriteOnlyRepository;
        private readonly IMapper _mappper;
        private readonly IUserReadOnlyRepository _userReadOnlyRepository;
        private readonly IPasswordEncrypter _passwordEncrypter;
        private readonly IAccessTokenGenerator _tokenGenerator;
        public CreateUserUseCase(
            IUnityOfWork unityOfWork,
            IUserWriteOnlyRepository userWriteOnlyRepository,
            IMapper mapper,
            IUserReadOnlyRepository userReadOnlyRepository,
            IPasswordEncrypter passwordEncrypter,
            IAccessTokenGenerator tokenGenerator)
        {
            _mappper = mapper;
            _unityOfWork = unityOfWork;
            _userWriteOnlyRepository = userWriteOnlyRepository;
            _userReadOnlyRepository = userReadOnlyRepository;
            _passwordEncrypter = passwordEncrypter;
            _tokenGenerator = tokenGenerator;   
        }
        public async Task<ResponseUserJson> Execute(RequestUserJson request)
        {
            await Validate(request);

            var user = _mappper.Map<Domain.Entities.User>(request);
            var encriptedPassword = user.Password = _passwordEncrypter.Encrypt(request.Password);

            await _userWriteOnlyRepository.AddUser(user);

            await _unityOfWork.Commit();

            return new ResponseUserJson
            {
                Name = request.Name,
                Token = _tokenGenerator.GenerateToken(user)
            };
        }
        private async Task Validate(RequestUserJson request)
        {
            var validator = new UserValidator();

            var result = validator.Validate(request);

            var emailAlreadyActive = await _userReadOnlyRepository.VerifyEmailDisponibility(request.Email);

            if (emailAlreadyActive)
            {
                result.Errors.Add(new FluentValidation.Results.ValidationFailure(string.Empty, ResourceErrorMessages.EMAIL_ALREADY_EXISITS));
            }

            if (result.IsValid == false)
            {
                var errorMessages = result.Errors.Select(error => error.ErrorMessage).ToList();

                throw new ErrorOnValidationException(errorMessages);
            }
        }
    }
}
