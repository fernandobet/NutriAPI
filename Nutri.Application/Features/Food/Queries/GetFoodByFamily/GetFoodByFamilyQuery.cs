using MediatR;
using Nutri.Domain.Models;

namespace Nutri.Application.Features.Food.Queries.GetFamiliesFood
{
    public class GetFoodByFamilyQuery:IRequest<IEnumerable<Alimento>>
    {
        public int IdFamily { get; set; }
    }
}
