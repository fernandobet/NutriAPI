using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Nutri.Application.Contracts.Persistence;
using Nutri.Application.DTO.Patiients;

namespace Nutri.Application.Features.Patients.Queries.GetPatientConsult
{
    public class GetPatientConsultQueryHandler : IRequestHandler<GetPatientConsultQuery, GetPatientConsultDTO>
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

        public async Task<GetPatientConsultDTO> Handle(GetPatientConsultQuery request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.PatientRepository.GetPatientConsult(request.IdConsulta);
        }
    }
}
