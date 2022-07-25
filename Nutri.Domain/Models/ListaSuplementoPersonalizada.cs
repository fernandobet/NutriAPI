using Nutri.Domain.Common;

namespace Nutri.Domain.Models
{
    public class ListaSuplementoPersonalizada:BaseDomainModel
    {
        public string Nombre { get; set; } = string.Empty;
        public int Renglon { get; set; }
        public string DescripcionSuplemento { get; set; }=string.Empty;

    }
}
