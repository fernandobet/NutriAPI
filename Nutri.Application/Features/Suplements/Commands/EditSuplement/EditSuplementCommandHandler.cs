using AutoMapper;
using MediatR;
using Nutri.Application.Contracts.Persistence;
using Nutri.Domain.Models;

namespace Nutri.Application.Features.Suplements.Commands.EditSuplement
{
    public class EditSuplementCommandHandler:IRequestHandler<EditSuplementCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public EditSuplementCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(EditSuplementCommand request, CancellationToken cancellationToken)
        {
            var suplemento = this._mapper.Map<Suplemento>(request);
            _unitOfWork.SuplementsRepository.UpdateEntity(suplemento);
            await _unitOfWork.Complete();
            return Unit.Value;
        }
    }
}
