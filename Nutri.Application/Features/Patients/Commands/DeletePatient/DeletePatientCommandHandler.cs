using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Nutri.Application.Contracts.Persistence;
using Nutri.Domain.Models;
using System.Transactions;

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
            var consultasPaciente = await _unitOfWork.Repository<ConsultaPaciente>().GetAsync(x => x.PacienteId == request.Id);

            if (consultasPaciente.Any())
            {
                foreach (var consultaPaciente in consultasPaciente)
                {
                    var consultasPacientesSuplementos = await _unitOfWork.Repository<ConsultaPacienteSuplementos>().GetAsync(x => x.ConsultaPacienteId == consultaPaciente.Id);
                    if (consultasPacientesSuplementos?.Any() ?? false)
                    {
                        foreach (var consultaSuplemento in consultasPacientesSuplementos)
                        {
                            _unitOfWork.Repository<ConsultaPacienteSuplementos>().DeleteEntity(consultaSuplemento);
                        }
                    }

                    var consultasPacientesNotas = await _unitOfWork.Repository<ConsultaPacienteNotas>().GetAsync(x => x.ConsultaPacienteId == consultaPaciente.Id);
                    if (consultasPacientesNotas?.Any() ?? false)
                    {
                        foreach (var consultaPacienteNota in consultasPacientesNotas)
                        {
                            _unitOfWork.Repository<ConsultaPacienteNotas>().DeleteEntity(consultaPacienteNota);
                        }
                    }

                    var consultasPacientesAlimentos = await _unitOfWork.Repository<ConsultaPacienteAlimentos>().GetAsync(x => x.ConsultaPacienteId == consultaPaciente.Id);
                    if (consultasPacientesAlimentos?.Any() ?? false)
                    {
                        foreach (var consultaPacienteAlimento in consultasPacientesAlimentos)
                        {
                            _unitOfWork.Repository<ConsultaPacienteAlimentos>().DeleteEntity(consultaPacienteAlimento);
                        }
                    }
                    _unitOfWork.Repository<ConsultaPaciente>().DeleteEntity(consultaPaciente);
                }
            }
            var paciente = _mapper.Map<Paciente>(request);
            _unitOfWork.Repository<Paciente>().DeleteEntity(paciente);
            await _unitOfWork.Complete();
            _logger.LogInformation("Paciente eliminado correctamente");
            return Unit.Value;
        }
    }
}
