using MediatR;
using Nutri.Application.Contracts.Persistence;

namespace Nutri.Application.Features.Suplements.Queries.GetSuplementsCustomList
{
    public class GetSuplementsCustomListQueryHandler : IRequestHandler<GetSuplementsCustomListQuery, List<GetSuplementsCustomListVm>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetSuplementsCustomListQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<GetSuplementsCustomListVm>> Handle(GetSuplementsCustomListQuery request, CancellationToken cancellationToken)
        {
            var list = _unitOfWork.SuplementsRepository.GetSuplementsCustomList();
            return await Task.FromResult(list);
        }
    }
}
