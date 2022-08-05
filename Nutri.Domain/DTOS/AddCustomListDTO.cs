namespace Nutri.Domain.DTOS
{
    public class AddCustomListDTO
    {
        public int Id { get; set; }
        public string NombreLista { get; set; }
        public List<string> Contenido { get; set; }
    }
}
