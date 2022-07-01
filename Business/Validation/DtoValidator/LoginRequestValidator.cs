using Core.Abstract;
using Entities.Dto.RequestDto.LoginRequestDto;
using FluentValidation;

namespace Business.Validation.DtoValidator
{
    public class LoginRequestValidator : AbstractValidator<LoginRequest>
    {
        public LoginRequestValidator(ILocalizerService localizer)
        {

            RuleFor(x => x.Password)
                .NotNull()
                .WithMessage(localizer.GetResource("LoginRequestValidator.PasswordNotNull"));

            RuleFor(x => x.Email)
                .NotNull()
                .When(x => string.IsNullOrEmpty(x.UserName) && string.IsNullOrEmpty(x.MobileNo))
                .WithMessage(localizer.GetResource("LoginRequestValidator.NotNull"));

            RuleFor(x => x.UserName)
                .NotNull()
                .When(x => string.IsNullOrEmpty(x.Email) && string.IsNullOrEmpty(x.MobileNo))
                .WithMessage(localizer.GetResource("LoginRequestValidator.NotNull"));

            RuleFor(x => x.MobileNo)
                .NotNull()
                .When(x => string.IsNullOrEmpty(x.UserName) && string.IsNullOrEmpty(x.Email))
                .WithMessage(localizer.GetResource("LoginRequestValidator.NotNull"));

        }
    }
}
