using AutoMapper;
using Complii.Application.Contracts.Persistence;
using MediatR;
using Sigim.Application.Models;
using Sigim.Domain;
using System.Collections.Generic;

namespace Sigim.Application.Features.IncomeFeature.Queries.GetAllIncome
{
    public class GetAllIncomeQueryHandler : IRequestHandler<GetAllIncomeQuery, ApiResult<List<IncomeResult>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        
        public GetAllIncomeQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ApiResult<List<IncomeResult>>> Handle(GetAllIncomeQuery request, CancellationToken cancellationToken)
        {
            var incomes = await _unitOfWork.Repository<Income>().GetAllAsync(
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
