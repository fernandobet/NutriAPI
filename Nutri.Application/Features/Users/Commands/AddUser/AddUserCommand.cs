using MediatR;

namespace Nutri.Application.Features.Users.Commands.AddUser
{
    public class AddUserCommand:IRequest
    {
        public string Nombre { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
