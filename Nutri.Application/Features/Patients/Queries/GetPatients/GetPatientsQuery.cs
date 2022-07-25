using MediatR;
using Nutri.Domain.Models;

namespace Nutri.Application.Features.Patients.Queries.GetPatients
{
    public class GetPatientsQuery:IRequest<IEnumerable<Paciente>>
    {
    }
}
