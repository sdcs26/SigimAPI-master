using MediatR;
using Sigim.Application.Models;

namespace Sigim.Application.Features.UserFeature.queries.GetAllUsers
{
    public class GetAllUsersQuery : IRequest<ApiResult<List<UserResult>>>
    {
    }
}
