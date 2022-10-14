using Nutri.Domain.Common;

namespace Nutri.Domain.Models
{
    public class ConsultaPacienteNotas:BaseDomainModel
    {
        public string Nota { get; set; } = string.Empty;    
        public ConsultaPaciente? ConsultaPaciente { get; set; }
        public int ConsultaPacienteId { get; set; }
    }
}
