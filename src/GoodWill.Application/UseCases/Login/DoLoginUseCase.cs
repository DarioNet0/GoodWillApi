using GoodWill.Communication.Requests;
using GoodWill.Communication.Responses;
using GoodWill.Domain.Repositories.User;
using GoodWill.Domain.Security.Cryptography;
using GoodWill.Domain.Security.Token;
using GoodWill.Exception.ExceptionBase;

namespace GoodWill.Application.UseCases.Login
{
    public class DoLoginUseCase : IDoLoginUseCase
    {
        private readonly IUserReadOnlyRepository _userReadOnlyRepository;
        private readonly IAccessTokenGenerator _tokenGenerator;
        private readonly IPasswordEncrypter _passwordEncrypter; 
        public DoLoginUseCase(
            IUserReadOnlyRepository userReadOnlyRepository,
            IAccessTokenGenerator tokenGenerator,
            IPasswordEncrypter passwordEncrypter)
        {
            _tokenGenerator = tokenGenerator;   
            _userReadOnlyRepository = userReadOnlyRepository;
            _passwordEncrypter = passwordEncrypter;
            
        }
        public async Task<ResponseUserJson> Execute(RequestLoginJson request)
        {
            var user = await _userReadOnlyRepository.GetUserByEmail(request.Email);

            if (user is null)
            {
                throw new InvalidLoginException();
            }

            var passwordMatch = _passwordEncrypter.verify(request.Password, user.Password);

            if (passwordMatch == false)
            {
                throw new InvalidLoginException();
            }

            return new ResponseUserJson
            {
                Name = user.Name,
                Token = _tokenGenerator.GenerateToken(user)
            };
        }
    }
}
