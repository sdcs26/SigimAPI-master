using MediatR;
using Sigim.Application.Models;

namespace Sigim.Application.Features.ExerciseFeature.Queries.GetAllExercises
{
    public class GetAllExercisesQuery : IRequest<ApiResult<List<ExerciseResult>>>
    {
    }
}
