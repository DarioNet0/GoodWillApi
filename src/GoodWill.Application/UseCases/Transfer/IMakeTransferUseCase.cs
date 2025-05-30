using GoodWill.Communication.Requests.Transfer;
using GoodWill.Communication.Responses.Transfer;

namespace GoodWill.Application.UseCases.Transfer
{
    public interface IMakeTransferUseCase
    {
        Task<ResponseMakeTransferJson> Execute(RequestMakeTransferJson request);
    }
}
