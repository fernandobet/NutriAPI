using Nutri.Application.Contracts.Persistence;
using Nutri.Domain.Models;
using Nutri.Infrastructure.Persistence;
using Utils;

namespace Nutri.Infrastructure.Repositories
{
    public class UsersRepository:RepositoryBase<Usuario>,IUsersRepository
    {
        public UsersRepository(NutriAppContext context):base(context)
        {
        }

        public Usuario iniciarSesion(Usuario usuario)
        {
            try
            {
                var crypt = Encrypt.GetSHA256(usuario.Password);
                var existe = _context.Usuarios!.FirstOrDefault(x=>x.Email == usuario.Email && x.Password == crypt);
                if (existe == null)
                    throw new Exception("Usuario ó Contraseña incorrectos.");
                return existe;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
