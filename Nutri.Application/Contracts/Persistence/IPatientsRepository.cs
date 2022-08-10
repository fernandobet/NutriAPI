using Nutri.Application.DTO.Patiients;
using Nutri.Domain.Models;

namespace Nutri.Application.Contracts.Persistence
{
    public interface IPatientsRepository:IAsyncRepository<Paciente> 
    {
        Task<IEnumerable<ConsultaPaciente>> GetAllHistory(int idPaciente);
        Task<GetPatientConsultDTO> GetPatientConsult(int id);
    }
}
