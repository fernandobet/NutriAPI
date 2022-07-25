using Nutri.Application.Models.Email;
using System.Text.Json.Serialization;

namespace Nutri.Application.Features.Patients.Queries.GetPatientConsult
{
    public class GetPatientConsultVm
    {
        public int IdPaciente { get; set; }
        public string NombrePaciente { get; set; } = string.Empty;
        public string EmailPaciente { get; set; } = string.Empty;
        public short NumeroComida { get; set; }
        public List<GetPatientConsultSelectedFoodVm> AlimentosSave { get; set; }
        [JsonPropertyName("Alimentos")]
        public List<GetPatientConsultInfoFoodVm> Alimentos { get; set; }
        public EmailBody? EmailBody { get; set; }
        public string Suplementos { get; set; } = string.Empty;
        public string Notas { get; set; } = string.Empty;

        public GetPatientConsultVm()
        {
            AlimentosSave = new List<GetPatientConsultSelectedFoodVm>();
            Alimentos = new List<GetPatientConsultInfoFoodVm>();
        }
    }
}
