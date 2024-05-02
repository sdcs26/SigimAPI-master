using FluentValidation;

namespace Sigim.Application.Features.AuthFeature.commands.RegisterUser
{
    public class RegisterUserCommandValidator : AbstractValidator<RegisterUserCommand>
    {
        public RegisterUserCommandValidator()
        {
            //RuleFor();
        }
    }
}
