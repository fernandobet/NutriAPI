using AutoMapper;
using MediatR;
using Nutri.Application.Contracts.Persistence;
using Nutri.Domain.DTOS;

namespace Nutri.Application.Features.Suplements.Commands.AddCustomList
{
    public class AddCustomListCommandHandler : IRequestHandler<AddCustomListCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AddCustomListCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(AddCustomListCommand request, CancellationToken cancellationToken)
        {
            var dto =_mapper.Map<AddCustomListDTO>(request);
            await _unitOfWork.SuplementsRepository.SaveCustomList(dto);
            await _unitOfWork.Complete();
            return Unit.Value;
        }
    }
}
