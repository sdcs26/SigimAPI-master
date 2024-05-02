using Complii.Application.Contracts.Persistence;
using Complii.Application.Exceptions;
using MediatR;
using Sigim.Application.Models;
using Sigim.Domain;

namespace Sigim.Application.Features.RoutineExerciseFeature.Commands.DeleteRoutineExercise
{
    public class DeleteRoutineExerciseCommandHandler : IRequestHandler<DeleteRoutineExerciseCommand, ApiResult<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteRoutineExerciseCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ApiResult<bool>> Handle(DeleteRoutineExerciseCommand request, CancellationToken cancellationToken)
        {
            var exitingRoutineExercise = (await _unitOfWork.Repository<RoutineExercise>().GetAsync(q => q.Id.Equals(request.Id))).FirstOrDefault();
            if (exitingRoutineExercise == null)
            {
                throw new NotFoundException("NOT FOUND", request.Id);
            }
            _unitOfWork.Repository<RoutineExercise>().DeleteEntity(exitingRoutineExercise);
            await _unitOfWork.Complete();
            return new ApiResult<bool>(true);
        }
    }
}
