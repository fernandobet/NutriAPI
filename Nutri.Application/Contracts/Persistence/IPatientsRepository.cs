using Nutri.Application.Features.Patients.Queries.GetPatientConsult;
using Nutri.Domain.DTOS;
using Nutri.Domain.Models;

namespace Nutri.Application.Contracts.Persistence
{
    public interface IPatientsRepository:IAsyncRepository<Paciente> 
    {
        Task<GetPatientConsultVm> GetPatientConsult(int id);
    }
}
