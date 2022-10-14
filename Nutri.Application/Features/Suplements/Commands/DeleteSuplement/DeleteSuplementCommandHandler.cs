using MediatR;
using Nutri.Application.Contracts.Persistence;

namespace Nutri.Application.Features.Suplements.Commands.DeleteSuplement
{
    public class DeleteSuplementCommandHandler:IRequestHandler<DeleteSuplementCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteSuplementCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(DeleteSuplementCommand request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.SuplementsRepository.GetByIdAsync(request.Id);
            _unitOfWork.SuplementsRepository.DeleteEntity(entity);
            await _unitOfWork.Complete();
            return Unit.Value;
        }
    }
}
