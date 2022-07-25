
using Nutri.Application.Models;
using Nutri.Application.Models.Identity;

namespace Nutri.Application.Contracts.Identity
{
    public interface IAuthService
    {
        Task<AuthResponse> Login(AuthRequest request);
        Task<RegistrationResponse> Register(RegistrationRequest request);
    }
}
