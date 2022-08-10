namespace Nutri.Application.Features.Patients.Queries.GetHistoryPatient
{
    public class GetHistoryPatientVm
    {
        public string Nombre { get; set; } = string.Empty;  
        public string Apellido { get; set; } = string.Empty;
        public short Edad { get; set; }
        public short Estatura { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Imagen { get; set; } = string.Empty;
        public List<HistorialPacientes> ListaConsultas { get; set; }

        public GetHistoryPatientVm()
        {
            ListaConsultas = new List<HistorialPacientes>();
        }
    }
    public class HistorialPacientes
    {
        public int IdConsulta { get; set; }
        public string FechaConsulta { get; set; } = string.Empty;
    }
}
