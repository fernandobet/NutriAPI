using MediatR;

namespace Nutri.Application.Features.Suplements.Queries.GetSuplementsCustomListDetail
{
    public class GetSuplementsCustomListDetailQuery:IRequest<List<string>>
    {
        public int Id { get; set; }
    }
}
