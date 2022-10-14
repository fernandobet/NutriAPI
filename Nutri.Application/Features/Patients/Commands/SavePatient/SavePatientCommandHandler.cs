
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Nutri.Application.Contracts.Persistence;
using Nutri.Domain.Models;

namespace Nutri.Application.Features.Patients.Commands.SavePatient
{
    public class SavePatientCommandHandler:IRequestHandler<SavePatientCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<SavePatientCommandHandler> _logger;
        private readonly IMapper _mapper;

        public SavePatientCommandHandler(IUnitOfWork unitOfWork, ILogger<SavePatientCommandHandler> logger, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(SavePatientCommand request, CancellationToken cancellationToken)
        {
            var paciente = _mapper.Map<Paciente>(request);
            paciente.FechaCreacion = DateTime.Now;
             _unitOfWork.Repository<Paciente>().AddEntity(paciente);
            await _unitOfWork.Complete();
            _logger.LogInformation("Paciente guardado correctamente");
            return Unit.Value;
        }
    }
}
