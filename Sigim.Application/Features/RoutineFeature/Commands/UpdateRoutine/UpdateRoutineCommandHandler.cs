using AutoMapper;
using Complii.Application.Contracts.Persistence;
using Complii.Application.Exceptions;
using MediatR;
using Sigim.Application.Models;
using Sigim.Domain;

namespace Sigim.Application.Features.RoutineFeature.Commands.UpdateRoutine
{
    public class UpdateRoutineCommandHandler : IRequestHandler<UpdateRoutineCommand, ApiResult<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateRoutineCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ApiResult<bool>> Handle(UpdateRoutineCommand request, CancellationToken cancellationToken)
        {
            var existingRoutine = (await _unitOfWork.Repository<Routine>().GetAsync(q => q.Id.Equals(request.Id))).FirstOrDefault();
            if (existingRoutine == null)
            {
                throw new BadRequestException($"ALREADY_EXISTS");
            }
            _unitOfWork.Repository<Routine>().DetachEntity(existingRoutine);

            var updatedRoutine = _mapper.Map<Routine>(request);
            _unitOfWork.Repository<Routine>().UpdateEntity(updatedRoutine);
            await _unitOfWork.Complete();
            return new ApiResult<bool>(true);
        }
    }
}
