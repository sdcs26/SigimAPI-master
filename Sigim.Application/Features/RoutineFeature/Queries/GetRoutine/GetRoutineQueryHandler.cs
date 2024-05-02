
using AutoMapper;
using Complii.Application.Contracts.Persistence;
using Complii.Application.Exceptions;
using MediatR;
using Sigim.Application.Models;
using Sigim.Domain;

namespace Sigim.Application.Features.RoutineFeature.Queries.GetRoutine
{
    public class GetRoutineQueryHandler : IRequestHandler<GetRoutineQuery, ApiResult<RoutineResult>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetRoutineQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ApiResult<RoutineResult>> Handle(GetRoutineQuery request, CancellationToken cancellationToken)
        {
            var existingRoutine = (await _unitOfWork.Repository<Routine>().GetAsync(q => q.Id.Equals(request.Id))).FirstOrDefault();
            if (existingRoutine == null)
            {
                throw new NotFoundException("NOT FOUND", request.Id);
            }
            var result = _mapper.Map<RoutineResult>(existingRoutine);
            return new ApiResult<RoutineResult>(result);
        }
    }
}
