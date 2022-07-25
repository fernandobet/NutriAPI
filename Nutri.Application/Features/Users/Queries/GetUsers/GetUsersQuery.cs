using MediatR;
using Nutri.Domain.Models;

namespace Nutri.Application.Features.Users.Queries.GetUsers
{
    public class GetUsersQuery:IRequest<List<Usuario>>
    {
    }
}
