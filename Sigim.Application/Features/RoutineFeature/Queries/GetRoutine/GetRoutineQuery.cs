using MediatR;
using Sigim.Application.Models;

namespace Sigim.Application.Features.RoutineFeature.Queries.GetRoutine
{
    public class GetRoutineQuery : IRequest<ApiResult<RoutineResult>>
    {
        public string Id { get; set; } = string.Empty;
    }
}
