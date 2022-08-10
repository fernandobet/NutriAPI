using MediatR;
using Microsoft.AspNetCore.Mvc;
using Nutri.Application.DTO.Patiients;
using Nutri.Application.Features.Patients.Commands.DeletePatient;
using Nutri.Application.Features.Patients.Commands.ModifyPatient;
using Nutri.Application.Features.Patients.Commands.SavePatient;
using Nutri.Application.Features.Patients.Commands.SavePatientDiet;
using Nutri.Application.Features.Patients.Queries.GetHistoryPatient;
using Nutri.Application.Features.Patients.Queries.GetPatientConsult;
using Nutri.Application.Features.Patients.Queries.GetPatients;
using Nutri.Domain.Models;
using System.Net;

namespace NutriAPI.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class PatientsController:ControllerBase
    {
        private readonly IMediator _mediator;

        public PatientsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        [Route("SavePatientDiet")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<ActionResult> SavePatientDiet([FromBody] SavePatientDietCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        [HttpGet]
        [Route("consultar")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<IEnumerable<Paciente>>> consultar()
        {
            return Ok( await _mediator.Send(new GetPatientsQuery()));
        }

        [HttpPost]
        [Route("guardar")]
        [ProducesResponseType(((int)HttpStatusCode.OK))]
        public async Task<ActionResult> SavePatient([FromBody] SavePatientCommand patient)
        {
            await _mediator.Send(patient);
            return Ok();
        }
        [HttpDelete]
        [Route("eliminarPaciente")]
        [ProducesResponseType(((int)HttpStatusCode.OK))]
        public async Task<ActionResult> DeletePatient([FromBody] DeletePatientCommand patient)
        {
            await _mediator.Send(patient);
            return Ok();
        }
        [HttpPut]
        [Route("editarPaciente")]
        [ProducesResponseType(((int)HttpStatusCode.OK))]
        public async Task<ActionResult> ModifyPatient([FromBody] ModifyPatientCommand patient)
        {
            await _mediator.Send(patient);
            return Ok();
        }

        [HttpGet]
        [Route("PatientHistory")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<GetHistoryPatientVm> PatientHistory([FromQuery] int idPaciente)
        {
            var patientHistory = await _mediator.Send(new GetHistoryPatientQuery { IdPaciente = idPaciente });
            return patientHistory;
        }

        [HttpGet]
        [Route("InfConsulta")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<GetPatientConsultDTO> InfoConsulta(int idConsulta)
        {
            var consultas = await _mediator.Send(new GetPatientConsultQuery { IdConsulta = idConsulta });
            return consultas;
        }


    }
}
