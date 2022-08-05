using MediatR;
using Nutri.Domain.Models;

namespace Nutri.Application.Features.Food.Queries.GetFamilyFood
{
    public class GetFamilyFoodQuery:IRequest<FamiliaAlimento>
    {
        public int Id { get; set; }
    }
}
