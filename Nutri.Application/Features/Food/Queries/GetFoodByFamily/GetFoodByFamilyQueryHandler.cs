using MediatR;
using Nutri.Application.Contracts.Persistence;
using Nutri.Domain.Models;

namespace Nutri.Application.Features.Food.Queries.GetFamiliesFood
{
    public class GetFoodByFamilyQueryHandler:IRequestHandler<GetFoodByFamilyQuery,IEnumerable<Alimento>>
    {

        private readonly IUnitOfWork _unitOfWork;

        public GetFoodByFamilyQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Alimento>> Handle(GetFoodByFamilyQuery request, CancellationToken cancellationToken)
        {
            var familyList = await _unitOfWork.Repository<Alimento>().GetAllAsync();
            if(!familyList.Any())
                return Enumerable.Empty<Alimento>();
            var foodFamily = familyList.Where(x => x.FamiliaAlimentoId == request.IdFamily);
            return foodFamily;
        }
    }
}
