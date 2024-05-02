using AutoMapper;
using Complii.Application.Contracts.Persistence;
using MediatR;
using Sigim.Application.Contracts.Infrastructure;
using Sigim.Application.Models;
using Sigim.Application.Models.Settings;
using Sigim.Domain;

namespace Sigim.Application.Features.HistoryFeature.queries.GetAllHistory
{
    public class GetAllHistoryQueryHandler : IRequestHandler<GetAllHistoryQuery, ApiResult<List<HistoryResult>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly TokenPayload _tokenPayload;

        public GetAllHistoryQueryHandler(IUnitOfWork unitOfWork, IMapper mapper, ITokenService tokenService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _tokenPayload = tokenService.GetTokenPayload();
        }

        public async Task<ApiResult<List<HistoryResult>>> Handle(GetAllHistoryQuery request, CancellationToken cancellationToken)
        {
            var histories = await _unitOfWork.Repository<History>().GetAsync(q=>q.IdUsuario.Equals(_tokenPayload.UserId));
            var result = _mapper.Map<List<HistoryResult>>(histories);
            return new ApiResult<List<HistoryResult>>(result);
        }
    }
}
