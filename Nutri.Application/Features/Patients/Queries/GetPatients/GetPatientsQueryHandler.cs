using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Nutri.Application.Contracts.Persistence;
using Nutri.Domain.Models;

namespace Nutri.Application.Features.Patients.Queries.GetPatients
{
    public class GetPatientsQueryHandler : IRequestHandler<GetPatientsQuery, IEnumerable<Paciente>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<GetPatientsQueryHandler> _logger;
        private readonly IMapper _mapper;

        public GetPatientsQueryHandler(IUnitOfWork unitOfWork, ILogger<GetPatientsQueryHandler> logger, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Paciente>> Handle(GetPatientsQuery request, CancellationToken cancellationToken)
        {
            var pacientes = await _unitOfWork.Repository<Paciente>().GetAllAsync();
            return pacientes;
        }
    }
}
