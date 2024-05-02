using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sigim.Application.Features.UserFeature.queries.GetAllUsers;
using Sigim.Application.Models;

namespace Sigim.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<ApiResult<List<UserResult>>>> GetAllUsers()
        {
            return Ok(await _mediator.Send(new GetAllUsersQuery()));
        }
    }
}
