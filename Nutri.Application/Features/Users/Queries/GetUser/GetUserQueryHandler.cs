using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Nutri.Application.Contracts.Persistence;
using Nutri.Application.Exceptions;
using Nutri.Domain.Models;

namespace Nutri.Application.Features.Users.Queries.GetUser
{
    public class GetUserQueryHandler : IRequestHandler<GetUserQuery, Usuario>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetUserQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<Usuario> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            var usuario = _unitOfWork.UserRepository.GetByIdAsync(request.Id);
            if(usuario == null)
            {
                //_logger.LogError($"No se encontro el usuario con id {request.Id}");
                throw new NotFoundException(nameof(Usuario),request.Id);
            }
            return usuario;
        }
    }
}
