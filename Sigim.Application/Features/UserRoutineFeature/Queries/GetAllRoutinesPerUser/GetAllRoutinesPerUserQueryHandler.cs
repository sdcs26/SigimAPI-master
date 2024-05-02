
using AutoMapper;
using Complii.Application.Contracts.Persistence;
using MediatR;
using Sigim.Application.Contracts.Infrastructure;
using Sigim.Application.Models;
using Sigim.Application.Models.Settings;
using Sigim.Domain;

namespace Sigim.Application.Features.UserRoutineFeature.Queries.GetAllRoutinesPerUser
{
    public class GetAllRoutinesPerUserQueryHandler : IRequestHandler<GetAllRoutinesPerUserQuery, ApiResult<List<UserRoutineResult>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly TokenPayload _tokenPayload;

        public GetAllRoutinesPerUserQueryHandler(IUnitOfWork unitOfWork, IMapper mapper, ITokenService tokenService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _tokenPayload = tokenService.GetTokenPayload();
        }


        public async Task<ApiResult<List<UserRoutineResult>>> Handle(GetAllRoutinesPerUserQuery request, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.Repository<UserRoutine>().GetAsync(q => q.IdUsuario.Equals(_tokenPayload.UserId), includes: new List<System.Linq.Expressions.Expression<Func<UserRoutine, object>>>
            {
                i=>i.Rutina
            });
            return new ApiResult<List<UserRoutineResult>>(_mapper.Map<List<UserRoutineResult>>(result));
        }

    }
}
