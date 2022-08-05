using MediatR;
using Microsoft.AspNetCore.Mvc;
using Nutri.Application.Features.Suplements.Commands.AddCustomList;
using Nutri.Application.Features.Suplements.Commands.AddSuplement;
using Nutri.Application.Features.Suplements.Queries.GetMedition;
using Nutri.Application.Features.Suplements.Queries.GetSuplementsCustomList;
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
    }
}
