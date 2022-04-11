using System.Threading.Tasks;
using GestaoAcesso.Application.Commands.LoginUser;
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
    }
}