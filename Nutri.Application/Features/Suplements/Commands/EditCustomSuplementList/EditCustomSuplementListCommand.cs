using MediatR;

namespace Nutri.Application.Features.Suplements.Commands.EditCustomSuplementList
{
    public class EditCustomSuplementListCommand:IRequest
    {
        public int Id { get; set; }
        public string NombreLista { get; set; } = String.Empty;
        public List<string> Contenido { get; set; }

        public EditCustomSuplementListCommand()
        {
            Contenido = new List<string>();
        }
    }
}
