using MediatR;
using Nutri.Application.Contracts.Persistence;
using Nutri.Domain.Models;

namespace Nutri.Application.Features.Suplements.Commands.DeleteSuplementList
{
    public class DeleteSuplementListCommandHandler : IRequestHandler<DeleteSuplementListCommand>
    {
        public IUnitOfWork _unitOfWork { get; set; }

        public DeleteSuplementListCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(DeleteSuplementListCommand request, CancellationToken cancellationToken)
        {
            var cabecero = await _unitOfWork.Repository<ListasSuplementosPersonalizadasDetalle>().GetByIdAsync(request.Id);
            _unitOfWork.Repository<ListasSuplementosPersonalizadasDetalle>().DeleteEntity(cabecero);
            await _unitOfWork.Complete();
            return Unit.Value;
            
        }
    }
}
