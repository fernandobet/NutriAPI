using Nutri.Application.Contracts.Persistence;
using Nutri.Application.Features.Patients.Queries.GetPatientConsult;
using Nutri.Domain.Models;
using Nutri.Infrastructure.Persistence;

namespace Nutri.Infrastructure.Repositories
{
    public class PatientsRepository:RepositoryBase<Paciente>,IPatientsRepository
    {
        public PatientsRepository(NutriAppContext context):base(context)
        {

        }

        public async Task<GetPatientConsultVm> GetPatientConsult(int id)
        {
            return new GetPatientConsultVm();
        }
    }
}
