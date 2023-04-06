using MediatR;
using Microsoft.AspNetCore.Mvc;
using Nutri.Application.Features.Mediciones.Commands.DeleteMedicion;
using Nutri.Application.Features.Mediciones.Commands.SaveMedicion;
using Nutri.Application.Features.Mediciones.Queries.GetMediciones;
using Nutri.Domain.Models;
using System.Security.Policy;

namespace NutriAPI.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class MedicionController:ControllerBase
    {
        private readonly IMediator _mediator;

        public MedicionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<ActionResult<List<MedicionAlimento>>> GetAll()
        {
            var data = await _mediator.Send(new GetMedicionQuery());
            return Ok(data);
        }
        [HttpPost]
        [Route("SaveMedicion")]
        public async Task<IActionResult> SaveMedicion(MedicionAlimento entity)
        {
            await _mediator.Send(new SaveMedicionCommand { 
                Id = entity.Id,
                Abreviacion= entity.Abreviacion,
                Descripcion = entity.Descripcion,
            });
            return Ok();
        }
        [HttpDelete]
        [Route("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var command= new DeleteMedicionCommand { Id = id };
            await _mediator.Send(command);
            return Ok();
        }
    }
}
