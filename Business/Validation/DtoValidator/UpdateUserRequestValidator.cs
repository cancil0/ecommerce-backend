using Entities.Dto.RequestDto.UserRequestDto;
using FluentValidation;

namespace Business.Validation.DtoValidator
{
    public class UpdateUserRequestValidator : AbstractValidator<UpdateUserRequest>
    {
        public UpdateUserRequestValidator()
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
                .WithMessage("User name must be filled");

            RuleFor(x => x.Email)
                .NotEmpty()
                .NotNull()
                .EmailAddress()
                .WithMessage("Email must be filled");

            RuleFor(x => x.Password)
                .NotEmpty()
                .NotNull()
                .WithMessage("Password must be filled");

            RuleFor(x => x.Password)
                .MinimumLength(6)
                .MaximumLength(50)
                .WithMessage("Password length must be between 6-50");

            RuleFor(x => x.MobileNo)
                .NotEmpty()
                .NotNull()
                .WithMessage("MobileNo must be filled");

            RuleFor(x => x.MobileNo)
                .Matches("^[0-9]{10}$")
                .WithMessage("Please enter a proper Mobile No");

            RuleFor(x => x.BirthDate)
                .GreaterThanOrEqualTo(19000101)
                .WithMessage("Birth date must be greater or equeal to 19000101");
        }
    }
}
