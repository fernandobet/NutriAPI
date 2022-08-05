using MediatR;
using Nutri.Domain.Models;

namespace Nutri.Application.Features.Suplements.Queries.GetMedition
{
    public class GetMeditionQuery:IRequest<IReadOnlyList<MedicionSuplemento>>
    {
    }
}
