using MediatR;
using Sigim.Application.Models;

namespace Sigim.Application.Features.RoutineExerciseFeature.Commands.UpdateRoutineExercise
{
    public class UpdateRoutineExerciseCommand : IRequest<ApiResult<bool>>
    {
        public string Id { get; set; } = string.Empty;
        public string EjercicioId { get; set; } = string.Empty;
        public string RutinaId { get; set; } = string.Empty;
        public int Series { get; set; }
        public int Cantidad { get; set; }
        public bool IsTime { get; set; }
    }
}
