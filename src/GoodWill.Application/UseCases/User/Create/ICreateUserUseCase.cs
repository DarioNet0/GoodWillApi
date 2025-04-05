using GoodWill.Communication.Requests;
using GoodWill.Communication.Responses;

namespace GoodWill.Application.UseCases.User.Create
{
    public interface ICreateUserUseCase
    {
        Task<ResponseUserJson> Execute(RequestUserJson request);
    }
}
