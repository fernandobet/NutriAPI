using MediatR;
using System.Text.Json.Serialization;

namespace Nutri.Application.Features.Food.Commands.SaveFood
{
    public class SaveFoodCommand : IRequest
    {
        //[JsonPropertyName("idFamilia")]
        public int FamiliaAlimentoId { get; set; }
        public string Nombre { get; set; } = string.Empty;
        //[JsonPropertyName("idMedicion")]
        public int MedicionAlimentoId { get; set; }
        public decimal Proteina { get; set; } = 0;
        public decimal Carbohidratos { get; set; } = 0;
        public decimal Azucar { get; set; } = 0;
        public decimal Lipidos { get; set; } = 0;
        public string Imagen { get; set; } = string.Empty;
        public decimal Calorias { get; set; } = 0;
    }
}
