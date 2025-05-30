using GoodWill.Application.UseCases.Transfer;
using GoodWill.Communication.Requests.Transfer;
using Microsoft.AspNetCore.Mvc;

namespace GoodWill.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransferController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> MakeTransfer(
            [FromBody] RequestMakeTransferJson request,
            [FromServices] IMakeTransferUseCase useCase)
        {
            var response = await useCase.Execute(request);

            return Ok(response);
        }
    }
}
