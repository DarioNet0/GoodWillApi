using GoodWill.Communication.Requests.Transfer;
using Microsoft.AspNetCore.Mvc;

namespace GoodWill.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransferController : ControllerBase
    {
        public async Task<IActionResult> MakeTransfer(
            [FromBody] RequestMakeTransferJson request)
        {

        }
    }
}
