﻿
using System.Net;

namespace GoodWill.Exception.ExceptionBase
{
    public class InvalidLoginException : GoodWillException
    {
        public override int StatusCode => (int)HttpStatusCode.Unauthorized;

        public override List<string> GetErrors()
        {
            return new List<string> { Message };
        }
        public InvalidLoginException() : base(ResourceErrorMessages.INVALID_LOGIN)
        {

        }
    }
}
