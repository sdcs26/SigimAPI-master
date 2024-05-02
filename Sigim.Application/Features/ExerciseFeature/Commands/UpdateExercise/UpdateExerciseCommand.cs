using MediatR;
using Sigim.Application.Models;

namespace Sigim.Application.Features.ExerciseFeature.Commands.UpdateExercise
{
    public class UpdateExerciseCommand : IRequest<ApiResult<bool>>
    {
        public string Id { get; set; } = string.Empty;
        public string Titulo { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public string EnlaceAnimacion { get; set; } = string.Empty;
    }
}
