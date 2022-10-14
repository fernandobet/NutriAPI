using MediatR;
using Microsoft.AspNetCore.Mvc;
using Nutri.Application.Features.Suplements.Commands.AddCustomList;
using Nutri.Application.Features.Suplements.Commands.AddSuplement;
using Nutri.Application.Features.Suplements.Commands.DeleteSuplement;
using Nutri.Application.Features.Suplements.Commands.DeleteSuplementList;
using Nutri.Application.Features.Suplements.Commands.EditCustomSuplementList;
using Nutri.Application.Features.Suplements.Commands.EditSuplement;
using Nutri.Application.Features.Suplements.Queries.GetMedition;
using Nutri.Application.Features.Suplements.Queries.GetSuplementsCustomList;
using Nutri.Application.Features.Suplements.Queries.GetSuplementsCustomListDetail;
using Nutri.Application.Features.Suplements.Queries.GetSuplementsMedition;
using Nutri.Domain.Models;
using System.Net;

namespace NutriAPI.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class SuplementsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SuplementsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        [Route("GetSuplementsCustomListDetail/{id}")]
        public async Task<ActionResult> GetSuplementsCustomListDetail(int id)
        {
            var query = new GetSuplementsCustomListDetailQuery { Id = id };
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet]
        [Route("GetSuplementsCustomList")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<List<GetSuplementsCustomListVm>>> GetSuplementsCustomList() {
            var result = await _mediator.Send(new GetSuplementsCustomListQuery());
            return Ok(result);
        }
        [HttpGet]
        [Route("GetSuplementsMedition")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<List<GetSuplementsMeditionVm>>> GetSuplementsMedition()
        {
            var result = await _mediator.Send(new GetSuplementsMeditionQuery());
            return Ok(result);
        }
        [HttpGet]
        [Route("GetMeditions")]
        public async Task<ActionResult<IReadOnlyList<MedicionSuplemento>>> GetMeditions()
        {
            var result = await _mediator.Send(new GetMeditionQuery());
            return Ok(result);
        }

        [HttpPost]
        [Route("EditSuplementsCustomList")]
        public async Task<ActionResult> EditSuplementsCustomList([FromBody] EditCustomSuplementListCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }
        [HttpDelete]
        [Route("DeleteSuplementsCustomList/{id}")]
        public async Task<ActionResult> DeleteSuplementsCustomList(int id)
        {
            var command = new DeleteSuplementListCommand { Id = id };
            await _mediator.Send(command);
            return Ok();
        }
        [HttpPost]
        [Route("AddCustomList")]
        public async Task<ActionResult> AddCustomList([FromBody] AddCustomListCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }
        [HttpPost]
        [Route("SaveSuplement")]
        public async Task<ActionResult> SaveSuplement([FromBody] AddSuplementCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }
        [HttpPut]
        [Route("EditSuplement")]
        public async Task<ActionResult> EditSuplement([FromBody] EditSuplementCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }
        [HttpDelete]
        [Route("DeleteSuplement/{id}")]
        public async Task<ActionResult> EditSuplement(int id)
        {
            var command = new DeleteSuplementCommand { Id = id };
            await _mediator.Send(command);
            return Ok();
        }
    }
}
