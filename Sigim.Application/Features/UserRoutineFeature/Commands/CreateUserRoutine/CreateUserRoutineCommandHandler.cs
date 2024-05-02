using AutoMapper;
using Complii.Application.Contracts.Persistence;
using MediatR;
using Sigim.Application.Models;
using Sigim.Domain;

namespace Sigim.Application.Features.UserRoutineFeature.Commands.CreateUserRoutine
{
    public class CreateUserRoutineCommandHandler : IRequestHandler<CreateUserRoutineCommand, ApiResult<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateUserRoutineCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ApiResult<bool>> Handle(CreateUserRoutineCommand request, CancellationToken cancellationToken)
        {
            var userRoutine = _mapper.Map<UserRoutine>(request);
            _unitOfWork.Repository<UserRoutine>().AddEntity(userRoutine);
            await _unitOfWork.Complete();
            return new ApiResult<bool>(true);
        }
    }
}
