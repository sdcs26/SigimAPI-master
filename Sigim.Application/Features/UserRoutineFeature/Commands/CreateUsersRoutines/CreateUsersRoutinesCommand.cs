using MediatR;
using Sigim.Application.Models;
using Sigim.Application.Models.Request;

namespace Sigim.Application.Features.UserRoutineFeature.Commands.CreateUsersRoutines
{
    public class CreateUsersRoutinesCommand : IRequest<ApiResult<bool>>
    {
        public ICollection<UserRoutineRequest> UserRoutine {  get; set; }

        public CreateUsersRoutinesCommand() {
            UserRoutine = new List<UserRoutineRequest>();
        }
    }
}
