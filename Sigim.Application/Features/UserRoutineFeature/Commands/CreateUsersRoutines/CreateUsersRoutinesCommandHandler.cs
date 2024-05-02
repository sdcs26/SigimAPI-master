using AutoMapper;
using Complii.Application.Contracts.Persistence;
using MediatR;
using Sigim.Application.Models;
using Sigim.Domain;

namespace Sigim.Application.Features.UserRoutineFeature.Commands.CreateUsersRoutines
{
    public class CreateUsersRoutinesCommandHandler : IRequestHandler<CreateUsersRoutinesCommand, ApiResult<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public CreateUsersRoutinesCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ApiResult<bool>> Handle(CreateUsersRoutinesCommand request, CancellationToken cancellationToken)
        {
            var list = _mapper.Map<List<UserRoutine>>(request.UserRoutine);
            _unitOfWork.Repository<UserRoutine>().AddListEntity(list);
            await _unitOfWork.Complete();
            return new ApiResult<bool>(true);
        }
    }
}
