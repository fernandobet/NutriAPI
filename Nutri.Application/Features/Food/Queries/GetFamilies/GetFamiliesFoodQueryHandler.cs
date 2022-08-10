using MediatR;
using Nutri.Application.Contracts.Persistence;
using Nutri.Domain.Models;

namespace Nutri.Application.Features.Food.Queries.GetFamilies
{
    public class GetFamiliesFoodQueryHandler : IRequestHandler<GetFamiliesFoodQuery, IEnumerable<FamiliaAlimento>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetFamiliesFoodQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<FamiliaAlimento>> Handle(GetFamiliesFoodQuery request, CancellationToken cancellationToken)
        {
            var data = await _unitOfWork.Repository<FamiliaAlimento>().GetAllAsync();
            return data;
        }
    }
}
