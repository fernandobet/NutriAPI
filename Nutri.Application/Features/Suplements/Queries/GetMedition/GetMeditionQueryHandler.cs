using MediatR;
using Nutri.Application.Contracts.Persistence;
using Nutri.Domain.Models;

namespace Nutri.Application.Features.Suplements.Queries.GetMedition
{
    public class GetMeditionQueryHandler : IRequestHandler<GetMeditionQuery, IReadOnlyList<MedicionSuplemento>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetMeditionQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IReadOnlyList<MedicionSuplemento>> Handle(GetMeditionQuery request, CancellationToken cancellationToken)
        {
            var list = await _unitOfWork.Repository<MedicionSuplemento>().GetAllAsync();
            return list;
        }
    }
}
