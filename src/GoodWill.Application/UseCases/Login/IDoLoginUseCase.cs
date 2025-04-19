using GoodWill.Communication.Requests;
using GoodWill.Communication.Responses;

namespace GoodWill.Application.UseCases.Login
{
    public interface IDoLoginUseCase
    {
        Task<ResponseUserJson> Execute(RequestLoginJson request);
    }
}
