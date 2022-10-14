using MediatR;

namespace Nutri.Application.Features.Suplements.Commands.DeleteSuplement
{
    public class DeleteSuplementCommand:IRequest
    {
        public int Id { get; set; }
    }
}
