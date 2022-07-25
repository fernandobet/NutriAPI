using Nutri.Domain.Common;

namespace Nutri.Domain.Models
{
    public class ConsultaPaciente:BaseDomainModel
    {
        public virtual Paciente? Paciente { get; set; }
        public int PacienteId { get; set; }
        public virtual ICollection<ConsultaPacienteAlimentos>? ConsultasPacienteAlimentos { get; set; }

        public ConsultaPaciente()
        {
            ConsultasPacienteAlimentos = new HashSet<ConsultaPacienteAlimentos>();  
        }
    }
}
