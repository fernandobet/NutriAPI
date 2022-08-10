using MediatR;
using Nutri.Application.Contracts.Persistence;
using Nutri.Domain.Models;

namespace Nutri.Application.Features.Patients.Queries.GetHistoryPatient
{
    public class GetHistoryPatientQueryHandler : IRequestHandler<GetHistoryPatientQuery, GetHistoryPatientVm>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetHistoryPatientQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<GetHistoryPatientVm> Handle(GetHistoryPatientQuery request, CancellationToken cancellationToken)
        {
            var paciente = await _unitOfWork.Repository<Paciente>().GetByIdAsync(request.IdPaciente);
            var consultasPacientes =  await _unitOfWork.PatientRepository.GetAllHistory(request.IdPaciente);

            if (!consultasPacientes.Any())
                Enumerable.Empty<GetHistoryPatientVm>();
            var historyViewModel = new GetHistoryPatientVm {
                Nombre = paciente.Nombre,
                Apellido = paciente.Apellido,
                Edad = paciente.Edad,
                Email = paciente.Email,
                Estatura = paciente.Estatura,
                Imagen = paciente.Imagen,
                ListaConsultas = consultasPacientes.Select(x => new HistorialPacientes { 
                 FechaConsulta = x.FechaCreacion.ToShortDateString(),
                 IdConsulta = x.Id
                }).ToList()
            };
            return historyViewModel;

        }
    }
}
