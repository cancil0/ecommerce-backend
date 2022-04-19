using Entities.Concrete;
using FluentValidation;

namespace Business.Validation.EntityValidator
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .NotNull()
                .WithMessage("Name must be filled");

            RuleFor(x => x.Name)
                .MinimumLength(2)
                .WithMessage("Please enter 2 or more letter for name");

            RuleFor(x => x.Name)
                .MaximumLength(51)
                .WithMessage("Please enter 50 or less letter for name");

            RuleFor(x => x.SurName)
                .NotEmpty()
                .NotNull()
                .WithMessage("SurName must be filled");

            RuleFor(x => x.SurName)
                .MinimumLength(2)
                .WithMessage("Please enter 2 or more letter for surname");

            RuleFor(x => x.SurName)
                .MaximumLength(50)
                .WithMessage("Please enter 50 or less letter for surname");

            RuleFor(x => x.UserName)
                .NotEmpty()
                .NotNull()
                .WithMessage("MobileNo must be filled");

            RuleFor(x => x.Email)
                .NotEmpty()
                .NotNull()
                .EmailAddress()
                .WithMessage("Email must be filled");

            RuleFor(x => x.MobileNo)
                .NotEmpty()
                .NotNull()
                .WithMessage("MobileNo must be filled");
        }
    }
}
