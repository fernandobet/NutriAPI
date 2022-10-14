using Nutri.Domain.Common;

namespace Nutri.Domain.Models
{
    public class ListaSuplementoPersonalizadaDetalle:BaseDomainModel
    {
        public virtual ListasSuplementosPersonalizadasDetalle ListaPersonalizada { get; set; }
        public int ListaPersonalizadaId { get; set; }
        public string DescripcionSuplemento { get; set; } = string.Empty;

        public ListaSuplementoPersonalizadaDetalle()
        {
            this.ListaPersonalizada = new ListasSuplementosPersonalizadasDetalle();
        }

    }
}
