using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodWill.Domain.Security.Token
{
    public interface ITokenProvider
    {
        string TokenOnRequest();
    }
}
