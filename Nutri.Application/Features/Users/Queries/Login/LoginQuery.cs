
using MediatR;
using Nutri.Domain.Models;

namespace Nutri.Application.Features.Users.Queries.Login
{
    public class LoginQuery:IRequest<Usuario>
    {
        public string UserName { get; set; } = string.Empty;    
        public string PassWord { get; set; } = string.Empty ;
    }
}
