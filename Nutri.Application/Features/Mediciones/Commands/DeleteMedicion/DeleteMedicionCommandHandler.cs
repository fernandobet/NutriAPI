using AutoMapper;
using MediatR;
using Nutri.Application.Contracts.Persistence;
using Nutri.Domain.Models;

namespace Nutri.Application.Features.Mediciones.Commands.DeleteMedicion
{
    public class DeleteMedicionCommandHandler : IRequestHandler<DeleteMedicionCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteMedicionCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteMedicionCommand request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.Repository<MedicionAlimento>().GetByIdAsync(request.Id);
            this._unitOfWork.Repository<MedicionAlimento>().DeleteEntity(entity);
            await _unitOfWork.Complete();
            return Unit.Value;
        }
    }
}
