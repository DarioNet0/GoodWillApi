using GoodWill.Application.UseCases.Campaigns.Create;
using GoodWill.Communication.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GoodWill.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CampaignController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Create(
            [FromBody] RequestCreateCampaignJson request,
            [FromServices] ICreateCampaignUseCase useCase)
        {
            var response = await useCase.Execute(request);

            return Created(string.Empty, response);
        }
    }
}
