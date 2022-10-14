using Nutri.Domain.Common;


namespace Nutri.Domain.Models
{
    public class ConsultaPacienteSuplementos:BaseDomainModel
    {
        public string Suplemento { get; set; }  = string.Empty; 
        public ConsultaPaciente? ConsultaPaciente { get; set; }
        public int ConsultaPacienteId { get; set; }
    }
}
