using AutoMapper;
using MediatR;
using Nutri.Application.Contracts.Persistence;
using Nutri.Domain.Models;

namespace Nutri.Application.Features.Suplements.Commands.AddSuplement
{
    public class AddSuplementCommandHandler : IRequestHandler<AddSuplementCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AddSuplementCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(AddSuplementCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Suplemento>(request);
            _unitOfWork.SuplementsRepository.AddEntity(entity);
            await _unitOfWork.Complete();
            return Unit.Value;

        }
    }
}
