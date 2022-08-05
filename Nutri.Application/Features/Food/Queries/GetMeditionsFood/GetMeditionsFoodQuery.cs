using MediatR;
using Nutri.Domain.Models;

namespace Nutri.Application.Features.Food.Queries.GetMeditionsFood
{
    public class GetMeditionsFoodQuery:IRequest<IEnumerable<MedicionAlimento>>
    {
    }
}
