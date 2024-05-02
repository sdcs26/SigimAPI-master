using MediatR;
using Sigim.Application.Models;

namespace Sigim.Application.Features.RoutineExerciseFeature.Commands.DeleteRoutineExercise
{
    public class DeleteRoutineExerciseCommand : IRequest<ApiResult<bool>>
    {
        public string Id { get; set; } = string.Empty;
    }
}
