using MediatR;

namespace Nutri.Application.Features.Patients.Queries.GetHistoryPatient
{
    public class GetHistoryPatientQuery:IRequest<GetHistoryPatientVm>
    {
        public int IdPaciente { get; set; }
    }
}
