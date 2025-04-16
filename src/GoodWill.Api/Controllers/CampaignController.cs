using GoodWill.Application.UseCases.Campaigns.Create;
using GoodWill.Application.UseCases.Campaigns.List;
using GoodWill.Application.UseCases.Campaigns.ListById;
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

        [HttpGet]
        public async Task<IActionResult> GetAll(
            [FromServices] IListAllCampaignUseCase useCase)
        {
            var response = await useCase.Execute();
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetById(
        [FromRoute] long searchCampaignId,
        [FromServices] IListByIdCampaignUseCase useCase)
        {
            var response = await useCase.Execute(searchCampaignId);
            return Ok(response);
        }
    }


}
