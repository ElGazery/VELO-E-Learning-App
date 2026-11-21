using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Velo.Application.Features.Auth.Commands.ConfirmEmailCommand;
using Velo.Application.Features.Auth.Commands.LoginCommand;
using Velo.Application.Features.Auth.Commands.RegisterCommand;

namespace Velo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("Register")]
        public async Task<ActionResult> Register(RegisterCommand command)
        {
            var result = await _mediator.Send(command);
            return StatusCode(result.StatusCode,result);
        }
        [HttpPost("Login")]
        public async Task<ActionResult> Login(LoginCommand command)
        {
            var result = await _mediator.Send(command);
            return StatusCode(result.StatusCode, result);
        }

        [HttpPost("Confrim-Email")]
        public async Task<ActionResult> ConfirmEmail(ConfirmEmailCommand command)
        {
            var result = await _mediator.Send(command);
            return StatusCode(result.StatusCode, result);


        }
    }
}
