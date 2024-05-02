using AutoMapper;
using Complii.Application.Contracts.Persistence;
using Complii.Application.Exceptions;
using MediatR;
using Sigim.Application.Contracts.Infrastructure;
using Sigim.Application.Models;
using Sigim.Application.Models.Settings;
using Sigim.Domain;

namespace Sigim.Application.Features.ExerciseFeature.Commands.UpdateExercise
{
    public class UpdateExerciseCommandHandler : IRequestHandler<UpdateExerciseCommand, ApiResult<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateExerciseCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ApiResult<bool>> Handle(UpdateExerciseCommand request, CancellationToken cancellationToken)
        {
            var existingExercise = (await _unitOfWork.Repository<Exercise>()
                .GetAsync(q => q.Id.Equals(request.Id) || !q.Titulo.Equals(request.Titulo)))
                .FirstOrDefault();

            if (existingExercise == null)
            {
                throw new BadRequestException($"ALREADY_EXISTS");
            }
            _unitOfWork.Repository<Exercise>().DetachEntity(existingExercise);

            var updatedExercise = _mapper.Map<Exercise>(request);
            _unitOfWork.Repository<Exercise>().UpdateEntity(updatedExercise);
            await _unitOfWork.Complete();
            return new ApiResult<bool>(true);
        }
    }
}