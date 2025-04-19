using GoodWill.Application.UseCases.User.Create;
using GoodWill.Communication.Requests;
using GoodWill.Communication.Responses;
using Microsoft.AspNetCore.Mvc;

namespace GoodWill.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(typeof(ResponseUserJson), StatusCodes.Status201Created)]
        public async Task<IActionResult> Create(
            [FromBody] RequestUserJson request,
            [FromServices] ICreateUserUseCase useCase)
        {
            var response = await useCase.Execute(request);

            return Created(string.Empty, response); 
        }
    }
}
