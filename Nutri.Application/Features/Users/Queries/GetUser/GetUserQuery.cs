using MediatR;
using Nutri.Domain.Models;

namespace Nutri.Application.Features.Users.Queries.GetUser
{
    public class GetUserQuery:IRequest<Usuario>
    {
        public int Id { get; set; }
    }
}
