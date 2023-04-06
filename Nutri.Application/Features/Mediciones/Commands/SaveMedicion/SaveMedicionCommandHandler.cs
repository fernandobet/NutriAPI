
using AutoMapper;
using MediatR;
using Nutri.Application.Contracts.Persistence;
using Nutri.Domain.Models;

namespace Nutri.Application.Features.Mediciones.Commands.SaveMedicion
{
    public class SaveMedicionCommandHandler : IRequestHandler<SaveMedicionCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public SaveMedicionCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(SaveMedicionCommand request, CancellationToken cancellationToken)
        {
            var mapped = _mapper.Map<MedicionAlimento>(request);
            mapped.FechaCreacion = DateTime.Now;
            if (mapped.Id == 0)
                await this._unitOfWork.MedicionRepository.AddAsync(mapped);
            else
                await this._unitOfWork.MedicionRepository.UpdatedAsync(mapped);
            return Unit.Value;
        }
    }
}
