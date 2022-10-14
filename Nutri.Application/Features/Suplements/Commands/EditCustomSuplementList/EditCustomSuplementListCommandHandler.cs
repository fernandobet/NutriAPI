using AutoMapper;
using MediatR;
using Nutri.Application.Contracts.Persistence;
using Nutri.Domain.DTOS;
using Nutri.Domain.Models;

namespace Nutri.Application.Features.Suplements.Commands.EditCustomSuplementList
{
    public class EditCustomSuplementListCommandHandler:IRequestHandler<EditCustomSuplementListCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public EditCustomSuplementListCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(EditCustomSuplementListCommand request, CancellationToken cancellationToken)
        {
            var dto = _mapper.Map<AddCustomListDTO>(request);
            await _unitOfWork.SuplementsRepository.EditCustomList(dto);
            await _unitOfWork.Complete();
            return Unit.Value;

        }
    }
}
