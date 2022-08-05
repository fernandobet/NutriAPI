using MediatR;
using Nutri.Application.Contracts.Persistence;
using Nutri.Domain.Models;

namespace Nutri.Application.Features.Food.Queries.GetMeditionsFood
{
    public class GetMeditionsFoodQueryHandler : IRequestHandler<GetMeditionsFoodQuery, IEnumerable<MedicionAlimento>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetMeditionsFoodQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public  async Task<IEnumerable<MedicionAlimento>> Handle(GetMeditionsFoodQuery request, CancellationToken cancellationToken)
        {
            var meditionFoodList = await _unitOfWork.Repository<MedicionAlimento>().GetAllAsync();
            return meditionFoodList;
        }
    }
}
