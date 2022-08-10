using AutoMapper;
using MediatR;
using Nutri.Application.Contracts.Persistence;
using Nutri.Domain.Models;

namespace Nutri.Application.Features.Users.Queries.Login
{
    public class LoginQueryHandler : IRequestHandler<LoginQuery, Usuario>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public LoginQueryHandler(IUnitOfWork unitOfwork, IMapper mapper)
        {
            _unitOfWork = unitOfwork;
            _mapper = mapper;
        }

        public async Task<Usuario> Handle(LoginQuery request, CancellationToken cancellationToken)
        {
            var usuarios = await _unitOfWork.UserRepository.GetAllAsync();
            var passEncrypt = Utils.Encrypt.GetSHA256(request.PassWord);
            var usuario = usuarios.FirstOrDefault(x => x.Email == request.UserName && x.Password == passEncrypt);
            if (usuario != null)
                return usuario!;
            return usuario;
        }
    }
}
