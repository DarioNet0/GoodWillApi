
using System.Net;

namespace GoodWill.Exception.ExceptionBase
{
    public class NotFoundException : GoodWillException
    {
        public override int StatusCode => (int)HttpStatusCode.NotFound;

        public override List<string> GetErrors()
        {
            throw new NotImplementedException();
        }
        public NotFoundException() : base(ResourceErrorMessages.CAMPAIGN_NOT_FOUND)
        {

        }
    }
}
