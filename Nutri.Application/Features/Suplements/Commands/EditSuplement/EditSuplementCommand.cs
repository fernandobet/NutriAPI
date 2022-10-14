using MediatR;

namespace Nutri.Application.Features.Suplements.Commands.EditSuplement
{
    public class EditSuplementCommand:IRequest
    {
        public int Id { get; set; }
        public int MedicionSuplementoId { get; set; }
        public string Nombre { get; set; } = string.Empty;
    }
}
