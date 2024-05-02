using MediatR;
using Sigim.Application.Models;

namespace Sigim.Application.Features.ExerciseFeature.Commands.CreateExercise
{
    public class CreateExerciseCommand : IRequest<ApiResult<bool>>
    {
        public string Titulo {  get; set; } = string.Empty;
        public string Descripcion {  get; set; } = string.Empty;
        public string EnlaceAnimacion {  get; set; } = string.Empty;
    }
}