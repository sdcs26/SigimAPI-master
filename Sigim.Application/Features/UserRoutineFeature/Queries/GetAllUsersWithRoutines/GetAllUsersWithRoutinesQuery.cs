using MediatR;
using Sigim.Application.Models;
using System.Collections.Generic;

namespace Sigim.Application.Features.UserRoutineFeature.Queries.GetAllUsersWithRoutines
{
    public class GetAllUsersWithRoutinesQuery : IRequest<ApiResult<List<UserResult>>>
    {
    }
}
