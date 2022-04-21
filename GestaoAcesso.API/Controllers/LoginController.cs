using System.Threading.Tasks;
using GestaoAcesso.Application.Commands.LoginUser;
using GestaoAcesso.Application.Commands.RequestPasswordChange;
using GestaoAcesso.Application.Commands.ResetPassword;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GestaoAcesso.API.Controllers
{
    [Route("api/login")]
    public class LoginController : ControllerBase
    {
        private readonly IMediator _mediator;
        public LoginController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginUserCommand model)
        {
            var resulado = await _mediator.Send(model);

            if (resulado.IsFailed)
            {
                return Unauthorized(resulado.Errors);
            }

            return Ok(resulado.Successes);
        }

        [HttpPost("requestpasswordchange")]
        public async Task<IActionResult> RequestPasswordChange([FromBody] RequestPasswordChangeCommand model)
        {
            var resulado = await _mediator.Send(model);

            if (resulado.IsFailed)
            {
                return Unauthorized(resulado.Errors);
            }

            return Ok(resulado.Successes);
        }

        [HttpPost("resetpassword")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordCommand model)
        {
            var resulado = await _mediator.Send(model);

            if (resulado.IsFailed)
            {
                return Unauthorized(resulado.Errors);
            }

            return Ok(resulado.Successes);
        }
    }
}