
using MediatR;
using Nutri.Domain.Models;

namespace Nutri.Application.Features.Patients.Queries.GetPatient
{
    public class GetPatientQuery:IRequest<Paciente>
    {
        public int Id { get; set; }
    }
}
