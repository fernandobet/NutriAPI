using Nutri.Domain.Common;

namespace Nutri.Application.Contracts.Persistence
{
    public interface IUnitOfWork:IDisposable
    {
        public IUsersRepository UserRepository { get; }
        public IPatientsRepository PatientRepository { get; }
        public ISuplementsRepository SuplementsRepository { get; }
        public IFoodRepository FoodRepository { get; }
        IAsyncRepository<TEntity> Repository<TEntity>() where TEntity : BaseDomainModel;
        Task<int> Complete();
    }
}
