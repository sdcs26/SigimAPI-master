using FluentValidation;

namespace Sigim.Application.Features.ExerciseFeature.Commands.CreateExercise
{
    public class CreateExerciseCommandValidator : AbstractValidator<CreateExerciseCommand>
    {
        public CreateExerciseCommandValidator()
        {
            //RuleFor();
        }
    }
}
