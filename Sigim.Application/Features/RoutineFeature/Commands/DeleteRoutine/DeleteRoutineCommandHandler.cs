
using Complii.Application.Contracts.Persistence;
using Complii.Application.Exceptions;
using MediatR;
using Sigim.Application.Models;
using Sigim.Domain;

namespace Sigim.Application.Features.RoutineFeature.Commands.DeleteRoutine
{
    public class DeleteRoutineCommandHandler : IRequestHandler<DeleteRoutineCommand, ApiResult<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteRoutineCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ApiResult<bool>> Handle(DeleteRoutineCommand request, CancellationToken cancellationToken)
        {
            var existingRoutine = (await _unitOfWork.Repository<Routine>().GetAsync(q => q.Id.Equals(request.Id))).FirstOrDefault();
            if (existingRoutine == null)
            {
                throw new NotFoundException("NOT FOUND", request.Id);
            }
            _unitOfWork.Repository<Routine>().DeleteEntity(existingRoutine);
            await _unitOfWork.Complete();
            return new ApiResult<bool>(true);
        }
    }
}
