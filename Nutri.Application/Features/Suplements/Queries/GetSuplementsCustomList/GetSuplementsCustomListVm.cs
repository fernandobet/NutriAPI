namespace Nutri.Application.Features.Suplements.Queries.GetSuplementsCustomList
{
    public class GetSuplementsCustomListVm
    {
        public int Id { get; set; }
        public string NombreLista { get; set; } = string.Empty; 
        public List<string> Contenido { get; set; }

        public GetSuplementsCustomListVm()
        {
            Contenido = new List<string>();
        }
    }
}
