using FluentValidation;

namespace Sigim.Application.Features.AuthFeature.commands.LoginUser
{
    public class LoginUserValidator : AbstractValidator<LoginUserCommand>
    {
        public LoginUserValidator()
        {
            RuleFor(r => r.Correo).EmailAddress();
        }
    }
}
