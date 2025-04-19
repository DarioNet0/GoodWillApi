using GoodWill.Application.UseCases.Login;
using GoodWill.Communication.Requests;
using GoodWill.Communication.Responses;
using Microsoft.AspNetCore.Mvc;

namespace GoodWill.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(typeof(ResponseUserJson), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Login(
            [FromBody] RequestLoginJson request,
            [FromServices] IDoLoginUseCase useCase)
        {
            var response = await useCase.Execute(request);

            return Ok(response);
        }
    }
}
