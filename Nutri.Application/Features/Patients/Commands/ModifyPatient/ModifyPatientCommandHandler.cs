
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Nutri.Application.Contracts.Persistence;
using Nutri.Domain.Models;

namespace Nutri.Application.Features.Patients.Commands.ModifyPatient
{
    public class ModifyPatientCommandHandler:IRequestHandler<ModifyPatientCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<ModifyPatientCommandHandler> _logger;
        private readonly IMapper _mapper;

        public ModifyPatientCommandHandler(IUnitOfWork unitOfWork, ILogger<ModifyPatientCommandHandler> logger, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(ModifyPatientCommand request, CancellationToken cancellationToken)
        {
            var paciente = _mapper.Map<Paciente>(request);
            _unitOfWork.Repository<Paciente>().UpdateEntity(paciente);
            await _unitOfWork.Complete();
            _logger.LogInformation("Paciente modificado correctamente");
            return Unit.Value;
        }
    }
}
