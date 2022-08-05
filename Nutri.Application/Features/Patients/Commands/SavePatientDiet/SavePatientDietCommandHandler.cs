using MediatR;
using Nutri.Application.Contracts.Persistence;
using Nutri.Domain.Models;

namespace Nutri.Application.Features.Patients.Commands.SavePatientDiet
{
    public class SavePatientDietCommandHandler:IRequestHandler<SavePatientDietCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public SavePatientDietCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(SavePatientDietCommand request, CancellationToken cancellationToken)
        {
            var nuevoCabecero = new ConsultaPaciente();
            nuevoCabecero.PacienteId = request.IdPaciente;
            nuevoCabecero.FechaCreacion = DateTime.Now;
            _unitOfWork.Repository<ConsultaPaciente>().AddEntity(nuevoCabecero);

            short numeroComida = 0;
            short renglon = 1;
            var horaComida = string.Empty;
            //Guardar alimentos detalle por comida
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
                renglonDetalle.NumeroComida = numeroComida;
                renglonDetalle.RenglonComida = renglon;
                renglonDetalle.Comida = comida.Comida;
                renglonDetalle.Hora = comida.HoraComida;
                _unitOfWork.Repository<ConsultaPacienteAlimentos>().AddEntity(renglonDetalle);
                renglon++;
            }
            await _unitOfWork.Complete();
            return await Task.FromResult(Unit.Value);
        }
    }
}
