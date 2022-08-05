using MediatR;
using Nutri.Application.Contracts.Persistence;
using Nutri.Domain.Models;

namespace Nutri.Application.Features.Food.Queries.GetFamilyFood
{
    public class GetFamilyFoodQueryHandler:IRequestHandler<GetFamilyFoodQuery,FamiliaAlimento>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetFamilyFoodQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<FamiliaAlimento> Handle(GetFamilyFoodQuery request, CancellationToken cancellationToken)
        {
            var familyFood = await _unitOfWork.Repository<FamiliaAlimento>().GetByIdAsync(request.Id);
            return familyFood;
        }
    }
}
