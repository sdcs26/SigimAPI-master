using MediatR;
using Sigim.Application.Models;

namespace Sigim.Application.Features.HistoryFeature.queries.GetAllHistory
{
    public class GetAllHistoryQuery : IRequest<ApiResult<List<HistoryResult>>>
    {
    }
}
