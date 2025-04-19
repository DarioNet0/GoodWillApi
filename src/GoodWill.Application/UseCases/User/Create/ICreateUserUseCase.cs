using GoodWill.Communication.Requests.User;
using GoodWill.Communication.Responses.User;

namespace GoodWill.Application.UseCases.User.Create
{
    public interface ICreateUserUseCase
    {
        Task<ResponseUserJson> Execute(RequestUserJson request);
    }
}
