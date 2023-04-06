using MediatR;

namespace Nutri.Application.Features.Mediciones.Commands.DeleteMedicion
{
    public class DeleteMedicionCommand:IRequest
    {
        public int Id { get; set; }
    }
}
