using AutoMapper;
using Complii.Application.Contracts.Persistence;
using Complii.Application.Exceptions;
using MediatR;
using Sigim.Application.Contracts.Infrastructure;
using Sigim.Application.Models;
using Sigim.Application.Models.Settings;
using Sigim.Domain;

namespace Sigim.Application.Features.ExerciseFeature.Commands.DeleteExercise
{
    public class DeleteExerciseCommandHandler : IRequestHandler<DeleteExerciseCommand, ApiResult<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteExerciseCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ApiResult<bool>> Handle(DeleteExerciseCommand request, CancellationToken cancellationToken)
        {
            var existingExercise = (await _unitOfWork.Repository<Exercise>().GetAsync(q=>q.Id.Equals(request.Id))).FirstOrDefault();

            if (existingExercise == null)
            {
                throw new BadRequestException($"NOT_EXISTS");
            }

            _unitOfWork.Repository<Exercise>().DeleteEntity(existingExercise);
            await _unitOfWork.Complete();
            return new ApiResult<bool>(true);
        }
    }
}
