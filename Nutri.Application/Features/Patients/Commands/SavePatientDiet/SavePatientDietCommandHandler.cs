using MediatR;
using Nutri.Application.Contracts.Persistence;
using Nutri.Application.Utils;
using Nutri.Domain.Models;

namespace Nutri.Application.Features.Patients.Commands.SavePatientDiet
{
    public class SavePatientDietCommandHandler : IRequestHandler<SavePatientDietCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public SavePatientDietCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(SavePatientDietCommand request, CancellationToken cancellationToken)
        {
            if (request.ReenviarDieta)
            {
                this.enviarDietaEmail(request);
                return Unit.Value;
            }
            var nuevoCabecero = new ConsultaPaciente();
            nuevoCabecero.PacienteId = request.IdPaciente;
            nuevoCabecero.FechaCreacion = DateTime.Now;
            _unitOfWork.Repository<ConsultaPaciente>().AddEntity(nuevoCabecero);

            short numeroComida = 0;
            var horaComida = string.Empty;
            //Guardar alimentos detalle por comida
            if (request?.AlimentosSave?.Any() ?? false)
                foreach (var comida in request.AlimentosSave)
                {
                    if (string.IsNullOrEmpty(horaComida) || !string.Equals(horaComida, comida.HoraComida, StringComparison.OrdinalIgnoreCase))
                    {
                        numeroComida++;
                        horaComida = comida.HoraComida;
                    }
                    var renglonDetalle = new ConsultaPacienteAlimentos();
                    renglonDetalle.Id = nuevoCabecero.Id;
                    renglonDetalle.ConsultaPaciente = nuevoCabecero;
                    renglonDetalle.ConsultaPacienteId = nuevoCabecero.Id;
                    renglonDetalle.NumeroComida = numeroComida;
                    renglonDetalle.Comida = comida.Comida;
                    renglonDetalle.Hora = comida.HoraComida;
                    renglonDetalle.FechaCreacion = DateTime.Now;
                    _unitOfWork.Repository<ConsultaPacienteAlimentos>().AddEntity(renglonDetalle);
                }
            //Save suplements
            if (request?.SuplementosSave?.Any() ?? false)
                foreach (var suplement in request.SuplementosSave)
                {
                    ConsultaPacienteSuplementos entity = new()
                    {
                        ConsultaPacienteId = nuevoCabecero.Id,
                        ConsultaPaciente = nuevoCabecero,
                        FechaCreacion = DateTime.Now,
                        Suplemento = suplement.Suplemento
                    };
                    _unitOfWork.Repository<ConsultaPacienteSuplementos>().AddEntity(entity);
                }
            if (!string.IsNullOrEmpty(request?.Notas))
            {
                ConsultaPacienteNotas consultaPacienteNotas = new()
                {
                    ConsultaPaciente = nuevoCabecero,
                    ConsultaPacienteId = nuevoCabecero.Id,
                    FechaCreacion = DateTime.Now,
                    Nota = request.Notas
                };
                _unitOfWork.Repository<ConsultaPacienteNotas>().AddEntity(consultaPacienteNotas);
            }
            await _unitOfWork.Complete();
            if (!string.IsNullOrEmpty(request?.EmailBody?.Attachment))
                this.enviarDietaEmail(request);
            return await Task.FromResult(Unit.Value);
        }


        private void enviarDietaEmail(SavePatientDietCommand request)
        {
            try
            {
                SendEmail.Send(request.EmailBody, request.NombrePaciente, request.EmailPaciente);
            }
            catch (Exception ex)
            {
            }
        }
    }
}
