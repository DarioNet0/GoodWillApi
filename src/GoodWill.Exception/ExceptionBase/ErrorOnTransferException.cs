
using System.Net;

namespace GoodWill.Exception.ExceptionBase
{
    public class ErrorOnTransferException : GoodWillException
    {
        public override int StatusCode => (int)HttpStatusCode.InternalServerError;

        public ErrorOnTransferException() : base(ResourceErrorMessages.TRANSFER_ERROR)
        {

        }

        public override List<string> GetErrors()
        {
            return new List<string>();
        }
    }
}
