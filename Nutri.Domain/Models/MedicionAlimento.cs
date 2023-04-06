using Nutri.Domain.Common;

namespace Nutri.Domain.Models
{
    public class MedicionAlimento: BaseDomainModel
    {
        public string Descripcion { get; set; }=string.Empty;
        public string Abreviacion { get; set; }=string.Empty;
        public List<Alimento>? Alimento { get; set; }
    }
}
