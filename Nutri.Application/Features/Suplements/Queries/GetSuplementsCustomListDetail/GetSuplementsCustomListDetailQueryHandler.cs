using MediatR;
using Nutri.Application.Contracts.Persistence;

namespace Nutri.Application.Features.Suplements.Queries.GetSuplementsCustomListDetail
{
    public class GetSuplementsCustomListDetailQueryHandler:IRequestHandler<GetSuplementsCustomListDetailQuery,List<string>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetSuplementsCustomListDetailQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<string>> Handle(GetSuplementsCustomListDetailQuery request, CancellationToken cancellationToken)
        {
            var detail = await this._unitOfWork.SuplementsRepository.GetSuplementCustomListDetailById(request.Id);
            return detail.Select(x => x.DescripcionSuplemento ).ToList();
        }
    }
}
