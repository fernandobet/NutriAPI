using MediatR;

namespace Nutri.Application.Features.Suplements.Commands.DeleteSuplementList
{
    public class DeleteSuplementListCommand:IRequest
    {
        public int Id { get; set; }
    }
}
