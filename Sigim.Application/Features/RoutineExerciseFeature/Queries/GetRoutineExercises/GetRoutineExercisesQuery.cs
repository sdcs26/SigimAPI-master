using MediatR;
using Sigim.Application.Models;

namespace Sigim.Application.Features.RoutineExerciseFeature.Queries.GetRoutineExercises
{
    public class GetRoutineExercisesQuery : IRequest<ApiResult<List<RoutineResult>>>
    {
        public string IdRutina {  get; set; } = string.Empty;
    }
}
