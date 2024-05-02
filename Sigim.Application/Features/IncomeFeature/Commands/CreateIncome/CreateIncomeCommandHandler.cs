using AutoMapper;
using Complii.Application.Contracts.Persistence;
using MediatR;
using Sigim.Application.Models;
using Sigim.Domain;

namespace Sigim.Application.Features.IncomeFeature.Commands.CreateIncome
{
    public class CreateIncomeCommandHandler : IRequestHandler<CreateIncomeCommand, ApiResult<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateIncomeCommandHandler (IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ApiResult<bool>> Handle(CreateIncomeCommand request, CancellationToken cancellationToken)
        {
            var income = _mapper.Map<Income>(request);
            _unitOfWork.Repository<Income>().AddEntity(income);
            await _unitOfWork.Complete();
            return new ApiResult<bool>(true);
        }
    }
}
