using MediatR;
using Nutri.Application.Contracts.Persistence;
using Nutri.Domain.Models;

namespace Nutri.Application.Features.Food.Commands.ModifyFoodFamily
{
    public class ModifyFoodFamilyCommandHandler : IRequestHandler<ModifyFoodFamilyCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public ModifyFoodFamilyCommandHandler(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }
        public async Task<Unit> Handle(ModifyFoodFamilyCommand request, CancellationToken cancellationToken)
        {
            var entity = await this._unitOfWork.Repository<FamiliaAlimento>().GetByIdAsync(request.Id);
            entity.Imagen = request.Image;
             this._unitOfWork.Repository<FamiliaAlimento>().UpdateEntity(entity);
            await this._unitOfWork.Complete();
            return Unit.Value;
        }
    }
}
