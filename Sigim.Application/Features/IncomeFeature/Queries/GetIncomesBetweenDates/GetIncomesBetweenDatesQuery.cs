using MediatR;
using Sigim.Application.Models;

namespace Sigim.Application.Features.IncomeFeature.Queries.GetIncomesBetweenDates
{
    public class GetIncomesBetweenDatesQuery : IRequest<ApiResult<List<IncomeResult>>>
    {
        public DateTimeOffset FechaInicio { get; set; }
        public DateTimeOffset FechaFin { get; set; }

    }
}
