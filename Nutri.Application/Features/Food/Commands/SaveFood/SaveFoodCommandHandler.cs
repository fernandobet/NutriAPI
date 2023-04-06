using AutoMapper;
using MediatR;
using Nutri.Application.Contracts.Persistence;
using Nutri.Application.Utils;
using Nutri.Domain.Models;

namespace Nutri.Application.Features.Food.Commands.SaveFood
{
    public class SaveFoodCommandHandler : IRequestHandler<SaveFoodCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public SaveFoodCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(SaveFoodCommand request, CancellationToken cancellationToken)
        {
            
            var entity = _mapper.Map<Alimento>(request);
            //Images
            //string fullPath = string.Empty;
            //string fileName = string.Empty;
            //if (!AdminFiles.ValidateImageExists(request.Imagen, out fullPath, out fileName))
            //    AdminFiles.AdminImage(request.Imagen, fullPath, fileName);
            //entity.Imagen = fullPath;
            entity!.FechaCreacion = DateTime.Now;
            _unitOfWork.FoodRepository.AddEntity(entity);

            await _unitOfWork.Complete();
            return Unit.Value;
        }
    }
}
