using GoodWill.Communication.Requests.Transfer;

namespace GoodWill.Application.UseCases.Transfer
{
    public interface IMakeTransferUseCase
    {
        Task Execute(RequestMakeTransferJson request);
    }
}
