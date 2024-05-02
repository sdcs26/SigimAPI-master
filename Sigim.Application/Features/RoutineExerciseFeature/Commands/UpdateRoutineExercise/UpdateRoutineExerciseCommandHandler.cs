using AutoMapper;
using Complii.Application.Contracts.Persistence;
using Complii.Application.Exceptions;
using MediatR;
using Sigim.Application.Models;
using Sigim.Domain;

namespace Sigim.Application.Features.RoutineExerciseFeature.Commands.UpdateRoutineExercise
{
    public class UpdateRoutineExerciseCommandHandler : IRequestHandler<UpdateRoutineExerciseCommand, ApiResult<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateRoutineExerciseCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ApiResult<bool>> Handle(UpdateRoutineExerciseCommand request, CancellationToken cancellationToken)
        {
            var exitingRoutineExercise = (await _unitOfWork.Repository<RoutineExercise>().GetAsync(q => q.Id.Equals(request.Id))).FirstOrDefault();
            if (exitingRoutineExercise == null)
            {
                throw new NotFoundException("NOT FOUND", request.Id);
            }
            _unitOfWork.Repository<RoutineExercise>().DetachEntity(exitingRoutineExercise);
            var updateRoutineExercise = _mapper.Map<RoutineExercise>(request);
            _unitOfWork.Repository<RoutineExercise>().UpdateEntity(updateRoutineExercise);
            await _unitOfWork.Complete();
            return new ApiResult<bool>(true);
        }
    }
}
