using AutoMapper;
using Complii.Application.Contracts.Persistence;
using MediatR;
using Sigim.Application.Models;
using Sigim.Domain;

namespace Sigim.Application.Features.IncomeFeature.Queries.GetIncomesBetweenDates
{
    public class GetIncomesBetweenDatesQueryHandler : IRequestHandler<GetIncomesBetweenDatesQuery, ApiResult<List<IncomeResult>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetIncomesBetweenDatesQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ApiResult<List<IncomeResult>>> Handle(GetIncomesBetweenDatesQuery request, CancellationToken cancellationToken)
        {
            var incomes = await _unitOfWork.Repository<Income>().GetAllAsync(
                filter: u => u.Fecha >= request.FechaInicio && u.Fecha <= request.FechaFin,
                includes: new List<System.Linq.Expressions.Expression<Func<Income, object>>>
                {
                    i=>i.Usuario!,
                    i=>i.Usuario!.Rol!
                }
            );
            var result = _mapper.Map<List<IncomeResult>>(incomes);
            return new ApiResult<List<IncomeResult>>(result);
        }
    }
}
