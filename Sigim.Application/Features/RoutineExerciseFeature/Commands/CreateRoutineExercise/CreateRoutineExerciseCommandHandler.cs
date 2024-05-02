using AutoMapper;
using Complii.Application.Contracts.Persistence;
using MediatR;
using Sigim.Application.Models;
using Sigim.Domain;

namespace Sigim.Application.Features.RoutineExerciseFeature.Commands.CreateRoutineExercise
{
    public class CreateRoutineExerciseCommandHandler : IRequestHandler<CreateRoutineExerciseCommand, ApiResult<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateRoutineExerciseCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ApiResult<bool>> Handle(CreateRoutineExerciseCommand request, CancellationToken cancellationToken)
        {
            var list = _mapper.Map<List<RoutineExercise>>(request.RoutineExercises);
            _unitOfWork.Repository<RoutineExercise>().AddListEntity(list);
            await _unitOfWork.Complete();
            return new ApiResult<bool>(true);
        }
    }
}
