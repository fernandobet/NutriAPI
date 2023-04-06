using MediatR;
using Nutri.Domain.Models;

namespace Nutri.Application.Features.Mediciones.Queries.GetMediciones
{
    public class GetMedicionQuery:IRequest<List<MedicionAlimento>>
    {
    }
}
