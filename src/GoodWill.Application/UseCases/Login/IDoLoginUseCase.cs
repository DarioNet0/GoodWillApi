using GoodWill.Communication.Requests;
using GoodWill.Communication.Responses;
using GoodWill.Communication.Responses.User;

namespace GoodWill.Application.UseCases.Login
{
    public interface IDoLoginUseCase
    {
        Task<ResponseUserJson> Execute(RequestLoginJson request);
    }
}
