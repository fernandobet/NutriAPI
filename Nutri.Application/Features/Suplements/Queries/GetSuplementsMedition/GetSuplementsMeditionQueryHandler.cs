using MediatR;
using Nutri.Application.Contracts.Persistence;

namespace Nutri.Application.Features.Suplements.Queries.GetSuplementsMedition
{
    public class GetSuplementsMeditionQueryHandler : IRequestHandler<GetSuplementsMeditionQuery, List<GetSuplementsMeditionVm>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetSuplementsMeditionQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<GetSuplementsMeditionVm>> Handle(GetSuplementsMeditionQuery request, CancellationToken cancellationToken)
        {
            var list = _unitOfWork.SuplementsRepository.GetSuplementsMedition();
            return await Task.FromResult(list);
        }
    }
}
