using System.Text.Json.Serialization;

namespace Nutri.Domain.DTOS
{
    public class SavePatientDietDTO
    {
        public int IdPaciente { get; set; }
        public string NombrePaciente { get; set; } = string.Empty;
        public string EmailPaciente { get; set; } = string.Empty;
        public short NumeroComida { get; set; }
        public List<AlimentosSeleccionados> AlimentosSave { get; set; }
        [JsonPropertyName("Alimentos")]
        public List<ComidaInfo> Alimentos { get; set; }
        public EmailDTO EmailBody { get; set; }
        public string Suplementos { get; set; } = string.Empty;
        public string Notas { get; set; } = string.Empty;
    }
    public class AlimentosSeleccionados
    {
        public string Comida { get; set; } = string.Empty;
        public string HoraComida { get; set; } = String.Empty;
    }
    public class ComidaInfo
    {
        public int IdPaciente { get; set; }
        public string NombrePaciente { get; set; }
        public string EmailPaciente { get; set; }
        public int Numero { get; set; }
        public List<ActualizarInfoComida> AlimentosSeleccionados { get; set; }
        public string Hora { get; set; } = string.Empty;
        public string FechaCreacion { get; set; }
    }

    public class ActualizarInfoComida
    {
        public short Proteina { get; set; }
        public short Carbohidratos { get; set; }
        public short Lipidos { get; set; }
        public short Azucar { get; set; }
        public short Calorias { get; set; }
        public short Cantidad { get; set; }
        public bool Agregar { get; set; }
        public string Alimento { get; set; } = string.Empty;

    }
    public class EmailDTO
    {
        public string Attachment { get; set; }

    }
}
