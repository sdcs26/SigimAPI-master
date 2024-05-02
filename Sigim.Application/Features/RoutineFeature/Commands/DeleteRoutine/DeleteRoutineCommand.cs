using MediatR;
using Sigim.Application.Models;

namespace Sigim.Application.Features.RoutineFeature.Commands.DeleteRoutine
{
    public class DeleteRoutineCommand : IRequest<ApiResult<bool>>
    {
        public string Id { get; set; } = string.Empty;
    }
}
