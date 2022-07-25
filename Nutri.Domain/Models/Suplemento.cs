using Nutri.Domain.Common;

namespace Nutri.Domain.Models
{
    public class Suplemento:BaseDomainModel
    {
        public int MedicionSuplementoId { get; set; }
        public virtual MedicionSuplemento? MedicionSuplemento { get; set; }
        public string Nombre { get; set; } = string.Empty;
    }
}
