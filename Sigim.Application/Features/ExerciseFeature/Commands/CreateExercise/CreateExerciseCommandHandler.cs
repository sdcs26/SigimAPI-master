using AutoMapper;
using Complii.Application.Contracts.Persistence;
using Complii.Application.Exceptions;
using MediatR;
using Sigim.Application.Models;
using Sigim.Domain;

namespace Sigim.Application.Features.ExerciseFeature.Commands.CreateExercise
{
    public class CreateExerciseCommandHandler : IRequestHandler<CreateExerciseCommand, ApiResult<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateExerciseCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ApiResult<bool>> Handle(CreateExerciseCommand request, CancellationToken cancellationToken)
        {
            var excercice = _mapper.Map<Exercise>(request);
            _unitOfWork.Repository<Exercise>().AddEntity(excercice);
            await _unitOfWork.Complete();
            return new ApiResult<bool>(true);
        }
    }
}
