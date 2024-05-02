using MediatR;
using Sigim.Application.Models;

namespace Sigim.Application.Features.IncomeFeature.Queries.GetAllIncome
{
    public class GetAllIncomeQuery : IRequest<ApiResult<List<IncomeResult>>>
    {
    }
}
