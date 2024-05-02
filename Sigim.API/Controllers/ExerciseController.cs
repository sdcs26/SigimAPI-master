using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sigim.Application.Features.ExerciseFeature.Commands.CreateExercise;
using Sigim.Application.Features.ExerciseFeature.Commands.UpdateExercise;
using Sigim.Application.Features.ExerciseFeature.Commands.DeleteExercise;
using Sigim.Application.Features.ExerciseFeature.Queries.GetAllExercises;
using Sigim.Application.Models;

namespace Sigim.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(Roles = "administrador,entrenador")]
    public class ExerciseController : ControllerBase
    {
        private IMediator _mediator;

        public ExerciseController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<ApiResult<bool>>> CreateExcercise([FromBody] CreateExerciseCommand request)
        {
            return Ok(await _mediator.Send(request));
        }

        [HttpGet]
        public async Task<ActionResult<ApiResult<List<ExerciseResult>>>> GetAllExercises()
        {
            return Ok(await _mediator.Send(new GetAllExercisesQuery()));
        }

        [HttpPut]
        public async Task<ActionResult<ApiResult<bool>>> UpdateExercise([FromBody] UpdateExerciseCommand request)
        {
            return Ok(await _mediator.Send(request));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ApiResult<bool>>> DeleteExercise(string id)
        {
            return Ok(await _mediator.Send(new DeleteExerciseCommand { Id = id }));
        }
    }
}
