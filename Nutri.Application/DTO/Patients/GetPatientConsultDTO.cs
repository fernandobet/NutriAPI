using Nutri.Application.Features.Patients.Queries.GetPatientConsult;
using Nutri.Application.Models.Email;
using System.Text.Json.Serialization;

namespace Nutri.Application.DTO.Patiients
{
    public class GetPatientConsultDTO
    {
        public int IdDietaPaciente { get; set; }
        public int IdPaciente { get; set; }
        public string NombrePaciente { get; set; } = string.Empty;
        public string EmailPaciente { get; set; } = string.Empty;
        public short NumeroComida { get; set; }
        public List<GetPatientConsultSelectedFoodVm> AlimentosSave { get; set; }
        [JsonPropertyName("Alimentos")]
        public List<GetPatientConsultInfoFoodVm> Alimentos { get; set; }
        public EmailBody? EmailBody { get; set; }
        public List<IGenSuplementosConMedicionDTO> Suplementos { get; set; } 
        public string Notas { get; set; } = string.Empty;

        public GetPatientConsultDTO()
        {
            AlimentosSave = new List<GetPatientConsultSelectedFoodVm>();
            Alimentos = new List<GetPatientConsultInfoFoodVm>();
            Suplementos = new List<IGenSuplementosConMedicionDTO>();
        }
    }
    public class IGenSuplementosConMedicionDTO
    {
        public int IdSuplemento { get; set; }
        public int IdMedicion { get; set; }
        public string Suplemento { get; set; } = string.Empty;
        public string Medicion { get; set; } = string.Empty;
        public string TextoAdicional { get; set; } = string.Empty;
        public short Medidas { get; set; }
    }
}
