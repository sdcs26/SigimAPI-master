using MediatR;
using Sigim.Application.Models;
using Sigim.Application.Models.Request;
using Sigim.Domain;

namespace Sigim.Application.Features.RoutineExerciseFeature.Commands.CreateRoutineExercise
{
    public class CreateRoutineExerciseCommand : IRequest<ApiResult<bool>>
    {
        public ICollection<RoutineExerciseRequest> RoutineExercises { get; set; }

        public CreateRoutineExerciseCommand()
        {
            RoutineExercises = new HashSet<RoutineExerciseRequest>();
        }
    }
}
