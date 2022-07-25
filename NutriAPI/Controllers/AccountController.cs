using Microsoft.AspNetCore.Mvc;
using Nutri.Application.Contracts.Identity;
using Nutri.Application.Models;
using Nutri.Application.Models.Identity;

namespace NutriAPI.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class AccountController:ControllerBase
    {
        private readonly IAuthService _authService;

        public AccountController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("Login")]
        public async Task<ActionResult<AuthResponse>> Login([FromBody] AuthRequest request)
        {
            return Ok( await _authService.Login(request));
        }

        [HttpPost("Register")]
        public async Task<ActionResult<RegistrationResponse>> Register([FromBody] RegistrationRequest request)
        {
            return Ok(await _authService.Register(request));
        }
    }
}
