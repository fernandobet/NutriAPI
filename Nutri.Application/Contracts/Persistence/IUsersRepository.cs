using Nutri.Domain.Models;

namespace Nutri.Application.Contracts.Persistence
{
    public interface IUsersRepository:IAsyncRepository<Usuario>
    {
        Usuario iniciarSesion(Usuario usuario);
    }
}
