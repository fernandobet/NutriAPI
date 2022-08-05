using MediatR;

namespace Nutri.Application.Features.Suplements.Commands.AddSuplement
{
    public class AddSuplementCommand:IRequest
    {
        public int MedicionSuplementoId { get; set; }
        public string Nombre { get; set; } = string.Empty;
    }
}
