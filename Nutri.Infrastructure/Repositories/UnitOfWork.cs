
using Nutri.Application.Contracts.Persistence;
using Nutri.Domain.Common;
using Nutri.Infrastructure.Persistence;
using System.Collections;

namespace Nutri.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private Hashtable _repositories;
        private readonly NutriAppContext _context;
        private IUsersRepository _usersRepository;
        public IPatientsRepository _patientRepository;

        public IPatientsRepository PatientRepository => _patientRepository ?? new PatientsRepository(_context);
        public IUsersRepository UserRepository => _usersRepository ?? new UsersRepository(_context);

        public UnitOfWork(NutriAppContext context)
        {
            _context = context;
        }

        public async Task<int> Complete()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public IAsyncRepository<TEntity> Repository<TEntity>() where TEntity : BaseDomainModel
        {
            if (_repositories == null)
            {
                _repositories = new Hashtable();
            }
            var type = typeof(TEntity).Name;
            if (!_repositories.ContainsKey(type))
            {
                var repositoryType = typeof(RepositoryBase<>);
                var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(TEntity)), _context);
                _repositories.Add(type, repositoryInstance);
            }
            return (IAsyncRepository<TEntity>)_repositories[type];
        }
    }
}
