using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Nutri.Application.Constants;
using Nutri.Application.Contracts.Identity;
using Nutri.Application.Models;
using Nutri.Application.Models.Identity;
using NutriApp.Identity.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace NutriApp.Identity.Services
{
    public class AuthService : IAuthService
    {
        //Objeto para consultar data de usuarios.
        private readonly UserManager<ApplicationUser> _userManager;
        //Objeto para hacer validacion de credenciales
        private readonly SignInManager<ApplicationUser> _signInManager;
        //Para crear el token
        private readonly JwtSettings _jwtSettings;

        public AuthService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IOptions<JwtSettings> jwtSettings)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _jwtSettings = jwtSettings.Value;
        }

        public async Task<AuthResponse> Login(AuthRequest request)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user == null)
                throw new Exception($"El usuario con email {request.Email} no existe");
            var resultado = await _signInManager.PasswordSignInAsync(user.UserName, request.Password, false, lockoutOnFailure: false);
            if (!resultado.Succeeded)
                throw new Exception($"Las credenciales son incorrectas");
            var token = await generateToken(user);
            var authResponse = new AuthResponse { 
                Id = user.Id,
                UserName = user.UserName,
                Token =new JwtSecurityTokenHandler().WriteToken(token),
                Email = user.Email
            };
            return authResponse;
        }

        public async Task<RegistrationResponse> Register(RegistrationRequest request)
        {
            var existingUser = await _userManager.FindByNameAsync(request.Username);
            if (existingUser != null)
                throw new Exception($"El username ya fue tomado por otra cuenta");
            var existingEmail = await _userManager.FindByEmailAsync(request.Email);
            if (existingEmail != null)
                throw new Exception($"El email ya fue tomado por otra cuenta");

            var user = new ApplicationUser { 
                Email = request.Email,
                Nombre = request.Nombre,
                Apellidos = request.Apellidos,
                UserName = request.Username,
                EmailConfirmed = true
            };
            var result = await _userManager.CreateAsync(user);
            if(result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "Operator");
                var token = await generateToken(user);

                return new RegistrationResponse { 
                    Email = user.Email,
                    Token = new JwtSecurityTokenHandler().WriteToken(token),
                    UserId = user.Id,
                    UserName = user.UserName,   
                };
            }
            throw new Exception($"{result.Errors}");
        }

        private async Task<JwtSecurityToken> generateToken(ApplicationUser user)
        {
            var userClaims = await _userManager.GetClaimsAsync(user);
            var roles = await _userManager.GetRolesAsync(user);

            var roleClaims = new List<Claim>();

            foreach (var rol in roles)
            {
                roleClaims.Add(new Claim(ClaimTypes.Role, rol));
            }

            var claims = new[] {
                new Claim(JwtRegisteredClaimNames.Sub,user.UserName),
                new Claim(JwtRegisteredClaimNames.Email,user.Email),
                new Claim(CustomClaimTypes.Uid, user.Id)
            }.Union(userClaims).Union(roleClaims).ToArray();

            var symetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes( _jwtSettings.Key));
            var signinCredentials = new SigningCredentials(symetricSecurityKey, SecurityAlgorithms.HmacSha256);
            var jwtSecurityToken = new JwtSecurityToken(
                    issuer : _jwtSettings.Issuer,
                    audience : _jwtSettings.Audience,
                    claims : claims,
                    expires: DateTime.UtcNow.AddMinutes(_jwtSettings.DurationInMinutes),
                    signingCredentials : signinCredentials
                );
            return jwtSecurityToken;
        }
    }
}
