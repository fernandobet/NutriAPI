using MediatR;
using Nutri.Domain.DTOS;

namespace Nutri.Application.Features.Patients.Commands.SavePatientDiet
{
    public class SavePatientDietCommand:IRequest
    {
        public int IdPaciente { get; set; }
        public string NombrePaciente { get; set; } = string.Empty;
        public string EmailPaciente { get; set; } = string.Empty;
        public short NumeroComida { get; set; }
        public List<AlimentosSeleccionados> AlimentosSave { get; set; }
        public List<ComidaInfo> Alimentos { get; set; }
        public EmailDTO EmailBody { get; set; }
        public string Suplementos { get; set; } = string.Empty;
        public string Notas { get; set; } = string.Empty;
    }
}
