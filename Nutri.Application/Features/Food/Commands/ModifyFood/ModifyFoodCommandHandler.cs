using AutoMapper;
using MediatR;
using Nutri.Application.Contracts.Persistence;
using Nutri.Domain.Models;

namespace Nutri.Application.Features.Food.Commands.ModifyFood
{
    public class ModifyFoodCommandHandler : IRequestHandler<ModifyFoodCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ModifyFoodCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(ModifyFoodCommand request, CancellationToken cancellationToken)
        {
            var entidad = _mapper.Map<Alimento>(request);
            _unitOfWork.Repository<Alimento>().UpdateEntity(entidad);
            await _unitOfWork.Complete();
            return Unit.Value;
        }
    }
}
