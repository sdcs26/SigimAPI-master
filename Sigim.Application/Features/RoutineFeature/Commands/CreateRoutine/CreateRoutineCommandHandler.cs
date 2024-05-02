using AutoMapper;
using Complii.Application.Contracts.Persistence;
using MediatR;
using Sigim.Application.Models;
using Sigim.Domain;

namespace Sigim.Application.Features.RoutineFeature.Commands.CreateRoutine
{
    public class CreateRoutineCommandHandler : IRequestHandler<CreateRoutineCommand, ApiResult<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateRoutineCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<ApiResult<bool>> Handle(CreateRoutineCommand request, CancellationToken cancellationToken)
        {
            var routine = _mapper.Map<Routine>(request);
            _unitOfWork.Repository<Routine>().AddEntity(routine);
            await _unitOfWork.Complete();
            return new ApiResult<bool>(true);
        }
    }
}
