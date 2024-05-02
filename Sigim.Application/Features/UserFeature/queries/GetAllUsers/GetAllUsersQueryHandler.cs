using AutoMapper;
using Complii.Application.Contracts.Persistence;
using Complii.Application.Exceptions;
using MediatR;
using Sigim.Application.Models;
using Sigim.Domain;
using System.Linq.Expressions;

namespace Sigim.Application.Features.UserFeature.queries.GetAllUsers
{
    public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, ApiResult<List<UserResult>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllUsersQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ApiResult<List<UserResult>>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            var users = await _unitOfWork.Repository<User>().GetAllAsync(
                includes: new List<System.Linq.Expressions.Expression<Func<User, object>>>
                {
                    i=>i.Rol!
                }
            );
            var result = _mapper.Map<List<UserResult>>(users);
            return new ApiResult<List<UserResult>>(result);
        }
    }
}
