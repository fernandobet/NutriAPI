using MediatR;
using Nutri.Domain.Models;

namespace Nutri.Application.Features.Food.Queries.GetFamilies
{
    public class GetFamiliesFoodQuery:IRequest<IEnumerable<FamiliaAlimento>>
    {
    }
}
