using Nutri.Application.Contracts.Persistence;
using Nutri.Domain.Models;
using Nutri.Infrastructure.Persistence;

namespace Nutri.Infrastructure.Repositories
{
    public class FoodRepository: RepositoryBase<Alimento>, IFoodRepository
    {
        protected readonly NutriAppContext _context;

        public FoodRepository(NutriAppContext context):base(context)
        {
            _context = context;
        }
    }
}
