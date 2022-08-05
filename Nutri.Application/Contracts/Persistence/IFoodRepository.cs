using Nutri.Domain.Models;

namespace Nutri.Application.Contracts.Persistence
{
    public interface IFoodRepository:IAsyncRepository<Alimento>
    {
    }
}
