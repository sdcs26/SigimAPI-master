using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sigim.Application.Features.AuthFeature.commands.LoginUser;
using Sigim.Application.Features.AuthFeature.commands.RegisterUser;
using Sigim.Application.Models;
using Sigim.Application.Models.Identity;

namespace Sigim.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IMediator _mediator;
        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpPost("Login")]
        public async Task<ActionResult<ApiResult<AuthResponse>>> Login([FromBody] LoginUserCommand request)
        {
            return Ok(await _mediator.Send(request));
        }

        [HttpPost("Register")]
        public async Task<ActionResult<ApiResult<bool>>> Register([FromBody] RegisterUserCommand request)
        {
            return Ok(await _mediator.Send(request));
        }
    }
}
