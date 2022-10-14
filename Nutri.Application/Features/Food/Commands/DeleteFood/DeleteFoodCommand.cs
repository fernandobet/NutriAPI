using MediatR;

namespace Nutri.Application.Features.Food.Commands.DeleteFood
{
    public class DeleteFoodCommand:IRequest
    {
        public int Id { get; set; }
    }
}
