using MediatR;

namespace Nutri.Application.Features.Mediciones.Commands.SaveMedicion
{
    public class SaveMedicionCommand:IRequest
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public string Abreviacion { get; set; }
    }
}
