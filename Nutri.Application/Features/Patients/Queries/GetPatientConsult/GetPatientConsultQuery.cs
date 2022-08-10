using MediatR;
using Nutri.Application.DTO.Patiients;

namespace Nutri.Application.Features.Patients.Queries.GetPatientConsult
{
    public class GetPatientConsultQuery:IRequest<GetPatientConsultDTO>
    {
        public int IdConsulta { get; set; }
    }
}
