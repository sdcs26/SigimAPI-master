using MediatR;
using Sigim.Application.Models;

namespace Sigim.Application.Features.RoutineFeature.Commands.CreateRoutine
{
    public class CreateRoutineCommand : IRequest<ApiResult<bool>>
    {
        public string Titulo { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
    }
}
