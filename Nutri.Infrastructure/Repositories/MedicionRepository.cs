using Nutri.Application.Contracts.Persistence;
using Nutri.Domain.Models;
using Nutri.Infrastructure.Persistence;

namespace Nutri.Infrastructure.Repositories
{
    public class MedicionRepository:RepositoryBase<MedicionAlimento>, IMedicionRepository
    {
        private NutriAppContext _context;
        public MedicionRepository(NutriAppContext context) :base(context)
        {
            _context= context;
        }
    }
}
