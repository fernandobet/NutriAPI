using MediatR;
using Nutri.Domain.Models;

namespace Nutri.Application.Features.Food.Queries.GetFoodList
{
    public class GetFoodListQuery : IRequest<IEnumerable<Alimento>>
    {
    }
}
