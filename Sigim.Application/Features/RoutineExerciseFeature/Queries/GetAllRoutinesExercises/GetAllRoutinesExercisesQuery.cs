using MediatR;
using Sigim.Application.Models;
using Sigim.Domain;

namespace Sigim.Application.Features.RoutineExerciseFeature.Queries.GetAllRoutinesExercises
{
    public class GetAllRoutinesExercisesQuery : IRequest<ApiResult<List<RoutineResult>>>
    {
    }
}
