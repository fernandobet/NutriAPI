using MediatR;

namespace Nutri.Application.Features.Patients.Queries.GetPatientConsult
{
    public class GetPatientConsultQuery:IRequest<GetPatientConsultVm>
    {
        public int IdConsulta { get; set; }
    }
}
