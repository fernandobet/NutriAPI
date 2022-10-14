
using MediatR;
using Nutri.Application.Contracts.Persistence;
using Nutri.Domain.Models;

namespace Nutri.Application.Features.Food.Commands.DeleteFood
{
    public class DeleteFoodCommandHandler : IRequestHandler<DeleteFoodCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteFoodCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(DeleteFoodCommand request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.Repository<Alimento>().GetByIdAsync(request.Id);
            _unitOfWork.Repository<Alimento>().DeleteEntity(entity);
            await _unitOfWork.Complete();
            return Unit.Value;
        }
    }
}
