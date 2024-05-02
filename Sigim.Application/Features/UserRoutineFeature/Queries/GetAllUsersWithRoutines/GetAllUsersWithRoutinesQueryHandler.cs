using AutoMapper;
using Complii.Application.Contracts.Persistence;
using MediatR;
using Sigim.Application.Models;
using Sigim.Domain;

namespace Sigim.Application.Features.UserRoutineFeature.Queries.GetAllUsersWithRoutines
{
    public class GetAllUsersWithRoutinesQueryHandler : IRequestHandler<GetAllUsersWithRoutinesQuery, ApiResult<List<UserResult>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public GetAllUsersWithRoutinesQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ApiResult<List<UserResult>>> Handle(GetAllUsersWithRoutinesQuery request, CancellationToken cancellationToken)
        {
            var usersWithRoutines = await _unitOfWork.Repository<User>().GetAsync(
                includeString: new List<string>() { "UserRoutines", "UserRoutines.Rutina" }
            );
            var result = _mapper.Map<List<UserResult>>(usersWithRoutines);
            return new ApiResult<List<UserResult>>(result);
        }
    }
}
