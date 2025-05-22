using Microsoft.AspNetCore.Mvc;

namespace GoodWill.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransferController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> MakeTransfer()
        {
            return Ok();
        }
    }
}
