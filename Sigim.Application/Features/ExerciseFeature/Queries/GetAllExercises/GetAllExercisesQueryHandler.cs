using AutoMapper;
using Complii.Application.Contracts.Persistence;
using MediatR;
using Sigim.Application.Contracts.Infrastructure;
using Sigim.Application.Models;
using Sigim.Application.Models.Settings;
using Sigim.Domain;

namespace Sigim.Application.Features.ExerciseFeature.Queries.GetAllExercises
{
    public class GetAllExercisesQueryHandler : IRequestHandler<GetAllExercisesQuery, ApiResult<List<ExerciseResult>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllExercisesQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ApiResult<List<ExerciseResult>>> Handle(GetAllExercisesQuery request, CancellationToken cancellationToken)
        {
            var exercices = await _unitOfWork.Repository<Exercise>().GetAllAsync();
            var result = _mapper.Map<List<ExerciseResult>>(exercices);
            return new ApiResult<List<ExerciseResult>>(result);
        }
    }
}