using Nutri.Domain.Common;

namespace Nutri.Domain.Models
{
    public class MedicionSuplemento:BaseDomainModel
    {
        public string Descripcion { get; set; } = string.Empty;
        public virtual List<Suplemento>? Suplementos { get; set; }

    }
}
