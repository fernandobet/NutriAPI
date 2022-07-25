using MediatR;
using Microsoft.AspNetCore.Mvc;
using Nutri.Application.Contracts.Persistence;
using Nutri.Application.Features.Users.Commands.AddUser;
using Nutri.Application.Features.Users.Queries.GetUser;
using Nutri.Application.Features.Users.Queries.GetUsers;
using Nutri.Domain.Models;

namespace NutriAPI.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class UsersController:ControllerBase
    {
        private readonly IMediator _mediator;
        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("GetUsuarios")]
        public async Task<ActionResult<IEnumerable<Usuario>>> GetUsuarios()
        {
            var usuarios = await _mediator.Send(new GetUsersQuery());
            return Ok(usuarios);
        }
        [HttpPost]
        [Route("iniciarSesion")]
        public async Task<IActionResult> iniciarSesion(Usuario usuario)
        {
            var user = await _mediator.Send(usuario);
            return Ok(user);
        }
        [HttpGet()]
        [Route("getUsuario/{id}")]
        public async Task<IActionResult> getUsuario(int id)
        {
            var user = await _mediator.Send(new GetUserQuery() { Id = id });
            return Ok(user);
        }
        [HttpPost(Name = "addUser")]
        public async Task<ActionResult> addUser(Usuario usuario)
        {
            await _mediator.Send(new AddUserCommand());
            return Ok();
        }
    }
}
