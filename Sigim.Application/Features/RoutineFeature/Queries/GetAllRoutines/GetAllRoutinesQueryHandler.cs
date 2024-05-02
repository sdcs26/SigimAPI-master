using AutoMapper;
using Complii.Application.Contracts.Persistence;
using MediatR;
using Sigim.Application.Models;
using Sigim.Domain;

namespace Sigim.Application.Features.RoutineFeature.Queries.GetAllRoutines
{
    public class GetAllRoutinesQueryHandler : IRequestHandler<GetAllRoutinesQuery, ApiResult<List<RoutineResult>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllRoutinesQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ApiResult<List<RoutineResult>>> Handle(GetAllRoutinesQuery request, CancellationToken cancellationToken)
        {
            var routines = await _unitOfWork.Repository<Routine>().GetAllAsync();
            var result = _mapper.Map<List<RoutineResult>>(routines);
            return new ApiResult<List<RoutineResult>>(result);
        }
    }
}
