using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sigim.Application.Features.RoutineExerciseFeature.Commands.CreateRoutineExercise;
using Sigim.Application.Features.RoutineExerciseFeature.Commands.DeleteRoutineExercise;
using Sigim.Application.Features.RoutineExerciseFeature.Commands.UpdateRoutineExercise;
using Sigim.Application.Features.RoutineExerciseFeature.Queries.GetAllRoutinesExercises;
using Sigim.Application.Features.RoutineExerciseFeature.Queries.GetRoutineExercises;
using Sigim.Application.Models;
using Sigim.Domain;

namespace Sigim.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoutineExerciseController : ControllerBase
    {
        private IMediator _mediator;
        public RoutineExerciseController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{idRutina}")]
        public async Task<ActionResult<ApiResult<RoutineResult>>> GetRoutineExercises(string idRutina)
        {
            return Ok(await _mediator.Send(new GetRoutineExercisesQuery { IdRutina = idRutina }));
        }

        [HttpGet]
        public async Task<ActionResult<ApiResult<RoutineResult>>> GetAllRoutinesExercises()
        {
            return Ok(await _mediator.Send(new GetAllRoutinesExercisesQuery()));
        }

        [HttpPost]
        public async Task<ActionResult<ApiResult<bool>>> CreateRoutineExercises([FromBody] CreateRoutineExerciseCommand request)
        {
            return Ok(await _mediator.Send(request));
        }

        [HttpPut]
        public async Task<ActionResult<ApiResult<bool>>> UpdateRoutineExercise([FromBody] UpdateRoutineExerciseCommand request)
        {
            return Ok(await _mediator.Send(request));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ApiResult<bool>>> DeleteRoutineExercise(string id)
        {
            return Ok(await _mediator.Send(new DeleteRoutineExerciseCommand { Id = id }));
        }
    }
}
