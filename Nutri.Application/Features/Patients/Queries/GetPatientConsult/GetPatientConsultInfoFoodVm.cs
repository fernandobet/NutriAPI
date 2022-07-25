namespace Nutri.Application.Features.Patients.Queries.GetPatientConsult
{
    public class GetPatientConsultInfoFoodVm
    {
        public int IdPaciente { get; set; }
        public string NombrePaciente { get; set; } = string.Empty;
        public string EmailPaciente { get; set; } = String.Empty;
        public int Numero { get; set; }
        public List<GetPatientConsultUpdateInfoFoodVm> AlimentosSeleccionados { get; set; }
        public string Hora { get; set; } = String.Empty;
        public string FechaCreacion { get; set; } = String.Empty;
        public GetPatientConsultInfoFoodVm()
        {
            AlimentosSeleccionados = new List<GetPatientConsultUpdateInfoFoodVm>();
        }
    }
}
