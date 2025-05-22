
using System.Net;

namespace GoodWill.Exception.ExceptionBase
{
    public class ForbidException : GoodWillException
    {
        public override int StatusCode => (int)HttpStatusCode.Forbidden;

        public override List<string> GetErrors()
        {
            throw new NotImplementedException();
        }
        public ForbidException() : base(ResourceErrorMessages.ACCESS_DENIED)
        {

        }
    }
}
