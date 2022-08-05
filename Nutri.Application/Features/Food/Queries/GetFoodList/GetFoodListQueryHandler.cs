
using MediatR;
using Nutri.Application.Contracts.Persistence;
using Nutri.Domain.Models;

namespace Nutri.Application.Features.Food.Queries.GetFoodList
{
    public class GetFoodListQueryHandler : IRequestHandler<GetFoodListQuery, IEnumerable<Alimento>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetFoodListQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Alimento>> Handle(GetFoodListQuery request, CancellationToken cancellationToken)
        {
            var foodList = await _unitOfWork.Repository<Alimento>().GetAllAsync();
            return foodList;
        }
    }
}
