using Nutri.Domain.Common;

namespace Nutri.Domain.Models
{
    public class ConsultaPacienteAlimentos:BaseDomainModel
    {
        public int RenglonComida { get; set; }
        public string Comida { get; set; } = string.Empty;
        public string Hora { get; set; } = string.Empty;
        public short NumeroComida { get; set; } = 0;
        public virtual ConsultaPaciente? ConsultaPaciente { get; set; }
    }
}
