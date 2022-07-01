using Core.Abstract;
using Entities.Concrete;
using FluentValidation;

namespace Business.Validation.EntityValidator
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator(ILocalizerService localizer)
        {
            RuleFor(x => x.Name)
                .NotNull()
                .WithMessage("CreateUserRequestValidator.NameNotNull");

            RuleFor(x => x.Name)
                .MinimumLength(2)
                .WithMessage("CreateUserRequestValidator.NameMinLength");

            RuleFor(x => x.Name)
                .MaximumLength(50)
                .WithMessage("CreateUserRequestValidator.NameMaxLength");

            RuleFor(x => x.SurName)
                .NotNull()
                .WithMessage("CreateUserRequestValidator.SurNameNotNull");

            RuleFor(x => x.SurName)
                .MinimumLength(2)
                .WithMessage("CreateUserRequestValidator.SurNameMinLength");

            RuleFor(x => x.SurName)
                .MaximumLength(50)
                .WithMessage("CreateUserRequestValidator.SurNameMaxLength");

            RuleFor(x => x.UserName)
                .NotNull()
                .WithMessage("CreateUserRequestValidator.UserNameNotNull");

            RuleFor(x => x.Email)
                .NotNull()
                .EmailAddress()
                .WithMessage("CreateUserRequestValidator.EmailNameNotNull");

            RuleFor(x => x.Password)
                .NotNull()
                .WithMessage("CreateUserRequestValidator.PasswordNotNull");

            RuleFor(x => x.Password)
                .MinimumLength(6)
                .MaximumLength(50)
                .WithMessage("CreateUserRequestValidator.PasswordLength");

            RuleFor(x => x.MobileNo)
                .NotNull()
                .WithMessage("CreateUserRequestValidator.MobileNoNotNull");

            RuleFor(x => x.MobileNo)
                .Matches("^[0-9]{10}$")
                .WithMessage("CreateUserRequestValidator.MobileNo");

            RuleFor(x => x.BirthDate)
                .GreaterThanOrEqualTo(19000101)
                .WithMessage("CreateUserRequestValidator.BirthDate");
        }
    }
}
