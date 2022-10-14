using MediatR;
using Nutri.Application.DTO.Patients;
using Nutri.Domain.DTOS;

namespace Nutri.Application.Features.Patients.Commands.SavePatientDiet
{
    public class SavePatientDietCommand:IRequest
    {
        public int IdPaciente { get; set; }
        public string NombrePaciente { get; set; } = string.Empty;
        public string EmailPaciente { get; set; } = string.Empty;
        public List<AlimentosSeleccionados>? AlimentosSave { get; set; }
        public EmailModel EmailBody { get; set; }
        public string? Notas { get; set; }
        public List<SuplementosSave>? SuplementosSave { get; set; }
        public bool ReenviarDieta { get; set; }
    }

    public class AlimentosSave
    {
        public string Comida { get; set; } = string.Empty;
        public string HoraComida { get; set; } = String.Empty;
    }
    public class SuplementosSave
    {
        public string Suplemento { get; set; }= string.Empty;
    }
}
