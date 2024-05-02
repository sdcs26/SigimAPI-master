using MediatR;
using Microsoft.AspNetCore.Mvc;
using Sigim.Application.Features.RoutineFeature.Commands.CreateRoutine;
using Sigim.Application.Features.RoutineFeature.Commands.DeleteRoutine;
using Sigim.Application.Features.RoutineFeature.Commands.UpdateRoutine;
using Sigim.Application.Features.RoutineFeature.Queries.GetAllRoutines;
using Sigim.Application.Features.RoutineFeature.Queries.GetRoutine;
using Sigim.Application.Models;

namespace Sigim.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(Roles = "administrador,entrenador")]
    public class RoutineController : ControllerBase
    {
        private IMediator _mediator;
        public RoutineController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ApiResult<RoutineResult>>> GetRoutine(string id)
        {
            return Ok(await _mediator.Send(new GetRoutineQuery { Id = id }));
        }

        [HttpGet]
        public async Task<ActionResult<ApiResult<List<RoutineResult>>>> GetAllRoutines()
        {
            return Ok(await _mediator.Send(new GetAllRoutinesQuery()));
        }

        [HttpPost]
        public async Task<ActionResult<ApiResult<bool>>> CreateRoutine([FromBody] CreateRoutineCommand request)
        {
            return Ok(await _mediator.Send(request));
        }

        [HttpPut]
        public async Task<ActionResult<ApiResult<bool>>> UpdateRoutine([FromBody] UpdateRoutineCommand request)
        {
            return Ok(await _mediator.Send(request));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ApiResult<bool>>> DeleteRoutine(string id)
        {
            return Ok(await _mediator.Send(new DeleteRoutineCommand { Id = id }));
        }
    }
}
