using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Nutri.Application.Contracts.Persistence;
using Nutri.Domain.Models;

namespace Nutri.Application.Features.Patients.Queries.GetPatient
{
    public class GetPatientQueryHandler : IRequestHandler<GetPatientQuery, Paciente>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<GetPatientQueryHandler> _logger;
        private readonly IMapper _mapper;

        public GetPatientQueryHandler(IUnitOfWork unitOfWork, ILogger<GetPatientQueryHandler> logger, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<Paciente> Handle(GetPatientQuery request, CancellationToken cancellationToken)
        {
            var paciente = await _unitOfWork.Repository<Paciente>().GetByIdAsync(request.Id);
            return paciente;
        }
    }
}
