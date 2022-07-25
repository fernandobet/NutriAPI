
using MediatR;
using Nutri.Domain.Models;

namespace Nutri.Application.Features.Users.Queries.Login
{
    public class LoginQuery:IRequest<Usuario>
    {
        public Usuario User { get; set; }
    }
}
