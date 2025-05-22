using GoodWill.Application.UseCases.Campaigns.Create;
using GoodWill.Application.UseCases.Campaigns.Delete;
using GoodWill.Application.UseCases.Campaigns.List;
using GoodWill.Application.UseCases.Campaigns.ListById;
using GoodWill.Application.UseCases.Campaigns.Update;
using GoodWill.Communication.Requests.Campaign;
using GoodWill.Communication.Responses.Campaign;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace GoodWill.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CampaignController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(typeof(ResponseListCampaignJson), StatusCodes.Status201Created)]
        public async Task<IActionResult> Create(
            [FromBody] RequestCreateCampaignJson request,
            [FromServices] ICreateCampaignUseCase useCase)
        {
            var response = await useCase.Execute(request);

            return Created(string.Empty, response);
        }

        [HttpGet]
        [ProducesResponseType(typeof(ResponseListCampaignJson), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll(
            [FromServices] IListAllCampaignUseCase useCase)
        {
            var response = await useCase.Execute();
            return Ok(response);
        }

        [HttpGet]
        [Route("{searchCampaignId}")]
        [ProducesResponseType(typeof(ResponseListCampaignJson), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetById(
        [FromRoute] long searchCampaignId,
        [FromServices] IListByIdCampaignUseCase useCase)
        {
            var response = await useCase.Execute(searchCampaignId);
            return Ok(response);
        }

        [HttpDelete]
        [Route("{searchCampaignId}")]
        public async Task<IActionResult> Delete(
            [FromRoute] long searchCampaignId,
            [FromServices] IDeleteCampaignUseCase useCase)
        {
            await useCase.Execute(searchCampaignId);
            return NoContent();
        }

        [HttpPut]
        [Route("{searchCampaignId}")]
        public IActionResult Edit(
            [FromRoute] long searchCampaignId,
            [FromBody] RequestCreateCampaignJson updatedCampaign,
            [FromServices] IEditCampaignUseCase useCase)
        {
            useCase.Execute(searchCampaignId, updatedCampaign);
            return Ok();
        }

    }
}
