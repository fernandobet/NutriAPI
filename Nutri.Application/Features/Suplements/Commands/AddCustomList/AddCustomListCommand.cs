
using MediatR;

namespace Nutri.Application.Features.Suplements.Commands.AddCustomList
{
    public class AddCustomListCommand:IRequest
    {
        public int Id { get; set; }
        public string NombreLista { get; set; }=String.Empty;
        public List<string> Contenido { get; set; }

        public AddCustomListCommand()
        {
            Contenido = new List<string>();
        }
    }
}
