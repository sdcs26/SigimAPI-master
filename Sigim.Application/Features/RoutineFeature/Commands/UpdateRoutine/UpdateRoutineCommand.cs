using MediatR;
using Sigim.Application.Models;

namespace Sigim.Application.Features.RoutineFeature.Commands.UpdateRoutine
{
    public class UpdateRoutineCommand : IRequest<ApiResult<bool>>
    {
        public string Id { get; set; } = string.Empty;
        public string Titulo { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
    }
}
