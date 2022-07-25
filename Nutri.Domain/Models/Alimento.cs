using Nutri.Domain.Common;

namespace Nutri.Domain.Models
{
    public class Alimento: BaseDomainModel
    {
        public int FamiliaAlimentoId { get; set; }
        public virtual FamiliaAlimento? FamiliaAlimento { get; set; }
        public string Nombre { get; set; }= string.Empty;
        public int MedicionAlimentoId { get; set; }
        public virtual MedicionAlimento? MedicionAlimento { get; set; }
        public decimal Proteina { get; set; } = 0;
        public decimal Carbohidratos { get; set; } = 0;
        public decimal Azucar { get; set; } = 0;
        public decimal Lipidos { get; set; } = 0;
        public string Imagen { get; set; }=string.Empty;
        public decimal Calorias { get; set; } = 0;

    }
}
