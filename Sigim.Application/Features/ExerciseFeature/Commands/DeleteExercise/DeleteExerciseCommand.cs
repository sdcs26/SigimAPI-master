using MediatR;
using Sigim.Application.Models;

namespace Sigim.Application.Features.ExerciseFeature.Commands.DeleteExercise
{
    public class DeleteExerciseCommand : IRequest<ApiResult<bool>>
    {
        public string Id { get; set; } = string.Empty;
    }
}
