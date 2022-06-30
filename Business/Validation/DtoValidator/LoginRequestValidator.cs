﻿using Core.Abstract;
using Core.IoC;
using Entities.Dto.RequestDto.LoginRequestDto;
using FluentValidation;

namespace Business.Validation.DtoValidator
{
    public class LoginRequestValidator : AbstractValidator<LoginRequest>
    {
        private readonly ILocalizerService localizer;
        public LoginRequestValidator()
        {
            localizer = Provider.Resolve<ILocalizerService>();

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