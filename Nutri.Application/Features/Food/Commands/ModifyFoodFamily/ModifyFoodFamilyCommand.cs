using MediatR;

namespace Nutri.Application.Features.Food.Commands.ModifyFoodFamily
{
    public class ModifyFoodFamilyCommand:IRequest
    {
        public int Id { get; set; }
        public string Image { get; set; }
    }
}
