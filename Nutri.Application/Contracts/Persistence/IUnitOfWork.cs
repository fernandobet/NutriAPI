using Nutri.Domain.Common;

namespace Nutri.Application.Contracts.Persistence
{
    public interface IUnitOfWork:IDisposable
    {
        public IUsersRepository UserRepository { get; }
        public IPatientsRepository PatientRepository { get; }

        IAsyncRepository<TEntity> Repository<TEntity>() where TEntity : BaseDomainModel;
        Task<int> Complete();
    }
}
