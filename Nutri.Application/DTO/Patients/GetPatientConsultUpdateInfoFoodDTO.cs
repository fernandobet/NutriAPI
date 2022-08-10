namespace Nutri.Application.DTO.Patients
{
    public class GetPatientConsultUpdateInfoFoodDTO
    {
        public short Proteina { get; set; }
        public short Carbohidratos { get; set; }
        public short Lipidos { get; set; }
        public short Azucar { get; set; }
        public short Calorias { get; set; }
        public short Cantidad { get; set; }
        public bool Agregar { get; set; }
        public string Alimento { get; set; }
    }
}
