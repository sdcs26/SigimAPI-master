using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sigim.Application.Features.UserRoutineFeature.Commands.CreateUserRoutine;
using Sigim.Application.Features.UserRoutineFeature.Commands.CreateUsersRoutines;
using Sigim.Application.Features.UserRoutineFeature.Queries.GetAllRoutinesPerUser;
using Sigim.Application.Features.UserRoutineFeature.Queries.GetAllUsersWithRoutines;
using Sigim.Application.Models;

namespace Sigim.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserRoutineController : ControllerBase
    {
        private IMediator _mediator;
        public UserRoutineController(IMediator mediator)
        {
            _mediator = mediator;
        }
        /*
        [HttpGet]
        public async Task<ActionResult<ApiResult<UserResult>>> GetAllUsersWithRoutines()
        {
            return Ok(await _mediator.Send(new GetAllUsersWithRoutinesQuery()));
        }
        */

        [HttpGet]
        [Authorize(Roles = "Deportista")]
        public async Task<ActionResult<ApiResult<List<UserRoutineResult>>>> GetRoutinesPerUser()
        {
            return Ok(await _mediator.Send(new GetAllRoutinesPerUserQuery()));
        }

        [HttpPost]
        public async Task<ActionResult<ApiResult<bool>>> CreateUserRoutine([FromBody] CreateUserRoutineCommand request)
        {
            return Ok(await _mediator.Send(request));
        }

        [HttpPost]
        [Route("List")]
        public async Task<ActionResult<ApiResult<bool>>> CreateUsersRoutines([FromBody] CreateUsersRoutinesCommand request)
        {
            return Ok(await _mediator.Send(request));
        }

    }
}
