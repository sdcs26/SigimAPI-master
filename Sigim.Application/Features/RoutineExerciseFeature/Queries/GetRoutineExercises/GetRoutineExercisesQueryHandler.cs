using AutoMapper;
using Complii.Application.Contracts.Persistence;
using MediatR;
using Sigim.Application.Models;
using Sigim.Domain;

namespace Sigim.Application.Features.RoutineExerciseFeature.Queries.GetRoutineExercises
{
    public class GetRoutineExercisesQueryHandler : IRequestHandler<GetRoutineExercisesQuery, ApiResult<List<RoutineResult>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetRoutineExercisesQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ApiResult<List<RoutineResult>>> Handle(GetRoutineExercisesQuery request, CancellationToken cancellationToken)
        {
            var routineExercises = await _unitOfWork.Repository<Routine>().GetAsync(q => q.Id.Equals(request.IdRutina),
                includeString: new List<string>() { "RoutineExercises", "RoutineExercises.Exercises" }
            );
            var result = _mapper.Map<List<RoutineResult>>(routineExercises);
            return new ApiResult<List<RoutineResult>>(result);
        }
    }
}
