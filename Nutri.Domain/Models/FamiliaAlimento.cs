using Nutri.Domain.Common;

namespace Nutri.Domain.Models
{
    public class FamiliaAlimento: BaseDomainModel
    {
        public string Nombre { get; set; } = string.Empty;
        public string Imagen { get; set; }=string.Empty;
        public List<Alimento>? Alimento { get; set; }

    }
}
