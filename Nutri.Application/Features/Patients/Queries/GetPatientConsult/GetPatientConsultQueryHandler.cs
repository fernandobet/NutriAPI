using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Nutri.Application.Contracts.Persistence;

namespace Nutri.Application.Features.Patients.Queries.GetPatientConsult
{
    public class GetPatientConsultQueryHandler : IRequestHandler<GetPatientConsultQuery, GetPatientConsultVm>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<GetPatientConsultQueryHandler> _logger;
        private readonly IMapper _mapper;

        public GetPatientConsultQueryHandler(IUnitOfWork unitOfWork, ILogger<GetPatientConsultQueryHandler> logger, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<GetPatientConsultVm> Handle(GetPatientConsultQuery request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.PatientRepository.GetPatientConsult(request.IdConsulta);
        }
    }
}
