
using MediatR;
using Sigim.Application.Models;

namespace Sigim.Application.Features.UserRoutineFeature.Queries.GetAllRoutinesPerUser
{
    public class GetAllRoutinesPerUserQuery : IRequest<ApiResult<List<UserRoutineResult>>>
    {
    }
}
