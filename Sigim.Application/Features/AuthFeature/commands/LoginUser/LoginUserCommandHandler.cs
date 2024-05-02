using AutoMapper;
using Complii.Application.Contracts.Infrastructure;
using Complii.Application.Contracts.Persistence;
using Complii.Application.Exceptions;
using MediatR;
using Sigim.Application.Contracts.Infrastructure;
using Sigim.Application.Models;
using Sigim.Application.Models.Identity;
using Sigim.Domain;

namespace Sigim.Application.Features.AuthFeature.commands.LoginUser
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, ApiResult<AuthResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICryptService _crypt;
        private readonly IAuthService _authService;
        private readonly IMapper _mapper;
        public LoginUserCommandHandler(IUnitOfWork unitOfWork, ICryptService crypt, IAuthService authService, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _crypt = crypt;
            _authService = authService;
            _mapper = mapper;
        }

        public async Task<ApiResult<AuthResponse>> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            var user = (await _unitOfWork.Repository<User>().GetAsync(q => q.Correo.Equals(request.Correo), 
                includes: new List<System.Linq.Expressions.Expression<Func<User, object>>>
                {
                    i=>i.Rol!
                })).FirstOrDefault();

            if (user == null)
            {
                throw new BadRequestException($"Usuario o Contraseña incorrecto");
            }
            if (!_crypt.VerifyPassword(request.Contrasena, user.Contrasena))
            {
                throw new BadRequestException($"Usuario o Contraseña incorrecto");
            }
            var token = _authService.GenereteToken(user);

            var respose = _mapper.Map<AuthResponse>(user);
            respose.Token = token;

            return new ApiResult<AuthResponse>(respose);
        }
    }
}
