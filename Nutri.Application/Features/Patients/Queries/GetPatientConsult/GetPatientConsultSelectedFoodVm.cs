namespace Nutri.Application.Features.Patients.Queries.GetPatientConsult
{
    public class GetPatientConsultSelectedFoodVm
    {
        public long IdConsulta { get; set; }
        public short RenglonComida { get; set; }
        public string Comida { get; set; } = String.Empty;
        public string HoraComida { get; set; } = String.Empty;
    }
}
