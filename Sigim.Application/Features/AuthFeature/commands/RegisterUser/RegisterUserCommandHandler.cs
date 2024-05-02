using AutoMapper;
using Complii.Application.Contracts.Persistence;
using Complii.Application.Exceptions;
using MediatR;
using Sigim.Application.Contracts.Infrastructure;
using Sigim.Application.Models;
using Sigim.Application.Models.Settings;
using Sigim.Domain;

namespace Sigim.Application.Features.AuthFeature.commands.RegisterUser
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, ApiResult<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ICryptService _crypt;

        public RegisterUserCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, ICryptService crypt)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _crypt = crypt;
        }

        public async Task<ApiResult<bool>> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var existingUser = (await _unitOfWork.Repository<User>().GetAsync(user => user.Correo.Equals(request.Correo))).FirstOrDefault();

            if (existingUser != null)
            {
                throw new BadRequestException($"EMAIL_ALREADY_EXISTS");
            }

            var userId = Guid.NewGuid().ToString();
            var RolDeportista = (await _unitOfWork.Repository<Rol>().GetAsync(q=>q.Titulo.Equals("Deportista"))).FirstOrDefault();
            var user = _mapper.Map<User>(request);
            user.RolId = RolDeportista.Id;
            user.Contrasena = _crypt.EncryptPassword(user.Contrasena);
            _unitOfWork.Repository<User>().AddEntity(user);
            await _unitOfWork.Complete();
            return new ApiResult<bool>(true);
        }
    }
}
