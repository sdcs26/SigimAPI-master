using AutoMapper;
using Complii.Application.Contracts.Persistence;
using MediatR;
using Sigim.Application.Models;
using Sigim.Domain;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Sigim.Application.Features.RoutineExerciseFeature.Queries.GetAllRoutinesExercises
{
    public class GetAllRoutinesExercisesQueryHandler : IRequestHandler<GetAllRoutinesExercisesQuery, ApiResult<List<RoutineResult>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllRoutinesExercisesQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ApiResult<List<RoutineResult>>> Handle(GetAllRoutinesExercisesQuery request, CancellationToken cancellationToken)
        {
            var routinesWithExercises = await _unitOfWork.Repository<Routine>().GetAsync(
                includeString: new List<string>() { "RoutineExercises", "RoutineExercises.Exercises" }
            );
            var result = _mapper.Map<List<RoutineResult>>(routinesWithExercises);
            return new ApiResult<List<RoutineResult>>(result);
        }

        /*
         * var routinesWithExercises = await _unitOfWork.Repository<RoutineExercise>().GetAllAsync(
                includes: new List<System.Linq.Expressions.Expression<Func<RoutineExercise, object>>>
                {
                    i => i.Routines,
                    i => i.Exercises
                }
            );
        */
    }
}
