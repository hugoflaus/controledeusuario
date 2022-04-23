using System;
using System.Net;
using System.Threading.Tasks;
using GestaoAcesso.Application.Commands.ActiveUser;
using GestaoAcesso.Application.Commands.CreateUser;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GestaoAcesso.API.Controllers
{
    [Route("api/users")]
    public class UsuarioController : ControllerBase
    {
        private readonly IMediator _mediator;
        public UsuarioController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> CreateUserAccount([FromBody] CreateUserCommand model)
        {
            var resulado = await _mediator.Send(model);

            if (resulado.IsFailed)
            {
                return StatusCode(500);
            }

            return Ok(resulado.Successes);
        }


        [HttpPost]
        [Route("active")]
        public async Task<IActionResult> ActivateUserAccount([FromQuery] ActiveUserCommand model)
        {
            var resulado = await _mediator.Send(model);

            if (resulado.IsFailed)
            {
                return StatusCode(500);
            }

            return Ok(resulado.Successes);
        }


    }
}