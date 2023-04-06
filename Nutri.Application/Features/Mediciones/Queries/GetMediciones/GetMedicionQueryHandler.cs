using MediatR;
using Nutri.Application.Contracts.Persistence;
using Nutri.Domain.Models;

namespace Nutri.Application.Features.Mediciones.Queries.GetMediciones
{
    public class GetMedicionQueryHandler : IRequestHandler<GetMedicionQuery, List<MedicionAlimento>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetMedicionQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<MedicionAlimento>> Handle(GetMedicionQuery request, CancellationToken cancellationToken)
        {
            var data = await _unitOfWork.MedicionRepository.GetAllAsync();
            return data.ToList();
        }
    }
}
