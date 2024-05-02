using MediatR;
using Sigim.Application.Models;

namespace Sigim.Application.Features.RoutineFeature.Queries.GetAllRoutines
{
    public class GetAllRoutinesQuery : IRequest<ApiResult<List<RoutineResult>>>
    {
    }
}
