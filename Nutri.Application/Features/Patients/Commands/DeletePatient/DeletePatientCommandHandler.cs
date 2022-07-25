using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Nutri.Application.Contracts.Persistence;
using Nutri.Domain.Models;

namespace Nutri.Application.Features.Patients.Commands.DeletePatient
{
    public class DeletePatientCommandHandler : IRequestHandler<DeletePatientCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<DeletePatientCommandHandler> _logger;
        private readonly IMapper _mapper;

        public DeletePatientCommandHandler(IUnitOfWork unitOfWork, ILogger<DeletePatientCommandHandler> logger, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeletePatientCommand request, CancellationToken cancellationToken)
        {
            var paciente = _mapper.Map<Paciente>(request);
            _unitOfWork.Repository<Paciente>().DeleteEntity(paciente);
            await _unitOfWork.Complete();
            _logger.LogInformation("Paciente eliminado correctamente");
            return Unit.Value;
        }
    }
}
